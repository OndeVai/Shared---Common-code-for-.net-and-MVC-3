#region

using System;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace Shared.Text
{
    internal static class TextUtility
    {
        const string HTML_TAG_PATTERN = "<(.|\n)+?>";

        public static string StripHtml(string inputString)
        {
            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
        }

        public static string ToLowerTrim(string input)
        {
            return input != null ? input.Trim().ToLower() : string.Empty;
        }

        public static string StripWhitespaceAndSpecialChars(string input, string replaceWhitespace)
        {
            if (input == null) return string.Empty;

            const string regexStr = @"[^\w ]";
            var r = new Regex(regexStr, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(input, string.Empty).Replace(@" ", replaceWhitespace);
        }

        public static string GetAbbreviated(string thisString, int len, string append)
        {
            if (string.IsNullOrWhiteSpace(thisString)) return string.Empty;

            if (thisString.Length > len)
            {
                var detailFragment = thisString.Substring(0, len);
                var lastSpaceIndex = detailFragment.LastIndexOf(" ");
                var sb = new StringBuilder();
                sb.Append(lastSpaceIndex > 0 ? detailFragment.Substring(0, lastSpaceIndex) : detailFragment).Append(
                    append);

                return sb.ToString();
            }
            return thisString;
        }

        public static string ToUppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            var a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        /// <summary>
        ///   Generates a random string with the given length
        /// </summary>
        /// <param name = "size">Size of the string</param>
        /// <param name = "lowerCase">If true, generate lowercase string</param>
        /// <returns>Random string</returns>
        public static string RandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}