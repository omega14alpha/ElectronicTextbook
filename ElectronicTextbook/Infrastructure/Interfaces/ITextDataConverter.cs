using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ITextDataConverter
    {
        IText GetTextFromFile(string filePath);

        IText GetTextFromString(string substring);

        ISentence CreateSentenceFromWords(IEnumerable<ISentencePart> words);
    }
}
