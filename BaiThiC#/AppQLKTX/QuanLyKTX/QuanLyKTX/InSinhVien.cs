using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
namespace QuanLyKTX
{
    public partial class frmInSinhVien : Form
    {
        public frmInSinhVien()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection
               (@"Data Source=DESKTOP-7KJ5F4U\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
            SqlDataAdapter dap = new SqlDataAdapter("select * from SinhVien", conn);

            DataSet ds = new DataSet();
            dap.Fill(ds, "hihi");

            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "QuanLyKTX.Report1.rdlc";

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
