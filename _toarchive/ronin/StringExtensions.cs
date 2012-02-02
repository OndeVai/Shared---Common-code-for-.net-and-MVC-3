#region

using ronin.Text;

#endregion

namespace ronin
{
    public static class StringExtensions
    {
        public static string ToLowerTrim(this string s)
        {
            return TextUtility.ToLowerTrim(s);
        }

        //public static string StripSpecialChars(this string s)
        //{
        //    return TextUtility.StripSpecialChars(ToLowerTrim(s));
        //}

        public static string StripWhitespaceAndSpecialChars(this string s, string replaceWhitespace)
        {
            return TextUtility.StripWhitespaceAndSpecialChars(ToLowerTrim(s), replaceWhitespace);
        }

        public static string ToAbbreviated(this string thisString, int len, string append)
        {
            return TextUtility.GetAbbreviated(thisString, len, append);
        }

        public static string ToUppercaseFirst(this string s)
        {
            return TextUtility.ToUppercaseFirst(s);
        }
    }
}