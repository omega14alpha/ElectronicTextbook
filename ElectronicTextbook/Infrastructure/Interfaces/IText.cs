using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface IText : IEnumerable<ISentence>, IDisplayed
    {
        int Count { get; }

        void AddNewAlphanumericSymbol(ISymbol alphanumericSymbol);

        void AddNewPunctuationSymbol(ISymbol punctuationSymbol);

        void AddEndOrNewSentencePart();
    }
}
