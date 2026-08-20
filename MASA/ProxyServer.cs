using System;
using System.Threading;

namespace MASA
{
	public class ProxyServer
	{
		public ProxyServer()
		{
			this.Checked = false;
			this.Processed = false;
		}

		public void DoCheckProxy()
		{
			string SourcePageHTML = HTTPScraper.GetPage("https://www.google.com", this);
			this.CanUse = SourcePageHTML.IndexOf("Google") > -1;
			this.Checked = true;
		}

		public void CheckProxy()
		{
			this.Checked = false;
			this.Processed = false;
			new Thread(new ThreadStart(this.DoCheckProxy)).Start();
		}

		public void CheckProxyAndWait()
		{
			string SourcePageHTML = HTTPScraper.GetPage("https://www.google.com", this);
			this.CanUse = SourcePageHTML.IndexOf("Google") > -1;
			this.Checked = true;
		}

		public string IP;
		public int Port;
		public bool CanUse;
		public bool Checked;
		public bool Processed;
		public double Rnd;
	}
}
