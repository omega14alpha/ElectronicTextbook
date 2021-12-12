using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ISentence : IEnumerable<ISentencePart>, IDisplayed
    {
        int Count { get; }

        ISentencePart LastSentencePart { get; }

        void Add(ISentencePart sentencePart);

        void AddNewAlphanumericSymbol(ISymbol alphanumericSymbol);

        void AddNewPunctuationSymbol(ISymbol punctuationSymbol);

        void NewSentencePart();
    }
}
