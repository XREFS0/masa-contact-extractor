namespace MASA
{
	// Token: 0x02000009 RID: 9
	public partial class SearchSettingsForm : global::Krypton.Toolkit.KryptonForm
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00005F85 File Offset: 0x00004185
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005FA4 File Offset: 0x000041A4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MASA.SearchSettingsForm));
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.rbSTBing = new global::Krypton.Toolkit.KryptonRadioButton();
			this.rbSTGoogle = new global::Krypton.Toolkit.KryptonRadioButton();
			this.rbSTBoth = new global::Krypton.Toolkit.KryptonRadioButton();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnStart = new global::Krypton.Toolkit.KryptonButton();
			this.btnCancel = new global::Krypton.Toolkit.KryptonButton();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.rbDataBoth = new global::Krypton.Toolkit.KryptonRadioButton();
			this.rbDataPhones = new global::Krypton.Toolkit.KryptonRadioButton();
			this.rbDataEmails = new global::Krypton.Toolkit.KryptonRadioButton();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.tbOwnProxyServers = new global::Krypton.Toolkit.KryptonTextBox();
			this.rbProxyFreeProxy = new global::Krypton.Toolkit.KryptonRadioButton();
			this.rbProxyOwnProxy = new global::Krypton.Toolkit.KryptonRadioButton();
			this.rbProxyNoProxy = new global::Krypton.Toolkit.KryptonRadioButton();
			this.btnLoad = new global::Krypton.Toolkit.KryptonButton();
			this.kryptonLabel2 = new global::Krypton.Toolkit.KryptonLabel();
			this.tbKeywords = new global::Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel1 = new global::Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel3 = new global::Krypton.Toolkit.KryptonLabel();
			this.cbLanguage = new global::Krypton.Toolkit.KryptonComboBox();
			this.cbCountry = new global::Krypton.Toolkit.KryptonComboBox();
			this.kryptonLabel4 = new global::Krypton.Toolkit.KryptonLabel();
			this.nudThreads = new global::Krypton.Toolkit.KryptonNumericUpDown();
			this.cbScanWebsites = new global::Krypton.Toolkit.KryptonCheckBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.cbScanSnippetsTitles = new global::Krypton.Toolkit.KryptonCheckBox();
			this.cbLinkedIn = new global::Krypton.Toolkit.KryptonCheckBox();
			this.cbInstagram = new global::Krypton.Toolkit.KryptonCheckBox();
			this.cbTwitter = new global::Krypton.Toolkit.KryptonCheckBox();
			this.cbFacebook = new global::Krypton.Toolkit.KryptonCheckBox();
			this.nudBingMaxPages = new global::Krypton.Toolkit.KryptonNumericUpDown();
			this.kryptonLabel5 = new global::Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel6 = new global::Krypton.Toolkit.KryptonLabel();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cbLanguage).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cbCountry).BeginInit();
			this.groupBox4.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.rbSTBing);
			this.groupBox1.Controls.Add(this.rbSTGoogle);
			this.groupBox1.Controls.Add(this.rbSTBoth);
			this.groupBox1.Location = new global::System.Drawing.Point(0, 109);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(216, 45);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search engine";
			this.rbSTBing.Location = new global::System.Drawing.Point(74, 18);
			this.rbSTBing.Name = "rbSTBing";
			this.rbSTBing.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.rbSTBing.Size = new global::System.Drawing.Size(86, 20);
			this.rbSTBing.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.rbSTBing.TabIndex = 2;
			this.rbSTBing.Values.Text = "Bing/Yahoo";
			this.rbSTGoogle.Checked = true;
			this.rbSTGoogle.Location = new global::System.Drawing.Point(6, 18);
			this.rbSTGoogle.Name = "rbSTGoogle";
			this.rbSTGoogle.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.rbSTGoogle.Size = new global::System.Drawing.Size(62, 20);
			this.rbSTGoogle.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.rbSTGoogle.TabIndex = 1;
			this.rbSTGoogle.Values.Text = "Google";
			this.rbSTBoth.Location = new global::System.Drawing.Point(166, 18);
			this.rbSTBoth.Name = "rbSTBoth";
			this.rbSTBoth.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.rbSTBoth.Size = new global::System.Drawing.Size(48, 20);
			this.rbSTBoth.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.rbSTBoth.TabIndex = 0;
			this.rbSTBoth.Values.Text = "Both";
			this.rbSTBoth.CheckedChanged += new global::System.EventHandler(this.rbSTBoth_CheckedChanged);
			this.panel1.Controls.Add(this.btnStart);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 495);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(412, 66);
			this.panel1.TabIndex = 1;
			this.btnStart.CornerRoundingRadius = -1f;
			this.btnStart.Location = new global::System.Drawing.Point(296, 3);
			this.btnStart.Name = "btnStart";
			this.btnStart.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.btnStart.Size = new global::System.Drawing.Size(103, 51);
			this.btnStart.TabIndex = 1;
			this.btnStart.Values.Image = (global::System.Drawing.Image)resources.GetObject("btnStart.Values.Image");
			this.btnStart.Values.Text = "START";
			this.btnStart.Click += new global::System.EventHandler(this.btnStart_Click);
			this.btnCancel.CornerRoundingRadius = -1f;
			this.btnCancel.Location = new global::System.Drawing.Point(200, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.btnCancel.Size = new global::System.Drawing.Size(90, 51);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Values.Image = (global::System.Drawing.Image)resources.GetObject("btnCancel.Values.Image");
			this.btnCancel.Values.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.groupBox2.Controls.Add(this.rbDataBoth);
			this.groupBox2.Controls.Add(this.rbDataPhones);
			this.groupBox2.Controls.Add(this.rbDataEmails);
			this.groupBox2.Location = new global::System.Drawing.Point(0, 161);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(216, 45);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Data to extraction";
			this.rbDataBoth.Checked = true;
			this.rbDataBoth.Location = new global::System.Drawing.Point(154, 19);
			this.rbDataBoth.Name = "rbDataBoth";
			this.rbDataBoth.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.rbDataBoth.Size = new global::System.Drawing.Size(48, 20);
			this.rbDataBoth.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.rbDataBoth.TabIndex = 2;
			this.rbDataBoth.Values.Text = "Both";
			this.rbDataPhones.Location = new global::System.Drawing.Point(86, 19);
			this.rbDataPhones.Name = "rbDataPhones";
			this.rbDataPhones.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.rbDataPhones.Size = new global::System.Drawing.Size(62, 20);
			this.rbDataPhones.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.rbDataPhones.TabIndex = 1;
			this.rbDataPhones.Values.Text = "Phones";
			this.rbDataEmails.Location = new global::System.Drawing.Point(23, 19);
			this.rbDataEmails.Name = "rbDataEmails";
			this.rbDataEmails.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.rbDataEmails.Size = new global::System.Drawing.Size(57, 20);
			this.rbDataEmails.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.rbDataEmails.TabIndex = 0;
			this.rbDataEmails.Values.Text = "Emails";
			this.groupBox3.Controls.Add(this.tbOwnProxyServers);
			this.groupBox3.Controls.Add(this.rbProxyFreeProxy);
			this.groupBox3.Controls.Add(this.rbProxyOwnProxy);
			this.groupBox3.Controls.Add(this.rbProxyNoProxy);
			this.groupBox3.Location = new global::System.Drawing.Point(222, 180);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(177, 262);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Proxy servers";
			this.tbOwnProxyServers.Location = new global::System.Drawing.Point(6, 97);
			this.tbOwnProxyServers.Multiline = true;
			this.tbOwnProxyServers.Name = "tbOwnProxyServers";
			this.tbOwnProxyServers.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.tbOwnProxyServers.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbOwnProxyServers.Size = new global::System.Drawing.Size(165, 179);
			this.tbOwnProxyServers.TabIndex = 3;
			this.rbProxyFreeProxy.Location = new global::System.Drawing.Point(6, 45);
			this.rbProxyFreeProxy.Name = "rbProxyFreeProxy";
			this.rbProxyFreeProxy.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.rbProxyFreeProxy.Size = new global::System.Drawing.Size(142, 20);
			this.rbProxyFreeProxy.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.rbProxyFreeProxy.TabIndex = 2;
			this.rbProxyFreeProxy.Values.Text = "Use free proxy servers";
			this.rbProxyOwnProxy.Location = new global::System.Drawing.Point(6, 71);
			this.rbProxyOwnProxy.Name = "rbProxyOwnProxy";
			this.rbProxyOwnProxy.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.rbProxyOwnProxy.Size = new global::System.Drawing.Size(144, 20);
			this.rbProxyOwnProxy.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.rbProxyOwnProxy.TabIndex = 1;
			this.rbProxyOwnProxy.Values.Text = "Use own proxy servers";
			this.rbProxyNoProxy.Checked = true;
			this.rbProxyNoProxy.Location = new global::System.Drawing.Point(6, 19);
			this.rbProxyNoProxy.Name = "rbProxyNoProxy";
			this.rbProxyNoProxy.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.rbProxyNoProxy.Size = new global::System.Drawing.Size(157, 20);
			this.rbProxyNoProxy.StateCommon.LongText.Color1 = global::System.Drawing.Color.Black;
			this.rbProxyNoProxy.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.rbProxyNoProxy.TabIndex = 0;
			this.rbProxyNoProxy.Values.Text = "Do not use proxy servers";
			this.btnLoad.CornerRoundingRadius = -1f;
			this.btnLoad.Location = new global::System.Drawing.Point(223, 448);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.btnLoad.Size = new global::System.Drawing.Size(177, 25);
			this.btnLoad.TabIndex = 4;
			this.btnLoad.Values.Image = (global::System.Drawing.Image)resources.GetObject("btnLoad.Values.Image");
			this.btnLoad.Values.Text = "Load from file";
			this.btnLoad.Click += new global::System.EventHandler(this.btnLoad_Click);
			this.kryptonLabel2.Location = new global::System.Drawing.Point(13, 12);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.kryptonLabel2.Size = new global::System.Drawing.Size(139, 20);
			this.kryptonLabel2.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.kryptonLabel2.TabIndex = 4;
			this.kryptonLabel2.Values.Text = "Keywords (one per line)";
			this.tbKeywords.Location = new global::System.Drawing.Point(13, 31);
			this.tbKeywords.Multiline = true;
			this.tbKeywords.Name = "tbKeywords";
			this.tbKeywords.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.tbKeywords.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbKeywords.Size = new global::System.Drawing.Size(386, 72);
			this.tbKeywords.TabIndex = 5;
			this.kryptonLabel1.Location = new global::System.Drawing.Point(13, 216);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.kryptonLabel1.Size = new global::System.Drawing.Size(64, 20);
			this.kryptonLabel1.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.kryptonLabel1.TabIndex = 6;
			this.kryptonLabel1.Values.Text = "Language";
			this.kryptonLabel1.Visible = false;
			this.kryptonLabel3.Location = new global::System.Drawing.Point(14, 246);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.kryptonLabel3.Size = new global::System.Drawing.Size(54, 20);
			this.kryptonLabel3.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.kryptonLabel3.TabIndex = 7;
			this.kryptonLabel3.Values.Text = "Country";
			this.kryptonLabel3.Visible = false;
			this.cbLanguage.CornerRoundingRadius = -1f;
			this.cbLanguage.DropDownWidth = 121;
			this.cbLanguage.IntegralHeight = false;
			this.cbLanguage.Location = new global::System.Drawing.Point(90, 216);
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.cbLanguage.Size = new global::System.Drawing.Size(121, 21);
			this.cbLanguage.StateCommon.ComboBox.Content.TextH = global::Krypton.Toolkit.PaletteRelativeAlign.Near;
			this.cbLanguage.TabIndex = 8;
			this.cbLanguage.Visible = false;
			this.cbCountry.CornerRoundingRadius = -1f;
			this.cbCountry.DropDownWidth = 121;
			this.cbCountry.IntegralHeight = false;
			this.cbCountry.Location = new global::System.Drawing.Point(296, 127);
			this.cbCountry.Name = "cbCountry";
			this.cbCountry.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.cbCountry.Size = new global::System.Drawing.Size(103, 21);
			this.cbCountry.StateCommon.ComboBox.Content.TextH = global::Krypton.Toolkit.PaletteRelativeAlign.Near;
			this.cbCountry.TabIndex = 9;
			this.cbCountry.SelectedIndexChanged += new global::System.EventHandler(this.cbCountry_SelectedIndexChanged);
			this.kryptonLabel4.Location = new global::System.Drawing.Point(56, 217);
			this.kryptonLabel4.Name = "kryptonLabel4";
			this.kryptonLabel4.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.kryptonLabel4.Size = new global::System.Drawing.Size(54, 20);
			this.kryptonLabel4.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.kryptonLabel4.TabIndex = 10;
			this.kryptonLabel4.Values.Text = "Threads";
			this.nudThreads.Location = new global::System.Drawing.Point(116, 217);
			global::Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown = this.nudThreads;
			int[] array = new int[4];
			array[0] = 5;
			kryptonNumericUpDown.Maximum = new decimal(array);
			global::Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown2 = this.nudThreads;
			int[] array2 = new int[4];
			array2[0] = 1;
			kryptonNumericUpDown2.Minimum = new decimal(array2);
			this.nudThreads.Name = "nudThreads";
			this.nudThreads.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.nudThreads.Size = new global::System.Drawing.Size(95, 22);
			this.nudThreads.TabIndex = 11;
			global::Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown3 = this.nudThreads;
			int[] array3 = new int[4];
			array3[0] = 2;
			kryptonNumericUpDown3.Value = new decimal(array3);
			this.cbScanWebsites.Location = new global::System.Drawing.Point(23, 19);
			this.cbScanWebsites.Name = "cbScanWebsites";
			this.cbScanWebsites.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.cbScanWebsites.Size = new global::System.Drawing.Size(116, 20);
			this.cbScanWebsites.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.cbScanWebsites.TabIndex = 12;
			this.cbScanWebsites.Values.Image = (global::System.Drawing.Image)resources.GetObject("cbScanWebsites.Values.Image");
			this.cbScanWebsites.Values.Text = "Scan websites";
			this.cbScanWebsites.CheckedChanged += new global::System.EventHandler(this.cbScanWebsites_CheckedChanged);
			this.groupBox4.Controls.Add(this.cbScanSnippetsTitles);
			this.groupBox4.Controls.Add(this.cbLinkedIn);
			this.groupBox4.Controls.Add(this.cbInstagram);
			this.groupBox4.Controls.Add(this.cbTwitter);
			this.groupBox4.Controls.Add(this.cbFacebook);
			this.groupBox4.Controls.Add(this.cbScanWebsites);
			this.groupBox4.Location = new global::System.Drawing.Point(14, 287);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(202, 202);
			this.groupBox4.TabIndex = 13;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Extraction rules";
			this.cbScanSnippetsTitles.Location = new global::System.Drawing.Point(23, 45);
			this.cbScanSnippetsTitles.Name = "cbScanSnippetsTitles";
			this.cbScanSnippetsTitles.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.cbScanSnippetsTitles.Size = new global::System.Drawing.Size(145, 20);
			this.cbScanSnippetsTitles.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.cbScanSnippetsTitles.TabIndex = 17;
			this.cbScanSnippetsTitles.Values.Image = (global::System.Drawing.Image)resources.GetObject("cbScanSnippetsTitles.Values.Image");
			this.cbScanSnippetsTitles.Values.Text = "Scan snippets titles";
			this.cbLinkedIn.Location = new global::System.Drawing.Point(23, 149);
			this.cbLinkedIn.Name = "cbLinkedIn";
			this.cbLinkedIn.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.cbLinkedIn.Size = new global::System.Drawing.Size(170, 20);
			this.cbLinkedIn.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.cbLinkedIn.TabIndex = 16;
			this.cbLinkedIn.Values.Image = (global::System.Drawing.Image)resources.GetObject("cbLinkedIn.Values.Image");
			this.cbLinkedIn.Values.Text = "Search only on LinkedIn";
			this.cbLinkedIn.CheckedChanged += new global::System.EventHandler(this.cbFacebook_CheckedChanged);
			this.cbInstagram.Location = new global::System.Drawing.Point(23, 123);
			this.cbInstagram.Name = "cbInstagram";
			this.cbInstagram.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.cbInstagram.Size = new global::System.Drawing.Size(179, 20);
			this.cbInstagram.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.cbInstagram.TabIndex = 15;
			this.cbInstagram.Values.Image = (global::System.Drawing.Image)resources.GetObject("cbInstagram.Values.Image");
			this.cbInstagram.Values.Text = "Search only on Instagram";
			this.cbInstagram.CheckedChanged += new global::System.EventHandler(this.cbFacebook_CheckedChanged);
			this.cbTwitter.Location = new global::System.Drawing.Point(23, 97);
			this.cbTwitter.Name = "cbTwitter";
			this.cbTwitter.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.cbTwitter.Size = new global::System.Drawing.Size(162, 20);
			this.cbTwitter.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.cbTwitter.TabIndex = 14;
			this.cbTwitter.Values.Image = (global::System.Drawing.Image)resources.GetObject("cbTwitter.Values.Image");
			this.cbTwitter.Values.Text = "Search only on Twitter";
			this.cbTwitter.CheckedChanged += new global::System.EventHandler(this.cbFacebook_CheckedChanged);
			this.cbFacebook.Location = new global::System.Drawing.Point(23, 71);
			this.cbFacebook.Name = "cbFacebook";
			this.cbFacebook.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.cbFacebook.Size = new global::System.Drawing.Size(177, 20);
			this.cbFacebook.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.cbFacebook.TabIndex = 13;
			this.cbFacebook.Values.Image = (global::System.Drawing.Image)resources.GetObject("cbFacebook.Values.Image");
			this.cbFacebook.Values.Text = "Search only on Facebook";
			this.cbFacebook.CheckedChanged += new global::System.EventHandler(this.cbFacebook_CheckedChanged);
			this.nudBingMaxPages.Location = new global::System.Drawing.Point(116, 249);
			global::Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown4 = this.nudBingMaxPages;
			int[] array4 = new int[4];
			array4[0] = 30;
			kryptonNumericUpDown4.Maximum = new decimal(array4);
			global::Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown5 = this.nudBingMaxPages;
			int[] array5 = new int[4];
			array5[0] = 1;
			kryptonNumericUpDown5.Minimum = new decimal(array5);
			this.nudBingMaxPages.Name = "nudBingMaxPages";
			this.nudBingMaxPages.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.nudBingMaxPages.Size = new global::System.Drawing.Size(95, 22);
			this.nudBingMaxPages.TabIndex = 15;
			global::Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown6 = this.nudBingMaxPages;
			int[] array6 = new int[4];
			array6[0] = 5;
			kryptonNumericUpDown6.Value = new decimal(array6);
			this.kryptonLabel5.Location = new global::System.Drawing.Point(13, 249);
			this.kryptonLabel5.Name = "kryptonLabel5";
			this.kryptonLabel5.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.kryptonLabel5.Size = new global::System.Drawing.Size(101, 20);
			this.kryptonLabel5.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.kryptonLabel5.TabIndex = 14;
			this.kryptonLabel5.Values.Text = "Page scan depth";
			this.kryptonLabel6.Location = new global::System.Drawing.Point(241, 127);
			this.kryptonLabel6.Name = "kryptonLabel6";
			this.kryptonLabel6.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			this.kryptonLabel6.Size = new global::System.Drawing.Size(49, 20);
			this.kryptonLabel6.StateCommon.ShortText.Color1 = global::System.Drawing.Color.Black;
			this.kryptonLabel6.TabIndex = 16;
			this.kryptonLabel6.Values.Text = "Region";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(412, 561);
			base.Controls.Add(this.kryptonLabel6);
			base.Controls.Add(this.nudBingMaxPages);
			base.Controls.Add(this.kryptonLabel5);
			base.Controls.Add(this.btnLoad);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.nudThreads);
			base.Controls.Add(this.kryptonLabel4);
			base.Controls.Add(this.cbCountry);
			base.Controls.Add(this.cbLanguage);
			base.Controls.Add(this.kryptonLabel3);
			base.Controls.Add(this.kryptonLabel1);
			base.Controls.Add(this.tbKeywords);
			base.Controls.Add(this.kryptonLabel2);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.groupBox1);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SearchSettingsForm";
			base.PaletteMode = global::Krypton.Toolkit.PaletteMode.Office2010Blue;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Search settings";
			base.Shown += new global::System.EventHandler(this.SearchSettingsForm_Shown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cbLanguage).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cbCountry).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000057 RID: 87
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400005A RID: 90
		private global::Krypton.Toolkit.KryptonButton btnCancel;

		// Token: 0x0400005B RID: 91
		private global::Krypton.Toolkit.KryptonButton btnStart;

		// Token: 0x0400005C RID: 92
		private global::Krypton.Toolkit.KryptonRadioButton rbSTBing;

		// Token: 0x0400005D RID: 93
		private global::Krypton.Toolkit.KryptonRadioButton rbSTGoogle;

		// Token: 0x0400005E RID: 94
		private global::Krypton.Toolkit.KryptonRadioButton rbSTBoth;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000061 RID: 97
		private global::Krypton.Toolkit.KryptonRadioButton rbDataBoth;

		// Token: 0x04000062 RID: 98
		private global::Krypton.Toolkit.KryptonRadioButton rbDataPhones;

		// Token: 0x04000063 RID: 99
		private global::Krypton.Toolkit.KryptonRadioButton rbDataEmails;

		// Token: 0x04000064 RID: 100
		private global::Krypton.Toolkit.KryptonTextBox tbOwnProxyServers;

		// Token: 0x04000065 RID: 101
		private global::Krypton.Toolkit.KryptonRadioButton rbProxyFreeProxy;

		// Token: 0x04000066 RID: 102
		private global::Krypton.Toolkit.KryptonRadioButton rbProxyOwnProxy;

		// Token: 0x04000067 RID: 103
		private global::Krypton.Toolkit.KryptonRadioButton rbProxyNoProxy;

		// Token: 0x04000068 RID: 104
		private global::Krypton.Toolkit.KryptonLabel kryptonLabel2;

		// Token: 0x04000069 RID: 105
		private global::Krypton.Toolkit.KryptonTextBox tbKeywords;

		// Token: 0x0400006A RID: 106
		private global::Krypton.Toolkit.KryptonLabel kryptonLabel1;

		// Token: 0x0400006B RID: 107
		private global::Krypton.Toolkit.KryptonLabel kryptonLabel3;

		// Token: 0x0400006C RID: 108
		private global::Krypton.Toolkit.KryptonComboBox cbLanguage;

		// Token: 0x0400006D RID: 109
		private global::Krypton.Toolkit.KryptonComboBox cbCountry;

		// Token: 0x0400006E RID: 110
		private global::Krypton.Toolkit.KryptonLabel kryptonLabel4;

		// Token: 0x0400006F RID: 111
		private global::Krypton.Toolkit.KryptonNumericUpDown nudThreads;

		// Token: 0x04000070 RID: 112
		private global::Krypton.Toolkit.KryptonCheckBox cbScanWebsites;

		// Token: 0x04000071 RID: 113
		private global::Krypton.Toolkit.KryptonButton btnLoad;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000073 RID: 115
		private global::Krypton.Toolkit.KryptonCheckBox cbLinkedIn;

		// Token: 0x04000074 RID: 116
		private global::Krypton.Toolkit.KryptonCheckBox cbInstagram;

		// Token: 0x04000075 RID: 117
		private global::Krypton.Toolkit.KryptonCheckBox cbTwitter;

		// Token: 0x04000076 RID: 118
		private global::Krypton.Toolkit.KryptonCheckBox cbFacebook;

		// Token: 0x04000077 RID: 119
		private global::Krypton.Toolkit.KryptonNumericUpDown nudBingMaxPages;

		// Token: 0x04000078 RID: 120
		private global::Krypton.Toolkit.KryptonLabel kryptonLabel5;

		// Token: 0x04000079 RID: 121
		private global::Krypton.Toolkit.KryptonCheckBox cbScanSnippetsTitles;

		// Token: 0x0400007A RID: 122
		private global::Krypton.Toolkit.KryptonLabel kryptonLabel6;
	}
}
