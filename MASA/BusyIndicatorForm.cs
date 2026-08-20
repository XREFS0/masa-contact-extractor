using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace MASA
{
	// Token: 0x02000004 RID: 4
	public partial class BusyIndicatorForm : Form
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002751 File Offset: 0x00000951
		public BusyIndicatorForm()
		{
			this.InitializeComponent();
			this.pbWait.Visible = true;
		}
	}
}
