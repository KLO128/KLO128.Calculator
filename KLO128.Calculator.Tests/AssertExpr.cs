using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;

namespace KLO128.Calculator.Tests
{
    public static class AssertExpr
    {
        public static void AreEqual(ExpressionContextTree? expected, ExpressionContextTree? actual)
        {
            Assert.IsTrue(expected == null == (actual == null));

            if (expected == null || actual == null)
            {
                return;
            }

            Assert.AreEqual(expected.Warning?.Code, actual.Warning?.Code);
            Assert.AreEqual(expected.Token?.Text, actual.Token?.Text);
            Assert.AreEqual(expected.Children.Count, actual.Children.Count);

            var expectedNext = expected.Children.First;
            var actualNext = actual.Children.First;
            do
            {
                AreEqual(expectedNext?.Value, actualNext?.Value);

                expectedNext = expectedNext?.Next;
                actualNext = actualNext?.Next;
            }
            while (expectedNext != null && actualNext != null);
        }

        public static void AreEqual(ExpressionBase? expected, ExpressionBase? actual)
        {
            Assert.IsTrue(expected == null == (actual == null));

            if (expected == null || actual == null)
            {
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.GetType(), actual.GetType());
            Assert.AreEqual(expected.Strength, actual.Strength);
            Assert.AreEqual(expected.StartIndex, actual.StartIndex);
            Assert.AreEqual(expected.EndIndex, actual.EndIndex);

            if (expected is BinaryExpression expectedBinary && actual is BinaryExpression actualBinary)
            {
                Assert.AreEqual(expectedBinary.Token?.Text, actualBinary.Token?.Text);
                Assert.AreEqual(expectedBinary.Warning?.Code, actualBinary.Warning?.Code);
                AreEqual(expectedBinary.Appendix, actualBinary.Appendix);
            }
            else if (expected is AppendixExpression expectedAppendix && actual is AppendixExpression actualAppendix)
            {
                Assert.AreEqual(expectedAppendix.Operator.Text, actualAppendix.Operator.Text);
            }

            AreEqual(expected.Inner, actual.Inner);
        }
    }
}
