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

        public void Remove(Sentence data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "parameter 'data' cannot be equals null!");
            }

            // _sentences[index].
        }

        public void Replace(IEnumerable<Sentence> oldDatas, Sentence newData)
        {
            if (oldDatas is null)
            {
                throw new ArgumentNullException(nameof(oldDatas), "parameter 'oldDatas' cannot be equals null!");
            }

            if (newData is null)
            {
                throw new ArgumentNullException(nameof(newData), "parameter 'newData' cannot be equals null!");
            }

            // _sentences[index].
        }

        public override string ToString()
        {
            return (string.Join("", _sentences)).Trim();
        }
    }
}
