namespace KLO128.Calculator.Domain.Shared.Models.Expressions
{
    public class BinaryExpression : ExpressionBase
    {
        public Token? Token { get; set; } = null!;

        public AppendixExpression? Appendix { get; set; }

        public Warning? Warning { get; set; }

        public BinaryExpression() : base()
        {

        }

        public BinaryExpression(Warning warning) : base()
        {
            Warning = warning;
        }

        public BinaryExpression(int StartIndex, int EndIndex) : base(StartIndex, EndIndex)
        {
        }
    }
}
