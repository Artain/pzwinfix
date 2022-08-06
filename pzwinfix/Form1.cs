using System.Runtime.InteropServices;

namespace pzwinfix
{
	public partial class win1 : Form
	{

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		private static extern Int64 FindWindowW(String lpClassName, String lpWindowName);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		private static extern Int64 SetWindowLongPtrW(Int64 hwnd, Int32 nIndex, Int64 dwNewLong);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		private static extern Int64 GetWindowLongPtrW(Int64 hwnd, Int32 nIndex);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		private static extern bool SetWindowPos(Int64 hwnd, Int64 hWndInsertAfter, Int32 x, Int32 y, Int32 cx, Int32 cy, UInt32 uFlags);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		private static extern bool IsIconic(Int64 hwnd);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		private static extern bool ShowWindow(Int64 hwnd, Int32 nCmdShow);

		int SW_RESTORE = 9;
		int GWL_STYLE = -16;
		long WS_BORDER = 0x00800000L;
		uint SWP_NOSIZE = 0x0001;
		uint SWP_NOMOVE = 0x0002;
		uint SWP_NOZORDER = 0x0004;
		uint SWP_NOACTIVATE = 0x0010;
		uint SWP_FRAMECHANGED = 0x0020;
		uint SWP_NOOWNERZORDER = 0x0200;
		uint SWP_NOSENDCHANGING = 0x0400;



		public win1()
		{
			InitializeComponent();
			label1.Text = "Open Project Zombiod\nStart a game until \"click to start\"\nClick in game\nClick on \"Try to fix window\" button";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			timer1.Start();
			long pzwindow = FindWindowW(null, "Project Zomboid");
			if(pzwindow == 0)
			{
				label1.Text = "Could not find Project Zomboid window";
				return;
			} else
			{
				label1.Text = "Find Project Zomboid window try to fix ...";
			}
			if (IsIconic(pzwindow))
			{
				ShowWindow(pzwindow, SW_RESTORE);
			}
			long original = GetWindowLongPtrW(pzwindow, GWL_STYLE);
			SetWindowLongPtrW(pzwindow, GWL_STYLE, original | WS_BORDER);
			SetWindowPos(pzwindow, 0, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_NOACTIVATE | SWP_NOOWNERZORDER | SWP_NOSENDCHANGING | SWP_FRAMECHANGED);
			SetWindowLongPtrW(pzwindow, GWL_STYLE, original);
			SetWindowPos(pzwindow, 0, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_NOACTIVATE | SWP_NOOWNERZORDER | SWP_NOSENDCHANGING | SWP_FRAMECHANGED);
			label1.Text = "Window fix executed";
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			label1.Text = "Open Project Zombiod\nStart a game until \"click to start\"\nClick in game\nClick on \"Try to fix window\" button";
		}
	}
}