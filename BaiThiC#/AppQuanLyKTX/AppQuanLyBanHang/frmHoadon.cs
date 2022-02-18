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
    public partial class frmHoadon : Form
    {
        DataTable tblHoaDon;
        public frmHoadon()
        {
            InitializeComponent();
        }

        // Load hóa đơn
        private void frmHoadon_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
        }

        // Truyền dữ liệu từ tblQLSV sang datagridview
        private void LoadDataGridView()
        {
            string sql = "SELECT * FROM HoaDon";

            tblHoaDon = Function.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvhd.DataSource = tblHoaDon; //Nguồn dữ liệu                      
            dgvhd.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvhd.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        // xử lý sự kiện click vào dgv Băm nhỏ dữ liệu từ datagridview sang textbox     
        private void dgvhd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvhd.CurrentRow.Index;
            txtMaHoaDon.Text = dgvhd.Rows[i].Cells[0].Value.ToString();
            txtMaphong.Text = dgvhd.Rows[i].Cells[7].Value.ToString();
            txtManv.Text = dgvhd.Rows[i].Cells[2].Value.ToString();
            txtTienDien.Text = dgvhd.Rows[i].Cells[3].Value.ToString();
            txtTienNuoc.Text = dgvhd.Rows[i].Cells[4].Value.ToString();
            txtTienMang.Text = dgvhd.Rows[i].Cells[5].Value.ToString();
            txtTienPhong.Text = dgvhd.Rows[i].Cells[6].Value.ToString();
            dtp1.Value = (DateTime)dgvhd.Rows[i].Cells[1].Value;

            btnXoa.Enabled = true;
            btnIn.Enabled = true;
        }

        // Hàm xóa dữ liệu trong txtbox
        private void ResetValue()
        {
            txtMaHoaDon.Text = "";
            txtManv.Text = "";
            txtMaphong.Text = "";
            dtp1.Value = DateTime.Now;
            txtTienDien.Text = "";
            txtTienMang.Text = "";
            txtTienNuoc.Text = "";
            txtTienPhong.Text = "";
        }

        // Check dữ liệu
        private bool Check_Value()
        {
            if (txtMaHoaDon.Text.Trim().Length == 0) // Nếu chưa nhập gì trong txt
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHoaDon.Focus();
                return true;
            }

            if (txtManv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return true;
            }


            if (txtMaphong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã phòng", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaphong.Focus();
                return true;
            }


            if (txtTienDien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tiền điện", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTienDien.Focus();
                return true;
            }


            if (txtTienMang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tiền mạng", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTienMang.Focus();
                return true;
            }


            if (txtTienNuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tiền nước", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTienNuoc.Focus();
                return true;
            }


            if (txtTienPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tiền phòng", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTienPhong.Focus();
                return true;
            }

            return false;
        }

        // Nút tạo hóa đơn
        private void btnTaoHoaDon_Click_1(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            txtMaHoaDon.Focus();
        }

        // Nút xóa hóa đơn
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            String sql;
            if (MessageBox.Show("Bạn có muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                sql = "DELETE FROM HoaDon WHERE mahoadon = '" + txtMaHoaDon.Text.Trim() + "'";
                Function.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
                btnXoa.Enabled = false;
            }
        }

        // Nút lưu hóa đơn
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            String sql;

            if (Check_Value() == true) return;

            sql = "SELECT mahoadon FROM HoaDon WHERE mahoadon = '" + txtMaHoaDon.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHoaDon.Focus();
                return;
            }

            sql = "INSERT INTO HoaDon VALUES(" + txtMaHoaDon.Text + ",'" + dtp1.Value.ToString("yyyy/MM/dd") + "',"
                + txtManv.Text + "," + txtTienDien.Text + "," + txtTienNuoc.Text + "," + txtTienMang.Text
                + "," + txtTienPhong.Text + "," + txtMaphong.Text + ")";

            Function.RunSQL(sql); // Chạy câu lệnh sql
            LoadDataGridView(); // Làm mới dữ liệu
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }

        // Nút làm mới
        private void btnLammoi_Click_1(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
        }

        // Nút In
        private void btnIn_Click_1(object sender, EventArgs e)
        {

        }

        // Nút đóng
        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút tìm kiếm
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from HoaDon WHERE 1=1";
            if (txtMaHoaDon.Text != "")
                sql += " AND mahoadon LIKE N'%" + txtMaHoaDon.Text + "%'";
            if (txtMaphong.Text != "")
                sql += " AND maphong LIKE N'%" + txtMaphong.Text + "%'";
            if (txtManv.Text != "")
                sql += " AND manv LIKE N'%" + txtManv + "%'";


            tblHoaDon = Function.GetDataToTable(sql);
            if (tblHoaDon.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblHoaDon.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvhd.DataSource = tblHoaDon;
            ResetValue();
        }
      
    }
}

