using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models.TextSymbols;
using System;
using System.Collections.Generic;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class Word : ISentencePart<Symbol>
    {
        private ICollection<Symbol> _symbols;

        public int Length => _symbols.Count;

        public Word()
        {
            _symbols = new List<Symbol>();
        }

        public void Add(Symbol wordSymbol)
        {
            if (wordSymbol is null)
            {
                throw new ArgumentNullException(nameof(wordSymbol), "parameter 'wordSymbol' cannot be equals null!");
            }

            _symbols.Add(wordSymbol);
        }

        public override string ToString()
        {
            return $"{string.Join("", _symbols)}";
        }
    }
}
