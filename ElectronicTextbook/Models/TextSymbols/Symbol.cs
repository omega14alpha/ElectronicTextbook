using ElectronicTextbook.Infrastructure.Interfaces;

namespace ElectronicTextbook.Models.TextSymbols
{
    internal abstract class Symbol : ITextElement
    {
        protected string Value;

        public override string ToString() => Value;
    }
}
