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
    public partial class frmHopDong : Form
    {
        String mhd;
        DataTable tblHopDong;
        public frmHopDong()
        {
            InitializeComponent();
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
        }

        // Truyền dữ liệu từ tblQLSV sang datagridview
        private void LoadDataGridView()
        {
            string sql = "SELECT * FROM HopDong";

            tblHopDong = Function.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvhd.DataSource = tblHopDong; //Nguồn dữ liệu                      
            dgvhd.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvhd.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }


        private void dgvhd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvhd.CurrentRow.Index;
            txtMHD.Text = dgvhd.Rows[i].Cells[0].Value.ToString();
            txtMaphong.Text = dgvhd.Rows[i].Cells[5].Value.ToString();
            txtDmasv.Text = dgvhd.Rows[i].Cells[1].Value.ToString();
            txtmanv.Text = dgvhd.Rows[i].Cells[2].Value.ToString();           
            dtpBd.Value = (DateTime)dgvhd.Rows[i].Cells[3].Value;
            dtpBd.Value = (DateTime)dgvhd.Rows[i].Cells[4].Value;

            mhd = dgvhd.Rows[i].Cells[0].Value.ToString();
            btnXoa.Enabled = true;
            btnIn.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql;
            if (MessageBox.Show("Bạn có muốn xóa hợp đồng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                sql = "DELETE FROM HoaDon WHERE mahoadon = '" + txtMHD.Text.Trim() + "'";
                Function.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
                btnXoa.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql;

            if (Check_Value() == true) return;

            // Check
            sql = "SELECT mahopdong FROM HopDong WHERE mahopdong = '" + txtMHD.Text.Trim() + "'";
            if (String.Compare(txtMHD.Text, mhd, true) != 0 && Function.CheckKey(sql))
            {
                MessageBox.Show("Mã hợp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMHD.Focus();
                return;
            }

            sql = "UPDATE HopDong SET mahopdong = '" + txtMHD.Text + "', mssv = '" + txtDmasv.Text + "', manv = '" + txtmanv.Text
                + "', ngaybatdau = '" + dtpBd.Value.ToString("yyyy/MM/dd") + "', ngayhethan = '" + dtpkt.Value.ToString("yyyy/MM/dd")
                + "', maphong = " + txtMaphong.Text;
                
            Function.RunSQL(sql);
            LoadDataGridView();
            btnSua.Enabled = false;
            MessageBox.Show("Đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            String sql;

            if (Check_Value() == true) return;

            sql = "SELECT mahopdong FROM HoaDon WHERE mahopdong = '" + txtMHD.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã hợp đồng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMHD.Focus();
                return;
            }

            sql = "INSERT INTO HopDong VALUES(" + txtMHD.Text + "," + txtDmasv.Text + "," + txtmanv.Text 
                + ",'" + dtpBd.Value.ToString("yyyy/MM/dd") + "','" + dtpBd.Value.ToString("yyyy/MM/dd") + "',"
                + txtMaphong.Text + ")";

            Function.RunSQL(sql); // Chạy câu lệnh sql
            LoadDataGridView(); // Làm mới dữ liệu
            btnXoa.Enabled = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from HopDong WHERE 1=1";
            if (txtMHD.Text != "")
                sql += " AND mahopdong LIKE N'%" + txtMHD.Text + "%'";
            if (txtMaphong.Text != "")
                sql += " AND maphong LIKE N'%" + txtMaphong.Text + "%'";
            if (txtDmasv.Text != "")
                sql += " AND mssv LIKE N'%" + txtDmasv + "%'";


            tblHopDong = Function.GetDataToTable(sql);
            if (tblHopDong.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblHopDong.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvhd.DataSource = tblHopDong;
            ResetValue();
        }

        // Nút in
        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
        }

        private void ResetValue()
        {
            txtMHD.Text = "";
            txtMaphong.Text = "";
            txtmanv.Text = "";
            dtpBd.Value = DateTime.Now;
            dtpkt.Value = DateTime.Now;
            txtDmasv.Text = "";
            
        }

        private bool Check_Value()
        {
            if (txtMHD.Text.Trim().Length == 0) // Nếu chưa nhập gì trong txt
            {
                MessageBox.Show("Bạn chưa nhập mã hợp đồng", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMHD.Focus();
                return true;
            }

            if (txtMaphong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã phòng", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaphong.Focus();
                return true;
            }

            if (txtmanv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanv.Focus();
                return true;
            }


            if (txtDmasv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDmasv.Focus();
                return true;
            }

            return false;
        }
    }
}
