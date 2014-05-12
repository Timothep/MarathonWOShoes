using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class NodaTime
	{
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
