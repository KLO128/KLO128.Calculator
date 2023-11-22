using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Services.Impl;
using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Tests.UnitTests.Domain.Mocks;

namespace KLO128.Calculator.Tests.IntegrationTests.Domain
{
    [TestClass]
    public class ComputeDomainServiceTest
    {
        private IComputeDomainService computeService;

        public ComputeDomainServiceTest()
        {
            var cultureService = new CultureDomainService();
            computeService = new ComputeDomainService(cultureService, new NumberFormatDomainService(), new ExpressionDomainService(cultureService), new ExpressionVisitorDomainService());
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
        public void ComputeService_TryCompute(string expression, string culture)
        {
            var expected = TestDataContainer.Expressions[expression].Culture[culture];

            if (computeService.TryCompute(expression, culture, out double result) is Warning warning)
            {
                Assert.AreEqual(expected.Warning?.Code, warning.Code);
            }
            else
            {
                Assert.AreEqual(expected.ResultString, result.AsNumberString());
            }
        }
    }
}
