using ElectronicTextbook.Infrastructure;
using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models.PieceOfText;
using System.Linq;

namespace ElectronicTextbook
{
    internal class Textbook
    {
        private ITextAnalyzer _textAnalyzer;
        private Text _text;

        public Textbook(string filePath)
        {
            _textAnalyzer = new IncomingTextAnalyzer(new TextFileReader());
            _text = _textAnalyzer.Parsing(filePath);
        }

        public Text GetTextModel()
        {
            return _text;
        }

        public Text SortingByOrderOfIncreasingNumberOfWords()
        {
            Text tempText = new Text();
            var result = _text.OrderBy(x => x.Where(x => x is Word).Count());
            foreach (var item in result)
            {
                tempText.Add(item);
            }

            return tempText;
        }

        public void GetAllWordsOfGivenLengthInQuestioningSentences(int wordLength)
        {
            var result = (from q in _text.Select(s => s)
                       where q.ToString().Contains('?')
                       from a in q
                       where a.Length == wordLength
                       group a by a.ToString() into x
                       select x.FirstOrDefault()).ToList();


        }
    }
}
