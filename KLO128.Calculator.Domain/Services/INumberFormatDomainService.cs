using System.Globalization;

namespace KLO128.Calculator.Domain.Services
{
    public interface INumberFormatDomainService
    {
        string Stringify(double d, CultureInfo cultureInfo, bool useThousandSeparator);

        bool TryParseNumber(string str, CultureInfo culture, out double d);

        bool ValidateNumber(string str);
    }
}
