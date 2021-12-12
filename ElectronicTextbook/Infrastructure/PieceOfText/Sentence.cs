using ElectronicTextbook.Enums;
using ElectronicTextbook.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ElectronicTextbook.Infrastructure.PieceOfText
{
    internal class Sentence : ISentence
    {
        private IList<ISentencePart> _sentenceParts;

        public int Count => _sentenceParts.Count;

        public ISentencePart LastSentencePart => _sentenceParts[Count - 1];

        public string Value
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in _sentenceParts)
                {
                    builder.Append(item.PartSentenceType == PartSentenceType.Word ? " " : "");
                    builder.Append(item.Value);
                }

                return builder.ToString();
            }
        }

        public IEnumerator<ISentencePart> GetEnumerator() => _sentenceParts.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Sentence()
        {
            _sentenceParts = new List<ISentencePart>();
            NewSentencePart();
        }

        public void Add(ISentencePart sentencePart)
        {
            if (sentencePart is null)
            {
                throw new ArgumentNullException(nameof(sentencePart), "parameter 'sentencePart' cannot be equals null!");
            }

            _sentenceParts.Add(sentencePart);
        }

        public void AddNewAlphanumericSymbol(ISymbol alphanumericSymbol)
        {
            if (_sentenceParts[Count - 1].PartSentenceType != PartSentenceType.Word)
            {
                _sentenceParts[Count - 1].PartSentenceType = PartSentenceType.Word;
            }

            _sentenceParts[Count - 1].Add(alphanumericSymbol);
        }

        public void AddNewPunctuationSymbol(ISymbol punctuationSymbol)
        {
            if (_sentenceParts[Count - 1].PartSentenceType != PartSentenceType.PunctuationMark)
            {
                _sentenceParts.Add(new SentencePart());
                _sentenceParts[Count - 1].PartSentenceType = PartSentenceType.PunctuationMark;
            }

            _sentenceParts[Count - 1].Add(punctuationSymbol);
        }

        public void NewSentencePart()
        {
            _sentenceParts.Add(new SentencePart());
        }
    }
}
