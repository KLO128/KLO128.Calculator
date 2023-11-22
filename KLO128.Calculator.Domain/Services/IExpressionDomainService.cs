using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;
using System.Globalization;

namespace KLO128.Calculator.Domain.Services
{
    public interface IExpressionDomainService
    {
        BinaryExpression ParseExpression(string? expression, string culture);

        IEnumerable<Token> GetTokens(string? expression, string culture);

        Warning? TryScanForTokens(string? expression, CultureInfo culture, out List<Token> tokens);
    }
}
