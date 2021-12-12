using System;

namespace ElectronicTextbook.EventsArgs
{
    internal class FileReaderEventArgs : EventArgs
    {
        public char Data { get; private set; }

        public FileReaderEventArgs(char data)
        {
            Data = data;
        }
    }
}
