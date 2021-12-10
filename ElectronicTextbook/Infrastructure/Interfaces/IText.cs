using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface IText : IEnumerable<ISentence>
    {
        int Count { get; }

        void Add(ISentence t);
    }
}
