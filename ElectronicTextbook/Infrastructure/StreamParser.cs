using ElectronicTextbook.EventsArgs;
using ElectronicTextbook.Infrastructure.Interfaces;
using System;
using System.IO;

namespace ElectronicTextbook.Infrastructure
{
    internal class StreamParser : IStreamParser
    {
        public event EventHandler<FileReaderEventArgs> IsAlphanumeric;
        public event EventHandler<FileReaderEventArgs> IsPunctuation;
        public event EventHandler<FileReaderEventArgs> IsSpaceOrEnd;

        public void Parsing(Stream stream)
        {
            char currentSymbol = ' ';
            using StreamReader reader = new(stream);
            while (reader.Peek() >= 0)
            {
                currentSymbol = (char)reader.Read();

                if (char.IsLetterOrDigit(currentSymbol))
                {
                    SendAlphanumeric(currentSymbol);
                    continue;
                }

                if (char.IsPunctuation(currentSymbol))
                {
                    SendPunctiation(currentSymbol);
                    continue;
                }

                SendSpaceOrEnd(currentSymbol);
            }

            SendSpaceOrEnd(currentSymbol);
        }

        private void SendAlphanumeric(char data)
        {
            if (IsAlphanumeric != null)
            {
                var args = new FileReaderEventArgs(data);
                IsAlphanumeric.Invoke(this, args);
            }
        }

        private void SendPunctiation(char data)
        {
            if (IsPunctuation != null)
            {
                var args = new FileReaderEventArgs(data);
                IsPunctuation.Invoke(this, args);
            }
        }

        private void SendSpaceOrEnd(char data)
        {
            if (IsSpaceOrEnd != null)
            {
                var args = new FileReaderEventArgs(data);
                IsSpaceOrEnd.Invoke(this, args);
            }
        }
    }
}
