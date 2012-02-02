#region

using ronin.Text;

#endregion

namespace ronin
{
    public static class StringExtensionsHtml
    {
        public static string StripHtml(this string thisString)
        {
            return TextUtility.StripHtml(thisString);
        }
    }
}