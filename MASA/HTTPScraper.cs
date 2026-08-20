using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace MASA
{
	public static class HTTPScraper
	{
		public static string GetPage(string Url, ProxyServer Proxy)
		{
			string text;
			try
			{
				ServicePointManager.Expect100Continue = false;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
				myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
				myHttpWebRequest.MaximumAutomaticRedirections = 25;
				myHttpWebRequest.AllowAutoRedirect = true;
				if (Proxy != null)
				{
					WebProxy myProxy = new WebProxy(string.Format("{0}:{1}", Proxy.IP, Proxy.Port), false);
					myHttpWebRequest.Proxy = myProxy;
				}
				myHttpWebRequest.Timeout = 7000;
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
				Stream dataStream = myHttpWebResponse.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);
				string responseFromServer = reader.ReadToEnd();
				if (string.IsNullOrEmpty(responseFromServer))
				{
					responseFromServer = "Empty response";
				}
				reader.Close();
				reader.Dispose();
				dataStream.Close();
				dataStream.Dispose();
				myHttpWebResponse.Close();
				text = responseFromServer;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				text = "";
			}
			return text;
		}

		public static string GetPage(string Url, string PostData, ProxyServer Proxy, CookieContainer CookieContainer)
		{
			string text;
			try
			{
				ServicePointManager.Expect100Continue = false;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
				myHttpWebRequest.MaximumAutomaticRedirections = 15;
				myHttpWebRequest.AllowAutoRedirect = true;
				myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
				myHttpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
				if (myHttpWebRequest.SupportsCookieContainer)
				{
					myHttpWebRequest.CookieContainer = CookieContainer;
				}
				if (Proxy != null)
				{
					WebProxy myProxy = new WebProxy(string.Format("{0}:{1}", Proxy.IP, Proxy.Port), false);
					myHttpWebRequest.Proxy = myProxy;
				}
				myHttpWebRequest.Timeout = 7000;
				myHttpWebRequest.Method = "POST";
				byte[] byteArray = Encoding.UTF8.GetBytes(PostData);
				myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
				myHttpWebRequest.ContentLength = (long)byteArray.Length;
				Stream requestStream = myHttpWebRequest.GetRequestStream();
				requestStream.Write(byteArray, 0, byteArray.Length);
				requestStream.Close();
				HttpWebResponse httpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string responseFromServer = streamReader.ReadToEnd();
				streamReader.Close();
				streamReader.Dispose();
				responseStream.Close();
				responseStream.Dispose();
				httpWebResponse.Close();
				text = responseFromServer;
			}
			catch (Exception ex)
			{
				text = ex.Message;
			}
			return text;
		}

		public static string GetPage(string Url, ProxyServer Proxy, CookieContainer CookieContainer)
		{
			string text;
			try
			{
				ServicePointManager.Expect100Continue = false;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
				myHttpWebRequest.MaximumAutomaticRedirections = 15;
				myHttpWebRequest.AllowAutoRedirect = true;
				myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
				myHttpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
				myHttpWebRequest.CookieContainer = CookieContainer;
				if (Proxy != null)
				{
					WebProxy myProxy = new WebProxy(string.Format("{0}:{1}", Proxy.IP, Proxy.Port), false);
					myHttpWebRequest.Proxy = myProxy;
				}
				myHttpWebRequest.Timeout = 7000;
				HttpWebResponse httpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string responseFromServer = streamReader.ReadToEnd();
				streamReader.Close();
				streamReader.Dispose();
				responseStream.Close();
				responseStream.Dispose();
				httpWebResponse.Close();
				text = responseFromServer;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				text = "";
			}
			return text;
		}

		public static string GetMarkeredText(string BPMarker, string EPMarker, string HTML, ref int StartPos)
		{
			int BeginPos = HTML.IndexOf(BPMarker, StartPos, StringComparison.InvariantCultureIgnoreCase);
			if (BeginPos <= -1)
			{
				return "";
			}
			int EndPos = HTML.IndexOf(EPMarker, BeginPos, StringComparison.InvariantCultureIgnoreCase);
			if (EndPos > -1)
			{
				StartPos = EndPos + EPMarker.Length;
				string Text = "";
				try
				{
					Text = HTML.Substring(BeginPos + BPMarker.Length, EndPos - BeginPos - BPMarker.Length);
				}
				catch
				{
				}
				return Text;
			}
			StartPos = HTML.Length - 1;
			string Text2 = "";
			try
			{
				Text2 = HTML.Substring(BeginPos + BPMarker.Length, HTML.Length - BeginPos - BPMarker.Length);
			}
			catch
			{
			}
			return Text2;
		}

		public static string ClearTags(string HTML)
		{
			HTML = HTML.Trim().Replace("\n", string.Empty);
			HTML = HTML.Trim().Replace("\r", string.Empty);
			HTML = HTML.Trim().Replace("\t", string.Empty);
			HTML = HTML.Trim().Replace("&nbsp;", " ");
			return Regex.Replace(HTML, "<[^>]*>", " ").Trim();
		}

		public static List<string[]> ParseHTML(string HTML, string Template)
		{
			List<string[]> Results = new List<string[]>();
			Match match = Regex.Match(HTML, Template);
			while (match.Success)
			{
				string[] Values = new string[match.Groups.Count];
				for (int i = 0; i < match.Groups.Count; i++)
				{
					Values[i] = match.Groups[i].Value;
				}
				Results.Add(Values);
				match = match.NextMatch();
			}
			return Results;
		}

		public static string ClearString(string Source)
		{
			Source = Source.Replace("   ", " ");
			char[] Result = Source.ToCharArray();
			char[] CharsToRemove = new char[] { '\n', '\r', '\t' };
			for (int i = 0; i < Source.Length - 1; i++)
			{
				if (Source[i] == ' ' && Source[i + 1] == ' ')
				{
					Result[i] = '*';
					Result[i + 1] = '*';
				}
				for (int j = 0; j < CharsToRemove.Length; j++)
				{
					if (Result[i] == CharsToRemove[j])
					{
						Result[i] = '*';
					}
				}
			}
			return new string(Result).Replace("*", "");
		}

		public struct Brand
		{
			public string Name;
			public string Url;
		}

		public struct Parameter
		{
			public string Name;
			public string Value;
		}
	}
}
