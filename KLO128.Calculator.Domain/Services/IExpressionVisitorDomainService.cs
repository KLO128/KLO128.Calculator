using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;

namespace KLO128.Calculator.Domain.Services
{
    public interface IExpressionVisitorDomainService
    {
        ExpressionContextTree DispatchExpression(AppendixExpression? expression);

        ExpressionContextTree DispatchExpression(BinaryExpression expression);
    }
}
