using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ISentence : IEnumerable<ISentencePart>
    {
        int Count { get; }

        void Add(ISentencePart t);
    }
}
