using ElectronicTextbook.Infrastructure.Interfaces;

namespace ElectronicTextbook.Models.TextSymbols.PhysicalSymbol
{
    internal struct ExclamationMark : ISymbol
    {
        private const char _value = '!';

        public char Value => _value;
    }
}
