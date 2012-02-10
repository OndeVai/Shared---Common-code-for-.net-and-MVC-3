#region

using System;

#endregion

namespace Shared
{
    public static class DoubleExtensions
    {
        public static bool EqualsWithinEpsilon(this double target, double compare)
        {
            return Math.Abs(target - compare) < double.Epsilon;
        }
    }
}