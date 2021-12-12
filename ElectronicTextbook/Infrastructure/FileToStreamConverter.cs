using ElectronicTextbook.Infrastructure.Interfaces;
using System.IO;

namespace ElectronicTextbook.Infrastructure
{
    internal class FileToStreamConverter : IToStreamConverter
    {
        public Stream Convert(string filePath)
        {
            var stream = new FileStream(filePath, FileMode.Open);
            return stream;
        }
    }
}
