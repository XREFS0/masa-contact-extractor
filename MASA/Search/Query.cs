using System;
using System.Windows.Forms;

namespace MASA.Search
{
	// Token: 0x02000012 RID: 18
	public class Query
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00007F7C File Offset: 0x0000617C
		public Query()
		{
			this.dgv = null;
		}

		// Token: 0x040000A5 RID: 165
		public SearchType Type;

		// Token: 0x040000A6 RID: 166
		public DataType Data;

		// Token: 0x040000A7 RID: 167
		public string Keyword;

		// Token: 0x040000A8 RID: 168
		public string CountryDomain;

		// Token: 0x040000A9 RID: 169
		public string LanguageCode;

		// Token: 0x040000AA RID: 170
		public bool ScanWebsites;

		// Token: 0x040000AB RID: 171
		public DataGridView dgv;
	}
}
