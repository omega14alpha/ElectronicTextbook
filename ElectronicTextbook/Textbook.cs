using ElectronicTextbook.Enums;
using ElectronicTextbook.Infrastructure;
using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models.PieceOfText;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicTextbook
{
    internal class Textbook : ITextbook
    {
        private readonly ITextDataConverter _textConverter;
        private IText _text;

        public IText Text => _text;

        public Textbook()
        {
            _textConverter = new TextDataConverter(new StreamParser(), new Text());
        }

        public void GetTextFromFile(string filePath)
        {
            _text = _textConverter.GetTextFromFile(filePath);
        }

        public IEnumerable<IDisplayed> SortSentencesByWordsCount()
        {
            return _text
                .OrderBy(x => x
                .Where(x => x.PartSentenceType == PartSentenceType.Word)
                .Count());
        }

        public IEnumerable<ISentencePart> GetWordsByLengthFromQuestions(int wordLength)
        {
            if (wordLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(wordLength), "parameter 'wordLength' cannot be less or equels that 0!");
            }

            return _text
                .Where(s => s.Value.Contains('?'))
                .Select(s => s.Where(x => x.PartSentenceType == PartSentenceType.Word && x.Length == wordLength)
                .OrderBy(s => s.Value)
                .FirstOrDefault());
        }

        public IEnumerable<ISentence> DeleteWordsByLength(int wordLength)
        {
            var deletionModel = _text
                .Select(s => s
                .Where(x => ConsonantChecker.IsStartWithConsonant(x.Value) && x.Length == wordLength));
            return _text.Zip(deletionModel, (f, s) => _textConverter.CreateSentenceFromWords(f.Except(s)));
        }

        public ISentence ReplaceWordsInSentence(int wordLength, string substring)
        {    
            var tempStr = _textConverter.GetTextFromString(substring).FirstOrDefault();
            var changeableSentence = GetTestSentence(wordLength).ToList();
            for (int i = 0; i < changeableSentence.Count; i++)
            {
                if (changeableSentence[i].Length == wordLength)
                {
                    changeableSentence.RemoveAt(i);
                    int index = i;

                    foreach (var item in tempStr)
                    {
                        changeableSentence.Insert(index, item);
                        ++index;
                    }
                }
            }

            return _textConverter.CreateSentenceFromWords(changeableSentence);
        }

        private ISentence GetTestSentence(int wordLength)
        {
            var sentencesForTest = _text
                .SelectMany(a => a, (z, x) => new { Sentence = z, Part = x })
                .Where(x => x.Part.PartSentenceType == PartSentenceType.Word && x.Part.Length == wordLength)
                .Select(s => s.Sentence)
                .ToList(); 

            Random random = new Random();
            var sentence = sentencesForTest[random.Next(sentencesForTest.Count)];
            return sentence;
        }
    }
}
