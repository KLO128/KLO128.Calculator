using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Services.Impl;
using KLO128.Calculator.Tests.UnitTests.Domain.Mocks;

namespace KLO128.Calculator.Tests.UnitTests.Domain
{
    [TestClass]
    public class ComputeDomainServiceTest
    {
        private IComputeDomainService computeService;

        public ComputeDomainServiceTest()
        {
            computeService = new ComputeDomainService(new CultureDomainService(), new NumberFormatDomainService(), new ExpressionDomainServiceMock(), new ExpressionVisitorDomainServiceMock());
        }

        [TestMethod]
        [DataRow(Expressions.Expression1, "cs-CZ", true)]
        [DataRow(Expressions.Expression2, "cs-CZ", true)]
        [DataRow(Expressions.Expression3, "cs-CZ", true)]
        [DataRow(Expressions.Expression4, "cs-CZ", true)]
        [DataRow(Expressions.Expression5, "cs-CZ", true)]
        [DataRow(Expressions.Expression6, "cs-CZ", true)]
        [DataRow(Expressions.Expression7, "cs-CZ", true)]
        [DataRow(Expressions.Expression1, "en-US", true)]
        [DataRow(Expressions.Expression2, "en-US", true)]
        [DataRow(Expressions.Expression3, "en-US", true)]
        [DataRow(Expressions.Expression4, "en-US", true)]
        [DataRow(Expressions.Expression5, "en-US", true)]
        [DataRow(Expressions.Expression6, "en-US", true)]
        [DataRow(Expressions.Expression7, "en-US", true)]
        [DataRow(Expressions.Expression1, "cs-CZ", false)]
        [DataRow(Expressions.Expression2, "cs-CZ", false)]
        [DataRow(Expressions.Expression3, "cs-CZ", false)]
        [DataRow(Expressions.Expression4, "cs-CZ", false)]
        [DataRow(Expressions.Expression5, "cs-CZ", false)]
        [DataRow(Expressions.Expression6, "cs-CZ", false)]
        [DataRow(Expressions.Expression7, "cs-CZ", false)]
        [DataRow(Expressions.Expression1, "en-US", false)]
        [DataRow(Expressions.Expression2, "en-US", false)]
        [DataRow(Expressions.Expression3, "en-US", false)]
        [DataRow(Expressions.Expression4, "en-US", false)]
        [DataRow(Expressions.Expression5, "en-US", false)]
        [DataRow(Expressions.Expression6, "en-US", false)]
        [DataRow(Expressions.Expression7, "en-US", false)]
        public void ComputeDomainService_PrettyPrint(string expression, string culture, bool useSeparators)
        {
            var data = TestDataContainer.Expressions[expression].Culture[culture];
            var expectedExpression = useSeparators ? data.PrettyPrintWithSeparators : data.PrettyPrint;
            var expectedResult = useSeparators ? data.ResultStringWithSeparators : data.ResultString;

            if (data.Warning != null)
            {
                Assert.AreEqual(string.Empty, computeService.PrettyPrint(expression, culture, useSeparators, false));
                return;
            }

            Assert.AreEqual(expectedExpression, computeService.PrettyPrint(expression, culture, useSeparators, false));
            Assert.AreEqual(expectedResult, computeService.PrettyPrint(expectedResult, culture, useSeparators, false));
        }

        [TestMethod]
        [DataRow(Expressions.Expression1)]
        [DataRow(Expressions.Expression2)]
        [DataRow(Expressions.Expression3)]
        [DataRow(Expressions.Expression4)]
        [DataRow(Expressions.Expression5)]
        [DataRow(Expressions.Expression6)]
        [DataRow(Expressions.Expression7)]
        public void ComputeDomainService_PrettyPrintNormalized(string expression)
        {
            var data = TestDataContainer.Expressions[expression].Culture["en-US"];
            var expectedExpression = data.PrettyPrint;

            if (data.Warning != null)
            {
                Assert.AreEqual(string.Empty, computeService.PrintNormalized(expression, "en-US", false));
                return;
            }

            Assert.AreEqual(expectedExpression, computeService.PrintNormalized(expression, "en-US", false));
        }
    }
}
