using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MASA.Search;
using Krypton.Ribbon;
using Krypton.Toolkit;

namespace MASA
{
	public partial class MainForm : KryptonForm
	{
		public MainForm()
		{
			this.InitializeComponent();
			Program.IsDemoVersion = false;
			this.Text = "MASA Contact Extractor";
			this.lblDataCount.Text = "";
			this.StyleDataGridView();
		}

		private void StyleDataGridView()
		{
			this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(240, 244, 248);
			this.dgv.GridColor = System.Drawing.Color.FromArgb(200, 210, 220);
			this.dgv.DefaultCellStyle.BackColor = System.Drawing.Color.White;
			this.dgv.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
			this.dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
			this.dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			this.dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f);
			this.dgv.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
			this.dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
			this.dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
			this.dgv.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dgv.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
			this.dgv.ColumnHeadersHeight = 36;
			this.dgv.EnableHeadersVisualStyles = false;
			this.dgv.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 236, 245);
			this.dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 242, 250);
			this.dgv.RowTemplate.Height = 28;
			this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
		}

		private static void CloseChromeProcesses()
		{
			try
			{
				foreach (Process chromeProcess in Process.GetProcessesByName("chrome"))
				{
					if (!chromeProcess.MainModule.FileName.Equals("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"))
					{
						chromeProcess.Kill();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}

		private static bool HaveInternetConnection(string host)
		{
			return new Ping().Send(host, 500).Status == IPStatus.Success;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002B58 File Offset: 0x00000D58
		private void btnStartNewSearch_Click(object sender, EventArgs e)
		{
			SearchSettingsForm searchSettingsForm = new SearchSettingsForm();
			searchSettingsForm.ShowDialog();
			if (searchSettingsForm.Result == DialogResult.OK)
			{
				this.Stop = false;
				MainForm.CloseChromeProcesses();
				this.CloseAllSelenium();
				if (Program.LogOn)
				{
					File.WriteAllText("log.txt", "");
				}
				if (Program.AppSettings.ProxyDoNotUse)
				{
					Program.ProxyServers.Clear();
					this.infoStatusLabel.Text = "Do not use proxy";
				}
				if (Program.AppSettings.ProxyFree)
				{
					this.infoStatusLabel.Text = "Free proxy loading...";
					Application.DoEvents();
					Program.ProxyServers.Clear();
					foreach (string[] i in HTTPScraper.ParseHTML(HTTPScraper.GetPage("https://github.com/resource-collector/proxylist/blob/results/all/https.proxy.txt", null), "(\\d+)\\.(\\d+)\\.(\\d+)\\.(\\d+):(\\d+)"))
					{
						string Server = string.Format("{0}.{1}.{2}.{3}", new object[]
						{
							i[1],
							i[2],
							i[3],
							i[4]
						});
						int Port = Convert.ToInt32(i[5]);
						Program.ProxyServers.Add(new ProxyServer
						{
							IP = Server,
							Port = Port,
							Rnd = this.rnd.NextDouble()
						});
					}
					this.infoStatusLabel.Text = string.Format("Free proxy loaded ({0}). Proxy checking is started...", Program.ProxyServers.Count);
					Application.DoEvents();
				}
				if (Program.AppSettings.ProxyOwn)
				{
					Program.ProxyServers.Clear();
					foreach (string[] j in HTTPScraper.ParseHTML(Program.AppSettings.OwnProxyServersList, "(\\d+)\\.(\\d+)\\.(\\d+)\\.(\\d+):(\\d+)"))
					{
						string Server2 = string.Format("{0}.{1}.{2}.{3}", new object[]
						{
							j[1],
							j[2],
							j[3],
							j[4]
						});
						int Port2 = Convert.ToInt32(j[5]);
						Program.ProxyServers.Add(new ProxyServer
						{
							IP = Server2,
							Port = Port2,
							CanUse = true,
							Checked = true
						});
					}
					Program.ProxyServers.RemoveRange(60, Program.ProxyServers.Count - 60);
					this.infoStatusLabel.Text = string.Format("Own proxy loaded ({0})", Program.ProxyServers.Count);
					Application.DoEvents();
				}
				if (Program.ProxyServers.Count > 0)
				{
					this.lblProxyFailed.Visible = true;
					this.lblWorkProxy.Visible = true;
					Application.DoEvents();
					int WorkProxy = 0;
					int UselessProxy = 0;
					int CheckedProxyTotal = 0;
					int CheckingThreads = 30;
					int CheckingIterations = Program.ProxyServers.Count / CheckingThreads;
					if (Program.ProxyServers.Count % CheckingThreads > 0)
					{
						CheckingIterations++;
					}
					Program.ProxyServers = Program.ProxyServers.OrderBy<ProxyServer, double>((ProxyServer x) => x.Rnd).ToList<ProxyServer>();
					for (int Iteration = 0; Iteration < CheckingIterations; Iteration++)
					{
						int PoolSize = Program.ProxyServers.Count - Iteration * CheckingThreads;
						if (PoolSize > CheckingThreads)
						{
							PoolSize = CheckingThreads;
						}
						Task[] tasks = new Task[PoolSize];
						int InitedProxyCount = 0;
						for (int k = Iteration * CheckingThreads; k < (Iteration + 1) * CheckingThreads; k++)
						{
							if (k < Program.ProxyServers.Count)
							{
								ProxyServer Proxy = Program.ProxyServers[k];
								tasks[InitedProxyCount] = Task.Factory.StartNew(delegate
								{
									Proxy.DoCheckProxy();
								});
								InitedProxyCount++;
							}
						}
						Task.WaitAll(tasks, 5000);
						GC.Collect();
						try
						{
							for (int l = Iteration * CheckingThreads; l < (Iteration + 1) * CheckingThreads; l++)
							{
								if (Program.ProxyServers[l].CanUse)
								{
									WorkProxy++;
								}
								else
								{
									UselessProxy++;
								}
								CheckedProxyTotal++;
							}
							this.lblProxyFailed.Text = string.Format("Useless proxy: {0}", UselessProxy);
							this.lblWorkProxy.Text = string.Format("Work proxy: {0}", WorkProxy);
							Application.DoEvents();
							if (CheckedProxyTotal > 1000)
							{
								break;
							}
						}
						catch
						{
						}
					}
					Program.ProxyServers = Program.ProxyServers.FindAll((ProxyServer x) => x.CanUse).ToList<ProxyServer>();
					this.infoStatusLabel.Text = string.Format("Free proxy loaded ({0}). Proxy checking done!", Program.ProxyServers.Count);
					this.lblProxyFailed.Visible = false;
					this.lblWorkProxy.Visible = false;
					Application.DoEvents();
				}
				string PhoneCode = "";
				try
				{
					PhoneCode = this.CountryCodesDict[Program.AppSettings.Country];
				}
				catch
				{
				}
				List<string> Keywords = new List<string>();
				string[] array = Program.AppSettings.Keywords.Split(new char[] { '|' });
				for (int num = 0; num < array.Length; num++)
				{
					foreach (string m in array[num].Split(new char[] { ',' }))
					{
						if (m.Trim() != "")
						{
							if (!Program.AppSettings.ScanWebsites || Program.AppSettings.ScanSnippetsTitles)
							{
								if (Program.AppSettings.DataEmails || Program.AppSettings.DataBoth)
								{
									if (!Program.AppSettings.Facebook && !Program.AppSettings.Twitter && !Program.AppSettings.Instagram && !Program.AppSettings.LinkedIn)
									{
										Keywords.Add(m.Trim());
										Keywords.Add(string.Format("{0} @yahoo.com", m.Trim()));
										Keywords.Add(string.Format("{0} @gmail.com", m.Trim()));
										Keywords.Add(string.Format("{0} @hotmail.com", m.Trim()));
										Keywords.Add(string.Format("{0} @ email:", m.Trim()));
									}
									if (Program.AppSettings.Facebook)
									{
										Keywords.Add(string.Format("{0} @gmail.com site:facebook.com", m.Trim()));
										Keywords.Add(string.Format("{0} @hotmail.com site:facebook.com", m.Trim()));
										Keywords.Add(string.Format("{0} @yahoo.com site:facebook.com", m.Trim()));
									}
									if (Program.AppSettings.Twitter)
									{
										Keywords.Add(string.Format("{0} @gmail.com site:twitter.com", m.Trim()));
										Keywords.Add(string.Format("{0} @hotmail.com site:twitter.com", m.Trim()));
										Keywords.Add(string.Format("{0} @yahoo.com site:twitter.com", m.Trim()));
									}
									if (Program.AppSettings.Instagram)
									{
										Keywords.Add(string.Format("{0} @gmail.com site:instagram.com", m.Trim()));
										Keywords.Add(string.Format("{0} @hotmail.com site:instagram.com", m.Trim()));
										Keywords.Add(string.Format("{0} @yahoo.com site:instagram.com", m.Trim()));
									}
									if (Program.AppSettings.LinkedIn)
									{
										Keywords.Add(string.Format("{0} @gmail.com site:linkedin.com", m.Trim()));
										Keywords.Add(string.Format("{0} @hotmail.com site:linkedin.com", m.Trim()));
										Keywords.Add(string.Format("{0} @yahoo.com site:linkedin.com", m.Trim()));
									}
								}
								if (Program.AppSettings.DataPhones || Program.AppSettings.DataBoth)
								{
									if (!Program.AppSettings.Facebook && !Program.AppSettings.Twitter && !Program.AppSettings.Instagram && !Program.AppSettings.LinkedIn)
									{
										Keywords.Add(m.Trim());
										Keywords.Add(string.Format("{0} tel {1}", m.Trim(), PhoneCode));
										Keywords.Add(string.Format("{0} whatsapp {1}", m.Trim(), PhoneCode));
									}
									if (Program.AppSettings.Facebook)
									{
										Keywords.Add(string.Format("{0} tel site:facebook.com", m.Trim(), PhoneCode));
										Keywords.Add(string.Format("{0} whatsapp: {1} site:facebook.com", m.Trim(), PhoneCode));
									}
									if (Program.AppSettings.Twitter)
									{
										Keywords.Add(string.Format("{0} tel {1} site:twitter.com", m.Trim(), PhoneCode));
										Keywords.Add(string.Format("{0} whatsapp: {1} site:twitter.com", m.Trim(), PhoneCode));
									}
									if (Program.AppSettings.Instagram)
									{
										Keywords.Add(string.Format("{0} tel {1} site:instagram.com", m.Trim(), PhoneCode));
										Keywords.Add(string.Format("{0} whatsapp: {1} site:instagram.com", m.Trim(), PhoneCode));
									}
									if (Program.AppSettings.LinkedIn)
									{
										Keywords.Add(string.Format("{0} tel {1} site:linkedin.com", m.Trim(), PhoneCode));
										Keywords.Add(string.Format("{0} whatsapp: {1} site:linkedin.com", m.Trim(), PhoneCode));
									}
								}
							}
							else
							{
								if (Program.AppSettings.DataEmails || Program.AppSettings.DataBoth)
								{
									Keywords.Add(m.Trim());
								}
								if (Program.AppSettings.DataPhones || Program.AppSettings.DataBoth)
								{
									Keywords.Add(string.Format("{0} {1}", m.Trim(), PhoneCode));
								}
							}
						}
					}
				}
				string CountryDomain = "all";
				if (Program.AppSettings.Country != "")
				{
					CountryDomain = this.CountriesDict[Program.AppSettings.Country];
				}
				string LanguageCode = "en";
				if (Program.AppSettings.Language != "")
				{
					LanguageCode = this.LanguagesDict[Program.AppSettings.Language].ToLower();
				}
				List<Query> Queries = new List<Query>();
				foreach (string Keyword in Keywords)
				{
					if (Program.AppSettings.SearchGoogle || Program.AppSettings.SearchBoth)
					{
						if (Program.AppSettings.DataEmails || Program.AppSettings.DataBoth)
						{
							Queries.Add(new Query
							{
								Type = SearchType.Google,
								Data = DataType.Email,
								Keyword = Keyword,
								CountryDomain = CountryDomain,
								LanguageCode = LanguageCode,
								ScanWebsites = Program.AppSettings.ScanWebsites,
								dgv = this.dgv
							});
							if (Program.LogOn)
							{
								File.AppendAllText("log.txt", Keyword + Environment.NewLine);
							}
						}
						if (Program.AppSettings.DataPhones || Program.AppSettings.DataBoth)
						{
							Queries.Add(new Query
							{
								Type = SearchType.Google,
								Data = DataType.Phone,
								Keyword = Keyword,
								CountryDomain = CountryDomain,
								LanguageCode = LanguageCode,
								ScanWebsites = Program.AppSettings.ScanWebsites,
								dgv = this.dgv
							});
							if (Program.LogOn)
							{
								File.AppendAllText("log.txt", Keyword + Environment.NewLine);
							}
						}
					}
					if (Program.AppSettings.SearchBing || Program.AppSettings.SearchBoth)
					{
						if (Program.AppSettings.DataEmails || Program.AppSettings.DataBoth)
						{
							Queries.Add(new Query
							{
								Type = SearchType.Bing,
								Data = DataType.Email,
								Keyword = Keyword,
								CountryDomain = CountryDomain,
								LanguageCode = LanguageCode,
								ScanWebsites = Program.AppSettings.ScanWebsites,
								dgv = this.dgv
							});
							if (Program.LogOn)
							{
								File.AppendAllText("log.txt", Keyword + Environment.NewLine);
							}
						}
						if (Program.AppSettings.DataPhones || Program.AppSettings.DataBoth)
						{
							Queries.Add(new Query
							{
								Type = SearchType.Bing,
								Data = DataType.Phone,
								Keyword = Keyword,
								CountryDomain = CountryDomain,
								LanguageCode = LanguageCode,
								ScanWebsites = Program.AppSettings.ScanWebsites,
								dgv = this.dgv
							});
							if (Program.LogOn)
							{
								File.AppendAllText("log.txt", Keyword + Environment.NewLine);
							}
						}
					}
				}
				BusyIndicatorForm bif = new BusyIndicatorForm();
				bif.Show();
				bif.TopLevel = true;
				bif.pbWait.Value = 0;
				base.Opacity = 1.0;
				Application.DoEvents();
				SearchProcess[] spPool = new SearchProcess[Program.AppSettings.Threads];
				int QueryIndex = 0;
				int n = 0;
				while (n < Program.AppSettings.Threads && QueryIndex < Queries.Count)
				{
					spPool[n] = new SearchProcess(Queries[QueryIndex]);
					int num = QueryIndex;
					QueryIndex = num + 1;
					n++;
				}
				global::System.Windows.Forms.Timer timer = new global::System.Windows.Forms.Timer();
				timer.Interval = 3000;
				timer.Tick += delegate(object sender1, EventArgs e1)
				{
					this.lblDataCount.Text = string.Format("Items found {0}...", this.dgv.Rows.Count);
					if (this.StatusForm == null || this.StatusForm.IsDisposed)
					{
						this.StatusForm = new StatusForm();
						this.StatusForm.Location = new Point(this.Location.X + this.Width - this.StatusForm.Width, this.Location.Y + 60);
						this.StatusForm.Show();
					}
					this.StatusForm.tbInfo.Text = "";
					int completed = 0;
					for (int i2 = 0; i2 < spPool.Length; i2++)
					{
						if (spPool[i2] != null && spPool[i2].Done)
						{
							spPool[i2] = null;
							if (QueryIndex < Queries.Count)
							{
								spPool[i2] = new SearchProcess(Queries[QueryIndex]);
								int num3 = QueryIndex;
								QueryIndex = num3 + 1;
							}
						}
						if (spPool[i2] == null)
						{
							completed++;
						}
						if (spPool[i2] != null)
						{
							this.StatusForm.tbInfo.AppendText("Processing Keyword: " + spPool[i2].Keyword + Environment.NewLine);
						}
					}
					bif.lblInfo.Text = string.Format("Processed queries: {0} out of {1}...", QueryIndex, Queries.Count);
					if (completed >= spPool.Length || this.Stop)
					{
						timer.Stop();
						timer.Dispose();
						if (this.StatusForm != null && !this.StatusForm.IsDisposed)
						{
							this.StatusForm.Close();
						}
						if (Program.LogOn)
						{
							File.AppendAllText("log.txt", "Done!" + Environment.NewLine);
						}
						bif.Close();
						bif.Dispose();
						this.Opacity = 1.0;
						Application.DoEvents();
						if (!this.Stop)
						{
							MessageBox.Show("Data collection is done!");
							return;
						}
						MessageBox.Show("Data collection is stopped by user!");
					}
				};
				timer.Start();
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000039F4 File Offset: 0x00001BF4
		private void btnStopSearch_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to stop data collecting?", "Stop", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.Stop = true;
				Application.DoEvents();
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003A18 File Offset: 0x00001C18
		private void btnExportData_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "CSV files|*.csv";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string Header = "#,Item,Url,Title,Type,Country,Keyword,Search Engine," + Environment.NewLine;
				try
				{
					File.WriteAllText(sfd.FileName, Header);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				foreach (object obj in ((IEnumerable)this.dgv.Rows))
				{
					DataGridViewRow r = (DataGridViewRow)obj;
					string Line = string.Format("{0},\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"{8}", new object[]
					{
						r.Cells[0].Value,
						r.Cells[1].Value,
						r.Cells[2].Value,
						r.Cells[3].Value,
						r.Cells[4].Value,
						r.Cells[5].Value,
						r.Cells[6].Value,
						r.Cells[7].Value,
						Environment.NewLine
					});
					try
					{
						File.AppendAllText(sfd.FileName, Line);
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.Message);
					}
				}
			}
			MessageBox.Show("Done!");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003BD0 File Offset: 0x00001DD0
		private void btnCopyToClipboard_Click(object sender, EventArgs e)
		{
			this.dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgv.SelectAll();
			DataObject dataObj = this.dgv.GetClipboardContent();
			if (dataObj != null)
			{
				Clipboard.SetDataObject(dataObj);
			}
			this.dgv.ClearSelection();
			MessageBox.Show("Copied!");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003C34 File Offset: 0x00001E34
		private void CloseAllSelenium()
		{
			bool ProcessIsRunning;
			do
			{
				ProcessIsRunning = true;
				Process[] processes = Process.GetProcesses();
				for (int i = 0; i < processes.Length; i++)
				{
					if (processes[i].ProcessName == "chromedriver")
					{
						try
						{
							processes[i].Kill();
							processes[i].WaitForExit();
							Thread.Sleep(500);
							Application.DoEvents();
						}
						catch
						{
						}
						ProcessIsRunning = false;
						break;
					}
				}
			}
			while (!ProcessIsRunning);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003CA8 File Offset: 0x00001EA8
		private void btnClearData_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure?", "Clear data", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.dgv.Rows.Clear();
				Program.AppData.Items.Clear();
				Program.AppData.Save(Program.AppDataFile);
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
		}

		private void btnRegistration_Click(object sender, EventArgs e)
		{
		}

		private void btnBuyFullVersion_Click(object sender, EventArgs e)
		{
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("MASA Contact Extractor\nContact & Email Extraction Tool", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003D4C File Offset: 0x00001F4C
		private void MainForm_Shown(object sender, EventArgs e)
		{
			Program.AppSettings = Settings.Load(Program.AppSettingsFile);
			Program.AppData = Data.Load(Program.AppDataFile);
			foreach (Data.DataRow r in Program.AppData.Items)
			{
				this.dgv.Rows.Add(new object[]
				{
					this.dgv.Rows.Count + 1,
					r.Item,
					r.Url,
					r.Title,
					r.Type,
					r.Country,
					r.Keyword,
					r.SearchEngine
				});
			}
			try
			{
				string[] array = File.ReadAllLines(string.Format("{0}\\countries.lst", Application.StartupPath));
				Program.Countries = new List<string>();
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string[] s = array2[i].Split(new char[] { ',' });
					if (s.Length > 1)
					{
						this.CountriesDict.Add(s[0], s[1]);
						Program.Countries.Add(s[0]);
					}
				}
			}
			catch
			{
			}
			try
			{
				string[] array3 = File.ReadAllLines(string.Format("{0}\\languages.lst", Application.StartupPath));
				Program.Languages = new List<string>();
				string[] array2 = array3;
				for (int i = 0; i < array2.Length; i++)
				{
					string[] s2 = array2[i].Split(new char[] { ',' });
					if (s2.Length > 1)
					{
						this.LanguagesDict.Add(s2[0], s2[1]);
						Program.Languages.Add(s2[0]);
					}
				}
			}
			catch
			{
			}
			foreach (string line in File.ReadAllLines(string.Format("{0}\\country-codes.lst", Application.StartupPath)))
			{
				try
				{
					string[] s3 = line.Split(new char[] { '\t' });
					if (s3.Length > 1)
					{
						this.CountryCodesDict.Add(s3[1].Split(new char[] { '(' })[0].Trim(), string.Format("+{0}", s3[0]));
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			MainForm.CloseChromeProcesses();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003FD0 File Offset: 0x000021D0
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			MainForm.CloseChromeProcesses();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003FD7 File Offset: 0x000021D7
		private void kryptonRibbonGroup4_DialogBoxLauncherClick(object sender, EventArgs e)
		{
		}

		// Token: 0x0400000B RID: 11
		private Dictionary<string, string> CountriesDict = new Dictionary<string, string>();

		// Token: 0x0400000C RID: 12
		private Dictionary<string, string> LanguagesDict = new Dictionary<string, string>();

		// Token: 0x0400000D RID: 13
		private Dictionary<string, string> CountryCodesDict = new Dictionary<string, string>();

		// Token: 0x0400000E RID: 14
		public bool Stop;

		// Token: 0x0400000F RID: 15
		public StatusForm StatusForm;

		// Token: 0x04000010 RID: 16
		private Random rnd = new Random(DateTime.Now.Millisecond);
	}
}
