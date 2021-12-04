using ElectronicTextbook.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class Sentence : ITextContainer, ITextElement
    {
        private ICollection<ITextElement> _partsOfSentence;

        public Sentence()
        {
            _partsOfSentence = new List<ITextElement>();
        }

        public void Add(ITextElement partsOfSentence)
        {
            _partsOfSentence.Add(partsOfSentence);
        }

        public override string ToString()
        {
            return string.Join("", _partsOfSentence);
        }
    }
}
