using ElectronicTextbook.EventsArgs;
using ElectronicTextbook.Infrastructure.Interfaces;
using System;
using System.IO;
using System.Text;

namespace ElectronicTextbook.Infrastructure
{
    internal class StreamsReader : IStreamReader
    {
        public event EventHandler<FileReaderEventArgs> WordIsCollected;
        public event EventHandler<FileReaderEventArgs> PunctuationIsCollected;
        public event EventHandler<FileReaderEventArgs> IsEnd;

        public void GetDataFromFile(string filePath)
        {
            FileParsing(new FileStream(filePath, FileMode.Open));
        }

        public void GetDataFromString(string strData)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(strData);
            FileParsing(new MemoryStream(bytes));
        }

        private void FileParsing(Stream stream)
        {
            StringBuilder builder = new StringBuilder();
            using StreamReader reader = new(stream);
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

            SendEnd(builder.ToString());
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
            if (PunctuationIsCollected != null)
            {
                var args = new FileReaderEventArgs(data);
                PunctuationIsCollected.Invoke(this, args);
            }
        }

        private void SendEnd(string data)
        {
            if (IsEnd != null)
            {
                var args = new FileReaderEventArgs(data);
                IsEnd.Invoke(this, args);
            }
        }
    }
}
