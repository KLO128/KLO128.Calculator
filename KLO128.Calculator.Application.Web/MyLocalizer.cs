using KLO128.Calculator.Domain.Shared;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Resources;

namespace KLO128.Calculator.Application.Web
{
    public class MyLocalizer : IStringLocalizer
    {
        private ResourceManager ResourceManager { get; }

        private string DefaultCultureString { get; }

        public MyLocalizer(ResourceManager resourceManager, string defaultCultureString)
        {
            ResourceManager = resourceManager;
            DefaultCultureString = defaultCultureString;
        }

        private CultureInfo? culture;
        private string? cultureStr;

        public string CultureString
        {
            get
            {
                if (cultureStr == null)
                {
                    cultureStr = CultureInfo.DefaultThreadCurrentUICulture?.Name ?? DefaultCultureString;
                }

                return cultureStr;
            }
            set
            {
                if (Constants.AllCultures.ContainsKey(value))
                {
                    cultureStr = value;
                    Culture = new CultureInfo(value);
                }
            }
        }

        protected CultureInfo Culture
        {
            get
            {
                return culture ?? CultureInfo.DefaultThreadCurrentUICulture ?? new CultureInfo(DefaultCultureString);
            }
            set
            {
                culture = value;
            }
        }

        public LocalizedString this[string name]
        {
            get
            {
                return new LocalizedString(name, ResourceManager.GetString(name, Culture) ?? string.Empty);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                return new LocalizedString(name, string.Format(ResourceManager.GetString(name, Culture) ?? string.Empty, arguments));
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotSupportedException();
        }
    }
}
