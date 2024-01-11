using System.Globalization;
using System.Text.RegularExpressions;

namespace FiyiStack.Library.NET
{
    public static class Validator
    {
        public static bool IsInt(string IntegerInStringFormat)
        {
            return int.TryParse(IntegerInStringFormat, out _);
        }

        public static bool IsDecimal(string DecimalInStringFormat)
        {
            return decimal.TryParse(DecimalInStringFormat, out _);
        }

        public static bool IsDateTime(string DateTimeInStringFormat)
        {
            return DateTime.TryParseExact(DateTimeInStringFormat, "MM'/'dd'/'yyyy hh':'mm':'ss'.'fff", new CultureInfo("en-US"), DateTimeStyles.None,  out _);
        }

        public static bool IsTimeSpan(string TimeSpanInStringFormat)
        {
            return TimeSpan.TryParse(TimeSpanInStringFormat, out _);
        }

        /// <summary>
        /// Options <br />
        /// 1. Accept a to z, A to Z, 0 to 9 and the symbols . _ - : @"^[a-zA-Z0-9._-]+$"
        /// </summary>
        /// <param name="StringToAnalyze"></param>
        /// <param name="Pattern"></param>
        /// <returns></returns>
        public static bool IsRegexOk(string StringToAnalyze, string Pattern)
        {
            try
            {
                Regex rgx = new Regex(Pattern);

                if (!rgx.IsMatch(StringToAnalyze)) { return false; }
                else { return true; }
            }
            catch (Exception) { throw; }
        }

        public static bool IsHexColour(string HexColourInStringFormat)
        {
            try
            {
                if (HexColourInStringFormat.Length > 6) { return false; }
                return IsRegexOk(HexColourInStringFormat, @"^[a-fA-F0-9]+$");
            }
            catch (Exception) { throw; }
        }

        public static bool IsEmail(string Mail, int TotalMaximumLength = 320, int UserNameMaximumLength = 64, int DomainNameMaximumLength = 255)
        {
            try
            {
                if (Mail.Contains("@") && Mail.Contains("."))
                {
                    if (Mail.Length > TotalMaximumLength) { return false; } //Mail too long
                    string username = Mail.Substring(0, Mail.IndexOf("@"));
                    string domainname = Mail.Substring(Mail.IndexOf("@") + 1); //+1 to not include @
                    if (username.Length > UserNameMaximumLength) { return false; } //UserName too long
                    if (domainname.Length > DomainNameMaximumLength) { return false; } //DomainName too long
                    
                    return true;
                }
                else { return false; }  //Seems that it's not a mail
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Returns 'A' if StringA is greater than String B and viceversa <br/>
        /// Returns 'E' if StringA is equal to StringB <br/>
        /// Returns '\0' if the strings have different length while <c>EqualLength = true</c> <br/>
        /// </summary>
        /// <param name="StringA"></param>
        /// <param name="StringB"></param>
        /// <param name="EqualLength"></param>
        /// <returns></returns>
        public static char CompareStrings(string StringA, string StringB, bool EqualLength = false)
        {
            try
            {
                if (EqualLength && (StringA.Length != StringB.Length))
                { return '\0'; }

                char Result = char.MinValue;
                int Indicator = StringA.CompareTo(StringB);
                if (Indicator == 0)
                {
                    return 'E';
                }
                else if (Indicator == 1)
                {
                    return 'A';
                }
                else if (Indicator == -1)
                {
                    return 'B';
                }
                return Result;
            }
            catch (Exception) { throw; }
        }
    }
}
