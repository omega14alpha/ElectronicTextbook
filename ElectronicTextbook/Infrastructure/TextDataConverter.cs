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
        private readonly IFileReader _fileParser;

        private Text _text;
        private Sentence _sentence;

        private Dictionary<string, Symbol> _punctuations;
        private Dictionary<string, Symbol> _endSentencePunctuations;

        public TextDataConverter(IFileReader fileReader)
        {
            _fileParser = fileReader;
            _fileParser.WordIsCollected += SendWord;
            _fileParser.PunctuationIsCollected += SendPunctuation;

            _text = new Text();
            _sentence = new Sentence();

            Init();
        }

        public Text GetTextFromFile(string filePath)
        {
            _fileParser.FileParsing(filePath);
            return _text;
        }

        public ISentencePart<Symbol> CreateWordFromString(string strWord)
        {
            var word = new Word();
            foreach (var symbol in strWord)
            {
                word.Add(new Alphanumeric(symbol));
            }

            return word;
        }

        public Sentence CreateSentenceFromWords(IEnumerable<ISentencePart<Symbol>> words)
        {
            _sentence = new Sentence();
            foreach (var item in words)
            {
                _sentence.Add(item);
            }

            return _sentence;
        }

        public ISentencePart<Symbol> PunctuationMarkCreate(Symbol symbol)
        {
            var punctuationMark = new PunctuationMark();
            punctuationMark.Add(symbol);
            return punctuationMark;
        }

        public Text CreateTextFromSentences(IEnumerable<Sentence> sentences)
        {
            _text = new Text();
            foreach (var sentence in sentences)
            {
                _text.Add(sentence);
            }

            return _text;
        }

        public Text CreateTextFromSentence(Sentence sentence)
        {
            _text = new Text();
            _text.Add(sentence);
            return _text;
        }

        public Text CreateTextFromWords(IEnumerable<ISentencePart<Symbol>> words)
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

        private void SendWord(object sender, FileReaderEventArgs e)
        {
            var word = CreateWordFromString(e.Data);
            _sentence.Add(word);
        }

        private void SendPunctuation(object sender, FileReaderEventArgs e)
        {
            if (_punctuations.TryGetValue(e.Data, out Symbol punctuation))
            {
                _sentence.Add(PunctuationMarkCreate(punctuation));
            }
            else if (_endSentencePunctuations.TryGetValue(e.Data, out Symbol newLinePunctuation))
            {
                _sentence.Add(PunctuationMarkCreate(newLinePunctuation));
                _text.Add(_sentence);
                _sentence = new Sentence();
            }
        }
    }
}
