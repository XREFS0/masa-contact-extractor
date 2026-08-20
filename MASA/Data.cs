using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MASA
{
	// Token: 0x0200000A RID: 10
	public class Data
	{
		// Token: 0x06000040 RID: 64 RVA: 0x0000792C File Offset: 0x00005B2C
		public Data()
		{
			this.Items = new List<Data.DataRow>();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00007940 File Offset: 0x00005B40
		public bool Save(string FName)
		{
			XmlSerializer writer = new XmlSerializer(typeof(Data));
			bool flag;
			try
			{
				StreamWriter file = new StreamWriter(FName);
				writer.Serialize(file, this);
				file.Close();
				flag = true;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000798C File Offset: 0x00005B8C
		public static Data Load(string FName)
		{
			XmlSerializer reader = new XmlSerializer(typeof(Data));
			Data data2;
			try
			{
				StreamReader file = new StreamReader(FName);
				Data data = (Data)reader.Deserialize(file);
				file.Close();
				data2 = data;
			}
			catch
			{
				data2 = new Data();
			}
			return data2;
		}

		// Token: 0x0400007B RID: 123
		public List<Data.DataRow> Items;

		// Token: 0x0200001B RID: 27
		public struct DataRow
		{
			// Token: 0x040000E4 RID: 228
			public string Item;

			// Token: 0x040000E5 RID: 229
			public string Url;

			// Token: 0x040000E6 RID: 230
			public string Title;

			// Token: 0x040000E7 RID: 231
			public string Type;

			// Token: 0x040000E8 RID: 232
			public string Country;

			// Token: 0x040000E9 RID: 233
			public string Keyword;

			// Token: 0x040000EA RID: 234
			public string SearchEngine;
		}
	}
}
