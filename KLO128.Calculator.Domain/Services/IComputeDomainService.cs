using KLO128.Calculator.Domain.Shared.Models;

namespace KLO128.Calculator.Domain.Services
{
    public interface IComputeDomainService
    {
        Warning? TryCompute(string expression, string culture, out double result);

        string PrettyPrint(string? expression, string culture, bool useThousandSeparator, bool throwError = true);

        string PrintNormalized(string? expression, string originalCulture, bool throwError = true);
    }
}
