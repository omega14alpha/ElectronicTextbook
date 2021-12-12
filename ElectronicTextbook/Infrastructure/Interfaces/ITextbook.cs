using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ITextbook
    {
        IText Text { get; }

        void GetTextFromFile(string filePath);

        IEnumerable<IDisplayed> SortSentencesByWordsCount();

        IEnumerable<string> GetWordsByLengthFromQuestions(int wordLength);

        IEnumerable<ISentence> DeleteWordsByLength(int wordLength);

        ISentence ReplaceWordsInSentence(int wordLength, string substring);
    }
}
