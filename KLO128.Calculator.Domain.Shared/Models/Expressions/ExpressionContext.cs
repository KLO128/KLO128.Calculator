namespace KLO128.Calculator.Domain.Shared.Models.Expressions
{
    public class ExpressionContext
    {
        public int StartIndex { get; }

        public int EndIndex { get; }

        public BinaryExpression Context { get; set; } = null!;

        public int Index { get; set; }

        public int BracketCount { get; set; }

        public ExpressionContext(int StartIndex, int EndIndex)
        {
            this.StartIndex = StartIndex;
            this.EndIndex = EndIndex;
        }
    }
}
