using ElectronicTextbook.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class Sentence : ISentence
    {
        private ICollection<ISentencePart> _sentenceParts;

        public Sentence()
        {
            _sentenceParts = new List<ISentencePart>();
        }
        public int Count => _sentenceParts.Count;

        public IEnumerator<ISentencePart> GetEnumerator() => _sentenceParts.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(ISentencePart word)
        {
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word), "parameter 'word' cannot be equals null!");
            }

            _sentenceParts.Add(word);
        }

        public override string ToString()
        {
             StringBuilder builder = new StringBuilder();
            foreach (var item in _sentenceParts)
            {
                builder.Append(item is Word ? " " : "");
                builder.Append(item.ToString());
            }

            return builder.ToString();
        }
    }
}
