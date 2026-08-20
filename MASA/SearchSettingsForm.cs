using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace MASA
{
	// Token: 0x02000009 RID: 9
	public partial class SearchSettingsForm : KryptonForm
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00005968 File Offset: 0x00003B68
		public SearchSettingsForm()
		{
			this.InitializeComponent();
			foreach (string c in Program.Countries)
			{
				this.cbCountry.Items.Add(c);
			}
			foreach (string c2 in Program.Languages)
			{
				this.cbLanguage.Items.Add(c2);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005A20 File Offset: 0x00003C20
		private void SearchSettingsForm_Shown(object sender, EventArgs e)
		{
			Program.AppSettings = Settings.Load(Program.AppSettingsFile);
			this.rbSTGoogle.Checked = Program.AppSettings.SearchGoogle;
			this.rbSTBing.Checked = Program.AppSettings.SearchBing;
			this.rbSTBoth.Checked = Program.AppSettings.SearchBoth;
			this.rbDataEmails.Checked = Program.AppSettings.DataEmails;
			this.rbDataPhones.Checked = Program.AppSettings.DataPhones;
			this.rbDataBoth.Checked = Program.AppSettings.DataBoth;
			this.rbProxyNoProxy.Checked = Program.AppSettings.ProxyDoNotUse;
			this.rbProxyFreeProxy.Checked = Program.AppSettings.ProxyFree;
			this.rbProxyOwnProxy.Checked = Program.AppSettings.ProxyOwn;
			this.tbOwnProxyServers.Text = Program.AppSettings.OwnProxyServersList;
			if (!string.IsNullOrEmpty(Program.AppSettings.Keywords))
			{
				this.tbKeywords.Lines = Program.AppSettings.Keywords.Split(new char[] { '|' });
			}
			this.cbLanguage.Text = Program.AppSettings.Language;
			this.cbCountry.Text = Program.AppSettings.Country;
			this.nudThreads.Value = ((Program.AppSettings.Threads > 0) ? Program.AppSettings.Threads : 5);
			this.nudBingMaxPages.Value = ((Program.AppSettings.BingMaxPages > 0) ? Program.AppSettings.BingMaxPages : 20);
			this.cbScanWebsites.Checked = Program.AppSettings.ScanWebsites;
			this.cbScanSnippetsTitles.Checked = Program.AppSettings.ScanSnippetsTitles;
			this.cbFacebook.Checked = Program.AppSettings.Facebook;
			this.cbTwitter.Checked = Program.AppSettings.Twitter;
			this.cbInstagram.Checked = Program.AppSettings.Instagram;
			this.cbLinkedIn.Checked = Program.AppSettings.LinkedIn;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00005C44 File Offset: 0x00003E44
		private void btnStart_Click(object sender, EventArgs e)
		{
			Program.AppSettings.SearchGoogle = this.rbSTGoogle.Checked;
			Program.AppSettings.SearchBing = this.rbSTBing.Checked;
			Program.AppSettings.SearchBoth = this.rbSTBoth.Checked;
			Program.AppSettings.DataEmails = this.rbDataEmails.Checked;
			Program.AppSettings.DataPhones = this.rbDataPhones.Checked;
			Program.AppSettings.DataBoth = this.rbDataBoth.Checked;
			Program.AppSettings.ProxyDoNotUse = this.rbProxyNoProxy.Checked;
			Program.AppSettings.ProxyFree = this.rbProxyFreeProxy.Checked;
			Program.AppSettings.ProxyOwn = this.rbProxyOwnProxy.Checked;
			Program.AppSettings.OwnProxyServersList = this.tbOwnProxyServers.Text;
			string KeywordsLines = "";
			for (int i = 0; i < this.tbKeywords.Lines.Length; i++)
			{
				if (!string.IsNullOrEmpty(this.tbKeywords.Lines[i].Trim()))
				{
					if (i == 0)
					{
						KeywordsLines += this.tbKeywords.Lines[i];
					}
					else
					{
						KeywordsLines = KeywordsLines + "|" + this.tbKeywords.Lines[i];
					}
				}
			}
			Program.AppSettings.Keywords = KeywordsLines;
			Program.AppSettings.Language = this.cbLanguage.Text;
			Program.AppSettings.Country = this.cbCountry.Text;
			Program.AppSettings.Threads = (int)this.nudThreads.Value;
			Program.AppSettings.BingMaxPages = (int)this.nudBingMaxPages.Value;
			Program.AppSettings.ScanWebsites = this.cbScanWebsites.Checked;
			Program.AppSettings.ScanSnippetsTitles = this.cbScanSnippetsTitles.Checked;
			Program.AppSettings.Facebook = this.cbFacebook.Checked;
			Program.AppSettings.Twitter = this.cbTwitter.Checked;
			Program.AppSettings.Instagram = this.cbInstagram.Checked;
			Program.AppSettings.LinkedIn = this.cbLinkedIn.Checked;
			Program.AppSettings.Save(Program.AppSettingsFile);
			this.Result = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005E90 File Offset: 0x00004090
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00005E98 File Offset: 0x00004098
		private void btnLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Text files|*.txt";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.tbOwnProxyServers.Text = File.ReadAllText(ofd.FileName);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00005EF4 File Offset: 0x000040F4
		private void cbScanWebsites_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cbScanWebsites.Checked)
			{
				this.cbFacebook.Checked = false;
				this.cbTwitter.Checked = false;
				this.cbInstagram.Checked = false;
				this.cbLinkedIn.Checked = false;
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005F34 File Offset: 0x00004134
		private void cbFacebook_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cbFacebook.Checked || this.cbTwitter.Checked || this.cbInstagram.Checked || this.cbLinkedIn.Checked)
			{
				this.cbScanWebsites.Checked = false;
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005F81 File Offset: 0x00004181
		private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005F83 File Offset: 0x00004183
		private void rbSTBoth_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000056 RID: 86
		public DialogResult Result;
	}
}
