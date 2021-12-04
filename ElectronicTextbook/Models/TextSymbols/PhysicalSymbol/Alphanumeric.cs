using System;

namespace ElectronicTextbook.Models.TextSymbols.PhysicalSymbol
{
    internal class Alphanumeric : Symbol
    {
        public Alphanumeric(char symbol)
        {
            if (!char.IsLetterOrDigit(symbol))
            {
                throw new ArgumentException("The symbol must be letter or digit!");
            }

            Value = symbol.ToString();
        }
    }
}
