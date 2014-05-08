using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using RestSharp;
using TinyIoC;

namespace Demo.MarathonWOShoes
{
	class Program
	{
		static void Main(string[] args)
		{
			//TestIoc();

			//ZonedDateTime
			var now = SystemClock.Instance.Now;
			var dtzi = DateTimeZoneProviders.Tzdb;
			var berlinTz = dtzi["Europe/Berlin"];
			var berlinNow = new ZonedDateTime(now, berlinTz);
			//2014-05-08T22:42:08 Europe/Berlin (+02)
			Console.WriteLine(berlinNow);



			var twentyFifth = new LocalDate(2018, 1, 16);
			var today = berlinNow.LocalDateTime.Date;
			var period = Period.Between(today, twentyFifth, PeriodUnits.Days);
			Console.WriteLine(period.Days); //1349 Days
			//P 3Y 8M 8D
			Console.Write(Period.Between(today, twentyFifth, 
				PeriodUnits.YearMonthDay));


			////January 28th 2010 + 1 month = February 28th 2010
			//Console.WriteLine(new DateTime(2010, 1, 28).AddMonths(1).ToShortDateString());

			////January 29th 2010 + 1 month = February 28th 2010
			//Console.WriteLine(new DateTime(2010, 1, 29).AddMonths(1).ToShortDateString());

			////January 30th 2010 + 1 month = February 28th 2010
			//Console.WriteLine(new DateTime(2010, 1, 30).AddMonths(1).ToShortDateString());

			////February 28th 2010 - 1 month = January 28th 2010
			//Console.WriteLine(new DateTime(2010, 2, 28).AddMonths(-1).ToShortDateString());

			//Console.ReadLine();

			///var client = new RestClient("http://example.com");

		}

		//public DateTime AddTwoDays()
		//{
		//	var now = System.DateTime.Now;
		//	return now.AddDays(2);
		//}

		//public static void TestIoc()
		//{
		//	var container = TinyIoCContainer.Current;
		//	container.AutoRegister();
		//	//var instance = container.Resolve<Ia>();

		//	//container.Register<B>();
		//	//container.Register<Ia>((c,p) => new A("something"));
		//	var instance = container.Resolve<Ib>();
		//}
	}


	//public interface Ia { }

	//public class A : Ia
	//{
	//	private string a;
	//	public A(string _a) { a = _a; }
	//}

	//public interface Ib {	}

	//public class B : Ib
	//{
	//	private Ia a;
	//	public B(Ia _a) { a = _a; }
	//}
}
