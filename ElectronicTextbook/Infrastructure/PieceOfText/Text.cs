using ElectronicTextbook.Infrastructure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicTextbook.Infrastructure.PieceOfText
{
    internal class Text : IText
    {
        private IList<ISentence> _sentences;

        public Text()
        {
            _sentences = new List<ISentence>();
            _sentences.Add(new Sentence());
        }
        public int Count => _sentences.Count;

        public string Value => string.Join("", _sentences.Select(s => s.Value)).Trim();

        public IEnumerator<ISentence> GetEnumerator() => _sentences.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void AddNewAlphanumericSymbol(ISymbol alphanumericSymbol)
        {
            _sentences[Count - 1].AddNewAlphanumericSymbol(alphanumericSymbol);
        }

        public void AddNewPunctuationSymbol(ISymbol punctuationSymbol)
        {
            _sentences[Count - 1].AddNewPunctuationSymbol(punctuationSymbol);
        }

        public void AddEndOrNewSentencePart()
        {
            var lastPart = _sentences[Count - 1].LastSentencePart.Value;
            if (lastPart.EndsWith('.') || lastPart.EndsWith('!') || lastPart.EndsWith('?'))
            {
                _sentences.Add(new Sentence());
            }
            else
            {
                _sentences[Count - 1].NewSentencePart();
            }
        }
    }
}
