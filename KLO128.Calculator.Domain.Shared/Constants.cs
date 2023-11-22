using KLO128.Calculator.Domain.Shared.Models;
using System.Globalization;

namespace KLO128.Calculator.Domain.Shared
{
    public static class Constants
    {
        public const string DefaultCulture = "en-US";
        public static Dictionary<string, CultureInfo> AllCultures { get; } = CultureInfo.GetCultures(CultureTypes.AllCultures).ToDictionary(x => x.Name);

        public const string AND = "&";
        public const string OR = "|";

        public const string ADD = "+";
        public const string SUBTRACT = "-";

        public const char chADD = '+';
        public const char chSUBTRACT = '-';

        public const string MULTIPLY = "*";
        public const string DIVIDE = "/";
        public const string MODULO = "%";

        public const string POWER = "^";
        public const string SQRT = "_";

        public const string EQUALS = "=";
        public const string LowerThan = "<";
        public const string GreaterThan = ">";
        public const string LowerThanOrEquals = "<=";
        public const string GreaterThanOrEquals = ">=";
        public const char chLowerThan = '<';
        public const char chGreaterThan = '>';
        public const char chEQUALS = '=';

        public const string LEFTBRACKET = "(";
        public const string RIGHTBRACKET = ")";
        public const char chLEFTBRACKET = '(';
        public const char chRIGHTBRACKET = ')';

        public const string NaN = "NaN";

        public const char WS = ' ';

        public static char[] NumberSeparators { get; } = new char[] { '.', ',' };

        public static Dictionary<string, OP> Operators { get; set; } = new Dictionary<string, OP>()
        {
            {
                OR, new OP(OR, OPStrength.LogicalOR)
            },
            {
                AND, new OP(AND, OPStrength.LogicalAnd)
            },
            {
                EQUALS, new OP(EQUALS, OPStrength.Comparison)
            },
            {
                LowerThan, new OP(LowerThan, OPStrength.Comparison)
            },
            {
                GreaterThan, new OP(GreaterThan, OPStrength.Comparison)
            },
            {
                LowerThanOrEquals, new OP(LowerThanOrEquals, OPStrength.Comparison)
            },
            {
                GreaterThanOrEquals, new OP(GreaterThanOrEquals, OPStrength.Comparison)
            },
            {
                ADD, new OP(ADD, OPStrength.Add)
            },
            {
                SUBTRACT, new OP(SUBTRACT, OPStrength.Add)
            },
            {
                MULTIPLY, new OP(MULTIPLY, OPStrength.Multiple)
            },
            {
                DIVIDE, new OP(DIVIDE, OPStrength.Multiple)
            },
            {
                MODULO, new OP(MODULO, OPStrength.Multiple)
            },
            {
                POWER, new OP(POWER, OPStrength.Power)
            },
            {
                SQRT, new OP(SQRT, OPStrength.Power)
            }
        };

        public const int ExpressionChainHash = -2;

        public const OPStrength HighestOPStrength = OPStrength.Power;

        public static class AppSettingKeys
        {
            public const string DefaultCulture = "DefaultCulture";
            public const string DefaultConnectionString = "Default";
            public const string LogFolder = "LogFolder";
            public const string CookiesExpirationDays = "CookiesExpirationDays";

        }

        public static class WebApi
        {
            public const string AccessToken = "accessToken";
            public const string CookieExpiration = "expiration";
        }
    }
}
