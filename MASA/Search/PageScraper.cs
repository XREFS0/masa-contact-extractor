using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace MASA.Search
{
	// Token: 0x0200000F RID: 15
	public class PageScraper
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00007CA0 File Offset: 0x00005EA0
		public PageScraper(string SearchUrl, string Keyword, string ItemUrl, DataType Data, DataGridView dgv)
		{
			this.SearchUrl = SearchUrl;
			this.Keyword = Keyword;
			this.ItemUrl = ItemUrl;
			this.Data = Data;
			this.dgvResults = dgv;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00007CCD File Offset: 0x00005ECD
		public void RunThread()
		{
			this.MainThread = new Thread(new ThreadStart(this.ProcessPage));
			this.MainThread.Priority = ThreadPriority.AboveNormal;
			this.MainThread.Start();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00007D00 File Offset: 0x00005F00
		public void ProcessPage()
		{
			List<string> Links = this.GetFirstLevelLinks(this.ItemUrl);
			Links = Links.FindAll((string x) => x.Contains("cont") || x.Contains("kon")).ToList<string>();
			Links.Insert(0, this.ItemUrl);
			Links.Insert(0, this.GetRootLink(this.ItemUrl));
			Task[] tasks = new Task[Links.Count];
			for (int i = 0; i < Links.Count; i++)
			{
				string Link = Links[i];
				tasks[i] = Task.Factory.StartNew(delegate
				{
					string WebsitePage = HTTPScraper.GetPage(Link, null);
					if (this.Data == DataType.Email)
					{
						SearchProcess.FindEmail(this.SearchUrl, this.Keyword, WebsitePage, Link, this.dgvResults, "");
						SearchProcess.FindEmail(this.SearchUrl, this.Keyword, Link, Link, this.dgvResults, "");
					}
					if (this.Data == DataType.Phone)
					{
						string Title = SearchProcess.GetTitle(WebsitePage, Link);
						SearchProcess.FindPhone(this.SearchUrl, this.Keyword, WebsitePage, Link, this.dgvResults, Title);
					}
				});
			}
			Task.WaitAll(tasks);
			GC.Collect();
			this.Done = true;
			try
			{
				Program.AppData.Save(Program.AppDataFile);
			}
			catch
			{
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00007DEC File Offset: 0x00005FEC
		private string GetRootLink(string Url)
		{
			string[] _url = Url.Split(new char[] { '/' });
			return string.Format("{0}//{1}/", _url[0], _url[2]);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00007E1C File Offset: 0x0000601C
		private List<string> GetFirstLevelLinks(string Url)
		{
			List<string> Links = new List<string>();
			Links.Add(Url);
			foreach (string[] array in HTTPScraper.ParseHTML(HTTPScraper.GetPage(Url, null), "<a(.*?)href=\"([^\"]+)\""))
			{
				string link = array[2];
				if (!link.Contains("http"))
				{
					link = string.Format("{0}/{1}", Url.Trim(new char[] { '/' }), link.Trim(new char[] { '/' }));
				}
				else if (!link.Contains(Url.Trim(new char[] { '/' })))
				{
					continue;
				}
				if (!link.ToLower().Contains(".png") && !link.ToLower().Contains(".jpeg") && !link.ToLower().Contains(".jpg") && !link.ToLower().Contains(".gif") && !link.ToLower().Contains(".doc") && !link.ToLower().Contains(".pdf") && !link.ToLower().Contains(".webp") && Links.IndexOf(link) == -1)
				{
					Links.Add(link);
				}
			}
			return Links;
		}

		// Token: 0x04000096 RID: 150
		public bool Done;

		// Token: 0x04000097 RID: 151
		public bool StopSearching;

		// Token: 0x04000098 RID: 152
		public string SearchUrl;

		// Token: 0x04000099 RID: 153
		public string Keyword;

		// Token: 0x0400009A RID: 154
		public string ItemUrl;

		// Token: 0x0400009B RID: 155
		public DataType Data;

		// Token: 0x0400009C RID: 156
		public DataGridView dgvResults;

		// Token: 0x0400009D RID: 157
		private Thread MainThread;

		// Token: 0x0400009E RID: 158
		private HtmlWeb web;

		// Token: 0x0200001C RID: 28
		public struct SearchEngineResult
		{
			// Token: 0x040000EB RID: 235
			public string Url;

			// Token: 0x040000EC RID: 236
			public string Title;

			// Token: 0x040000ED RID: 237
			public string Snippet;
		}
	}
}
