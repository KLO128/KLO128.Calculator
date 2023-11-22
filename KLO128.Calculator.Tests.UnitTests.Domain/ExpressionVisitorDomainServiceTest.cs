using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Services.Impl;
using KLO128.Calculator.Tests.UnitTests.Domain.Mocks;
namespace KLO128.Calculator.Tests.UnitTests.Domain
{
    [TestClass]
    public class ExpressionVisitorDomainServiceTest
    {
        private IExpressionDomainService expressionService;
        private IExpressionVisitorDomainService expressionVisitorService;
        private ExpressionVisitorDomainServiceMock expressionVisitorServiceMock;

        public ExpressionVisitorDomainServiceTest()
        {
            expressionService = new ExpressionDomainServiceMock();
            expressionVisitorService = new ExpressionVisitorDomainService();
            expressionVisitorServiceMock = new ExpressionVisitorDomainServiceMock();
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
        public void ExpressionVisitorDomainService_DispatchExpression(string expression, string culture)
        {
            var binaryExpression = expressionService.ParseExpression(expression, culture);

            AssertExpr.AreEqual(expressionVisitorServiceMock.DispatchExpression(binaryExpression), expressionVisitorService.DispatchExpression(binaryExpression));
        }
    }
}
