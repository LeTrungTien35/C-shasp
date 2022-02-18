using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc với SQL server
using AppQuanLyBanHang.Class; //Sử dụng class Functions.cs

namespace AppQuanLyBanHang
{
    public partial class frmSmart : Form
    {
        DataTable tblTKTM;
        public frmSmart()
        {
            InitializeComponent();
        }

        private void btntktp_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtmaphong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphong.Focus();
                return;
            } else
                {
                    sql = "SELECT * from SinhVien WHERE maphong = " + txtmaphong.Text;
                }    
                 
            tblTKTM = Function.GetDataToTable(sql);
            if (tblTKTM.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblTKTM.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvQLSV.DataSource = tblTKTM;
        }

        private void btntktyc_Click(object sender, EventArgs e)
        {
            string sql;
            String gt;
            if (rdoNam.Enabled == false && rdoNu.Enabled == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rdoNam.Focus();
                return;
            }
            else
            {
                if (rdoNam.Checked == true)
                {
                    gt = "Nam";
                }
                else gt = "Nữ";

                sql = "SELECT * from Phong WHERE gioitinh = N'" + gt + "'";
            }
            tblTKTM = Function.GetDataToTable(sql);
            if (tblTKTM.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblTKTM.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvPhong.DataSource = tblTKTM;
        }
    }
}
