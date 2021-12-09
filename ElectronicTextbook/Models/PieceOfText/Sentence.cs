using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models.TextSymbols;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class Sentence : ITextContainer<ISentencePart<Symbol>>
    {
        private IList<ISentencePart<Symbol>> _sentenceParts;

        public IEnumerator<ISentencePart<Symbol>> GetEnumerator() => _sentenceParts.GetEnumerator();

        public Sentence()
        {
            _sentenceParts = new List<ISentencePart<Symbol>>();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(ISentencePart<Symbol> word)
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
