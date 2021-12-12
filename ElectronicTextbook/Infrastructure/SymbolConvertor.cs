using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models.TextSymbols.PhysicalSymbol;

namespace ElectronicTextbook.Infrastructure
{
    internal static class SymbolConvertor
    {
        public static ISymbol Convert(char chSymbol)
        {
            switch (chSymbol)
            {
                case ',': return new Comma();
                case ':': return new Colon();
                case ';': return new Semicolon();
                case '.': return new Point();
                case '?': return new QuestionMark();
                case '!': return new ExclamationMark();
                default: return null;
            }
        }
    }
}
