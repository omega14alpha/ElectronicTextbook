using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ITextDataConverter
    {
        IText GetTextFromFile(string filePath);

        ISentence CreateSentenceFromWords(IEnumerable<ISentencePart> words);

        IText CreateTextFromString(string data);

        IText CreateTextFromSentences(IEnumerable<ISentence> sentences);

        IText CreateTextFromSentence(ISentence sentence);

        IText CreateTextFromWords(IEnumerable<ISentencePart> words);
    }
}
