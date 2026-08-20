namespace MASA
{
	// Token: 0x0200000C RID: 12
	public partial class StatusForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00007AED File Offset: 0x00005CED
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00007B0C File Offset: 0x00005D0C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MASA.StatusForm));
			this.tbInfo = new global::Krypton.Toolkit.KryptonTextBox();
			base.SuspendLayout();
			this.tbInfo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbInfo.Location = new global::System.Drawing.Point(0, 0);
			this.tbInfo.Multiline = true;
			this.tbInfo.Name = "tbInfo";
			this.tbInfo.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbInfo.Size = new global::System.Drawing.Size(441, 175);
			this.tbInfo.TabIndex = 0;
			this.tbInfo.Text = "Info...";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(441, 175);
			base.Controls.Add(this.tbInfo);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "StatusForm";
			this.Text = "Progress...";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000091 RID: 145
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000092 RID: 146
		public global::Krypton.Toolkit.KryptonTextBox tbInfo;
	}
}
