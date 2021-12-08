using ElectronicTextbook.EventsArgs;
using System;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface IFileReader
    {
        event EventHandler<FileReaderEventArgs> WordIsCollected;
        event EventHandler<FileReaderEventArgs> PunctuationCollected;

        void FileParsing(string path);
    }
}
