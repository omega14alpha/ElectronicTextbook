using ElectronicTextbook.EventsArgs;
using System;
using System.IO;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface IStreamParser
    {
        event EventHandler<FileReaderEventArgs> IsAlphanumeric;

        event EventHandler<FileReaderEventArgs> IsPunctuation;

        event EventHandler<FileReaderEventArgs> IsSpaceOrEnd;

        void Parsing(Stream stream);
    }
}
