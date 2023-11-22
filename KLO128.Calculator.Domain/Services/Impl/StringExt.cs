using System.Globalization;

namespace KLO128.Calculator.Domain.Services.Impl
{
    public static class StringExt
    {
        public static string AsNumberString(this double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
