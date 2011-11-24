using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ItzWarty;

using Be.Windows.Forms;

namespace RAFManager
{
    public partial class BinaryViewer : Form
    {
        /// <summary>
        /// Implements a Binary viewer (More Hex-Editor) using the Be.HexBox control
        /// </summary>
        public BinaryViewer(string title, byte[] content)
        {
            InitializeComponent();

            this.Text = title;
            
            HexBox hb = new HexBox();
            hb.Dock = DockStyle.Fill;
            hb.ByteProvider = new MemoryByteProvider(content);
            hb.VScrollBarVisible = true;
            hb.UseFixedBytesPerLine = true;
            hb.StringViewVisible = true;
            this.Controls.Add(hb);
        }
    }
}
