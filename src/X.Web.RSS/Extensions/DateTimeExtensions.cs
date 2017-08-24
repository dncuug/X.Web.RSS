using System;

namespace X.Web.RSS.Extensions
{
    public static class DateTimeExtensions
    {
        ///<summary>
        /// Converts a regular DateTime to a RFC822 date string.
        ///</summary>
        ///<returns>The specified date formatted as a RFC822 date string.</returns>
        public static string ToRFC822Date(this DateTime date)
        {
            var utcOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            var offset = utcOffset.Hours;
            var timeZone = "+" + offset.ToString().PadLeft(2, '0');

            if (offset < 0)
            {
                int i = offset * -1;
                timeZone = "-" + i.ToString().PadLeft(2, '0');
            }

            var result = date.ToString("ddd, dd MMM yyyy HH:mm:ss " + timeZone.PadRight(5, '0'));
            return result;
        }
    }
}