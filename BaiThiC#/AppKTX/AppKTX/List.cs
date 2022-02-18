using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibKtx;

namespace AppKTX
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
            dataGridView1.DataSource = sql.Load1();
        }
        public ConnectSql sql = new ConnectSql();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = sql.ListDanhSach(textBox1.Text);
        }

    }
}
