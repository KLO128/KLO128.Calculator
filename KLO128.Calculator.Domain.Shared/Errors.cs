using KLO128.Calculator.Domain.Shared.Models;

namespace KLO128.Calculator.Domain.Shared
{
    public static class Errors
    {
        public static Warning CouldNotFindCulture(string culture)
        {
            return new Warning(nameof(Translations.exp001), culture);
        }

        public static Warning CannotStartWithOP(Token? token)
        {
            return new Warning(nameof(Translations.exp002), token?.Text ?? string.Empty);
        }

        public static Warning TooManyOperands()
        {
            return new Warning(nameof(Translations.exp003));
        }

        public static Warning InvalidNumber(Token? token)
        {
            return new Warning(nameof(Translations.exp004), token?.Text ?? string.Empty, token?.StartCharIndex.ToString() ?? string.Empty);
        }

        public static Warning NotSupportedOperation(Token? token)
        {
            return new Warning(nameof(Translations.exp005), Translations.exp005, token?.Text ?? string.Empty, token?.StartCharIndex.ToString() ?? string.Empty);
        }

        public static Warning TooManyOperands(Token? token)
        {
            return new Warning(nameof(Translations.exp006), token?.Text ?? string.Empty, token?.StartCharIndex.ToString() ?? string.Empty);
        }

        public static Warning UnexpectedSymbol(Token? token)
        {
            return new Warning(nameof(Translations.exp007), token?.Text ?? string.Empty, token?.StartCharIndex.ToString() ?? string.Empty);
        }

        public static Warning MissingOperand(Token? token)
        {
            return new Warning(nameof(Translations.exp008), (token?.StartCharIndex + (token?.Text ?? string.Empty).Length).ToString() ?? string.Empty);
        }

        public static Warning MissingClosingBracket(Token? token)
        {
            return new Warning(nameof(Translations.exp009), token?.StartCharIndex.ToString() ?? string.Empty);
        }

        public static Warning TooManyOperators(Token? token)
        {
            return new Warning(nameof(Translations.exp010), token?.StartCharIndex.ToString() ?? string.Empty, token?.Text ?? string.Empty);
        }

        public static Warning MissingOppenningBracket(Token? token)
        {
            return new Warning(nameof(Translations.exp011), token?.StartCharIndex.ToString() ?? string.Empty);
        }
    }
}
