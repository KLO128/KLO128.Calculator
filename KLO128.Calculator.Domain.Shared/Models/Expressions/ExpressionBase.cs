namespace KLO128.Calculator.Domain.Shared.Models.Expressions
{
    public abstract class ExpressionBase
    {
        public OPStrength Strength { get; set; }

        public BinaryExpression? Inner { get; set; }

        public int StartIndex { get; set; }

        public int EndIndex { get; set; }

        public ExpressionBase()
        {

        }

        public ExpressionBase(int StartIndex, int EndIndex = -1)
        {
            this.StartIndex = StartIndex;
            this.EndIndex = EndIndex;
        }

    }
}
