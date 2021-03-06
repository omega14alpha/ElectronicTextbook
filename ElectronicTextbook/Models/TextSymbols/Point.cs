using ElectronicTextbook.Infrastructure.Interfaces;

namespace ElectronicTextbook.Models.TextSymbols
{
    internal struct Point : ISymbol
    {
        private const char _value = '.';

        public char Value => _value;
    }
}
