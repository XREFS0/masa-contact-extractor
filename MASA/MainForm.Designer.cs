namespace MASA
{
	// Token: 0x02000005 RID: 5
	public partial class MainForm : global::Krypton.Toolkit.KryptonForm
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00003FD9 File Offset: 0x000021D9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003FF8 File Offset: 0x000021F8
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MASA.MainForm));
			this.statusStrip = new global::System.Windows.Forms.StatusStrip();
			this.infoStatusLabel = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.lblProxyFailed = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.lblWorkProxy = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.lblDataCount = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.btnStartNewSearch = new global::Krypton.Ribbon.KryptonRibbonGroupButton();
			this.btnStopSearch = new global::Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonGroupTriple1 = new global::Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.kryptonRibbonGroup1 = new global::Krypton.Ribbon.KryptonRibbonGroup();
			this.btnExportData = new global::Krypton.Ribbon.KryptonRibbonGroupButton();
			this.btnCopyToClipboard = new global::Krypton.Ribbon.KryptonRibbonGroupButton();
			this.btnClearData = new global::Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonGroupTriple2 = new global::Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.kryptonRibbonGroup2 = new global::Krypton.Ribbon.KryptonRibbonGroup();
			this.kryptonRibbonGroupTriple3 = new global::Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.kryptonRibbonGroup3 = new global::Krypton.Ribbon.KryptonRibbonGroup();
			this.btnAbout = new global::Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonGroupTriple4 = new global::Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.kryptonRibbonGroup4 = new global::Krypton.Ribbon.KryptonRibbonGroup();
			this.kryptonRibbonTab1 = new global::Krypton.Ribbon.KryptonRibbonTab();
			this.buttonSpecAny1 = new global::Krypton.Toolkit.ButtonSpecAny();
			this.kryptonRibbon = new global::Krypton.Ribbon.KryptonRibbon();
			this.dgv = new global::System.Windows.Forms.DataGridView();
			this.nbr = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.item = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.url = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.title = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.type = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.country = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.keyword = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.engine = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statusStrip.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.kryptonRibbon).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dgv).BeginInit();
			base.SuspendLayout();
			this.statusStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.infoStatusLabel, this.lblProxyFailed, this.lblWorkProxy, this.lblDataCount });
			this.statusStrip.Location = new global::System.Drawing.Point(0, 609);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new global::System.Drawing.Size(984, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			this.infoStatusLabel.Name = "infoStatusLabel";
			this.infoStatusLabel.Size = new global::System.Drawing.Size(42, 17);
			this.infoStatusLabel.Text = "Ready!";
			this.lblProxyFailed.ForeColor = global::System.Drawing.Color.Red;
			this.lblProxyFailed.Name = "lblProxyFailed";
			this.lblProxyFailed.Padding = new global::System.Windows.Forms.Padding(30, 0, 0, 0);
			this.lblProxyFailed.Size = new global::System.Drawing.Size(120, 17);
			this.lblProxyFailed.Text = "Useless proxy: 0";
			this.lblProxyFailed.Visible = false;
			this.lblWorkProxy.ForeColor = global::System.Drawing.Color.Green;
			this.lblWorkProxy.Name = "lblWorkProxy";
			this.lblWorkProxy.Padding = new global::System.Windows.Forms.Padding(30, 0, 0, 0);
			this.lblWorkProxy.Size = new global::System.Drawing.Size(110, 17);
			this.lblWorkProxy.Text = "Work proxy: 0";
			this.lblWorkProxy.Visible = false;
			this.lblDataCount.Name = "lblDataCount";
			this.lblDataCount.Size = new global::System.Drawing.Size(77, 17);
			this.lblDataCount.Text = "lblDataCount";
			this.btnStartNewSearch.ImageLarge = (global::System.Drawing.Image)resources.GetObject("btnStartNewSearch.ImageLarge");
			this.btnStartNewSearch.TextLine1 = "Start New Search";
			this.btnStartNewSearch.Click += new global::System.EventHandler(this.btnStartNewSearch_Click);
			this.btnStopSearch.ImageLarge = (global::System.Drawing.Image)resources.GetObject("btnStopSearch.ImageLarge");
			this.btnStopSearch.TextLine1 = "Stop Search";
			this.btnStopSearch.TextLine2 = "                       ";
			this.btnStopSearch.Click += new global::System.EventHandler(this.btnStopSearch_Click);
			this.kryptonRibbonGroupTriple1.Items.AddRange(new global::Krypton.Ribbon.KryptonRibbonGroupItem[] { this.btnStartNewSearch, this.btnStopSearch });
			this.kryptonRibbonGroup1.Items.AddRange(new global::Krypton.Ribbon.KryptonRibbonGroupContainer[] { this.kryptonRibbonGroupTriple1 });
			this.kryptonRibbonGroup1.TextLine1 = "Search";
			this.btnExportData.ImageLarge = (global::System.Drawing.Image)resources.GetObject("btnExportData.ImageLarge");
			this.btnExportData.TextLine1 = "Export Data";
			this.btnExportData.Click += new global::System.EventHandler(this.btnExportData_Click);
			this.btnCopyToClipboard.ImageLarge = (global::System.Drawing.Image)resources.GetObject("btnCopyToClipboard.ImageLarge");
			this.btnCopyToClipboard.TextLine1 = "Copy to Clipboard";
			this.btnCopyToClipboard.Click += new global::System.EventHandler(this.btnCopyToClipboard_Click);
			this.btnClearData.ImageLarge = (global::System.Drawing.Image)resources.GetObject("btnClearData.ImageLarge");
			this.btnClearData.TextLine1 = "Clear Data";
			this.btnClearData.Click += new global::System.EventHandler(this.btnClearData_Click);
			this.kryptonRibbonGroupTriple2.Items.AddRange(new global::Krypton.Ribbon.KryptonRibbonGroupItem[] { this.btnExportData, this.btnCopyToClipboard, this.btnClearData });
			this.kryptonRibbonGroup2.Items.AddRange(new global::Krypton.Ribbon.KryptonRibbonGroupContainer[] { this.kryptonRibbonGroupTriple2 });
			this.kryptonRibbonGroup2.TextLine1 = "Data";
			this.btnAbout.ImageLarge = (global::System.Drawing.Image)resources.GetObject("btnAbout.ImageLarge");
			this.btnAbout.TextLine1 = "User Guide";
			this.btnAbout.Click += new global::System.EventHandler(this.btnAbout_Click);
			this.kryptonRibbonGroupTriple4.Items.AddRange(new global::Krypton.Ribbon.KryptonRibbonGroupItem[] { this.btnAbout });
			this.kryptonRibbonGroup4.Items.AddRange(new global::Krypton.Ribbon.KryptonRibbonGroupContainer[] { this.kryptonRibbonGroupTriple4 });
			this.kryptonRibbonGroup4.TextLine1 = "Help";
			this.kryptonRibbonGroup4.DialogBoxLauncherClick += new global::System.EventHandler(this.kryptonRibbonGroup4_DialogBoxLauncherClick);
			this.kryptonRibbonTab1.Groups.AddRange(new global::Krypton.Ribbon.KryptonRibbonGroup[] { this.kryptonRibbonGroup1, this.kryptonRibbonGroup2, this.kryptonRibbonGroup4 });
			this.kryptonRibbonTab1.Text = "General actions";
			this.buttonSpecAny1.UniqueName = "d6343c6a83d043479503639cdcab1a9b";
			this.kryptonRibbon.ButtonSpecs.AddRange(new global::Krypton.Toolkit.ButtonSpecAny[] { this.buttonSpecAny1 });
			this.kryptonRibbon.InDesignHelperMode = true;
			this.kryptonRibbon.Name = "kryptonRibbon";
			this.kryptonRibbon.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.kryptonRibbon.RibbonAppButton.AppButtonImage = (global::System.Drawing.Image)resources.GetObject("kryptonRibbon.RibbonAppButton.AppButtonImage");
			this.kryptonRibbon.RibbonAppButton.AppButtonVisible = false;
			this.kryptonRibbon.RibbonTabs.AddRange(new global::Krypton.Ribbon.KryptonRibbonTab[] { this.kryptonRibbonTab1 });
			this.kryptonRibbon.SelectedContext = null;
			this.kryptonRibbon.SelectedTab = this.kryptonRibbonTab1;
			this.kryptonRibbon.Size = new global::System.Drawing.Size(984, 115);
			this.kryptonRibbon.TabIndex = 1;
			this.dgv.AllowUserToAddRows = false;
			this.dgv.AllowUserToDeleteRows = false;
			this.dgv.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.nbr, this.item, this.url, this.title, this.type, this.country, this.keyword, this.engine });
			this.dgv.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new global::System.Drawing.Point(0, 115);
			this.dgv.Name = "dgv";
			this.dgv.ReadOnly = true;
			this.dgv.RowHeadersWidth = 11;
			this.dgv.Size = new global::System.Drawing.Size(984, 494);
			this.dgv.TabIndex = 2;
			this.nbr.HeaderText = "#";
			this.nbr.Name = "nbr";
			this.nbr.ReadOnly = true;
			this.nbr.Width = 40;
			this.item.HeaderText = "Item";
			this.item.Name = "item";
			this.item.ReadOnly = true;
			this.item.Width = 150;
			this.url.HeaderText = "Url";
			this.url.Name = "url";
			this.url.ReadOnly = true;
			this.url.Width = 200;
			this.title.HeaderText = "Title";
			this.title.Name = "title";
			this.title.ReadOnly = true;
			this.title.Width = 200;
			this.type.HeaderText = "Type";
			this.type.Name = "type";
			this.type.ReadOnly = true;
			this.type.Width = 75;
			this.country.HeaderText = "Country";
			this.country.Name = "country";
			this.country.ReadOnly = true;
			this.country.Width = 80;
			this.keyword.HeaderText = "Keyword";
			this.keyword.Name = "keyword";
			this.keyword.ReadOnly = true;
			this.engine.HeaderText = "Search Engine";
			this.engine.Name = "engine";
			this.engine.ReadOnly = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(984, 631);
			base.Controls.Add(this.dgv);
			base.Controls.Add(this.kryptonRibbon);
			base.Controls.Add(this.statusStrip);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "MainForm";
			base.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MASA Contact Extractor";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			base.Shown += new global::System.EventHandler(this.MainForm_Shown);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.kryptonRibbon).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dgv).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000011 RID: 17
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.StatusStrip statusStrip;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.ToolStripStatusLabel infoStatusLabel;

		// Token: 0x04000014 RID: 20
		private global::Krypton.Ribbon.KryptonRibbonGroupButton btnStartNewSearch;

		// Token: 0x04000015 RID: 21
		private global::Krypton.Ribbon.KryptonRibbonGroupButton btnStopSearch;

		// Token: 0x04000016 RID: 22
		private global::Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;

		// Token: 0x04000017 RID: 23
		private global::Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;

		// Token: 0x04000018 RID: 24
		private global::Krypton.Ribbon.KryptonRibbonGroupButton btnExportData;

		// Token: 0x04000019 RID: 25
		private global::Krypton.Ribbon.KryptonRibbonGroupButton btnCopyToClipboard;

		// Token: 0x0400001A RID: 26
		private global::Krypton.Ribbon.KryptonRibbonGroupButton btnClearData;

		// Token: 0x0400001B RID: 27
		private global::Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;

		// Token: 0x0400001C RID: 28
		private global::Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup2;

		private global::Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple3;

		// Token: 0x04000021 RID: 33
		private global::Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup3;

		private global::Krypton.Ribbon.KryptonRibbonGroupButton btnAbout;

		// Token: 0x04000024 RID: 36
		private global::Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple4;

		// Token: 0x04000025 RID: 37
		private global::Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup4;

		// Token: 0x04000026 RID: 38
		private global::Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab1;

		// Token: 0x04000027 RID: 39
		private global::Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;

		// Token: 0x04000028 RID: 40
		private global::Krypton.Ribbon.KryptonRibbon kryptonRibbon;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.DataGridView dgv;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.DataGridViewTextBoxColumn nbr;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.DataGridViewTextBoxColumn item;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.DataGridViewTextBoxColumn url;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.DataGridViewTextBoxColumn title;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.DataGridViewTextBoxColumn type;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.DataGridViewTextBoxColumn country;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.DataGridViewTextBoxColumn keyword;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.DataGridViewTextBoxColumn engine;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.ToolStripStatusLabel lblProxyFailed;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.ToolStripStatusLabel lblWorkProxy;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.ToolStripStatusLabel lblDataCount;
	}
}
