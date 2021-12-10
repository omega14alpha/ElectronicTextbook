using ElectronicTextbook.Infrastructure;
using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models;
using ElectronicTextbook.Models.PieceOfText;
using System;
using System.Linq;

namespace ElectronicTextbook
{
    internal class Textbook : ITextbook
    {
        private readonly ITextDataConverter _textConverter;
        private readonly IText _text;

        public IText Text => _text;

        public Textbook()
        {
            string filePath = GetFileNameFromConfigurationFile();
            _textConverter = new TextDataConverter(new StreamsReader());
            _text = _textConverter.GetTextFromFile(filePath);
        }

        public IText SortSentencesByWordsCount()
        {
            var result = _text.OrderBy(x => x.Where(x => x is Word).Count());
            return _textConverter.CreateTextFromSentences(result);
        }

        public IText GetWordsByLengthFromQuestions(int wordLength)
        {
            if (wordLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(wordLength), "parameter 'wordLength' cannot be less or equels that 0!");
            }

            var result = from q in _text.Select(s => s)
                         where q.ToString().Contains('?')
                         from a in q
                         where a is Word && a.Length == wordLength
                         group a by a.ToString() into x
                         select x.FirstOrDefault();

            return _textConverter.CreateTextFromWords(result);
        }

        public IText DeleteWordsByLength(int length)
        {
            ConsonantChecker checker = new ConsonantChecker();
            var deletionModel = _text.Select(s => s.Select(x => x).Where(x => checker.IsStartWithConsonant(x.ToString()) && x.Length == length));
            var clearedSentences = _text.Zip(deletionModel, (f, s) => _textConverter.CreateSentenceFromWords(f.Except(s)));
            return _textConverter.CreateTextFromSentences(clearedSentences);
        }

        public IText ReplaceWordsInSentence(int length, string newData)
        {    
            var substring = _textConverter.CreateTextFromString(newData).FirstOrDefault();
            var changeableSentence = GetTestSentence(length).ToList();
            for (int i = 0; i < changeableSentence.Count; i++)
            {
                if (changeableSentence[i].Length == length)
                {
                    changeableSentence.RemoveAt(i);
                    int index = i;

                    foreach (var item in substring)
                    {
                        changeableSentence.Insert(index, item);
                        ++index;
                    }
                }
            }

            var resultSentence = _textConverter.CreateSentenceFromWords(changeableSentence);
            return _textConverter.CreateTextFromSentence(resultSentence);
        }

        private string GetFileNameFromConfigurationFile()
        {
            var configurationWorker = new XmlFileWorker<ConfigurationModel>();
            var config = configurationWorker.ReadData();
            return config.FilePath;
        }

        private ISentence GetTestSentence(int length)
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
