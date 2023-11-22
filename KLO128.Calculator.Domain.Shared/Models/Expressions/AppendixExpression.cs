namespace KLO128.Calculator.Domain.Shared.Models.Expressions
{
    public class AppendixExpression : ExpressionBase
    {
        public OP Operator { get; set; }

        public AppendixExpression(OP Operator, int StartIndex, int EndIndex = -1) : base(StartIndex, EndIndex)
        {
            this.Operator = Operator;
            Strength = Operator.Strength;
        }
    }
}
