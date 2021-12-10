namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ITextbook
    {
        IText Text { get; }

        IText SortSentencesByWordsCount();

        IText GetWordsByLengthFromQuestions(int wordLength);

        IText DeleteWordsByLength(int length);

        IText ReplaceWordsInSentence(int length, string newData);
    }
}
