using ElectronicTextbook.EventsArgs;
using ElectronicTextbook.Models.PieceOfText;
using ElectronicTextbook.Models.TextSymbols;
using ElectronicTextbook.Models.TextSymbols.LogicSymbols;
using ElectronicTextbook.Models.TextSymbols.PhysicalSymbol;
using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure
{
    internal class IncomingTextAnalyzer
    {
        private readonly TextFileReader _fileParser;

        private Text _text;
        private Sentence _sentence;

        private Dictionary<string, Symbol> _punctuations;
        private Dictionary<string, Symbol> _newLinePunctuations;

        public IncomingTextAnalyzer()
        {
            _fileParser = new TextFileReader();
            _fileParser.WordIsCollected += SendWord;
            _fileParser.PunctuationCollected += SendPunctuation;

            _text = new Text();
            _sentence = new Sentence();

            _punctuations = new Dictionary<string, Symbol>()
            {
                { ",", new Comma() }
            };

            _newLinePunctuations = new Dictionary<string, Symbol>()
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

        internal Text Parsing(string filePath)
        {
            _fileParser.FileParsing(filePath);
            return _text;
        }

        private void SendWord(object sender, FileReaderEventArgs e)
        {
            Word word = new Word();
            foreach (var symbol in e.Data)
            {
                word.Add(new Alphanumeric(symbol));
            }

            _sentence.Add(word);
        }

        private void SendPunctuation(object sender, FileReaderEventArgs e)
        {
            PunctuationMark punctuationMark = new PunctuationMark();
            if (_punctuations.TryGetValue(e.Data, out Symbol punctuation))
            {
                punctuationMark.Add(punctuation);
                _sentence.Add(punctuationMark);
            }
            else if (_newLinePunctuations.TryGetValue(e.Data, out Symbol newLinePunctuation))
            {
                punctuationMark.Add(newLinePunctuation);
                _sentence.Add(punctuationMark);
                _text.Add(_sentence);
                _sentence = new Sentence();
            }
        }
    }
}
