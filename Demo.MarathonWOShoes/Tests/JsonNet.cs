using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Tests
{
	[TestClass]
	public class JsonNet
	{
		[TestMethod]
		public void TestDateDeserialize()
		{
			const string json = @"{ ""Date"" : ""09/12/2013"" }";

			var obj = JsonConvert.DeserializeObject<MyObject>(json,
					new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

			DateTime date = obj.Date;
			Console.WriteLine("day = " + date.Day);
		}

		internal class MyObject
		{
			public DateTime Date { get; set; }
		}

		[TestMethod]
		public void TestLinq2Json()
		{
			JObject jobj = JObject.Parse(@"{
				'CPU': 'Intel',
				'Drives': [ 'DVD read/writer', '500 gigabyte hard drive' ]
			}");

			// Intel
			Assert.AreEqual("Intel", jobj["CPU"]);
		}

		[TestMethod]
		public void TestSchemaValidation()
		{
			const string schemaJson = @"{
				'description': 'A person', 'type': 'object',
				'properties': {
					'name': {'type':'string'},
					'hobbies': {
						'type': 'array',
						'items': {'type':'string'} 
				}}}";

			JsonSchema schema = JsonSchema.Parse(schemaJson);

			JObject person = JObject.Parse(@"{ 'name': 'James',
				'hobbies': ['.NET', 'Blogging', 'Reading', 'Xbox', 'LOLCATS']
			}");

			Assert.IsTrue(person.IsValid(schema));
		}
	}
}
