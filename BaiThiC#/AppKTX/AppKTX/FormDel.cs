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
    public partial class FormDel : Form
    {
        public FormDel()
        {
            InitializeComponent();
        }
        string[] checkSv()
        {
            string[] s = new string[1];
            DataTable b = sql.FindSv(textBox1.Text);
            s[0] = b.Rows[0]["Phong"].ToString();
            return s;

        }
        string[] soP()
        { 
            try
            {
                string[] s = checkSv();
                string[] p = new string[2];
                DataTable a = sql.FindP(s[0]);
                p[0] = a.Rows[0]["Phong"].ToString();
                p[1] = a.Rows[0]["So nguoi dang o"].ToString();
                return p;
            }
            catch (Exception a)
            {
                MessageBox.Show("ERRO : " + a.Message);
            }
            return null;
        }
        public ConnectSql sql = new ConnectSql();
        private void button1_Click(object sender, EventArgs e)
        {
            string[] p = soP();
            int a = Int32.Parse(p[1]) - 1;
            sql.fixp(a, p[0]);
            sql.Delete(textBox1.Text);
            MessageBox.Show("Đã xoá thành công !!");        
        
        }
    }
}
