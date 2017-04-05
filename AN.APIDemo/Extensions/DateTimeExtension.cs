using System;

namespace AN.APIDemo
{
	public static class DateTimeExtension
	{
		public static readonly DateTime UNIX_EPOC = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		/// <summary>
		/// Converted date time instance into Unix timestamp.
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static long ToUnixTimestamp(this DateTime dt)
		{
			DateTime utcVal;

			if (dt.Kind == DateTimeKind.Utc)
			{
				utcVal = dt;
			}
			else
			{
				utcVal = dt.ToUniversalTime();
			}

			var diff = utcVal - UNIX_EPOC;

			return Convert.ToInt64(diff.TotalSeconds);
		}
	}
}