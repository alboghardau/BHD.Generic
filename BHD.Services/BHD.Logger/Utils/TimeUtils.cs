using System;
namespace BHD.Logger.Utils.Writers
{
	public static class TimeUtils
	{
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts DateTime to Unix Timestamp
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns></returns>
        public static long ConvertToUnixTimestamp(DateTime dateTime)
        {
            TimeSpan timeSpan = dateTime.ToUniversalTime() - UnixEpoch;
            return (long)timeSpan.TotalSeconds;
        }

        /// <summary>
        /// Converts Unix Timestamp to DateTime
        /// </summary>
        /// <param name="unixTimestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertFromUnixTimestamp(long unixTimestamp)
        {
            DateTime dateTime = UnixEpoch.AddSeconds(unixTimestamp);
            return dateTime.ToLocalTime();
        }
    }
}