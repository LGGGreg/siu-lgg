using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SkinInstaller
{
    /// <summary>
    /// A ListView wise enough to display tooltips when needed.
    /// The tooltips are displayed over ListViewItem or ListViewSubItem.
    /// </summary>
    public class ListViewItemHover : System.Windows.Forms.ListView
    {
        private System.ComponentModel.IContainer components;

        public ListViewItemHover()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // we need to trap the notify message
            SetStyle(ControlStyles.EnableNotifyMessage, true);

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            
        }
        #endregion


        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg == WM_NOTIFY)
            {
                NMHDR n = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));

                if (n.code == TTN_NEEDTEXT)
                {
                    NeedText();
                }
            }

            // base.OnNotifyMessage(m);
            // calling the base class's OnNotifyMessage method is 
            // not necessary because there is no initial implementation
        }

        private void NeedText()
        {
            ItemHoverEventArgs ihea = new ItemHoverEventArgs();
            LVHITTESTINFO lvh = new LVHITTESTINFO();

            lvh.pt = PointToClient(Control.MousePosition);
            ListView_SubItemHitTest(ref lvh);

            // check if the item is valid
            if ((lvh.iItem < 0) ||
                (lvh.iSubItem < 0))
            {
                return;
            }

            ihea.Item = lvh.iItem;
            ihea.SubItem = lvh.iSubItem;
            ihea.ItemTextInVisible = IsItemTextHidden(lvh);

            if (m_itemHover != null)
            {
                m_itemHover(this, ihea);
            }
        }

        /// <summary>
        /// Finds whether the listview item text is completely visible or 
        /// contains a trailing ellipsis "...".
        /// </summary>
        /// <param name="lvhi">List view hit test information structure</param>
        /// <returns>True if text is hidden, false otherwise</returns>
        private bool IsItemTextHidden(LVHITTESTINFO lvhi)
        {
            Rectangle rect = Rectangle.Empty;
            int stringWidth, colWidth;

            if (lvhi.iSubItem > 0)
            {
                // MSDN : ListView_GetStringWidth() talks something about padding.
                // for subitem: The text is padded with 6 pixels on either sides

                stringWidth = ListView_GetStringWidth(Items[lvhi.iItem].SubItems[lvhi.iSubItem].Text);
                colWidth = ListView_GetColumnWidth(lvhi.iSubItem);
                return ((stringWidth + 12) > colWidth);

            }
            else
            {
                // MSDN : ListView_GetStringWidth() talks something about padding.
                // for item: The text is padded with 2 pixel on either sides

                stringWidth = ListView_GetStringWidth(Items[lvhi.iItem].Text);
                colWidth = ListView_GetColumnWidth(0);
                ListView_GetItemRect(lvhi.iItem, LVIR_LABEL, ref rect);
                rect = Rectangle.Inflate(rect, -2, -2);
                return ((rect.Left + stringWidth + 4) > colWidth);

            }

        }


        // Win API 
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct NMHDR
        {
            public IntPtr hwndFrom;
            public int idFrom;
            public int code;
        }
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, IntPtr lParam);
        // overloaded for wParam type
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam);

        private const int WM_NOTIFY = 0x4E;

        // tooltip
        private const int TTN_FIRST = -520;
        private const int TTN_NEEDTEXT = (TTN_FIRST - 10);

        // listview
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct LVHITTESTINFO
        {
            public Point pt;
            public int flags;
            public int iItem;
            public int iSubItem;
        }
        private const int LVM_FIRST = 0x1000;
        private const int LVM_GETITEMRECT = LVM_FIRST + 14;
        private const int LVM_GETCOLUMNWIDTH = LVM_FIRST + 29;
        private const int LVM_SUBITEMHITTEST = LVM_FIRST + 57;
        private const int LVM_GETSTRINGWIDTHW = LVM_FIRST + 87;

        private const int LVIR_LABEL = 2;


        private void ListView_SubItemHitTest(ref LVHITTESTINFO lvhi)
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(lvhi));
            Marshal.StructureToPtr(lvhi, ptr, true);

            SendMessage(Handle, LVM_SUBITEMHITTEST, IntPtr.Zero, ptr);

            lvhi = (LVHITTESTINFO)Marshal.PtrToStructure(ptr, typeof(LVHITTESTINFO));
            Marshal.FreeHGlobal(ptr);

        }

        private int ListView_GetColumnWidth(int iCol)
        {
            return SendMessage(Handle, LVM_GETCOLUMNWIDTH, iCol, IntPtr.Zero);
        }

        private int ListView_GetStringWidth(string psz)
        {
            IntPtr ptr = Marshal.StringToHGlobalAuto(psz);
            int ret = SendMessage(Handle, LVM_GETSTRINGWIDTHW, 0, ptr);
            Marshal.FreeHGlobal(ptr);

            return ret;

        }

        private bool ListView_GetItemRect(int iItem, int code, ref Rectangle lpRect)
        {
            Rectangle rct = new Rectangle();
            IntPtr pRct = Marshal.AllocHGlobal(Marshal.SizeOf(rct));
            Marshal.StructureToPtr(rct, pRct, true);

            SendMessage(Handle, LVM_GETITEMRECT, iItem, pRct);

            lpRect = (Rectangle)Marshal.PtrToStructure(pRct, typeof(Rectangle));
            Marshal.FreeHGlobal(pRct);

            return true;

        }

        /// <summary>
        /// Provides data about the ItemHover event.
        /// </summary>
        public class ItemHoverEventArgs : EventArgs
        {
            // ref to listview item and sub items
            protected int m_item;
            protected int m_subitem;
            protected bool m_itemTextVisible;

            /// <summary>
            /// The zero based index of a Listview item.
            /// </summary>
            public int Item
            {
                get
                {
                    return m_item;
                }
                set
                {
                    m_item = value;
                }

            }

            /// <summary>
            /// The 1 based index of a ListviewSubitem item.
            /// </summary>
            public int SubItem
            {
                get
                {
                    return m_subitem;
                }
                set
                {
                    m_subitem = value;
                }
            }

            /// <summary>
            /// The item or subitem has text which is currently 
            /// TRUE = Invisible, FALSE = Visible.
            /// </summary>
            public bool ItemTextInVisible
            {
                get
                {
                    return m_itemTextVisible;
                }
                set
                {
                    m_itemTextVisible = value;
                }
            }

        }

        public delegate void ItemHoverEventHandler(object sender, ItemHoverEventArgs e);

        protected event ItemHoverEventHandler m_itemHover;
        public event ItemHoverEventHandler ItemHover
        {
            add
            {
                m_itemHover += value;
            }
            remove
            {
                m_itemHover -= value;
            }
        }
    }
}
