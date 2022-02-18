using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaiKTCuoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 1;
            int b = 1;
            int c = a + b;

#if DEBUG
            textBox1.Text = string.Format("DEBUG App Tính Toán a, b, c: {0} + {1} = {2}\r\n\r\n", a, b, c);
#endif
            textBox1.Text += string.Format("Tổng 2 số a, b: {0}", c);
        }
    }
}
