using ElectronicTextbook.Enums;
using ElectronicTextbook.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class SentencePart : ISentencePart
    {
        private readonly ICollection<ISymbol> _symbols;

        private PartSentenceType _partSentenceType;

        public int Length => _symbols.Count;

        public string Value => string.Join("", _symbols.Select(s => s.Value));           
        
        public PartSentenceType PartSentenceType
        {
            get => _partSentenceType;
            set => _partSentenceType = value;
        }

        public SentencePart()
        {
            _symbols = new List<ISymbol>();
        }

        public void Add(ISymbol symbol)
        {
            if (symbol is null)
            {
                throw new ArgumentNullException(nameof(symbol), "The parameter 'symbol' cannot be equals null!");
            }

            _symbols.Add(symbol);
        }
    }
}
