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
    public partial class FormSmat : Form
    {
        public FormSmat()
        {
            InitializeComponent();
        }
        public ConnectSql sql = new ConnectSql();

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataS.DataSource = sql.SearchSmart2();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dataS.DataSource = sql.SearchSmart();
        }
    }
}
