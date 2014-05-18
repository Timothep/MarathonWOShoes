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
			WebRequest request = WebRequest.Create("url");
			WebResponse response = request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string responseFromServer = reader.ReadToEnd();
			Console.WriteLine(responseFromServer);
			reader.Close();
			response.Close();
		}

		[TestMethod]
		public async void TestHttpClient()
		{
			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage response = await client.GetAsync("url"))
				{
					using (HttpContent content = response.Content)
					{
						// Read the string.
						string result = await content.ReadAsStringAsync();
					}
				}
			}
		}

		[TestMethod]
		public async void TestHttpClient2()
		{
			var client = new HttpClient();
			var response = await client.GetAsync("www.google.com");
			var content = response.Content;
			var result = await content.ReadAsStringAsync();
		}

		[TestMethod]
		public void TestRestSharp()
		{
			//Ex1
			var client = new RestClient("url");
			var request = new RestRequest("/", Method.GET);
			var response = client.Execute(request);
			Console.WriteLine(response.Content);

			//Ex2
			client = new RestClient("http://example.com");
			request = new RestRequest("resource/{id}", Method.POST);

			//Ex3 Async
			client.ExecuteAsync(request, resp => Console.WriteLine(resp.Content));
		}

		[TestMethod]
		public void TestParameters()
		{
			var client = new RestClient("http://example.com");
			var request = new RestRequest("resource/{id}", Method.POST);

			// adds to POST or URL querystring based on Method
			request.AddParameter("name", "value");

			// replaces matching token in request.Resource
			request.AddUrlSegment("id", "123");

			// add parameters for all properties on an object
			request.AddObject(new MyInt{myInt = 42});

			// add files to upload (works with compatible verbs)
			// may throw a FileNotFoundException
			request.AddFile("name", "path"); 
		}

		internal class MyInt
		{
			public int myInt { get; set; }
		}

		[TestMethod]
		public void TestHeaders()
		{
			var client = new RestClient("url");
			var request = new RestRequest("/", Method.GET);

			// easily add HTTP Headers
			request.AddHeader("header", "value");

		}

		[TestMethod]
		public void TestExecution()
		{
			var client = new RestClient("url");
			var request = new RestRequest("/", Method.GET);

			// execute the request
			IRestResponse response = client.Execute(request);
			var content = response.Content; // raw content as string

			// easy async support
			client.ExecuteAsync(request, resp => Console.WriteLine(resp.Content));

		}

		[TestMethod]
		public void TestSerialize()
		{
			var client = new RestClient("url");
			var request = new RestRequest("/", Method.GET);

			// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
			IRestResponse<Person> response = client.Execute<Person>(request);
			var name = response.Data.Name;
		}

		[TestMethod]
		public void TestDeserialize()
		{
			var client = new RestClient("url");
			var request = new RestRequest("/", Method.GET);

			// async with deserialization
			var asyncHandle = client.ExecuteAsync<Person>(request, resp => Console.WriteLine(resp.Data.Name));

			asyncHandle.Abort();
		}

		internal class Person
		{
			public bool Name { get; set; }
		}

		[TestMethod]
		public void TestDownload()
		{
			var client = new RestClient("url");
			var request = new RestRequest("/", Method.GET);

			client.DownloadData(request).SaveAs("path");
		}

		[TestMethod]
		public void TestStreaming()
		{
			string tempFile = Path.GetTempFileName();
			using (var writer = File.OpenWrite(tempFile))
			{
				var client = new RestClient("baseUrl");
				var request = new RestRequest("Assets/LargeFile.7z");
				request.ResponseWriter = (responseStream) => responseStream.CopyTo(writer);
				var response = client.DownloadData(request);
			}
		}
	}
}
