namespace KLO128.Calculator.Domain.Shared.Models.Expressions
{
    public class BracketExpression : BinaryExpression
    {
        public BracketExpression() : base()
        {

        }

        public BracketExpression(int StartIndex, int EndIndex) : base(StartIndex, EndIndex)
        {
        }
    }
}
