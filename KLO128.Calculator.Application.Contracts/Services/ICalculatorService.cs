using KLO128.Calculator.Application.Contracts.DTOs.Results;

namespace KLO128.Calculator.Application.Contracts.Services
{
    public interface ICalculatorService
    {
        ServiceResult<ComputeResult> GetComputeResult(string? accessToken, string expression, string culture, bool useSeparators);

        ServiceResult<PrettyPrintResult> PrettyPrint(string expression, bool normalize, string culture, string? expressionResult = null, bool useSeparators = false);
    }
}
