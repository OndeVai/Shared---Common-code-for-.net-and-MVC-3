namespace Shared
{
    public static class BoolExtensions
    {
        public static string ToYesNoString(this bool input)
        {
            return input ? "Yes" : "No";
        }
    }
}