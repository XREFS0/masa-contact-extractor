using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MASA.Search
{
	// Token: 0x02000013 RID: 19
	public class SearchProcess
	{
		// Token: 0x06000056 RID: 86 RVA: 0x00007F8C File Offset: 0x0000618C
		public SearchProcess(Query TheQuery)
		{
			this.Type = TheQuery.Type;
			this.Data = TheQuery.Data;
			this.Keyword = TheQuery.Keyword;
			this.CountryDomain = TheQuery.CountryDomain;
			this.LanguageCode = TheQuery.LanguageCode;
			this.ScanWebsites = TheQuery.ScanWebsites;
			this.dgvResults = TheQuery.dgv;
			this.MainThread = new Thread(new ThreadStart(this.ProcessPages));
			this.MainThread.Start();
			this.IsRunning = true;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00008024 File Offset: 0x00006224
		private void ProcessPages()
		{
			try
			{
				if (this.Type == SearchType.Google)
				{
					if (this.CountryDomain != "all")
					{
						this.SearchUrl = string.Format("https://www.startpage.com/do/dsearch?qsr={0}&query={1}", this.CountryDomain, WebUtility.UrlEncode(this.Keyword));
					}
					else
					{
						this.SearchUrl = string.Format("https://www.startpage.com/do/dsearch?&query={0}", WebUtility.UrlEncode(this.Keyword));
					}
					ChromeDriverService service = ChromeDriverService.CreateDefaultService();
					service.HideCommandPromptWindow = true;
					ChromeOptions options = new ChromeOptions();
					string[] userAgents = new string[] { "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36" };
					Random rnd = new Random();
					options.AddArgument("--user-agent=" + userAgents[rnd.Next(userAgents.Length)]);
					options.AddArgument("--headless=new");
					options.AddExcludedArgument("--enable-automation");
					options.AddArgument("--disable-gpu");
					options.AddArgument("--blink-settings=imagesEnabled=false");
					options.AddArgument("--no-sandbox");
					if (Program.ProxyServers.Count > 0)
					{
						int ProxyIndex = new Random().Next(0, Program.ProxyServers.Count);
						Proxy proxy = new Proxy
						{
							HttpProxy = string.Format("{0}:{1}", Program.ProxyServers[ProxyIndex].IP, Program.ProxyServers[ProxyIndex].Port)
						};
						options.Proxy = proxy;
					}
					using (ChromeDriver driver = new ChromeDriver(service, options))
					{
						if (Program.LogOn)
						{
							SearchProcess.LogToFile("Navigating: " + this.SearchUrl);
						}
						try
						{
							driver.Navigate().GoToUrl(this.SearchUrl);
							new WebDriverWait(driver, TimeSpan.FromSeconds(200.0));
							Thread.Sleep(1500);
							if (Program.LogOn)
							{
								SearchProcess.LogToFile(this.SearchUrl + " Done!");
							}
							int PageNbr = 1;
							IReadOnlyCollection<IWebElement> headers;
							do
							{
								Thread.Sleep(1500);
								List<PageScraper.SearchEngineResult> SEResults = new List<PageScraper.SearchEngineResult>();
								headers = driver.FindElements(By.ClassName("result"));
								if (Program.LogOn)
								{
									SearchProcess.LogToFile(string.Format("{0} Page {1}: {2} results", this.SearchUrl, PageNbr, headers.Count));
								}
								foreach (IWebElement webElement in headers)
								{
									string Link = webElement.FindElement(By.TagName("a")).GetAttribute("href");
									string Title = webElement.FindElement(By.TagName("h2")).GetDomProperty("innerText");
									string Snippet = webElement.GetDomProperty("innerText");
									SEResults.Add(new PageScraper.SearchEngineResult
									{
										Url = Link,
										Title = Title,
										Snippet = Snippet
									});
									if (Program.LogOn)
									{
										SearchProcess.LogToFile(string.Concat(new string[] { "Title: ", Title, " URL: ", Link, " Snippet: ", Snippet }));
									}
									this.ProcessData(this.Data, this.SearchUrl, this.Keyword, Snippet, Link, Title, SEResults);
								}
								if (this.ScanWebsites)
								{
									this.DoScanWebsites(SEResults);
								}
								try
								{
									driver.FindElement(By.XPath("//button[text()='Next']")).Click();
									PageNbr++;
									Thread.Sleep(2000);
								}
								catch (NoSuchElementException)
								{
									headers = null;
								}
							}
							while (PageNbr < Program.AppSettings.BingMaxPages && headers != null && headers.Count > 0 && !this.Stopped);
						}
						catch (Exception ex)
						{
							SearchProcess.LogToFile("Error: " + ex.Message);
						}
					}
				}
				if (this.Type == SearchType.Bing)
				{
					string[] array = this.CountryDomain.Split(new char[] { '.' });
					string text = array[array.Length - 1];
					this.SearchUrl = string.Format("https://search.yahoo.com/search?p={0}", WebUtility.UrlEncode(this.Keyword));
					ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
					chromeDriverService.HideCommandPromptWindow = true;
					ChromeOptions options2 = new ChromeOptions();
					options2.AddArgument("--headless=new");
					options2.AddArgument("--blink-settings=imagesEnabled=false");
					options2.AddExcludedArgument("--enable-automation");
					options2.AddArgument("--disable-gpu");
					options2.AddArgument("--no-sandbox");
					options2.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36");
					if (Program.ProxyServers.Count > 0)
					{
						int ProxyIndex2 = new Random().Next(0, Program.ProxyServers.Count);
						Proxy proxy2 = new Proxy
						{
							HttpProxy = string.Format("{0}:{1}", Program.ProxyServers[ProxyIndex2].IP, Program.ProxyServers[ProxyIndex2].Port)
						};
						options2.Proxy = proxy2;
					}
					using (ChromeDriver driver2 = new ChromeDriver(chromeDriverService, options2))
					{
						SearchProcess.LogToFile("Navigating: " + this.SearchUrl);
						try
						{
							driver2.Navigate().GoToUrl(this.SearchUrl);
							Thread.Sleep(1500);
							try
							{
								string JSCookie = "document.querySelectorAll('button.btn.secondary.accept-all')[0].click();";
								((IJavaScriptExecutor)driver2).ExecuteScript(JSCookie, Array.Empty<object>());
							}
							catch (NoSuchElementException)
							{
							}
							Thread.Sleep(1500);
							int PageNbr2 = 1;
							IReadOnlyCollection<IWebElement> headers2;
							do
							{
								List<PageScraper.SearchEngineResult> SEResults2 = new List<PageScraper.SearchEngineResult>();
								headers2 = driver2.FindElements(By.ClassName("algo-sr"));
								SearchProcess.LogToFile(string.Format("{0} Page {1}: {2} results", this.SearchUrl, PageNbr2, headers2.Count));
								foreach (IWebElement webElement2 in headers2)
								{
									string Link2 = webElement2.FindElement(By.TagName("a")).GetAttribute("href");
									string Title2 = webElement2.FindElement(By.TagName("h3")).GetDomProperty("innerText");
									string Snippet2 = webElement2.GetDomProperty("innerText");
									SEResults2.Add(new PageScraper.SearchEngineResult
									{
										Url = Link2,
										Title = Title2,
										Snippet = Snippet2
									});
									SearchProcess.LogToFile(string.Concat(new string[] { "Title: ", Title2, " URL: ", Link2, " Snippet: ", Snippet2 }));
									string InSnippet = Title2 + " - snippet";
									string InTitle = Title2 + " - title";
									if (this.Data == DataType.Email)
									{
										SearchProcess.FindEmail(this.SearchUrl, this.Keyword, Snippet2, Link2, this.dgvResults, InSnippet);
										if (Program.AppSettings.ScanSnippetsTitles)
										{
											SearchProcess.FindEmail(this.SearchUrl, this.Keyword, Title2, Link2, this.dgvResults, InTitle);
										}
									}
									if (this.Data == DataType.Phone)
									{
										SearchProcess.FindPhone(this.SearchUrl, this.Keyword, Snippet2, Link2, this.dgvResults, InSnippet);
										if (Program.AppSettings.ScanSnippetsTitles)
										{
											SearchProcess.FindPhone(this.SearchUrl, this.Keyword, Title2, Link2, this.dgvResults, InTitle);
										}
									}
								}
								if (this.ScanWebsites)
								{
									this.DoScanWebsites(SEResults2);
								}
								try
								{
									if (driver2.FindElement(By.ClassName("next")) != null)
									{
										int pagina = PageNbr2 * 10;
										string SearchUrl = string.Format("https://search.yahoo.com/search?p={0}&b={1}", WebUtility.UrlEncode(this.Keyword), pagina);
										PageNbr2++;
										driver2.Navigate().GoToUrl(SearchUrl);
									}
								}
								catch (NoSuchElementException)
								{
									headers2 = null;
								}
							}
							while (PageNbr2 < Program.AppSettings.BingMaxPages && headers2 != null && headers2.Count > 0 && !this.Stopped);
						}
						catch (Exception ex2)
						{
							SearchProcess.LogToFile("Error: " + ex2.Message);
						}
						finally
						{
							driver2.Quit();
						}
					}
				}
			}
			catch
			{
			}
			this.Done = true;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000088E8 File Offset: 0x00006AE8
		public static bool FindEmail(string SearchUrl, string Keyword, string Html, string ItemUrl, DataGridView dgvResults, string Title = "")
		{
			if (Title == "")
			{
				Title = SearchProcess.GetTitle(Html, ItemUrl);
			}
			using (IEnumerator<string> enumerator = (from Match x in Regex.Matches(Html, "(?i)(([a-zA-Z]+[\\w.-]+)@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6})")
				select x.Groups[1].Value).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string Email = enumerator.Current;
					bool FilterPassed = true;
					try
					{
						FilterPassed = Email.Length > 9 && Email.ToLower().Substring(Email.Length - 4, 4) != ".png" && !Email.ToLower().Contains("image") && !Email.ToLower().Contains("jpeg") && !Email.ToLower().Contains("jpg") && !Email.ToLower().Contains("abuse") && !Email.ToLower().Contains("example") && !Email.ToLower().Contains("email.com") && !Email.ToLower().Contains("spam") && !Email.ToLower().Contains("noreply") && !Email.ToLower().Contains("legal") && !Email.ToLower().Contains("pec") && !Email.ToLower().Contains("forum") && !Email.ToLower().Contains("webmaster") && !Email.ToLower().Contains("sentry") && !Email.ToLower().Contains("www") && !Email.ToLower().Contains("remove") && !Email.ToLower().Contains("privacy") && !Email.ToLower().Contains("avvocat") && !Email.ToLower().Contains("no-reply") && Email.Length < 60 && Email.ToLower().Substring(Email.Length - 4, 4) != ".gif" && Email.ToLower().Substring(Email.Length - 5, 5) != ".webp" && Program.AppData.Items.FindIndex((Data.DataRow x) => x.Item.Equals(Email)) == -1;
					}
					catch
					{
					}
					if (FilterPassed)
					{
						string SearchEngine = string.Empty;
						if (SearchUrl.Contains("startpage"))
						{
							SearchEngine = string.Format("Google {0}", Program.AppSettings.Language);
						}
						else
						{
							SearchEngine = "Bing";
						}
						Program.AppData.Items.Add(new Data.DataRow
						{
							Item = Email,
							Url = ItemUrl,
							Title = Title,
							Type = "Email",
							Country = Program.AppSettings.Country,
							Keyword = Keyword.Split(new char[] { '@' })[0],
							SearchEngine = SearchEngine
						});
						dgvResults.Invoke(new MethodInvoker(delegate
						{
							dgvResults.Rows.Add(new object[]
							{
								dgvResults.Rows.Count + 1,
								Email,
								ItemUrl,
								Title,
								"Email",
								Program.AppSettings.Country,
								Keyword.Split(new char[] { '@' })[0],
								SearchEngine
							});
						}));
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00008DB4 File Offset: 0x00006FB4
		public static bool FindPhone(string SearchUrl, string Keyword, string Html, string ItemUrl, DataGridView dgvResults, string Title)
		{
			bool Result = false;
			List<int[]> Combinations = new List<int[]>();
			Combinations.Add(new int[] { 1, 10 });
			Combinations.Add(new int[] { 1, 4, 3, 3 });
			Combinations.Add(new int[] { 1, 4, 4, 2 });
			Combinations.Add(new int[] { 1, 4, 2, 4 });
			Combinations.Add(new int[] { 1, 4, 2, 2, 2 });
			Combinations.Add(new int[] { 1, 3, 3, 4 });
			Combinations.Add(new int[] { 1, 3, 3, 2, 2 });
			Combinations.Add(new int[] { 1, 3, 4, 3 });
			Combinations.Add(new int[] { 1, 3, 2, 2, 3 });
			Combinations.Add(new int[] { 1, 3, 2, 3, 2 });
			Combinations.Add(new int[] { 1, 2, 4, 4 });
			Combinations.Add(new int[] { 1, 2, 4, 2, 2 });
			Combinations.Add(new int[] { 1, 2, 3, 2, 3 });
			Combinations.Add(new int[] { 1, 2, 3, 3, 2 });
			Combinations.Add(new int[] { 1, 2, 2, 2, 4 });
			Combinations.Add(new int[] { 1, 2, 2, 3, 3 });
			Combinations.Add(new int[] { 1, 2, 2, 4, 2 });
			Combinations.Add(new int[] { 2, 2, 3, 4 });
			Combinations.Add(new int[] { 2, 2, 3, 2, 2 });
			Combinations.Add(new int[] { 2, 2, 4, 3 });
			Combinations.Add(new int[] { 2, 2, 2, 2, 3 });
			Combinations.Add(new int[] { 2, 3, 2, 4 });
			Combinations.Add(new int[] { 2, 3, 2, 2, 2 });
			Combinations.Add(new int[] { 2, 3, 3, 3 });
			Combinations.Add(new int[] { 2, 4, 2, 3 });
			Combinations.Add(new int[] { 2, 4, 3, 2 });
			List<string[]> items = HTTPScraper.ParseHTML(Html, "(?:\\+)[0-9\\s.\\/-]{10,17}");
			if (items.Count > 0)
			{
				foreach (string[] item in items)
				{
					string Phone = item[0].Replace("(", "").Replace(")", "").Replace(" ", "")
						.Replace(".", "")
						.Replace("-", "")
						.Trim();
					if (Program.AppData.Items.FindIndex((Data.DataRow x) => x.Item.Equals(Phone)) == -1)
					{
						string SearchEngine = string.Empty;
						if (SearchUrl.Contains("google"))
						{
							SearchEngine = string.Format("Google {0}", Program.AppSettings.Language);
						}
						else
						{
							SearchEngine = "Bing";
						}
						Program.AppData.Items.Add(new Data.DataRow
						{
							Item = Phone,
							Url = ItemUrl,
							Title = Title,
							Type = "Phone",
							Country = Program.AppSettings.Country,
							Keyword = Keyword.Split(new char[] { '@' })[0],
							SearchEngine = SearchEngine
						});
						dgvResults.Invoke(new MethodInvoker(delegate
						{
							dgvResults.Rows.Add(new object[]
							{
								dgvResults.Rows.Count + 1,
								Phone,
								ItemUrl,
								Title,
								"Phone",
								Program.AppSettings.Country,
								Keyword.Split(new char[] { '@' })[0],
								SearchEngine
							});
						}));
						Result = true;
					}
				}
			}
			return Result;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00009270 File Offset: 0x00007470
		public static string GetTitle(string Html, string URL)
		{
			List<string[]> items = HTTPScraper.ParseHTML(Html, "<title>(.*?)</title>");
			if (items.Count > 0)
			{
				return items[0][1].Trim();
			}
			string test = URL.Replace("https://", "").Replace("http://", "").Replace("www.", "")
				.Split(new char[] { '/' })[0];
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(test.ToLower());
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000092F8 File Offset: 0x000074F8
		public void Stop()
		{
			this.Stopped = true;
			try
			{
				if (this.driver != null)
				{
					this.driver.Quit();
					this.driver.Dispose();
					this.driver = null;
				}
				foreach (Process process in Process.GetProcessesByName("chromedriver"))
				{
					try
					{
						Console.WriteLine(string.Format("Killing ChromeDriver process: {0}", process.Id));
						process.Kill();
					}
					catch (Exception ex)
					{
						Console.WriteLine("Error while killing ChromeDriver process: " + ex.Message);
					}
				}
				Task.Run(delegate
				{
					this.KillChromeProcesses();
				});
			}
			catch (Exception ex2)
			{
				Console.WriteLine("Error while stopping ChromeDriver: " + ex2.Message);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000093D4 File Offset: 0x000075D4
		private void KillChromeProcesses()
		{
			foreach (Process process in Process.GetProcessesByName("chrome"))
			{
				try
				{
					string commandLine = this.GetCommandLine(process);
					if (commandLine != null && commandLine.Contains("webdriver"))
					{
						Console.WriteLine(string.Format("Killing Chrome process launched by ChromeDriver: {0}", process.Id));
						process.Kill();
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error while checking or killing Chrome process: " + ex.Message);
				}
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00009464 File Offset: 0x00007664
		private string GetCommandLine(Process process)
		{
			try
			{
				using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(string.Format("SELECT CommandLine FROM Win32_Process WHERE ProcessId = {0}", process.Id)))
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							object obj = enumerator.Current["CommandLine"];
							return (obj != null) ? obj.ToString() : null;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error retrieving command line: " + ex.Message);
			}
			return null;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00009520 File Offset: 0x00007720
		public void DoScanWebsites(List<PageScraper.SearchEngineResult> SEResults)
		{
			Task[] tasks = new Task[SEResults.Count];
			for (int i = 0; i < SEResults.Count; i++)
			{
				string Url = SEResults[i].Url;
				tasks[i] = Task.Factory.StartNew(delegate
				{
					new PageScraper(this.SearchUrl, this.Keyword, Url, this.Data, this.dgvResults).ProcessPage();
				});
			}
			Task.WaitAll(tasks, 10000);
			GC.Collect();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00009594 File Offset: 0x00007794
		[CompilerGenerated]
		internal static void LogToFile(string message)
		{
			if (Program.LogOn)
			{
				try
				{
					File.AppendAllText("log.txt", message + Environment.NewLine);
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000095D4 File Offset: 0x000077D4
		[CompilerGenerated]
		private void ProcessData(DataType dataType, string searchUrl, string keyword, string snippet, string link, string title, List<PageScraper.SearchEngineResult> results)
		{
			string InSnippet = title + " - snippet";
			string InTitle = title + " - title";
			if (dataType == DataType.Email)
			{
				SearchProcess.FindEmail(searchUrl, keyword, snippet, link, this.dgvResults, InSnippet);
				if (Program.AppSettings.ScanSnippetsTitles)
				{
					SearchProcess.FindEmail(searchUrl, keyword, title, link, this.dgvResults, InTitle);
				}
			}
			if (dataType == DataType.Phone)
			{
				SearchProcess.FindPhone(searchUrl, keyword, snippet, link, this.dgvResults, InSnippet);
				if (Program.AppSettings.ScanSnippetsTitles)
				{
					SearchProcess.FindPhone(searchUrl, keyword, title, link, this.dgvResults, InTitle);
				}
			}
		}

		// Token: 0x040000AC RID: 172
		private string SearchUrl;

		// Token: 0x040000AD RID: 173
		public int PageNbr = 1;

		// Token: 0x040000AE RID: 174
		private SearchType Type;

		// Token: 0x040000AF RID: 175
		public DataType Data;

		// Token: 0x040000B0 RID: 176
		public string CountryDomain;

		// Token: 0x040000B1 RID: 177
		public string LanguageCode;

		// Token: 0x040000B2 RID: 178
		public bool ScanWebsites;

		// Token: 0x040000B3 RID: 179
		public string Keyword;

		// Token: 0x040000B4 RID: 180
		private DataGridView dgvResults;

		// Token: 0x040000B5 RID: 181
		private ChromeDriver driver;

		// Token: 0x040000B6 RID: 182
		private Thread MainThread;

		// Token: 0x040000B7 RID: 183
		public bool IsRunning;

		// Token: 0x040000B8 RID: 184
		public bool Done;

		// Token: 0x040000B9 RID: 185
		public bool StopSearching;

		// Token: 0x040000BA RID: 186
		public bool Stopped;
	}
}
