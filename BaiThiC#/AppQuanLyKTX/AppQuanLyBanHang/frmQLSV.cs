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
    public partial class frmQLSV : Form
    {
        DataTable tblQLSV; // Tạo bảng để hứng dữ liệu
        String masv; // Lưu mã sinh viên khi Click vào DataGridView
        public frmQLSV()
        {
            InitializeComponent();
        }

        // Hàm load dữ liệu lên bảng khi Load frm QLSV
        private void frmQLSV_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        // Truyền dữ liệu từ tblQLSV sang datagridview
        private void LoadDataGridView()
        {
            string sql = "SELECT * FROM SinhVien";

            tblQLSV = Function.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvQLSV.DataSource = tblQLSV; //Nguồn dữ liệu                      
            dgvQLSV.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvQLSV.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        // xử lý sự kiện click vào dgv Băm nhỏ dữ liệu từ datagridview sang textbox     
        private void dgvQLSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvQLSV.CurrentRow.Index;
            txtTenSV.Text = dgvQLSV.Rows[i].Cells[1].Value.ToString();
            txtMaSV.Text = dgvQLSV.Rows[i].Cells[0].Value.ToString();
            dtpSV.Value = (DateTime)dgvQLSV.Rows[i].Cells[3].Value;
            txtHokhau.Text = dgvQLSV.Rows[i].Cells[6].Value.ToString();
            txtDantoc.Text = dgvQLSV.Rows[i].Cells[4].Value.ToString();
            txtTongiao.Text = dgvQLSV.Rows[i].Cells[5].Value.ToString();
            txtLop.Text = dgvQLSV.Rows[i].Cells[7].Value.ToString();
            txtphong.Text = dgvQLSV.Rows[i].Cells[8].Value.ToString();
            // So sánh hai chuỗi không phân biệt chữ hoa chữ thường
            if (String.Compare(dgvQLSV.Rows[i].Cells[2].Value.ToString(), "Nam", true) == 0)
            {
                rdonam.Checked = true;
            }
            else
            {
                rdonu.Checked = true;
            }
            // Chuyển mã sinh viên vào biến masv
            masv = dgvQLSV.Rows[i].Cells[0].Value.ToString();
            // Khi click vào một dòng thì Enable 2 nút xóa và sửa
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Nút xóa sinh viên 
        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql;
            if(MessageBox.Show("Bạn có muốn xóa sinh viên này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                sql = "DELETE FROM SinhVien WHERE mssv = '" + txtMaSV.Text.Trim() + "'";
                Function.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
                btnXoa.Enabled = false;
            }                
        }

        // Nút thêm mới một sinh viên 
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtTenSV.Focus();
        }

        // Hàm xóa dữ liệu trong txtbox
        private void ResetValue()
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtHokhau.Text = "";
            dtpSV.Value = DateTime.Now;
            txtTongiao.Text = "";
            txtDantoc.Text = "";
            txtLop.Text = "";
            txtphong.Text = "";
            rdonam.Checked = false;
            rdonu.Checked = false;
        }

        // Nút lưu sinh viên vào cơ sở dữ liệu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            String sql;
            String gt = "";

            if (Check_Value() == true) return;

            sql = "SELECT mssv FROM SinhVien WHERE mssv = '" + txtMaSV.Text.Trim() + "'"; 
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }
            if (rdonam.Checked == true)
            {
                gt = "Nam";
            }
            else gt = "Nữ";

            sql = "INSERT INTO SinhVien VALUES('" + txtMaSV.Text + "',N'" + txtTenSV.Text + "',N'" + gt
                + "','" + dtpSV.Value.ToString("yyyy/MM/dd") + "', N'" + txtDantoc.Text + "', N'" + txtTongiao.Text + "', N'"
                + txtHokhau.Text + "', N'" + txtLop.Text + "'," + txtphong.Text + ")";

            Function.RunSQL(sql); // Chạy câu lệnh sql
            LoadDataGridView(); // Làm mới dữ liệu
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
  

        // Sửa(UPDATE) dữ liệu
        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql;
            String gt = "";

            if (Check_Value() == true) return;

            // Check mã sinh viên
            sql = "SELECT mssv FROM SinhVien WHERE mssv = '" + txtMaSV.Text.Trim() + "'";
            if (String.Compare(txtMaSV.Text, masv, true) != 0 && Function.CheckKey(sql))  
            {
                MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }
            // xách định giới tính
            if (rdonam.Checked == true)
            {
                gt = "Nam";
            }
            else gt = "Nữ";

            sql = "UPDATE SinhVien SET mssv = '" + txtMaSV.Text + "', hoten = N'" + txtTenSV.Text + "', gioitinh = N'" + gt + "', ngaysinh = N'"
                + dtpSV.Value.ToString("yyyy/MM/dd") + "', dantoc = N'" + txtDantoc.Text + "', tongiao = N'" + txtTongiao.Text + "', hokhau = N'"
                + txtHokhau.Text + "', lop = '" + txtLop.Text + "', maphong = " + txtphong.Text + " WHERE mssv = '" + masv + "'";
            Function.RunSQL(sql);
            LoadDataGridView();
            btnSua.Enabled = false;
            MessageBox.Show("Đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Đóng form 
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Nút làm mới
        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
        }

        // Nút load danh sách
        private void btnDanhsach_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        // Check xem đã điền đầy đủ giá trị trong txt hay chưa 
        private bool Check_Value()
        {
            if (txtTenSV.Text.Trim().Length == 0) // Nếu chưa nhập gì trong txt
            {
                MessageBox.Show("Bạn chưa nhập tên sinh viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSV.Focus();
                return true;
            }

            if (txtMaSV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return true;
            }
            

            if (txtHokhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập hộ khẩu", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHokhau.Focus();
                return true;
            }


            if (txtDantoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập dân tộc", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return true;
            }


            if (txtTongiao.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tôn giáo", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTongiao.Focus();
                return true;
            }


            if (txtLop.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập lớp sinh viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLop.Focus();
                return true;
            }


            if (txtphong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập phòng sinh viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtphong.Focus();
                return true;
            }

            if (rdonam.Checked == false && rdonu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        // Nút tìm kiếm
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;        
            sql = "SELECT * from SinhVien WHERE 1=1";
            if (txtMaSV.Text != "")
                sql += " AND mssv LIKE N'%" + txtMaSV.Text + "%'";
            if (txtTenSV.Text != "")
                sql += " AND hoten LIKE N'%" + txtTenSV.Text + "%'";
            if (txtHokhau.Text != "")
                sql += " AND hokhau LIKE N'%" + txtHokhau + "%'";


            tblQLSV = Function.GetDataToTable(sql);
            if (tblQLSV.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblQLSV.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvQLSV.DataSource = tblQLSV;
            ResetValue();
        }

        private void btnTKTP_Click(object sender, EventArgs e)
        {
            new frmSmart().Show();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }
    }
}
