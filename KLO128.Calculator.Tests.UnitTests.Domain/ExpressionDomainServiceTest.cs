using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Tests.UnitTests.Domain.Mocks;

namespace KLO128.Calculator.Tests.UnitTests.Domain
{
    [TestClass]
    public class ExpressionDomainServiceTest
    {
        private IExpressionDomainService expressionService;
        private ExpressionDomainServiceMock expressionServiceMock;

        public ExpressionDomainServiceTest()
        {
            expressionService = new ExpressionDomainServiceMock();
            expressionServiceMock = new ExpressionDomainServiceMock();
        }

        [TestMethod]
        [DataRow(Expressions.Expression1, "cs-CZ")]
        [DataRow(Expressions.Expression2, "cs-CZ")]
        [DataRow(Expressions.Expression3, "cs-CZ")]
        [DataRow(Expressions.Expression4, "cs-CZ")]
        [DataRow(Expressions.Expression5, "cs-CZ")]
        [DataRow(Expressions.Expression6, "cs-CZ")]
        [DataRow(Expressions.Expression7, "cs-CZ")]
        [DataRow(Expressions.Expression1, "en-US")]
        [DataRow(Expressions.Expression2, "en-US")]
        [DataRow(Expressions.Expression3, "en-US")]
        [DataRow(Expressions.Expression4, "en-US")]
        [DataRow(Expressions.Expression5, "en-US")]
        [DataRow(Expressions.Expression6, "en-US")]
        [DataRow(Expressions.Expression7, "en-US")]
        public void ExpressionService_GetTokens(string expression, string culture)
        {
            var expectedTokens = expressionServiceMock.GetTokens(expression, culture);
            var actualTokens = expressionService.GetTokens(expression, culture);

            Assert.AreEqual(expectedTokens.Count(), actualTokens.Count());

            for (int i = 0; i < expectedTokens.Count(); i++)
            {
                Assert.AreEqual(expectedTokens.ElementAtOrDefault(i)?.Text, actualTokens.ElementAtOrDefault(i)?.Text);
                Assert.AreEqual(expectedTokens.ElementAtOrDefault(i)?.CharOrder, actualTokens.ElementAtOrDefault(i)?.CharOrder);
            }
        }

        [TestMethod]
        [DataRow(Expressions.Expression1, "cs-CZ")]
        [DataRow(Expressions.Expression2, "cs-CZ")]
        [DataRow(Expressions.Expression3, "cs-CZ")]
        [DataRow(Expressions.Expression4, "cs-CZ")]
        [DataRow(Expressions.Expression5, "cs-CZ")]
        [DataRow(Expressions.Expression6, "cs-CZ")]
        [DataRow(Expressions.Expression7, "cs-CZ")]
        [DataRow(Expressions.Expression1, "en-US")]
        [DataRow(Expressions.Expression2, "en-US")]
        [DataRow(Expressions.Expression3, "en-US")]
        [DataRow(Expressions.Expression4, "en-US")]
        [DataRow(Expressions.Expression5, "en-US")]
        [DataRow(Expressions.Expression6, "en-US")]
        [DataRow(Expressions.Expression7, "en-US")]
        public void ExpressionService_ParseExpression(string expression, string culture)
        {
            var expectedExpression = expressionServiceMock.ParseExpression(expression, culture);
            var actualExpression = expressionService.ParseExpression(expression, culture);

            AssertExpr.AreEqual(expectedExpression, actualExpression);
        }
    }
}
