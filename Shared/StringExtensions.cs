#region

using System;

#endregion

namespace Shared
{
    public static class StringExtensions
    {
        public static bool EqualsOrdinal(this string value, string compare)
        {
            return value.Equals(compare, StringComparison.Ordinal);
        }

        public static bool EqualsOrdinalIgnorCase(this string value, string compare)
        {
            return value.Equals(compare, StringComparison.OrdinalIgnoreCase);
        }
    }
}