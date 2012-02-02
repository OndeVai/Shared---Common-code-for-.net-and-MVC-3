#region

using System;

#endregion

namespace Shared
{
    public static class DateTimeExtensions
    {
        /// <summary>
        ///   First tick of the day.
        /// </summary>
        /// <param name = "date">The date.</param>
        /// <returns></returns>
        public static DateTime DayMin(this DateTime date)
        {
            return date.Date; // minimum of this day
        }

        /// <summary>
        ///   Last tick of the day.
        /// </summary>
        /// <param name = "date">The date.</param>
        /// <returns></returns>
        public static DateTime DayMax(this DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1); // last tick of this day
        }
    }
}