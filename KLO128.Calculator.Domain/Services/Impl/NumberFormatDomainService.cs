using System.Globalization;
using System.Text;

namespace KLO128.Calculator.Domain.Services.Impl
{
    public class NumberFormatDomainService : INumberFormatDomainService
    {
        private static readonly char[] thousandSeparators = new char[] { ' ', ',' };
        private static readonly char[] decimalPoints = new char[] { ',', '.' };

        public string Stringify(double d, CultureInfo cultureInfo, bool useThousandSeparator)
        {
            var str = d.ToString(CultureInfo.InvariantCulture);
            var hasFloatingPoint = str.Contains('.');
            var floatingPoint = cultureInfo.NumberFormat.NumberDecimalSeparator;
            var thousandSeparator = cultureInfo.NumberFormat.NumberGroupSeparator;
            var reachedFloatingPoint = false;
            var j = 0;
            var sb = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--, j++)
            {
                var ch = str[i];
                if (ch == '.')
                {
                    reachedFloatingPoint = true;
                    j = -1;
                    sb.Insert(0, floatingPoint);
                }
                else if (ch == '-')
                {
                    //if (sb[0] == thousandSeparator[0])
                    //{
                    //    sb.Remove(0, 1);
                    //}

                    sb.Insert(0, ch);
                }
                else if (useThousandSeparator && j > 0 && j % 3 == 0 && (!hasFloatingPoint || reachedFloatingPoint))
                {
                    sb.Insert(0, thousandSeparator);
                    sb.Insert(0, ch);
                }
                else
                {
                    sb.Insert(0, ch);
                }
            }

            return sb.ToString();
        }

        public bool TryParseNumber(string str, CultureInfo culture, out double d)
        {
            return double.TryParse(str, NumberStyles.Any, culture.NumberFormat, out d) || double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out d);
        }

        public bool ValidateNumber(string str)
        {
            var digitsInRow = 0;
            var thousandSeparator = '\0';
            var thousandSeparatorUsage = 0;
            var decimalPoint = '\0';
            for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                if (char.IsDigit(ch))
                {
                    digitsInRow++;

                    if (digitsInRow > 3)
                    {
                        thousandSeparatorUsage = -1;
                    }
                }
                else if (ch == '-' && i == 0)
                {
                    continue;
                }
                else if (i == 0)
                {
                    return false;
                }
                else
                {
                    if (thousandSeparatorUsage == 0 && thousandSeparators.Contains(ch))
                    {
                        if (str.Length <= i + 4)
                        {
                            if (decimalPoint != '\0')
                            {
                                return false;
                            }

                            return true;
                        }

                        var lookAhead = str.ElementAtOrDefault(i + 4);

                        if (char.IsDigit(lookAhead))
                        {
                            if (!CanUseDecimal(ref decimalPoint, null, ch, ref thousandSeparator, ref thousandSeparatorUsage))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (ch == lookAhead)
                            {
                                thousandSeparator = ch;
                                thousandSeparatorUsage++;
                            }
                            else if (!CanUseDecimal(ref decimalPoint, ch, lookAhead, ref thousandSeparator, ref thousandSeparatorUsage))
                            {
                                return false;
                            }
                        }

                        for (int j = i + 1; j < i + 4; j++)
                        {
                            if (!char.IsDigit(str[j]))
                            {
                                return false;
                            }
                        }

                        i += 4;
                    }
                    else if (thousandSeparatorUsage == -1 || thousandSeparator != ch || digitsInRow < 3)
                    {
                        if (!CanUseDecimal(ref decimalPoint, null, ch, ref thousandSeparator, ref thousandSeparatorUsage))
                        {
                            return false;
                        }
                    }
                    else if (thousandSeparator == ch && digitsInRow != 3)
                    {
                        return false;
                    }

                    digitsInRow = 0;
                }
            }

            return true;
        }

        private static bool CanUseDecimal(ref char decimalPoint, char? chThousands, char chDecimal, ref char thousandSeparator, ref int thousandSeparatorUsage)
        {
            if (decimalPoint == '\0')
            {
                if (decimalPoints.Contains(chDecimal))
                {
                    if ((chThousands ?? null) != null)
                    {
                        thousandSeparator = chThousands ?? '\0';
                    }

                    thousandSeparatorUsage++;
                    decimalPoint = chDecimal;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
