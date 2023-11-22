using KLO128.Calculator.Application.Contracts.DTOs.Results;

namespace KLO128.Calculator.Application.Contracts.Services
{
    public interface IHistoryService
    {
        ServiceResult<CalcHistoryResult> GetCalcHistory(string? accessToken, string culture, bool useSeparator);
    }
}
