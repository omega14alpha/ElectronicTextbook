using System.IO;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface IToStreamConverter
    {
        Stream Convert(string source);
    }
}
