using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AppQuanLyBanHang.Class;

namespace AppQuanLyBanHang
{
    public partial class frmQLPhong : Form
    {
        DataTable tblPhong;
        String mphong;

        public frmQLPhong()
        {
            InitializeComponent();
        }

        // Những thao tác khi load form 
        private void frmQLPhong_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        // Load data lên DataGridView
        private void LoadDataGridView()
        {
            string sql = "SELECT * FROM Phong";

            tblPhong = Function.GetDataToTable(sql); // Hứng dữ liệu từ bảng trong Function
            dgvPhong.DataSource = tblPhong; //Nguồn dữ liệu                      
            dgvPhong.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvPhong.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        // Băm nhỏ dữ liệu
        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvPhong.CurrentRow.Index;
            txtMaPhong.Text = dgvPhong.Rows[i].Cells[0].Value.ToString();
            txtSoLuong.Text = dgvPhong.Rows[i].Cells[1].Value.ToString();
            txtDango.Text = dgvPhong.Rows[i].Cells[2].Value.ToString();
            txtGiaphong.Text = dgvPhong.Rows[i].Cells[4].Value.ToString();

            // Chuyển mã sinh viên vào biến masv
            mphong = dgvPhong.Rows[i].Cells[0].Value.ToString();
            // Khi click vào một dòng thì Enable 2 nút xóa và sửa
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Nút thêm
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtMaPhong.Focus();
        }

        // Nút xóa
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            String sql;
            if(MessageBox.Show("Bạn có muốn xóa phòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                sql = "DELETE FROM Phong WHERE maphong = " + txtMaPhong.Text.Trim();
                Function.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
                btnXoa.Enabled = false;
            }    
            
        }

        // Nút sửa (UPDATE)
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            String sql;

            if (Check_Value() == true) return;

            // Check mã phòng
            sql = "SELECT maphong FROM Phong WHERE maphong = '" + txtMaPhong.Text.Trim() + "'";
            if (String.Compare(txtMaPhong.Text, mphong, true) != 0 && Function.CheckKey(sql))
            {
                MessageBox.Show("Mã phòng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                return;
            }

            sql = "UPDATE Phong SET maphong = " + txtMaPhong.Text + " , slmax = " + txtSoLuong.Text + ", slo = " + txtDango.Text + ", giaphong = " + txtGiaphong.Text
                + "WHERE maphong =" + mphong;

            Function.RunSQL(sql);
            LoadDataGridView();
            btnSua.Enabled = false;
            MessageBox.Show("Đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút lưu
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            String sql;

            if (Check_Value() == true) return;

            sql = "SELECT maphong FROM Phong WHERE maphong = '" + txtMaPhong.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã phòng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                return;
            }

            sql = "INSERT INTO Phong(maphong, slmax, slo, giaphong) VALUES(" + txtMaPhong.Text + "," + txtSoLuong.Text + "," + txtDango.Text + "," + txtGiaphong.Text  + ")";

            Function.RunSQL(sql); // Chạy câu lệnh sql
            LoadDataGridView(); // Làm mới dữ liệu
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }


        // Nút làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        // Nút đóng form
        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm ResetValue
        private void ResetValue()
        {
            txtMaPhong.Text = "";
            txtSoLuong.Text = "";
            txtDango.Text = "";
            txtGiaphong.Text = "";
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        // Check xem đã điền đầy đủ giá trị trong txt hay chưa 
        private bool Check_Value()
        {
            if (txtMaPhong.Text.Trim().Length == 0) // Nếu chưa nhập gì trong txt
            {
                MessageBox.Show("Bạn chưa nhập mã phòng", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPhong.Focus();
                return true;
            }

            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng max", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return true;
            }


            if (txtDango.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng đang ở", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDango.Focus();
                return true;
            }


            if (txtGiaphong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập giá phòng", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaphong.Focus();
                return true;
            }

            return false;
        }

        // Nút tìm kiếm
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtGiaphong.Text == "") && (txtMaPhong.Text == "") && (txtSoLuong.Text == "") && (txtDango.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from Phong WHERE 1=1";
            if (txtMaPhong.Text != "")
                sql += " AND maphong LIKE '%" + txtMaPhong.Text + "%'";
            if (txtSoLuong.Text != "")
                sql += " AND slmax LIKE '%" + txtSoLuong.Text + "%'";
            if (txtGiaphong.Text != "")
                sql += " AND giaphong LIKE '%" + txtGiaphong + "%'";


            tblPhong = Function.GetDataToTable(sql);
            if (tblPhong.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblPhong.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvPhong.DataSource = tblPhong;
            ResetValue();
        }
    }
}

