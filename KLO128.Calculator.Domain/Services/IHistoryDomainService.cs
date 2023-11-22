using KLO128.Calculator.Domain.Models.Entities;

namespace KLO128.Calculator.Domain.Services
{
    public interface IHistoryDomainService
    {
        CalcHistory? GetCalcHistory(string? accessToken, bool includeEntries);
    }
}
