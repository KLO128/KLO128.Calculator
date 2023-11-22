using KLO128.Calculator.Domain.Shared;
using System.Globalization;

namespace KLO128.Calculator.Domain.Services.Impl
{
    public class CultureDomainService : ICultureDomainService
    {
        public CultureDomainService()
        {
        }

        public CultureInfo GetCultureInfo(string culture)
        {
            if (!Constants.AllCultures.ContainsKey(culture))
            {
                throw Errors.CouldNotFindCulture(culture);
            }

            return Constants.AllCultures[culture];
        }
    }
}
