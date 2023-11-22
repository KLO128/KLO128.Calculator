using KLO128.Calculator.Domain.Models.Entities;

namespace KLO128.Calculator.Domain.Services
{
    public interface ICryptoDomainService
    {
        string GetNewAccessToken(CalcHistory calcHistory);
    }
}
