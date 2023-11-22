using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;

namespace KLO128.Calculator.Tests.UnitTests.Domain.Mocks
{
    internal class ExpressionVisitorDomainServiceMock : IExpressionVisitorDomainService
    {
        public ExpressionContextTree DispatchExpression(AppendixExpression? expression)
        {
            return GetTree(expression);
        }

        public ExpressionContextTree DispatchExpression(BinaryExpression expression)
        {
            return GetTree(expression);
        }

        private ExpressionContextTree GetTree<T>(T? expression) where T : ExpressionBase
        {
            var ret = expression is BinaryExpression binary ? new ExpressionContextTree(binary) : new ExpressionContextTree(expression as AppendixExpression);

            if (expression == null)
            {
                return ret;
            }

            foreach (var item in TestDataContainer.Expressions)
            {
                try
                {
                    var itemValue = item.Value.Culture.First().Value;
                    AssertExpr.AreEqual(itemValue.BinaryExpression, expression);

                    return itemValue.Tree;
                }
                catch (AssertFailedException)
                {
                    continue;
                }
            }

            return ret;
        }
    }
}
