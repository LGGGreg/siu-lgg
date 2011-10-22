using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Test
{
    internal partial class Form1 : Form
    {
        internal Form1()
        {
            InitializeComponent();

            //Cliver.Message.ShowMessagesInTurn = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliver.Message.NextTime_Owner = this;
            Cliver.Message.Inform("cvbvcb");
            //Inform("cvbvcb");
            //Form g = new Form();
            //g.Text = "qqq";
            //g.ShowDialog();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart m = f;
            t = new Thread(m);
            t.Start();
        }
        Thread t;

        private void button3_Click(object sender, EventArgs e)
        {
            ThreadStart m = f;
            t2 = new Thread(m);
            t2.Start();
        }
        Thread t2;

        void f()
        {
            Cliver.Message.Inform((i++).ToString());
            //Inform((i++).ToString());
            //Form g = new Form();
            //g.Text = (i++).ToString();
            //g.ShowDialog();
        }

        int i = 0;

        int Inform(string t)
        {
            {
                Cliver.MessageForm mf;
                mf = new Cliver.MessageForm("", t, null, null, 0, null, (Image)null);
                //mf.ShowDialog();
                mf.GetAnswer();
                return 0;
            }
            //MessageBox.Show(t); return 0;
            try
            {
                //UI thread does its events here until message box is showed by another thread
                while (!System.Threading.Monitor.TryEnter(lock_v))
                    Application.DoEvents();

                Cliver.MessageForm mf;
                mf = new Cliver.MessageForm("", t, null, null, 0, null, (Image)null);
                return mf.GetAnswer();
            }
            finally
            {
                System.Threading.Monitor.Exit(lock_v);
            }
        }
        static object lock_v = new object();
    }
}