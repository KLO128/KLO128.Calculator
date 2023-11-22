using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;

namespace KLO128.Calculator.Tests.UnitTests.Domain.Mocks
{
    public class ExpressionData
    {
        public Dictionary<string, CultureData> Culture { get; set; } = new Dictionary<string, CultureData>();

        public class CultureData
        {
            public ExpressionContextTree Tree { get; set; } = null!;

            public BinaryExpression BinaryExpression { get; set; } = null!;

            public string PrettyPrint { get; set; } = null!;

            public string PrettyPrintWithSeparators { get; set; } = null!;

            public List<Token> Tokens { get; set; } = new List<Token>();

            public string? ResultString { get; set; }

            public string? ResultStringWithSeparators { get; set; }

            public Warning? Warning { get; set; }
        }
    }
}
