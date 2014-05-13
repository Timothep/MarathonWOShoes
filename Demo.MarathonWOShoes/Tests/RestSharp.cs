using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Extensions;

namespace Tests
{
	[TestClass]
	public class RestSharp
	{
		[TestMethod]
		public void TestHttpWebRequest()
		{
			WebRequest request = WebRequest.Create(url);
			WebResponse response = request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string responseFromServer = reader.ReadToEnd();
			Console.WriteLine(responseFromServer);
			reader.Close();
			response.Close();
		}

		[TestMethod]
		public void TestHttpClient()
		{
			using (HttpClient client = new HttpClient())
			using (HttpResponseMessage response = await client.GetAsync(url))
			using (HttpContent content = response.Content)
			{
				// Read the string.
				string result = await content.ReadAsStringAsync();
			}
		}

		[TestMethod]
		public void TestRestSharp()
		{
			var client = new RestClient(url);
			var request = new RestRequest("/", Method.GET);
			var response = client.Execute(request);
			var content = response.Content;

			// Or async
			//client.ExecuteAsync(request, response => {
			//    Console.WriteLine(response.Content);
			//});
		}

		[TestMethod]
		public void TestRestSharp()
		{
			var client = new RestClient("http://example.com");
			var request = new RestRequest("resource/{id}", Method.POST);

			// --------------------

			// adds to POST or URL querystring based on Method
			request.AddParameter("name", "value"); 

			// replaces matching token in request.Resource
			request.AddUrlSegment("id", "123"); 

			// add parameters for all properties on an object
			request.AddObject(object);

			// or just whitelisted properties
			request.AddObject(object, "PersonId", "Name", ...);

			// add files to upload (works with compatible verbs)
			request.AddFile(path);

			// --------------------

			// easily add HTTP Headers
			request.AddHeader("header", "value");

			// --------------------

			// execute the request
			IRestResponse response = client.Execute(request);
			var content = response.Content; // raw content as string

			// easy async support
			client.ExecuteAsync(request, response => {
					Console.WriteLine(response.Content);
			});



			// --------------------

			// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
			IRestResponse<Person> response = client.Execute<Person>(request);
			var name = response.Data.Name; 

			// async with deserialization
			var asyncHandle = client.ExecuteAsync<Person>(request, response => {
					Console.WriteLine(response.Data.Name);
			});

			asyncHandle.Abort();

			// --------------------

			client.DownloadData(request).SaveAs(path);

			string tempFile = Path.GetTempFileName();
			using (var writer = File.OpenWrite(tempFile))
			{
					var client = new RestClient(baseUrl);
					var request = new RestRequest("Assets/LargeFile.7z");
					request.ResponseWriter = (responseStream) => responseStream.CopyTo(writer);
					var response = client.DownloadData(request);
			}

		}

		[TestMethod]
		public void TestRestSharp()
		{
		}

		[TestMethod]
		public void TestRestSharp()
		{
		}
	}
}
