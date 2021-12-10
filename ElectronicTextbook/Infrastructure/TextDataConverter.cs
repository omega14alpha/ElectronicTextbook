using ElectronicTextbook.EventsArgs;
using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models.PieceOfText;
using ElectronicTextbook.Models.TextSymbols;
using ElectronicTextbook.Models.TextSymbols.LogicSymbols;
using ElectronicTextbook.Models.TextSymbols.PhysicalSymbol;
using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure
{
    internal class TextDataConverter : ITextDataConverter
    {
        private readonly IStreamReader _fileParser;

        private IText _text;
        private ISentence _sentence;

        private Dictionary<string, Symbol> _punctuations;
        private Dictionary<string, Symbol> _endSentencePunctuations;

        public TextDataConverter(IStreamReader fileReader)
        {
            _fileParser = fileReader;
            _fileParser.WordIsCollected += SendWord;
            _fileParser.PunctuationIsCollected += SendPunctuation;
            _fileParser.IsEnd += TextEnd;

            _text = new Text();
            _sentence = new Sentence();

            Init();
        }

        public IText GetTextFromFile(string filePath)
        {
            _fileParser.GetDataFromFile(filePath);
            return _text;
        }

        public IText CreateTextFromString(string data)
        {
            _text = new Text();
            _sentence = new Sentence();
            _fileParser.GetDataFromString(data);
            return _text;
        }

        public ISentence CreateSentenceFromWords(IEnumerable<ISentencePart> words)
        {
            _sentence = new Sentence();
            foreach (var item in words)
            {
                _sentence.Add(item);
            }

            return _sentence;
        }

        public IText CreateTextFromSentences(IEnumerable<ISentence> sentences)
        {
            _text = new Text();
            foreach (var sentence in sentences)
            {
                _text.Add(sentence);
            }

            return _text;
        }

        public IText CreateTextFromSentence(ISentence sentence)
        {
            _text = new Text();
            _text.Add(sentence);
            return _text;
        }

        public IText CreateTextFromWords(IEnumerable<ISentencePart> words)
        {
            _text = new Text();
            foreach (var item in words)
            {
                var sentences = new Sentence();
                sentences.Add(item);
                _text.Add(sentences);
            }

            return _text;
        }

        private void Init()
        {
            _punctuations = new Dictionary<string, Symbol>()
            {
                { ",", new Comma() }
            };

            _endSentencePunctuations = new Dictionary<string, Symbol>()
            {
                { ":", new Colon() },
                { ".", new Point() },
                { ";", new Semicolon() },
                { "?", new QuestionMark() },
                { "!", new ExclamationMark() },
                { "?!", new QuestionExclamation() },
                { "...", new Ellipsis() },
                { "!..", new ExclamationEllipsis() },
                { "!!!", new TripleExclamation() },
                { "?..", new QuestionEllipsis() }
            };
        }

        private ISentencePart PunctuationMarkCreate(Symbol symbol)
        {
            var punctuationMark = new PunctuationMark();
            punctuationMark.Add(symbol);
            return punctuationMark;
        }

        private void SendWord(object sender, FileReaderEventArgs e)
        {
            AddedWordToSentence(e.Data);
        }

        private void SendPunctuation(object sender, FileReaderEventArgs e)
        {
            AddedPunctuationMarkToSentence(e.Data);
        }

        private void TextEnd(object sender, FileReaderEventArgs e)
        {
            AddedWordToSentence(e.Data);
            _text.Add(_sentence);
            _sentence = new Sentence();
        }

        private void AddedWordToSentence(string newWord)
        {
            var word = CreateWordFromString(newWord);
            _sentence.Add(word);
        }

        private void AddedPunctuationMarkToSentence(string newMark)
        {
            if (_punctuations.TryGetValue(newMark, out Symbol punctuation))
            {
                _sentence.Add(PunctuationMarkCreate(punctuation));
            }
            else if (_endSentencePunctuations.TryGetValue(newMark, out Symbol newLinePunctuation))
            {
                _sentence.Add(PunctuationMarkCreate(newLinePunctuation));
                _text.Add(_sentence);
                _sentence = new Sentence();
            }
        }

        private ISentencePart CreateWordFromString(string strWord)
        {
            var word = new Word();
            foreach (var symbol in strWord)
            {
                word.Add(new Alphanumeric(symbol));
            }

            return word;
        }
    }
}
