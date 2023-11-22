using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Services.Impl;
using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;
using System.Reflection;
using System.Text;

namespace KLO128.Calculator.Tests
{
    [TestClass]
    public class TestCaseGenerator
    {
        #region ExpressionContextTree Code Strings

        private const string ExpressionsDataDictFormat = @"
        public static Dictionary<string, ExpressionData> Expressions {{ get; }} = new Dictionary<string, ExpressionData>()
        {{
{0}
        }};
";
        private const string ExpressionKeyValueFormat = @"
            {{
                Tests.Expressions.{0}, new ExpressionData
                {{
                    Culture = new Dictionary<string, ExpressionData.CultureData>
                    {{
                        {{
                            ""cs-CZ"",
                            new ExpressionData.CultureData
                            {{
{1}
                            }}
                        }},
                        {{
                            ""en-US"",
                            new ExpressionData.CultureData
                            {{
{2}
                            }}
                        }}
                    }}
                }}
            }},";

        private const string TreeFormat = @"
new ExpressionContextTree(new Token(""placeholder""))
{{
    Token = {0},
    Warning = {1},
    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
    {{
{2}
    }})
}},
";

        private const string ExpressionCultureDataFormat = @"
                                PrettyPrint = ""{0}"",
                                PrettyPrintWithSeparators = ""{1}"",
                                ResultString = ""{2}"",
                                ResultStringWithSeparators = ""{3}"",
                                Tokens = {4},
                                Warning = {5},
                                Tree = {6}
                                BinaryExpression = {7}
";
        #endregion

        #region BinaryExpression Code Strings

        private const string BinaryExpressionFormat = @"
new {0}
{{
    Token = {1},
    Warning = {2},
    Strength = OPStrength.{3},
    StartIndex = {4},
    EndIndex = {5},
    Inner = {6},
    Appendix = {7}
}}
";
        private const string AppendixExpressionFormat = @"
new AppendixExpression({0}, {1}, {2})
{{
    Inner = {3}
}}
";

        #endregion

        private IExpressionDomainService ExpressionDomainService { get; }
        private ExpressionVisitorDomainService ExpressionVisitorDomainService { get; }
        private IComputeDomainService ComputeDomainService { get; }

        public TestCaseGenerator()
        {
            ExpressionDomainService = new ExpressionDomainService(new CultureDomainService());
            ExpressionVisitorDomainService = new ExpressionVisitorDomainService();
            ComputeDomainService = new ComputeDomainService(new CultureDomainService(), new NumberFormatDomainService(), ExpressionDomainService, ExpressionVisitorDomainService);
        }

        [TestMethod]
        public void GenerateCases()
        {
            var sb = new StringBuilder();
            var expressionsCount = typeof(Expressions).GetFields(BindingFlags.Public | BindingFlags.Static).Length;

            for (int i = 1; i <= expressionsCount; i++)
            {
                var key = $"Expression{i}";
                var propValue = typeof(Expressions).GetField(key, BindingFlags.Public | BindingFlags.Static)?.GetValue(null)?.ToString();

                sb.AppendFormat(ExpressionKeyValueFormat, key, GenerateCases(propValue!, "cs-CZ"), GenerateCases(propValue!, "en-US"));
            }

            var result = string.Format(ExpressionsDataDictFormat, sb.ToString());

            Assert.IsNotNull(result);
        }

        private string GenerateCases(string expression, string culture)
        {
            var pading = "                                ";

            var binaryExpression = ExpressionDomainService.ParseExpression(expression, culture);
            var binaryExpressionString = PrintExpression(binaryExpression, pading);
            var tree = PrintTreeContext(ExpressionVisitorDomainService.DispatchExpression(binaryExpression), pading);
            var prettyPrint = ComputeDomainService.PrettyPrint(expression, culture, false, false);
            var prettyPrintWithSeparators = ComputeDomainService.PrettyPrint(expression, culture, true, false);
            var tokens = $"new List<Token> {{{string.Join(", ", ExpressionDomainService.GetTokens(expression, culture).Select(x => StringifyToken(x)).ToArray())}}}";
            var warning = ComputeDomainService.TryCompute(expression, culture, out double result);
            var resultStringWithSeparators = ComputeDomainService.PrettyPrint(result.AsNumberString(), culture, true, false);

            return string.Format(ExpressionCultureDataFormat, prettyPrint, prettyPrintWithSeparators, result.AsNumberString(), resultStringWithSeparators, tokens, StringifyWarning(warning), tree, binaryExpressionString);
        }

        private string PrintExpression(ExpressionBase expression, string pading)
        {
            var sb = new StringBuilder();

            string innerStr;

            if (expression.Inner != null)
            {
                innerStr = PrintExpression(expression.Inner, pading + "    ");
            }
            else
            {
                innerStr = "null";
            }

            if (expression is BinaryExpression binaryExpression)
            {
                string appendixStr;

                if (binaryExpression.Appendix != null)
                {
                    appendixStr = PrintExpression(binaryExpression.Appendix, pading + "    ");
                }
                else
                {
                    appendixStr = "null";
                }

                sb.AppendFormat(BinaryExpressionFormat, expression is BracketExpression ? nameof(BracketExpression) : nameof(BinaryExpression), StringifyToken(binaryExpression.Token), StringifyWarning(binaryExpression.Warning), binaryExpression.Strength, binaryExpression.StartIndex, binaryExpression.EndIndex, innerStr, appendixStr);
            }
            else if (expression is AppendixExpression appendixExpression)
            {
                sb.AppendFormat(AppendixExpressionFormat, StringifyOperator(appendixExpression.Operator), appendixExpression.StartIndex, appendixExpression.EndIndex, innerStr);
            }

            var ret = sb.ToString();

            return ret.Replace("\r\n", "\r\n" + pading);
        }

        private string PrintTreeContext(ExpressionContextTree tree, string pading)
        {
            var childrenSb = new StringBuilder();

            foreach (var child in tree.Children)
            {
                childrenSb.AppendLine(PrintTreeContext(child, pading + "    "));
            }

            var ret = string.Format(TreeFormat, StringifyToken(tree.Token), StringifyWarning(tree.Warning), childrenSb.ToString());

            return ret.Replace("\r\n", "\r\n" + pading);
        }

        private string StringifyOperator(OP? op)
        {
            return op == null ? "null" : $"new {nameof(OP)}(\"{op.Text}\", {nameof(OPStrength)}.{op.Strength}, {op.StartCharIndex})";
        }

        private string StringifyWarning(Warning? warning)
        {
            return warning == null ? "null" : $"{nameof(Warning)}.{nameof(Warning.CreateForTesting)}(\"{warning.Code}\")";
        }

        private string StringifyToken(Token? token)
        {
            return token == null ? "null" : $"new {(token is not OP ? nameof(Token) : nameof(OP))}(\"{token.Text}\")";
        }
    }
}
