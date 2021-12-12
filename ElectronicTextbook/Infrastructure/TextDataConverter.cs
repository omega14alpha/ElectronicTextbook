﻿using ElectronicTextbook.EventsArgs;
using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Infrastructure.PieceOfText;
using ElectronicTextbook.Models.TextSymbols.PhysicalSymbol;
using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure
{
    internal class TextDataConverter : ITextDataConverter
    {
        private readonly IStreamParser _fileParser;

        private IText _text;

        public TextDataConverter(IStreamParser fileReader, IText text)
        {
            _fileParser = fileReader;
            _fileParser.IsAlphanumeric += AddSymbolToWord;
            _fileParser.IsPunctuation += SendPunctuation;
            _fileParser.IsSpaceOrEnd += End;
            _text = text;
        }

        public IText GetTextFromFile(string filePath)
        {
            StartParsing(new FileToStreamConverter(), filePath);
            return _text;
        }

        public IText GetTextFromString(string substring)
        {
            _text = new Text();
            StartParsing(new StringToStreamConverter(), substring);
            return _text;
        }

        public ISentence CreateSentenceFromWords(IEnumerable<ISentencePart> words)
        {
            ISentence tempSentence = new Sentence();
            foreach (var item in words)
            {
                tempSentence.Add(item);
            }

            return tempSentence;
        }

        private void StartParsing(IToStreamConverter converter, string source)
        {
            var stream = converter.Convert(source);
            _fileParser.Parsing(stream);
        }

        private void AddSymbolToWord(object sender, FileReaderEventArgs e)
        {
            _text.AddNewAlphanumericSymbol(new Alphanumeric(e.Data));
        }

        private void SendPunctuation(object sender, FileReaderEventArgs e)
        {
            ISymbol punctuation = SymbolConvertor.Convert(e.Data);
            if (punctuation is not null)
            {
                _text.AddNewPunctuationSymbol(punctuation);
            }
        }

        private void End(object sender, FileReaderEventArgs e)
        {
            _text.AddEndOrNewSentencePart();
        }
    }
}
