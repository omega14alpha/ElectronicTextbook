using ElectronicTextbook.Infrastructure.Interfaces;
using System.IO;
using System.Text;

namespace ElectronicTextbook.Infrastructure
{
    internal class StringToStreamConverter : IToStreamConverter
    {
        public Stream Convert(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            var stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
