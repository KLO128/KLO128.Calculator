using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Shared;
using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;
using System.Globalization;

namespace KLO128.Calculator.Tests.UnitTests.Domain.Mocks
{
    public class ExpressionDomainServiceMock : IExpressionDomainService
    {
        public IEnumerable<Token> GetTokens(string? expression, string culture)
        {
            if (expression == null)
            {
                return new List<Token>();
            }

            return TestDataContainer.Expressions[expression].Culture[culture].Tokens;
        }

        public BinaryExpression ParseExpression(string? expression, string culture)
        {
            if (expression == null)
            {
                return new BinaryExpression();
            }

            return TestDataContainer.Expressions[expression].Culture[culture].BinaryExpression;
        }

        public Warning? TryScanForTokens(string? expression, CultureInfo culture, out List<Token> tokens)
        {
            if (expression == null)
            {
                tokens = new List<Token>();
                return null;
            }

            if (TestDataContainer.Expressions.TryGetValue(expression, out ExpressionData? result))
            {
                tokens = result.Culture[culture.Name].Tokens;

                return null;
            }
            else
            {
                foreach (var item in TestDataContainer.Expressions)
                {
                    if (item.Value.Culture[culture.Name].ResultString == expression)
                    {
                        tokens = new List<Token>()
                        {
                            new Token(expression)
                        };
                    }
                }
                tokens = new List<Token>();

                return new Warning(nameof(Translations.exp005), $"Mock not set for: {expression}", "0");
            }
        }
    }
}
