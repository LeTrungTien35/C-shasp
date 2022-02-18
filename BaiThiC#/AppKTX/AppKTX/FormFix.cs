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
    public partial class FormFix : Form
    {
        public FormFix()
        {
            InitializeComponent();
        }
        public ConnectSql sql = new ConnectSql();
        string[] soP()
        {
          
                string[] p = new string[2];
                DataTable a = sql.FindP(textBox4.Text);
                p[0] = a.Rows[0]["Phong"].ToString();
                p[1] = a.Rows[0]["So nguoi dang o"].ToString();
                return p;
        }

        string[] checkSv()
        {
            string[] s = new string[1];
            DataTable b = sql.FindSv(textBox1.Text);
            s[0] = b.Rows[0]["Phong"].ToString();
            return s;

        }
        string[] soP2()
        {
            string[] s = checkSv();
            string[] t = new string[2];
            DataTable a = sql.FindP(s[0]);
            t[0] = a.Rows[0]["Phong"].ToString();
            t[1] = a.Rows[0]["So nguoi dang o"].ToString();
            return t;
        }
        string[] Max()
        {
            string[] m = new string[2];
            DataTable a = sql.FindP(textBox4.Text);
            m[1] = a.Rows[0]["Max"].ToString();
            return m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] p = soP();
            string[] t = soP2();
            string[] m = Max();
            int d = Int32.Parse(t[1])-1;
           
            int c = Int32.Parse(p[1]) + 1;
            int b = Int32.Parse(m[1]);
            if (c <= b)
            {
                sql.fixp(c, p[0]);
                sql.fixp(d, t[0]);
                sql.Fix(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                sql.Load2();
                MessageBox.Show("Đã sửa thành công !!");
            }
            else MessageBox.Show("Phòng đã full !!!");
        }
    }
}
