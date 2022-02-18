using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppQuanLyBanHang.Class;
using System.Data.SqlClient;
namespace AppQuanLyBanHang
{
    public partial class frmQLNV : Form
    {
        private DataTable tblNV;
        string msnv;
        public frmQLNV()
        {
            InitializeComponent();
        }

        // Những thao tác khi load form 
        private void frmQLNV_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        // Load data lên DataGridView
        private void LoadDataGridView()
        {
            string sql = "SELECT * FROM NhanVien";

            tblNV = Function.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvNhanvien.DataSource = tblNV; //Nguồn dữ liệu                      
            dgvNhanvien.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        // Băm nhỏ dữ liệu
        private void dgvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvNhanvien.CurrentRow.Index;
            txtManhanvien.Text = dgvNhanvien.Rows[i].Cells[0].Value.ToString();
            txtTen.Text = dgvNhanvien.Rows[i].Cells[1].Value.ToString();
            txtDiachi.Text = dgvNhanvien.Rows[i].Cells[3].Value.ToString();
            txtDienthoai.Text = dgvNhanvien.Rows[i].Cells[4].Value.ToString();

            if (String.Compare(dgvNhanvien.Rows[i].Cells[2].Value.ToString(), "Nam", true) == 0)
            {
                rdoNam.Checked = true;
            }
            else
            {
                rdoNu.Checked = true;
            }
            // Chuyển mã sinh viên vào biến masv
            msnv = dgvNhanvien.Rows[i].Cells[0].Value.ToString();
            // Khi click vào một dòng thì Enable 2 nút xóa và sửa
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtManhanvien.Focus();
        }

        // Nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql;
            if(MessageBox.Show("Bạn có muốn xóa nhân viên này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                sql = "DELETE FROM NhanVien WHERE manv = " + txtManhanvien.Text.Trim();
                Function.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
                btnXoa.Enabled = false;
            }    
            
        }

        // Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql;
            String gt = "";

            if (Check_Value() == true) return;

            // Check mã nhân viên
            sql = "SELECT manv FROM NhanVien WHERE manv = '" + txtManhanvien.Text.Trim() + "'";
            if (String.Compare(txtManhanvien.Text, msnv, true) != 0 && Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }
            // xách định giới tính
            if (rdoNam.Checked == true)
            {
                gt = "Nam";
            }
            else gt = "Nữ";

            sql = "UPDATE NhanVien SET manv = " + txtManhanvien.Text + " , hoten = N'" + txtTen.Text + "', gioitinh = N'" + gt
                + "', diachi = N'" + txtDiachi.Text + "', sdt = " + txtDienthoai.Text + " WHERE manv = " + msnv;
                  
            Function.RunSQL(sql);
            LoadDataGridView();
            btnSua.Enabled = false;
            MessageBox.Show("Đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            String sql;
            String gt = "";

            if (Check_Value() == true) return;

            sql = "SELECT manv FROM NhanVien WHERE manv = '" + txtManhanvien.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }
            if (rdoNam.Checked == true)
            {
                gt = "Nam";
            }
            else gt = "Nữ";

            sql = "INSERT INTO NhanVien VALUES(" + txtManhanvien.Text + ",N'" + txtTen.Text + "',N'" + gt
                +  "', N'" + txtDiachi.Text + "'," + txtDienthoai.Text + ")";

            Function.RunSQL(sql); // Chạy câu lệnh sql
            LoadDataGridView(); // Làm mới dữ liệu
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }


        // Nút làm mới
        private void btnLammoi_Click_1(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        // Nút đóng form
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm ResetValue
        private void ResetValue()
        {
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
            txtManhanvien.Text = "";
            txtTen.Text = "";
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
        }

        // Check xem đã điền đầy đủ giá trị trong txt hay chưa 
        private bool Check_Value()
        {
            if (txtManhanvien.Text.Trim().Length == 0) // Nếu chưa nhập gì trong txt
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManhanvien.Focus();
                return true;
            }

            if (txtTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTen.Focus();
                return true;
            }


            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return true;
            }


            if (txtDienthoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập điện thoại", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienthoai.Focus();
                return true;
            }
            
            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        // Nút xóa
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtDiachi.Text == "") && (txtDienthoai.Text == "") && (txtManhanvien.Text == "") && (txtTen.Text == "") && (rdoNam.Checked == false)
                && (rdoNu.Checked == false))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from NhanVien WHERE 1=1";
            if (txtTen.Text != "")
                sql += " AND hoten LIKE N'%" + txtTen.Text + "%'";
            if (txtManhanvien.Text != "")
                sql += " AND manv LIKE '%" + txtManhanvien.Text + "%'";
            if (txtDienthoai.Text != "")
                sql += " AND sdt LIKE '%" + txtDienthoai.Text + "%'";
            if (txtDiachi.Text != "")
                sql += " AND diachi LIKE N'%" + txtDiachi.Text + "%'";
            if(rdoNam.Checked == true)
                sql += " AND gioitinh LIKE N'%Nam%'";
            if (rdoNu.Checked == true)
                sql += " AND gioitinh LIKE N'%Nữ%'";


            tblNV = Function.GetDataToTable(sql);
            if (tblNV.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else 
            {
                MessageBox.Show("Có " + tblNV.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNhanvien.DataSource = tblNV;
            }
            
        }
    }
}
