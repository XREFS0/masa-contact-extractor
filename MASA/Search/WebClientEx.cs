using System;
using System.Net;

namespace MASA.Search
{
	// Token: 0x02000014 RID: 20
	public class WebClientEx : WebClient
	{
		// Token: 0x06000062 RID: 98 RVA: 0x0000966E File Offset: 0x0000786E
		public WebClientEx(CookieContainer container)
		{
			this.container = container;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00009688 File Offset: 0x00007888
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00009690 File Offset: 0x00007890
		public CookieContainer CookieContainer
		{
			get
			{
				return this.container;
			}
			set
			{
				this.container = value;
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000969C File Offset: 0x0000789C
		protected override WebRequest GetWebRequest(Uri address)
		{
			WebRequest webRequest = base.GetWebRequest(address);
			HttpWebRequest request = webRequest as HttpWebRequest;
			if (request != null)
			{
				request.CookieContainer = this.container;
			}
			return webRequest;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000096C8 File Offset: 0x000078C8
		protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
		{
			WebResponse response = base.GetWebResponse(request, result);
			this.ReadCookies(response);
			return response;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000096E8 File Offset: 0x000078E8
		protected override WebResponse GetWebResponse(WebRequest request)
		{
			WebResponse response = base.GetWebResponse(request);
			this.ReadCookies(response);
			return response;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00009708 File Offset: 0x00007908
		private void ReadCookies(WebResponse r)
		{
			HttpWebResponse response = r as HttpWebResponse;
			if (response != null)
			{
				CookieCollection cookies = response.Cookies;
				this.container.Add(cookies);
			}
		}

		// Token: 0x040000BB RID: 187
		private CookieContainer container = new CookieContainer();
	}
}
