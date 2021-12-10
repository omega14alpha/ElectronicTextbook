using ElectronicTextbook.Models.TextSymbols;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ISentencePart
    {
        int Length { get; }

        void Add(Symbol t);
    }
}
