#region

using System;
using Shared.Text;

#endregion

namespace Shared
{
    public static class StringExtensions
    {
        public static bool EqualsOrdinal(this string value, string compare)
        {
            return value.Equals(compare, StringComparison.Ordinal);
        }

        public static bool EqualsOrdinalIgnoreCase(this string value, string compare)
        {
            return value.Equals(compare, StringComparison.OrdinalIgnoreCase);
        }

        public static string ToLowerTrim(this string s)
        {
            return TextUtility.ToLowerTrim(s);
        }

        public static string StripWhitespaceAndSpecialChars(this string s, string replaceWhitespace)
        {
            return TextUtility.StripWhitespaceAndSpecialChars(ToLowerTrim(s), replaceWhitespace);
        }

        public static string ToAbbreviated(this string thisString, int len, string append = "...")
        {
            return TextUtility.GetAbbreviated(thisString, len, append);
        }

        public static string ToUppercaseFirst(this string s)
        {
            return TextUtility.ToUppercaseFirst(s);
        }
    }
}