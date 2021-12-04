using System;

namespace ElectronicTextbook.EventsArgs
{
    internal class FileReaderEventArgs : EventArgs
    {
        public string Data { get; private set; }

        public FileReaderEventArgs(string data)
        {
            Data = data;
        }
    }
}
