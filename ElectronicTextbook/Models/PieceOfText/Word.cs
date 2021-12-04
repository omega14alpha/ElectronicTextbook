using ElectronicTextbook.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class Word : ITextContainer, ITextElement
    {
        private ICollection<ITextElement> _symbols;

        public Word()
        {
            _symbols = new List<ITextElement>();
        }

        public void Add(ITextElement symbol)
        {
            _symbols.Add(symbol);
        }

        public override string ToString()
        {
            return $" {string.Join("", _symbols)}";
        }
    }
}
