using ElectronicTextbook.Models.PieceOfText;

namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface ITextAnalyzer
    {
        Text Parsing(string filePath);
    }
}
