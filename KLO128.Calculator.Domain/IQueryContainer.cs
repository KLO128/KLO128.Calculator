using KLO128.Calculator.Domain.Models.Entities;
using KLO128.D3ORM.Common.Abstract;

namespace KLO128.Calculator.Domain
{
    public interface IQueryContainer
    {
        ISpecificationWithParams<CalcHistory> GetCalcHistoryByAccessToken(string accessToken, bool includeDependencies);
    }
}
