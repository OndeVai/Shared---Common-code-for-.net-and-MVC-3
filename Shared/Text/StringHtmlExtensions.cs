#region



#endregion

namespace Shared.Text
{
    public static class StringExtensionsHtml
    {
        public static string StripHtml(this string thisString)
        {
            return TextUtility.StripHtml(thisString);
        }
    }
}