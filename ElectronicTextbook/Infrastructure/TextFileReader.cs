using ElectronicTextbook.EventsArgs;
using System;
using System.IO;
using System.Text;

namespace ElectronicTextbook.Infrastructure
{
    internal class TextFileReader
    {
        public event EventHandler<FileReaderEventArgs> WordIsCollected;
        public event EventHandler<FileReaderEventArgs> PunctuationCollected;

        internal void FileParsing(string path)
        {
            StringBuilder builder = new StringBuilder();
            using StreamReader reader = new(new FileStream(path, FileMode.Open));
            while (reader.Peek() >= 0)
            {
                char currentSymbol = (char)reader.Read();

                if (char.IsLetterOrDigit(currentSymbol))
                {
                    builder.Append(currentSymbol);
                    continue;
                }

                if (builder.Length > 0)
                {
                    SendWord(builder.ToString());
                    builder.Clear();
                }

                if (char.IsPunctuation(currentSymbol))
                {
                    builder.Append(currentSymbol);
                    while (reader.Peek() >= 0)
                    {
                        char secondSymbol = (char)reader.Read();

                        if (char.IsWhiteSpace(secondSymbol))
                        {
                            break;
                        }

                        builder.Append(secondSymbol);
                    }

                    SendPunctiation(builder.ToString());
                    builder.Clear();
                }
            }
        }

        private void SendWord(string data)
        {
            if (WordIsCollected != null)
            {
                var args = new FileReaderEventArgs(data);
                WordIsCollected.Invoke(this, args);
            }
        }

        private void SendPunctiation(string data)
        {
            if (PunctuationCollected != null)
            {
                var args = new FileReaderEventArgs(data);
                PunctuationCollected.Invoke(this, args);
            }
        }
    }
}
