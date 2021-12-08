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

        public void Remove(ISentencePart<Symbol> data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "parameter 'data' cannot be equals null!");
            }

            _sentenceParts.Remove(data);
        }

        public void Replace(IEnumerable<ISentencePart<Symbol>> oldDatas, ISentencePart<Symbol> newData)
        {
            if (oldDatas is null)
            {
                throw new ArgumentNullException(nameof(oldDatas), "parameter 'oldDatas' cannot be equals null!");
            }

            if (newData is null)
            {
                throw new ArgumentNullException(nameof(newData), "parameter 'newData' cannot be equals null!");
            }

            foreach (var item in oldDatas)
            {
                int index = _sentenceParts.IndexOf(item);
                _sentenceParts[index] = newData;
            }
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
