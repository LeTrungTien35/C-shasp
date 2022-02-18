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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView2.DataSource = a.Load2();
            dataGridView1.DataSource = a.Load1();
          
        }
        public ConnectSql a = new ConnectSql();
        void ShowAdd()
        {
            FormAdd Add = new FormAdd();
            DialogResult kq = Add.ShowDialog();
            
        }
        void ShowFix()
        {
            FormFix Fix = new FormFix();
            DialogResult kq = Fix.ShowDialog();
            
        }
        void ShowDel()
        {
            FormDel Del = new FormDel();
            DialogResult kq = Del.ShowDialog();
           
        }
        void ShowSmat()
        {
            FormSmat S= new FormSmat();
            DialogResult kq = S.ShowDialog();

        }
        void ShowList()
        {
            List L = new List();
            DialogResult kq = L.ShowDialog();

        }
        void ShowHD()
        {
            HDKTX H = new HDKTX();
            DialogResult kq = H.ShowDialog();

        }
        void LoadData()
        {
            dataGridView2.DataSource = a.Load2();
        }
        
        private void hoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAdd(); 
        }

        private void fixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFix();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDel();
        }

        private void smartSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSmat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.DataSource = a.Load1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           dataGridView2.DataSource = a.Find(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowList();
        }

        private void hợpĐồngKtxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHD();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();  
        }
        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }  
    }
}
