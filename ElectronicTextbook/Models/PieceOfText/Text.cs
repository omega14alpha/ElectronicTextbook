using ElectronicTextbook.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class Text : ITextContainer, ITextElement
    {
        private ICollection<ITextElement> _sentences;

        public Text()
        {
            _sentences = new List<ITextElement>();
        }

        public void Add(ITextElement sentence)
        {
            _sentences.Add(sentence);
        }

        public override string ToString()
        {
            return (string.Join("", _sentences)).Trim();
        }
    }
}
