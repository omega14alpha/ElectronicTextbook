using ElectronicTextbook.Infrastructure.Interfaces;

namespace ElectronicTextbook.Models.PieceOfText
{
    internal class PunctuationMark : ITextContainer, ITextElement
    {
        private ITextElement _symbol;

        public void Add(ITextElement symbol)
        {
            _symbol = symbol;
        }

        public override string ToString()
        {
            return _symbol.ToString();
        }
    }
}
