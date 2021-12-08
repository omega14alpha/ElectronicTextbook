namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ISentencePart<T>
    {
        int Length { get; }

        void Add(T t);
    }
}
