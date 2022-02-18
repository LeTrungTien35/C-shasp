using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibKtx;

namespace AppKTX
{
    public partial class FormAdd : Form
    {
        ConnectSql sql = new ConnectSql();
        string[] soP()
        {
           
                string[] p = new string[2];
                DataTable a = sql.FindP(textBox4.Text);
                p[0] = a.Rows[0]["Phong"].ToString();
                p[1] = a.Rows[0]["So nguoi dang o"].ToString();
                return p;
            
        }
        string[] Max()
        {
            string[] m = new string[2];
            DataTable a = sql.FindP(textBox4.Text);
            m[1] = a.Rows[0]["Max"].ToString();
            return m;
        }
        public FormAdd()
        {
            InitializeComponent();
        }
      
        private void FormAdd_Load(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string[] m = Max();
            string[] p = soP();
            int a = Int32.Parse(p[1])+1;
            int b= Int32.Parse(m[1]);
            if (a <= b)
            {
                sql.fixp(a, p[0]);
                sql.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                MessageBox.Show("Đã thêm thành công !!");
            }
            else MessageBox.Show("Phòng đã full !!!");
        }
    }
}
