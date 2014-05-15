using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Tests
{
	[TestClass]
	public class Json
	{
		public void TestSerialization()
		{
			Product product = new Product();

			product.Name = "Apple";
			product.ExpiryDate = new DateTime(2008, 12, 28);
			product.Price = 3.99M;
			product.Sizes = new string[] { "Small", "Medium", "Large" };

			string output = JsonConvert.SerializeObject(product);
			//{
			//  "Name": "Apple",
			//  "ExpiryDate": "2008-12-28T00:00:00",
			//  "Price": 3.99,
			//  "Sizes": [
			//    "Small",
			//    "Medium",
			//    "Large"
			//  ]
			//}
		}

		[TestMethod]
		public void TestDeserialize()
		{
			string json = @"{
				'Name': 'Bad Boys',
				'ReleaseDate': '1995-4-7T00:00:00',
				'Genres': [ 'Action',
										'Comedy' ]
			}";

			Movie m = JsonConvert.DeserializeObject<Movie>(json);

			string name = m.Name;
			// Bad Boys
		}

		

		

		[TestMethod]
		public void TestJsonFx()
		{
			var reader = new JsonFx.Json.JsonReader();

			string input = @"{ ""foo"": true, ""array"": [ 42, false, ""Hello!"", null ] }";
			dynamic output = reader.Read(input);
			Console.WriteLine(output.array[0]); // 42
		}

		[TestMethod]
		public void TestJsonFxVSLinq2Json()
		{
			var reader = new JsonFx.Json.JsonReader();

			string input = @"{ 'CPU': 'Intel', 'Drives': [ 'DVD read/writer', '500 gigabyte hard drive' ]	}";
			dynamic output = reader.Read(input);
			Assert.AreEqual(output.CPU, "Intel");
			Assert.AreEqual(output.Drives[0], "DVD read/writer");
		}

		public class Product
		{
			public string Name
			{
				get { throw new NotImplementedException(); }
				set { throw new NotImplementedException(); }
			}

			public DateTime ExpiryDate
			{
				get { throw new NotImplementedException(); }
				set { throw new NotImplementedException(); }
			}

			public decimal Price
			{
				get { throw new NotImplementedException(); }
				set { throw new NotImplementedException(); }
			}

			public string[] Sizes
			{
				get { throw new NotImplementedException(); }
				set { throw new NotImplementedException(); }
			}
		}
		
		public class Movie
		{
			public string Name
			{
				get { throw new NotImplementedException(); }
				set { throw new NotImplementedException(); }
			}
		}
	}
}
