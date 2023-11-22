using System.Globalization;

namespace KLO128.Calculator.Domain.Services
{
    public interface ICultureDomainService
    {
        CultureInfo GetCultureInfo(string culture);
    }
}
