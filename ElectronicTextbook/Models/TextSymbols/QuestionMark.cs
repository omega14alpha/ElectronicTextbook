using ElectronicTextbook.Infrastructure.Interfaces;

namespace ElectronicTextbook.Models.TextSymbols
{
    internal struct QuestionMark : ISymbol
    {
        private const char _value = '?';

        public char Value => _value;
    }
}
