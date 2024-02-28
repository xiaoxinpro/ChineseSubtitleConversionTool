using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ChineseSubtitleConversionTool
{
    public class SyncTextBox : TextBox
    {
        public SyncTextBox()
        {
            this.Multiline = true;
            this.ScrollBars = ScrollBars.Vertical;
        }

        public Control[] Buddies { get; set; }

        private static bool scrolling;   // In case buddy tries to scroll us
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            // Trap WM_VSCROLL message and pass to buddy
            if (Buddies != null)
            {
                foreach (Control ctr in Buddies)
                {
                    if (ctr != this)
                    {
                        if (((m.Msg == 0x114) || m.Msg == 0x115 || m.Msg == 0x20a) && !scrolling && ctr.IsHandleCreated)
                        {
                            scrolling = true;
                            SendMessage(ctr.Handle, m.Msg, m.WParam, m.LParam);
                            scrolling = false;
                        }
                    }
                }
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
