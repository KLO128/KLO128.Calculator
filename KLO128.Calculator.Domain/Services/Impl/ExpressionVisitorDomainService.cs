using KLO128.Calculator.Domain.Shared;
using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;

namespace KLO128.Calculator.Domain.Services.Impl
{
    public class ExpressionVisitorDomainService : IExpressionVisitorDomainService
    {
        public ExpressionContextTree DispatchExpression(AppendixExpression? expression)
        {
            var ret = new ExpressionContextTree(expression);

            if (expression?.Inner == null)
            {
                return ret;
            }

            ret.AddSister(expression.Operator);

            ExpressionContextTree inner;

            bool addSister;

            if (expression.Inner is BracketExpression)
            {
                inner = DispatchExpression(expression.Inner);
                addSister = false;
            }
            else if (expression.Inner.Appendix == null || (expression.Inner.Appendix != null && expression.Inner.Appendix.Strength > expression.Strength))
            {
                inner = DispatchExpression(expression.Inner);
                addSister = expression.Inner.Strength == expression.Strength;
            }
            else
            {
                inner = new ExpressionContextTree(expression.Inner);
                var inner0 = DispatchExpression(expression.Inner?.Inner);
                var appendix = DispatchExpression(expression.Inner?.Appendix);

                if (expression.Inner?.Inner is BracketExpression || expression.Inner?.Inner?.Strength > expression.Inner?.Appendix?.Strength)
                {
                    inner.AddChild(inner0);
                    inner.AddSister(appendix);
                }
                else
                {
                    inner.AddSister(inner0);
                    inner.AddSister(appendix);
                }

                addSister = true;
            }

            if (inner.IsEmpty())
            {
                return new ExpressionContextTree(Errors.MissingOperand(expression.Operator));
            }
            else if (!addSister)
            {
                ret.AddChild(inner);
            }
            else
            {
                ret.AddSister(inner);
            }

            return ret;
        }

        public ExpressionContextTree DispatchExpression(BinaryExpression? expression)
        {
            var ret = new ExpressionContextTree(expression);

            if (expression?.Token != null)
            {
                if (expression.Token is OP)
                {
                    if (expression.Token.StartCharIndex == 0)
                    {
                        return new ExpressionContextTree(Errors.CannotStartWithOP(expression.Token));
                    }

                    return new ExpressionContextTree(Errors.TooManyOperators(expression.Token));
                }

                ret.AddSister(expression.Token);

                return ret;
            }
            else if (expression?.Inner != null)
            {
                var inner = DispatchExpression(expression.Inner);

                if (inner.Warning != null)
                {
                    return inner;
                }

                if (expression.Inner is BracketExpression || (inner.Children.Count > 1 && expression.Inner.Strength > expression.Strength))
                {
                    ret.AddChild(inner);
                }
                else
                {
                    ret.AddSister(inner);
                }
            }

            if (expression?.Appendix != null)
            {
                var appendix = DispatchExpression(expression.Appendix);

                if (appendix.Warning != null)
                {
                    return appendix;
                }
                else if (appendix.IsEmpty())
                {
                    return ret;
                }
                else if (appendix.Children.FirstOrDefault()?.Token is OP)
                {
                    ret.AddSister(appendix);
                }
                else
                {
                    return new ExpressionContextTree(Errors.TooManyOperands(ret.FirstToken()));
                }
            }

            return ret;
        }
    }
}
