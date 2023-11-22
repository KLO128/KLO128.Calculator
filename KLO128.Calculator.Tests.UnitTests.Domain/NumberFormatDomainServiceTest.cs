using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Services.Impl;
using KLO128.Calculator.Tests.UnitTests.Domain.Mocks;

namespace KLO128.Calculator.Tests.UnitTests.Domain
{
    [TestClass]
    public class NumberFormatDomainServiceTest
    {
        private INumberFormatDomainService Service { get; }

        public NumberFormatDomainServiceTest()
        {
            Service = new NumberFormatDomainService();
        }

        [TestMethod]
        public void MyNumberFormat_ValidateNumber()
        {
            foreach (var item in TestDataContainer.NumberFormatsValidation)
            {
                Assert.AreEqual(item.Value, Service.ValidateNumber(item.Key), $"Expected {item.Value}, got {!item.Value}; for Expression {item.Key}");
            }
        }
    }
}
