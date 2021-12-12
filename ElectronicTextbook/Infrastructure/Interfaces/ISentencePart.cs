using ElectronicTextbook.Enums;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ISentencePart : IDisplayed
    {
        int Length { get; }

        PartSentenceType PartSentenceType { get; set; }

        void Add(ISymbol t);
    }
}
