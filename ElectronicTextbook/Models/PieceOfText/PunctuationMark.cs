using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models.TextSymbols;
using System;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class PunctuationMark : ISentencePart
    {
        private Symbol _symbol;

        public int Length => _symbol is null ? 0 : 1;

        public void Add(Symbol markSymbol)
        {
            if (markSymbol is null)
            {
                throw new ArgumentNullException(nameof(markSymbol), "parameter 'markSymbol' cannot be equals null!");
            }

            _symbol = markSymbol;
        }

        public override string ToString()
        {
            return _symbol.ToString();
        }
    }
}
