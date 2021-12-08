using ElectronicTextbook.Infrastructure.Interfaces;

namespace ElectronicTextbook.Models.TextSymbols
{
    internal abstract class Symbol
    {
        protected string Value;

        public override string ToString() => Value;
    }
}
