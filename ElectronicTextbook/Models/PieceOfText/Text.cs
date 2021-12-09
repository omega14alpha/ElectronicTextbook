using ElectronicTextbook.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class Text : ITextContainer<Sentence>
    {
        private ICollection<Sentence> _sentences;

        public IEnumerator<Sentence> GetEnumerator() => _sentences.GetEnumerator();

        public Text()
        {
            _sentences = new List<Sentence>();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(Sentence sentence)
        {
            if (sentence is null)
            {
                throw new ArgumentNullException(nameof(sentence), "parameter 'sentence' cannot be equals null!");
            }

            _sentences.Add(sentence);
        }        

        public override string ToString()
        {
            return (string.Join("", _sentences)).Trim();
        }
    }
}
