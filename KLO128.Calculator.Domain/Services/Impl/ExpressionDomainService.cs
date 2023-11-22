using KLO128.Calculator.Domain.Shared;
using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using BinaryExpression = KLO128.Calculator.Domain.Shared.Models.Expressions.BinaryExpression;

namespace KLO128.Calculator.Domain.Services.Impl
{
    public class ExpressionDomainService : IExpressionDomainService
    {
        private ICultureDomainService CultureService { get; }


        public ExpressionDomainService(ICultureDomainService cultureService)
        {
            CultureService = cultureService;
        }

        public BinaryExpression ParseExpression(string? expression, string culture)
        {
            if (TryScanForTokens(expression, CultureService.GetCultureInfo(culture), out List<Token> tokens) is Warning exp)
            {
                return new BinaryExpression(exp);
            }

            if (tokens.Count == 0)
            {
                return new BinaryExpression(Errors.MissingOperand(new Token(string.Empty, 0)));
            }

            TryGetContext(tokens, out BinaryExpression ret);

            return ret;
        }

        public IEnumerable<Token> GetTokens(string? expression, string culture)
        {
            if (TryScanForTokens(expression, CultureService.GetCultureInfo(culture), out List<Token> tokens) is Warning)
            {
                return new List<Token>();
            }

            return tokens;
        }

        public Warning? TryScanForTokens(string? expression, CultureInfo culture, out List<Token> tokens)
        {
            if (expression == null)
            {
                tokens = new List<Token>();
                return null;
            }

            expression = Regex.Replace(expression, @"\p{Z}", " ");

            if (expression == null || expression.Length == 0)
            {
                tokens = new List<Token>();
                return null;
            }

            tokens = new List<Token>();
            var context = new StringBuilder();

            var thousandSeparator = culture.NumberFormat.NumberGroupSeparator.FirstOrDefault();

            string? previous = null;
            char previousChar = '\0';

            for (int i = 0; i < expression.Length; i++)
            {
                var ch = expression[i];
                var nextChar = expression.ElementAtOrDefault(i + 1);
                var res = IsNumberOrBracketPart(ch, previous, thousandSeparator, ref previousChar, IsThousandSeparator(nextChar, thousandSeparator));

                if (res == -1 && context.Length == 0 && LookAhead(expression, i + 1, skipWS: true) is LookAheadResult<char> lookAhead && lookAhead.Value == Constants.chLEFTBRACKET)
                {
                    if (ch != Constants.chADD)
                    {
                        context.Append(ch);
                        AddIfNotEmpty(tokens, context, ref previous, i);
                        previousChar = ch;
                    }

                    i = lookAhead.Index - 1;
                    continue;
                }
                else if (res == 1 || (context.Length == 0 || context[0] == Constants.chSUBTRACT) && res == -1)
                {
                    if (ch == Constants.chADD)
                    {
                        previousChar = ch;
                        continue;
                    }

                    context.Append(ch);

                    var originalIndex = i;

                    if (res == -1 && char.IsWhiteSpace(nextChar))
                    {
                        do
                        {
                            i++;
                            nextChar = expression.ElementAtOrDefault(i + 1);
                        } while (i < expression.Length && char.IsWhiteSpace(nextChar));
                    }

                    if (IsNumberOrBracketPart(nextChar, string.Empty, thousandSeparator, ref ch, IsThousandSeparator(expression.ElementAtOrDefault(i + 2), thousandSeparator)) != 1)
                    {
                        AddIfNotEmpty(tokens, context, ref previous, originalIndex);
                    }
                }
                else if (char.IsWhiteSpace(ch))
                {
                    AddIfNotEmpty(tokens, context, ref previous, i - 1);
                }
                else if ((ch == Constants.chLowerThan || ch == Constants.chGreaterThan) && nextChar == Constants.chEQUALS)
                {//double char operators
                    context.Append(ch);
                }
                else if (ch != Constants.chLEFTBRACKET && ch != Constants.chRIGHTBRACKET && !Constants.Operators.ContainsKey(ch.ToString()))
                {
                    if (ch == 'N' && expression.ElementAtOrDefault(i + 1) == 'a' && expression.ElementAtOrDefault(i + 2) == 'N')
                    {
                        i += 2;
                        context.Append(Constants.NaN);
                        AddIfNotEmpty(tokens, context, ref previous, i);
                    }
                    else
                    {
                        return Errors.UnexpectedSymbol(new Token(ch.ToString(), i));
                    }
                }
                else
                {
                    context.Append(ch);
                    AddIfNotEmpty(tokens, context, ref previous, i);
                }

                previousChar = ch;
            }

            if (context.Length > 0)
            {
                AddIfNotEmpty(tokens, context, ref previous, expression.Length - 1);
            }

            return null;
        }

        private bool IsThousandSeparator(char ch, char thousandSeparator)
        {
            if (char.IsWhiteSpace(thousandSeparator) && char.IsWhiteSpace(ch))
            {
                return true;
            }

            return ch == thousandSeparator;
        }

        private int IsNumberOrBracketPart(char ch, string? previous, char thounsandSeparator, ref char previousChar, bool nextCharIsThousandSeparator)
        {
            if (char.IsDigit(ch) || (Constants.NumberSeparators.Contains(ch) && char.IsDigit(previousChar)) || (IsThousandSeparator(ch, thounsandSeparator) && char.IsDigit(previousChar) && !nextCharIsThousandSeparator))
            {
                return 1;
            }
            else if ((ch == Constants.chSUBTRACT || ch == Constants.chADD) && !char.IsDigit(previousChar))
            {
                if (previous == Constants.LEFTBRACKET || (previous ?? null) == null || previous != null && Constants.Operators.ContainsKey(previous))
                {
                    //if (char.IsWhiteSpace(nextChar))
                    //{
                    //    do
                    //    {
                    //        i++;
                    //        previousChar = nextChar;
                    //        nextChar = expression.ElementAtOrDefault(i + 1);
                    //    } while (char.IsWhiteSpace(nextChar));
                    //}

                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private LookAheadResult<char> LookAhead(string str, int startAt, bool skipWS)
        {
            while (skipWS && char.IsWhiteSpace(str.ElementAtOrDefault(startAt)))
            {
                startAt++;
            }

            return new LookAheadResult<char> { Index = startAt, Value = str.ElementAtOrDefault(startAt) };
        }

        private void AddIfNotEmpty(List<Token> array, StringBuilder context, ref string? previous, int charIndex)
        {
            var length = context.Length;
            var token = context.ToString().TrimEnd();
            context.Clear();

            if (string.IsNullOrWhiteSpace(token))
            {
                return;
            }

            if (token.Length > 0)
            {
                if (Constants.Operators.ContainsKey(token))
                {
                    array.Add(CloneOP(Constants.Operators[token], charIndex - length + 1));
                }
                else
                {
                    array.Add(new Token(token, charIndex - length + 1));
                }
            }

            previous = token;
        }

        private void AnalyzeExpression(IEnumerable<Token> tokens, out BreakingToken[] ret, out BinaryExpression? failure, out List<List<OPStrength>> lowestOpStrength)
        {
            ret = new BreakingToken[tokens.Count()];
            var bracketContext = new Stack<BracketContextInfo>();
            failure = null;
            lowestOpStrength = new List<List<OPStrength>>
            {
                new List<OPStrength> { Constants.HighestOPStrength }
            };
            bracketContext.Push(new BracketContextInfo());

            BreakingToken? prePreviousToken = null;
            BreakingToken? previousToken = null;

            for (int i = 0; i < tokens.Count(); i++)
            {
                var token = tokens.ElementAt(i);
                var tokenText = token.Text;
                BreakingToken? breakingToken;

                if (tokenText == Constants.LEFTBRACKET)
                {
                    if (TryAnalyzeBracketOp(ret, i, token, bracketContext.Peek().BracketCount /*Belongs to parent context*/, bracketContext.Peek().Order, previousToken, prePreviousToken, out breakingToken) is BinaryExpression failure0)
                    {
                        failure = failure0;
                        return;
                    }

                    bracketContext.Peek().Order++;

                    if (lowestOpStrength.Count == bracketContext.Peek().BracketCount + 1)
                    {
                        lowestOpStrength.Add(new List<OPStrength> { Constants.HighestOPStrength });
                    }
                    else
                    {
                        lowestOpStrength[bracketContext.Peek().BracketCount + 1].Add(Constants.HighestOPStrength);
                    }

                    bracketContext.Push(new BracketContextInfo() { BracketCount = bracketContext.Peek().BracketCount + 1, BracketToken = breakingToken!, Order = 0 });
                }
                else if (token is OP op)
                {
                    if (TryAnalyzeOp(ret, i, op, bracketContext.Peek(), previousToken, tokens.ElementAtOrDefault(i + 1), out breakingToken) is BinaryExpression failure0)
                    {
                        failure = failure0;
                        return;
                    }
                }
                else if (token.Text == Constants.RIGHTBRACKET)
                {
                    breakingToken = new BreakingToken(i)
                    {
                        BracketCount = bracketContext.Peek().BracketCount,
                        ContextBracketOrder = bracketContext.Peek().Order,
                        Token = new Token(Constants.RIGHTBRACKET, token.StartCharIndex),
                    };

                    ret[i] = breakingToken;

                    if (bracketContext.Count <= 1)
                    {
                        failure = new BinaryExpression(Errors.MissingOppenningBracket(token));
                        return;
                    }

                    var poppedContext = bracketContext.Pop();

                    poppedContext.BracketToken.EndBracketIndex = i;
                    poppedContext.BracketToken.NextOp = GetNextOp(tokens, i + 1);

                    lowestOpStrength[poppedContext.BracketCount][poppedContext.BracketToken.ContextBracketOrder] = poppedContext.LowestOpStrength;
                }
                else
                {
                    if (TryAnalyzeOperand(ret, tokens, i, token, bracketContext.Peek(), previousToken, out breakingToken) is BinaryExpression failure0)
                    {
                        failure = failure0;
                        return;
                    }
                }

                SetPreviousTokens(ref prePreviousToken, ref previousToken, breakingToken);
            }


            if (bracketContext.Count > 1)
            {
                failure = new BinaryExpression(Errors.MissingClosingBracket(bracketContext.Peek().BracketToken.Token));
                return;
            }

            lowestOpStrength[0][0] = bracketContext.Peek().LowestOpStrength;
        }

        private void SetPreviousTokens(ref BreakingToken? prePreviousToken, ref BreakingToken? previousToken, BreakingToken? current)
        {
            prePreviousToken = previousToken;
            previousToken = current;
        }

        private BinaryExpression? TryAnalyzeBracketOp(BreakingToken[] ret, int i, Token token, int bracketCount, int bracketOrder, BreakingToken? previousToken, BreakingToken? prePreviousToken, out BreakingToken? result)
        {
            if (!(previousToken?.Token is OP) && previousToken?.Token.Text != Constants.LEFTBRACKET && i > 0)
            {
                result = null;
                return new BinaryExpression(Errors.TooManyOperands(token));
            }

            result = new BreakingToken(i)
            {
                BracketCount = bracketCount,
                ContextBracketOrder = bracketOrder,
                Token = token,
                IsMinusLeftBracket = previousToken?.Token?.Text == Constants.SUBTRACT && (prePreviousToken?.Token is OP || prePreviousToken?.Token?.Text == Constants.LEFTBRACKET)
            };

            if (result.IsMinusLeftBracket && previousToken != null)
            {
                previousToken.LookAheadToken = result;
                result.PrePreviousToken = prePreviousToken;
            }

            ret[i] = result;

            return null;
        }

        private BinaryExpression? TryAnalyzeOp(BreakingToken[] ret, int retIndex, OP op, BracketContextInfo bracketContext, BreakingToken? previousToken, Token? nextToken, out BreakingToken result)
        {
            result = new BreakingToken(retIndex)
            {
                BracketCount = bracketContext.BracketCount,
                ContextBracketOrder = bracketContext.BracketToken?.ContextBracketOrder ?? bracketContext.Order,
                Token = op
            };

            ret[retIndex] = result;

            if (op.Text == Constants.SUBTRACT && previousToken?.Operator is OP)
            {
                return null;
            }
            else if (previousToken?.Token is OP || previousToken?.Token.Text == Constants.LEFTBRACKET)
            {
                return new BinaryExpression(Errors.TooManyOperators(op));
            }

            if (bracketContext.LowestOpStrength > op.Strength)
            {
                bracketContext.LowestOpStrength = op.Strength;
            }

            return null;
        }

        private BinaryExpression? TryAnalyzeOperand(BreakingToken[] ret, IEnumerable<Token> tokens, int i, Token token, BracketContextInfo bracketContext, BreakingToken? previousToken, out BreakingToken? result)
        {
            if (previousToken?.Token != null && !(previousToken.Token is OP) && previousToken.Token.Text != Constants.LEFTBRACKET && i > 0)
            {
                result = null;
                return new BinaryExpression(Errors.TooManyOperands(token));
            }

            result = new BreakingToken(i)
            {
                BracketCount = bracketContext.BracketCount,
                ContextBracketOrder = bracketContext.BracketToken?.ContextBracketOrder ?? bracketContext.Order,
                Token = token,
                NextOp = GetNextOp(tokens, i + 1)
            };

            ret[i] = result;

            return null;
        }

        private BreakingToken? GetNextOp(IEnumerable<Token> tokens, int index)
        {
            if (tokens.ElementAtOrDefault(index) is OP op)
            {
                return new BreakingToken(index)
                {
                    TokenIndex = index,
                    Token = op
                };
            }

            return null;
        }

        private bool TryGetContext(IEnumerable<Token> tokens, out BinaryExpression result)
        {
            var stack = new Stack<ExpressionContext>();

            AnalyzeExpression(tokens, out BreakingToken[] breakingOps, out BinaryExpression? failure, out List<List<OPStrength>> opStrengths);

            if (failure != null)
            {
                result = failure;
                return false;
            }

            var ret = new ExpressionContext(0, tokens.Count() - 1)
            {
                BracketCount = 0,
                Index = 0,
                Context = new BinaryExpression(0, tokens.Count() - 1)
                {
                    Strength = opStrengths[0][0],
                }
            };

            stack.Push(ret);

            do
            {
                var pop = stack.Pop();
                OP? opAfterBracket = null;
                OPStrength newOpStrength = 0;
                BinaryExpression? child = null;

                while (true)
                {
                    var skipIndex = SkipContextTo(pop, breakingOps);
                    if (skipIndex == -1)
                    {
                        if (MissingOperandCheck(pop, tokens) is BinaryExpression failure0)
                        {
                            result = failure0;

                            return false;
                        }

                        if (child?.EndIndex < pop.EndIndex - 1 /*last token can be bracket*/)
                        {
                            skipIndex = pop.EndIndex;
                            newOpStrength = pop.Context.Strength + 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    var breakingOp = breakingOps.ElementAtOrDefault(skipIndex);
                    var token = tokens.ElementAt(skipIndex);
                    var tokenText = token.Text;

                    if (tokenText == Constants.LEFTBRACKET && breakingOp != null)
                    {
                        if (breakingOp.IsMinusLeftBracket)
                        {
                            child = new BracketExpression(skipIndex - 1, breakingOp.EndBracketIndex - 1)
                            {
                                Inner = new BinaryExpression(-1, -1)
                                {
                                    Token = new Token("-1", token.StartCharIndex)
                                },
                                Appendix = new AppendixExpression(new OP(Constants.MULTIPLY, token.StartCharIndex), skipIndex)
                                {
                                    Inner = new BracketExpression(skipIndex + 1, breakingOp.EndBracketIndex - 1)
                                    {
                                        Strength = opStrengths[breakingOp.BracketCount + 1][breakingOp.ContextBracketOrder]
                                    }
                                }
                            };
                        }
                        else
                        {
                            child = InitChild<BracketExpression>(pop, skipIndex + 1, breakingOp.EndBracketIndex - 1, opStrengths, breakingOp, addBracketCount: 1);
                        }

                        if (PushBracket(stack, child, pop, breakingOp, token, skipIndex) is BinaryExpression failure0)
                        {
                            result = failure0;
                            return false;
                        }

                        if (!TryPlaceExpression(pop, child, token, opAfterBracket, out failure))
                        {
                            result = failure ?? new BinaryExpression();
                            return false;
                        }

                        opAfterBracket = breakingOp.Operator is OP opTmp && opTmp.Strength == pop.Context.Strength ? opTmp : null;
                    }
                    else if (token is OP op && breakingOp != null)
                    {
                        if (skipIndex == pop.EndIndex)
                        {
                            result = new BinaryExpression(Errors.MissingOperand(token));
                            return false;
                        }

                        child = InitChild<BinaryExpression>(pop, pop.Index, skipIndex - 1, opStrengths, breakingOp);

                        PushChild(stack, child, pop.Index, skipIndex - 1, pop.BracketCount);

                        if (!TryPlaceExpression(pop, child, op, opAfterBracket, out failure))
                        {
                            result = failure ?? new BinaryExpression();
                            return false;
                        }
                    }
                    else if (skipIndex == pop.EndIndex && newOpStrength == 0)
                    {
                        child = new BinaryExpression(pop.Index, pop.EndIndex)
                        {
                            Token = token,
                            Strength = pop.Context.Strength
                        };

                        if (!TryPlaceExpression(pop, child, token, opAfterBracket, out failure))
                        {
                            result = failure ?? new BinaryExpression();
                            return false;
                        }

                        break;
                    }
                    else
                    {
                        child = InitChild<BinaryExpression>(pop.Index, skipIndex, newOpStrength);

                        PushChild(stack, child, pop.Index, skipIndex, pop.BracketCount);

                        if (!TryPlaceExpression(pop, child, token, opAfterBracket, out failure))
                        {
                            result = failure ?? new BinaryExpression();
                            return false;
                        }
                    }

                    pop.Index = breakingOp != null && breakingOp.EndBracketIndex != -1 ? (breakingOp.EndBracketIndex + 1) : (skipIndex + 1);
                }
            } while (stack.Count > 0);

            result = ret.Context;

            return true;
        }

        private BinaryExpression? MissingOperandCheck(ExpressionContext pop, IEnumerable<Token> tokens)
        {
            if (pop.Context.Inner == null && pop.Context.Token == null)
            {
                return new BinaryExpression(Errors.MissingOperand(tokens.ElementAt(pop.Index)));
            }

            return null;
        }

        private int SkipContextTo(ExpressionContext context, BreakingToken[] indexes, int lookAhead = 0)
        {
            while (true)
            {
                OP? previousOp = null;
                var weakestStrongerOp = new OP(string.Empty, Constants.HighestOPStrength + 1);
                var i = context.Index + lookAhead;
                for (; i <= context.EndIndex; i++)
                {
                    if (indexes.ElementAt(i) is BreakingToken op)
                    {
                        if (op.Token?.Text == Constants.LEFTBRACKET)
                        {
                            if (op.BracketCount == context.BracketCount)
                            {
                                if ((op.NextOp == null || op.NextOp.TokenIndex > context.EndIndex) && (previousOp == null || previousOp.Strength == context.Context.Strength))
                                {// including minus bracket
                                    return i;
                                }
                                else if (op.NextOp != null && op?.NextOp?.Operator?.Strength == context.Context.Strength && op.NextOp.TokenIndex <= context.EndIndex)
                                {
                                    return op.EndBracketIndex + 1;
                                }
                            }

                            i = op?.EndBracketIndex ?? -1;
                        }
                        else if (op.BracketCount == context.BracketCount)
                        {
                            if (op.LookAheadToken is BreakingToken minusBracket && minusBracket.PrePreviousToken?.Operator is OP)
                            {//no setting of previous op => minus bracket can be solved
                                continue;
                            }
                            else if (op.Operator == null && op.NextOp == null && previousOp == null || op.NextOp != null && op.NextOp.TokenIndex > context.EndIndex && (previousOp == null || previousOp.Strength == context.Context.Strength) || op.Operator != null && op.Operator.Strength == context.Context.Strength)
                            {
                                return i;
                            }
                        }

                        previousOp = op?.Operator ?? previousOp;

                        if (previousOp != null && previousOp.Strength < weakestStrongerOp.Strength)
                        {
                            weakestStrongerOp = previousOp;
                        }
                    }
                }

                if (context.StartIndex == context.Index && context.Context.Strength < weakestStrongerOp.Strength)
                {
                    context.Context.Strength = weakestStrongerOp.Strength;
                }
                else
                {
                    break;
                }
            }

            return -1;
        }

        private BinaryExpression InitChild<TChild>(ExpressionContext pop, int startIndex, int endIndex, List<List<OPStrength>> opStrengths, BreakingToken breakingOp, int addBracketCount = 0) where TChild : BinaryExpression, new()
        {
            var child = new TChild()
            {
                StartIndex = startIndex,
                EndIndex = endIndex,
                Strength = (typeof(TChild) == typeof(BracketExpression) ? opStrengths[breakingOp.BracketCount + addBracketCount][breakingOp.ContextBracketOrder] : pop.Context.Strength)
            };

            return child;
        }

        private BinaryExpression InitChild<TChild>(int startIndex, int endIndex, OPStrength newStrength) where TChild : BinaryExpression, new()
        {
            var child = new TChild()
            {
                StartIndex = startIndex,
                EndIndex = endIndex,
                Strength = newStrength
            };

            return child;
        }

        private void PushChild(Stack<ExpressionContext> stack, BinaryExpression child, int startIndex, int endIndex, int bracketCount)
        {
            stack.Push(new ExpressionContext(startIndex, endIndex)
            {
                BracketCount = bracketCount,
                Context = child,
                Index = startIndex
            });
        }

        private BinaryExpression? PushBracket(Stack<ExpressionContext> stack, BinaryExpression child, ExpressionContext pop, BreakingToken breakingOp, Token token, int tokenIndex)
        {
            if (tokenIndex + 1 == breakingOp.EndBracketIndex)
            {
                return new BinaryExpression(Errors.MissingOperand(token));
            }

            stack.Push(new ExpressionContext(tokenIndex + 1, breakingOp.EndBracketIndex - 1)
            {
                BracketCount = pop.BracketCount + 1,
                Context = child,
                Index = tokenIndex + 1
            });

            return null;
        }

        private bool TryPlaceExpression(ExpressionContext pop, BinaryExpression child, Token currentToken, OP? opAfterBracket, out BinaryExpression? failure)
        {
            var context = pop.Context;

            while (true)
            {

                if (context != null && context.Inner == null && context.Token == null && (context.Appendix == null || context.Appendix.StartIndex > child.EndIndex))
                {
                    context.Inner = child;

                    if (context.Appendix != null)
                    {
                        context = context.Inner;
                    }

                    if (!TryPlaceOp(context, opAfterBracket ?? currentToken, child, false, out failure))
                    {
                        return false;
                    }

                    break;
                }
                else if (context != null && context.Appendix == null)
                {
                    if (!TryPlaceOp(context, opAfterBracket ?? currentToken, child, true, out failure))
                    {
                        return false;
                    }

                    break;
                }
                else if (context != null && context.Appendix?.StartIndex > child.EndIndex)
                {
                    context = context.Inner;
                }
                else if (context?.Appendix != null && context.Appendix.Inner == null)
                {
                    context.Appendix.Inner = child;

                    if (!TryPlaceOp(context.Appendix.Inner, opAfterBracket ?? currentToken, child, false, out failure))
                    {
                        return false;
                    }

                    break;
                }
                else
                {
                    context = context?.Appendix?.Inner;
                }
            }

            failure = null;

            return true;
        }

        private bool TryPlaceOp(BinaryExpression context, Token currentToken, BinaryExpression child, bool childIsRightSide, out BinaryExpression? failure)
        {
            failure = null;

            if (currentToken is OP op)
            {
                if (context.Appendix != null)
                {
                    failure = new BinaryExpression(Errors.TooManyOperators(currentToken));

                    return false;
                }

                context.Appendix = new AppendixExpression(op, childIsRightSide ? child.StartIndex : child.EndIndex + 2)
                {
                    Inner = childIsRightSide ? child : null
                };
            }
            else if (childIsRightSide)
            {
                failure = new BinaryExpression(Errors.TooManyOperands(currentToken));

                return false;
            }

            return true;
        }

        private OP CloneOP(OP orig, int startIndex)
        {
            var ret = (OP)orig.Clone();
            ret.StartCharIndex = startIndex;

            return ret;
        }
    }
}
