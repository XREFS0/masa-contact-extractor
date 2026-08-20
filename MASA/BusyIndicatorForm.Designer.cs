namespace MASA
{
	// Token: 0x02000004 RID: 4
	public partial class BusyIndicatorForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000D RID: 13 RVA: 0x0000276B File Offset: 0x0000096B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000278C File Offset: 0x0000098C
		private void InitializeComponent()
		{
			this.kryptonLabel1 = new global::Krypton.Toolkit.KryptonLabel();
			this.pbWait = new global::Krypton.Toolkit.KryptonProgressBar();
			this.lblInfo = new global::Krypton.Toolkit.KryptonLabel();
			base.SuspendLayout();
			this.kryptonLabel1.Location = new global::System.Drawing.Point(12, 12);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new global::System.Drawing.Size(94, 19);
			this.kryptonLabel1.StateCommon.ShortText.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
			this.kryptonLabel1.TabIndex = 0;
			this.kryptonLabel1.Values.Text = "Please wait...";
			this.pbWait.Location = new global::System.Drawing.Point(12, 56);
			this.pbWait.Name = "pbWait";
			this.pbWait.Size = new global::System.Drawing.Size(276, 23);
			this.pbWait.Style = global::System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pbWait.TabIndex = 1;
			this.pbWait.UseKrypton = true;
			this.pbWait.Value = 99;
			this.lblInfo.AutoSize = false;
			this.lblInfo.Location = new global::System.Drawing.Point(12, 34);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new global::System.Drawing.Size(276, 20);
			this.lblInfo.TabIndex = 2;
			this.lblInfo.Values.Text = "Building search queries...";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(300, 91);
			base.Controls.Add(this.lblInfo);
			base.Controls.Add(this.pbWait);
			base.Controls.Add(this.kryptonLabel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "BusyIndicatorForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BusyIndicatorForm";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000007 RID: 7
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000008 RID: 8
		private global::Krypton.Toolkit.KryptonLabel kryptonLabel1;

		// Token: 0x04000009 RID: 9
		public global::Krypton.Toolkit.KryptonProgressBar pbWait;

		// Token: 0x0400000A RID: 10
		public global::Krypton.Toolkit.KryptonLabel lblInfo;
	}
}
