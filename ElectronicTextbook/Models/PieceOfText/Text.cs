using ElectronicTextbook.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class Text : IText
    {
        private ICollection<ISentence> _sentences;

        public Text()
        {
            _sentences = new List<ISentence>();
        }
        public int Count => _sentences.Count;

        public IEnumerator<ISentence> GetEnumerator() => _sentences.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(ISentence sentence)
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
