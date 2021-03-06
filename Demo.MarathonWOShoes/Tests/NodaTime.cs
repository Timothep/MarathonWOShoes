﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaTime;
using NodaTime.TimeZones;

namespace Tests
{
	[TestClass]
	public class NodaTime
	{
		[TestMethod]
		public void Test()
		{
			DateTime date = new DateTime(2014, 01, 01);
		}

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

			var dtzi = DateTimeZoneProviders.Tzdb;
			var londonTz = dtzi["Europe/London"];

			var localBeginDateTime = LocalDateTime.FromDateTime(new DateTime(2014, 05, 21, 8, 0, 0));
			ZonedDateTime zonedBeginDateTime = localBeginDateTime.InZoneStrictly(tz);
			
			var localEndDateTime = LocalDateTime.FromDateTime(new DateTime(2014, 08, 23, 17, 0, 0));
			ZonedDateTime zonedEndDateTime = localEndDateTime.InZoneStrictly(londonTz);

			var karlsruheEntwicklerTageInterval = new Interval(zonedBeginDateTime.ToInstant(), zonedEndDateTime.ToInstant());
			// 2014-05-21T06:00:00Z - 2014-08-23T15:00:00Z
			Console.WriteLine(karlsruheEntwicklerTageInterval);
		}

		[TestMethod]
		public void TestPeriod()
		{
			////ZonedDateTime
			var now = SystemClock.Instance.Now;
			var dtzi = DateTimeZoneProviders.Tzdb;
			var berlinTz = dtzi["Europe/Berlin"];
			var berlinNow = new ZonedDateTime(now, berlinTz);
			////2014-05-08T22:42:08 Europe/Berlin (+02)
			//Console.WriteLine(berlinNow);


			var fourthieth = new LocalDate(2023, 4, 19);
			var today = berlinNow.LocalDateTime.Date;
			Period period = Period.Between(today, fourthieth, PeriodUnits.Days);
			Console.WriteLine(period); //P3257D
			Period between = Period.Between(today, fourthieth, PeriodUnits.YearMonthDay);
			Console.WriteLine(between); //P8Y11M
		}

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
