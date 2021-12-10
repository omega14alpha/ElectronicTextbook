using ElectronicTextbook.EventsArgs;
using System;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface IStreamReader
    {
        event EventHandler<FileReaderEventArgs> WordIsCollected;

        event EventHandler<FileReaderEventArgs> PunctuationIsCollected;

        event EventHandler<FileReaderEventArgs> IsEnd;

        void GetDataFromFile(string filePath);

        void GetDataFromString(string strData);
    }
}
