using ElectronicTextbook.Infrastructure;
using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models.PieceOfText;
using System;
using System.Linq;

namespace ElectronicTextbook
{
    internal class Textbook
    {
        private ITextDataConverter _textConverter;
        private Text _text;

        public Text Text => _text;

        public Textbook(string filePath)
        {
            _textConverter = new TextDataConverter(new TextFileReader());
            _text = _textConverter.GetTextFromFile(filePath);
        }

        public Text SortSentencesByWordsCount()
        {
            var result = _text.OrderBy(x => x.Where(x => x is Word).Count());
            return _textConverter.CreateTextFromSentences(result);
        }

        public Text GetWordsByLengthFromQuestions(int wordLength)
        {
            if (wordLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(wordLength), "parameter 'wordLength' cannot be less or equels that 0!");
            }

            var result = from q in _text.Select(s => s)
                         where q.ToString().Contains('?')
                         from a in q
                         where a.Length == wordLength
                         group a by a.ToString() into x
                         select x.FirstOrDefault();

            return _textConverter.CreateTextFromWords(result);
        }

        public Text DeleteWordsByLength(int length)
        {
            ConsonantChecker checker = new ConsonantChecker();
            var deletionModel = _text.Select(s => s.Select(x => x).Where(x => checker.IsStartWithConsonant(x.ToString()) && x.Length == length));
            var clearedSentences = _text.Zip(deletionModel, (f, s) => _textConverter.CreateSentenceFromWords(f.Except(s)));
            return _textConverter.CreateTextFromSentences(clearedSentences);
        }

        public Text ReplaceWordsInSentence(int length, string newData)
        {
            var newWord = _textConverter.CreateWordFromString(newData);
            var changeableSentence = GetTestSentence(length).ToList();
            for (int i = 0; i < changeableSentence.Count; i++)
            {
                if (changeableSentence[i].Length == length)
                {
                    changeableSentence[i] = newWord;
                }
            }

            var resultSentence = _textConverter.CreateSentenceFromWords(changeableSentence);
            return _textConverter.CreateTextFromSentence(resultSentence);
        }

        private Sentence GetTestSentence(int length)
        {
            var sentencesForTest = (from q in _text
                                    from a in q.Select(s => s)
                                    where a.Length == length
                                    group q by q.ToString() into x
                                    select x.FirstOrDefault()).ToList();

            Random random = new Random();
            var sentence = sentencesForTest[random.Next(sentencesForTest.Count)];
            return sentence;
        }
    }
}
