using ElectronicTextbook.Infrastructure.Interfaces;
using System;

namespace ElectronicTextbook.Models.TextSymbols
{
    internal struct Alphanumeric : ISymbol
    {
        private readonly char _value;

        public char Value => _value;

        public Alphanumeric(char alphanumeric)
        {
            if (char.IsWhiteSpace(alphanumeric))
            {
                throw new ArgumentException("The parameter 'alphanumeric' cannot be white space!");
            }

            _value = alphanumeric;
        }
    }
}
