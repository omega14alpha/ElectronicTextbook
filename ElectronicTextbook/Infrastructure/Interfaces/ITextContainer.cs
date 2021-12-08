using System.Collections.Generic;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ITextContainer<T> : IEnumerable<T>
    {
        void Add(T t);

        void Replace(IEnumerable<T> oldDatas, T newData);

        void Remove(T data);
    }
}
