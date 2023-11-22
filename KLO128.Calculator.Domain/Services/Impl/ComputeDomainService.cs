using KLO128.Calculator.Domain.Shared;
using KLO128.Calculator.Domain.Shared.Models;
using System.Globalization;
using System.Text;

namespace KLO128.Calculator.Domain.Services.Impl
{
    public class ComputeDomainService : IComputeDomainService
    {
        private ICultureDomainService CultureService { get; }

        private INumberFormatDomainService NumberFormatService { get; }

        private IExpressionDomainService ExpressionService { get; }

        private IExpressionVisitorDomainService ExpressionVisitorService { get; }

        public ComputeDomainService(ICultureDomainService cultureService, INumberFormatDomainService numberFormatDomainService, IExpressionDomainService expressionService, IExpressionVisitorDomainService expressionVisitorService)
        {
            CultureService = cultureService;
            NumberFormatService = numberFormatDomainService;
            ExpressionService = expressionService;
            ExpressionVisitorService = expressionVisitorService;
        }

        public Warning? TryCompute(string expression, string culture, out double result)
        {
            var tree = ExpressionVisitorService.DispatchExpression(ExpressionService.ParseExpression(expression, culture));

            if (tree.Warning != null)
            {
                result = 0;
                return tree.Warning;
            }

            var ret = InterpretContextRec(tree, CultureService.GetCultureInfo(culture));

            if (ret.Warning != null)
            {
                result = double.NaN;
                return ret.Warning;
            }

            if (double.IsInfinity(ret.Result) || double.IsNaN(ret.Result))
            {
                ret.Result = double.MaxValue;
            }

            result = ret.Result;
            return null;
        }

        public string PrintNormalized(string? expression, string originalCulture, bool throwError = true)
        {
            return PrettyPrint(expression, CultureService.GetCultureInfo(originalCulture), CultureInfo.InvariantCulture, false, throwError);
        }

        public string PrettyPrint(string? expression, string culture, bool useThousandSeparator, bool throwError = true)
        {
            var cultureInfo = CultureService.GetCultureInfo(culture);
            return PrettyPrint(expression, cultureInfo, cultureInfo, useThousandSeparator, throwError);
        }

        private string PrettyPrint(string? expression, CultureInfo originalCulture, CultureInfo culture, bool useThousandSeparator, bool throwError)
        {
            if (ExpressionService.TryScanForTokens(expression, originalCulture, out List<Token> tokens) is Warning exp)
            {
                if (throwError)
                {
                    throw exp;
                }
                else
                {
                    return expression!;
                }
            }

            var sb = new StringBuilder();

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                var addWS = false;

                if (i < tokens.Count - 1)
                {
                    if (token is OP op && tokens.ElementAtOrDefault(i + 1)?.Text == Constants.LEFTBRACKET && tokens.ElementAtOrDefault(i - 1) is OP)
                    {
                        if (op.Text == Constants.ADD)
                        {
                            sb.Append(Constants.WS);
                            continue;
                        }
                        else if (op.Text != Constants.SUBTRACT)
                        {
                            addWS = true;
                        }
                    }
                    else
                    {
                        addWS = true;
                    }
                }

                if (NumberFormatService.TryParseNumber(token.Text, originalCulture, out double d))
                {
                    sb.Append(NumberFormatService.Stringify(d, culture, useThousandSeparator));
                }
                else
                {
                    sb.Append(token.Text);
                }

                if (addWS)
                {
                    sb.Append(Constants.WS);
                }
            }

            return sb.ToString();
        }

        protected virtual ContextResult InterpretContextRec(ExpressionContextTree context, CultureInfo culture)
        {
            var token = context.Token;
            ContextResult? result = null;

            if (token != null)
            {
                result = new ContextResult(token);

                if (token is OP)
                {
                    return result;
                }
            }
            else
            {
                var next = context.Children.First;

                while (next?.Value != null)
                {
                    var tmpResult = InterpretContextRec(next.Value, culture);

                    if (tmpResult.Warning != null)
                    {
                        return tmpResult;
                    }
                    else if (tmpResult.Token is OP op)
                    {//binary operation will follow
                        if (result == null)
                        {
                            result = new ContextResult(0);
                        }

                        next = next.Next;

                        if (next?.Value == null)
                        {
                            return new ContextResult(Errors.MissingOperand(op));
                        }

                        if (!SolveOperation(result, op, next.Value, culture))
                        {
                            return result;
                        }
                    }
                    else if (result == null)
                    {
                        result = new ContextResult(tmpResult.Result);
                    }
                    else
                    {
                        return new ContextResult(Errors.TooManyOperands());
                    }

                    next = next.Next;
                }
            }

            if (result?.Token != null)
            {
                if (NumberFormatService.TryParseNumber(result.Token.Text, culture, out double d))
                {
                    if (NumberFormatService.ValidateNumber(token?.Text ?? string.Empty))
                    {
                        return new ContextResult(d);
                    }
                }

                return new ContextResult(Errors.InvalidNumber(result.Token));

            }

            return result ?? new ContextResult(0);
        }

        protected bool SolveOperation(ContextResult input, OP op, ExpressionContextTree oppositeContext, CultureInfo culture)
        {
            if (oppositeContext == null || op == null)
            {
            }
            else
            {
                input.Token = null;
                var opToken = op.Text.ToUpper();
                var resTmp = InterpretContextRec(oppositeContext, culture);

                if (resTmp.Warning != null)
                {
                    input.Warning = resTmp.Warning;
                    return false;
                }

                switch (opToken)
                {
                    case Constants.AND:
                        input.Result = (int)input.Result & (int)resTmp.Result;
                        break;
                    case Constants.OR:
                        input.Result = (int)input.Result | (int)resTmp.Result;
                        break;
                    case Constants.EQUALS:
                        input.Result = input.Result == resTmp.Result ? 1 : 0;
                        break;
                    case Constants.LowerThan:
                        input.Result = input.Result < resTmp.Result ? 1 : 0;
                        break;
                    case Constants.GreaterThan:
                        input.Result = input.Result > resTmp.Result ? 1 : 0;
                        break;
                    case Constants.LowerThanOrEquals:
                        input.Result = input.Result <= resTmp.Result ? 1 : 0;
                        break;
                    case Constants.GreaterThanOrEquals:
                        input.Result = input.Result >= resTmp.Result ? 1 : 0;
                        break;
                    case Constants.ADD:
                        input.Result = input.Result + resTmp.Result;
                        break;
                    case Constants.SUBTRACT:
                        input.Result = input.Result - resTmp.Result;
                        break;
                    case Constants.MODULO:
                        input.Result = input.Result % resTmp.Result;
                        break;
                    case Constants.DIVIDE:
                        input.Result = input.Result / resTmp.Result;
                        break;
                    case Constants.MULTIPLY:
                        input.Result = input.Result * resTmp.Result;
                        break;
                    case Constants.POWER:
                        input.Result = Math.Pow(input.Result, resTmp.Result);
                        break;
                    case Constants.SQRT:
                        var inverseCoef = 1;
                        if (resTmp.Result % 2 != 0)
                        {
                            inverseCoef = -1;
                        }
                        input.Result = Math.Pow(Math.Abs(input.Result), 1d / resTmp.Result) * inverseCoef;
                        break;
                    default:
                        input.Result = double.NaN;
                        input.Warning = Errors.NotSupportedOperation(op);
                        return false;
                }
            }

            return true;
        }

        protected class ContextResult
        {
            public ContextResult(double result)
            {
                Result = result;
            }

            public ContextResult(Warning warning)
            {
                Warning = warning;
            }

            public ContextResult(Token Token) : base()
            {
                this.Token = Token;
            }

            public Token? Token { get; set; }

            public double Result { get; set; }

            public Warning? Warning { get; set; }
        }
    }
}
