using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppQuanLyBanHang.Class;

namespace AppQuanLyBanHang
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //kết nối csdl khi load form main
        private void frmMain_Load(object sender, EventArgs e)
        {
            Function.Connnect();
        }

        // Đóng kết nối csdl khi đóng form main
        private void mnuthoat_Click(object sender, EventArgs e)
        {
            Function.Disconnect();
            Application.Exit();
        }
        // Mở form quản lý sinh viên
        private void mnQLSV_Click(object sender, EventArgs e)
        {
            frmQLSV qlsv = new frmQLSV();
            qlsv.ShowDialog();
        }

        // Quản lý nhân viên
        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmQLNV Nhanvien = new frmQLNV();
            Nhanvien.ShowDialog();
        }

        // Quản lý phòng
        private void mnuPhong_Click(object sender, EventArgs e)
        {
            frmQLPhong Phong = new frmQLPhong();
            Phong.ShowDialog();
        }     

        private void mnuHopDong_Click(object sender, EventArgs e)
        {
            new frmHopDong().Show();        
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            new frmSmart().Show();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            new frmHoadon().Show();
        }
       
    }
}
