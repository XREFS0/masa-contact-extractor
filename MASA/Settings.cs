using System;
using System.IO;
using System.Xml.Serialization;

namespace MASA
{
	// Token: 0x0200000B RID: 11
	public class Settings
	{
		// Token: 0x06000043 RID: 67 RVA: 0x000079E0 File Offset: 0x00005BE0
		public bool Save(string FName)
		{
			XmlSerializer writer = new XmlSerializer(typeof(Settings));
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

		// Token: 0x06000044 RID: 68 RVA: 0x00007A2C File Offset: 0x00005C2C
		public static Settings Load(string FName)
		{
			XmlSerializer reader = new XmlSerializer(typeof(Settings));
			Settings settings2;
			try
			{
				StreamReader file = new StreamReader(FName);
				Settings settings = (Settings)reader.Deserialize(file);
				file.Close();
				settings2 = settings;
			}
			catch
			{
				settings2 = new Settings();
			}
			return settings2;
		}

		// Token: 0x0400007C RID: 124
		public bool SearchGoogle;

		// Token: 0x0400007D RID: 125
		public bool SearchBing;

		// Token: 0x0400007E RID: 126
		public bool SearchBoth = true;

		// Token: 0x0400007F RID: 127
		public bool DataEmails = true;

		// Token: 0x04000080 RID: 128
		public bool DataPhones;

		// Token: 0x04000081 RID: 129
		public bool DataBoth;

		// Token: 0x04000082 RID: 130
		public bool ProxyDoNotUse = true;

		// Token: 0x04000083 RID: 131
		public bool ProxyFree;

		// Token: 0x04000084 RID: 132
		public bool ProxyOwn;

		// Token: 0x04000085 RID: 133
		public string OwnProxyServersList;

		// Token: 0x04000086 RID: 134
		public string Keywords;

		// Token: 0x04000087 RID: 135
		public string Language;

		// Token: 0x04000088 RID: 136
		public string Country = "all";

		// Token: 0x04000089 RID: 137
		public int Threads = 2;

		// Token: 0x0400008A RID: 138
		public int BingMaxPages = 4;

		// Token: 0x0400008B RID: 139
		public bool ScanWebsites = true;

		// Token: 0x0400008C RID: 140
		public bool ScanSnippetsTitles = true;

		// Token: 0x0400008D RID: 141
		public bool Facebook;

		// Token: 0x0400008E RID: 142
		public bool Twitter;

		// Token: 0x0400008F RID: 143
		public bool Instagram;

		// Token: 0x04000090 RID: 144
		public bool LinkedIn;
	}
}
