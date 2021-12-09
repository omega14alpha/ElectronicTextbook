using ElectronicTextbook.Models.PieceOfText;
using ElectronicTextbook.Models.TextSymbols;
using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ITextDataConverter
    {
        Text GetTextFromFile(string filePath);

        ISentencePart<Symbol> CreateWordFromString(string strWord);

        Sentence CreateSentenceFromWords(IEnumerable<ISentencePart<Symbol>> words);

        Text CreateTextFromSentences(IEnumerable<Sentence> sentences);

        Text CreateTextFromSentence(Sentence sentence);

        Text CreateTextFromWords(IEnumerable<ISentencePart<Symbol>> words);
    }
}
