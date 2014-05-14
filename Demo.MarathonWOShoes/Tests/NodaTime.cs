using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaTime;
using NodaTime.TimeZones;

namespace Tests
{
	[TestClass]
	public class NodaTime
	{

		[TestMethod]
		public void TestInstant()
		{
			var now = SystemClock.Instance.Now;
			Console.WriteLine(now.Ticks); // 14001007108796083
		}

		[TestMethod]
		public void TestLocalDateTime()
		{
			var birthday = new LocalDate(1983, 04, 19);
			var noon = new LocalTime(12,0,0);
		}

		[TestMethod]
		public void TestInterval()
		{
			var tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();

			var localBeginDateTime = LocalDateTime.FromDateTime(new DateTime(2014, 05, 21, 8, 0, 0));
			var zonedBeginDateTime = localBeginDateTime.InZoneStrictly(tz);
			
			var localEndDateTime = LocalDateTime.FromDateTime(new DateTime(2014, 08, 23, 17, 0, 0));
			var zonedEndDateTime = localEndDateTime.InZoneStrictly(tz);

			var karlsruheEntwicklerTageInterval = new Interval(zonedBeginDateTime.ToInstant(), zonedEndDateTime.ToInstant());
			// 2014-05-21T06:00:00Z - 2014-08-23T15:00:00Z
			Console.WriteLine(karlsruheEntwicklerTageInterval);
		}

		////ZonedDateTime
		//var now = SystemClock.Instance.Now;
		//var dtzi = DateTimeZoneProviders.Tzdb;
		//var berlinTz = dtzi["Europe/Berlin"];
		//var berlinNow = new ZonedDateTime(now, berlinTz);
		////2014-05-08T22:42:08 Europe/Berlin (+02)
		//Console.WriteLine(berlinNow);


		//var twentyFifth = new LocalDate(2018, 1, 16);
		//var today = berlinNow.LocalDateTime.Date;
		//var period = Period.Between(today, twentyFifth, PeriodUnits.Days);
		//Console.WriteLine(period.Days); //1349 Days
		////P 3Y 8M 8D
		//Console.Write(Period.Between(today, twentyFifth, 
		//	PeriodUnits.YearMonthDay));


		////January 28th 2010 + 1 month = February 28th 2010
		//Console.WriteLine(new DateTime(2010, 1, 28).AddMonths(1).ToShortDateString());

		////January 29th 2010 + 1 month = February 28th 2010
		//Console.WriteLine(new DateTime(2010, 1, 29).AddMonths(1).ToShortDateString());

		////January 30th 2010 + 1 month = February 28th 2010
		//Console.WriteLine(new DateTime(2010, 1, 30).AddMonths(1).ToShortDateString());

		////February 28th 2010 - 1 month = January 28th 2010
		//Console.WriteLine(new DateTime(2010, 2, 28).AddMonths(-1).ToShortDateString());

		//Console.ReadLine();

		//var client = new RestClient("http://example.com");
		 
		//public DateTime AddTwoDays()
		//{
		//	var now = System.DateTime.Now;
		//	return now.AddDays(2);
		//}
	}
}
