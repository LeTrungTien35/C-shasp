namespace AppQuanLyBanHang
{
    partial class frmSmart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSmart));
            this.label1 = new System.Windows.Forms.Label();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btntktyc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmaphong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvQLSV = new System.Windows.Forms.DataGridView();
            this.mssv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dantoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hokhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maphong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slmax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaphong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btntktp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(589, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm kiếm theo yêu cầu";
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Location = new System.Drawing.Point(651, 118);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(47, 17);
            this.rdoNam.TabIndex = 3;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(704, 118);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(39, 17);
            this.rdoNu.TabIndex = 4;
            this.rdoNu.TabStop = true;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Giới tính:";
            // 
            // btntktyc
            // 
            this.btntktyc.Location = new System.Drawing.Point(788, 110);
            this.btntktyc.Name = "btntktyc";
            this.btntktyc.Size = new System.Drawing.Size(85, 33);
            this.btntktyc.TabIndex = 6;
            this.btntktyc.Text = "Tìm kiếm";
            this.btntktyc.UseVisualStyleBackColor = true;
            this.btntktyc.Click += new System.EventHandler(this.btntktyc_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(110, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tìm kiếm theo phòng";
            // 
            // txtmaphong
            // 
            this.txtmaphong.Location = new System.Drawing.Point(115, 117);
            this.txtmaphong.Name = "txtmaphong";
            this.txtmaphong.Size = new System.Drawing.Size(119, 20);
            this.txtmaphong.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mã phòng:";
            // 
            // dgvQLSV
            // 
            this.dgvQLSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mssv,
            this.hoten,
            this.gioitinh,
            this.ngaysinh,
            this.dantoc,
            this.tongiao,
            this.hokhau,
            this.lop,
            this.maphong});
            this.dgvQLSV.Location = new System.Drawing.Point(2, 203);
            this.dgvQLSV.Name = "dgvQLSV";
            this.dgvQLSV.Size = new System.Drawing.Size(452, 245);
            this.dgvQLSV.TabIndex = 17;
            // 
            // mssv
            // 
            this.mssv.DataPropertyName = "mssv";
            this.mssv.HeaderText = "Mã sinh viên";
            this.mssv.Name = "mssv";
            this.mssv.Width = 120;
            // 
            // hoten
            // 
            this.hoten.DataPropertyName = "hoten";
            this.hoten.HeaderText = "Tên sinh viên";
            this.hoten.Name = "hoten";
            this.hoten.Width = 110;
            // 
            // gioitinh
            // 
            this.gioitinh.DataPropertyName = "gioitinh";
            this.gioitinh.HeaderText = "Giới tính";
            this.gioitinh.Name = "gioitinh";
            this.gioitinh.Width = 60;
            // 
            // ngaysinh
            // 
            this.ngaysinh.DataPropertyName = "ngaysinh";
            this.ngaysinh.HeaderText = "Ngày sinh";
            this.ngaysinh.Name = "ngaysinh";
            // 
            // dantoc
            // 
            this.dantoc.DataPropertyName = "dantoc";
            this.dantoc.HeaderText = "Dân tộc";
            this.dantoc.Name = "dantoc";
            this.dantoc.Width = 60;
            // 
            // tongiao
            // 
            this.tongiao.DataPropertyName = "tongiao";
            this.tongiao.HeaderText = "Tôn giáo";
            this.tongiao.Name = "tongiao";
            this.tongiao.Width = 60;
            // 
            // hokhau
            // 
            this.hokhau.DataPropertyName = "hokhau";
            this.hokhau.HeaderText = "Hộ khẩu thường trú";
            this.hokhau.Name = "hokhau";
            this.hokhau.Width = 250;
            // 
            // lop
            // 
            this.lop.DataPropertyName = "lop";
            this.lop.HeaderText = "Lớp";
            this.lop.Name = "lop";
            this.lop.Width = 68;
            // 
            // maphong
            // 
            this.maphong.DataPropertyName = "maphong";
            this.maphong.HeaderText = "Phòng";
            this.maphong.Name = "maphong";
            this.maphong.Width = 60;
            // 
            // dgvPhong
            // 
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.slmax,
            this.slo,
            this.dataGridViewTextBoxColumn2,
            this.giaphong});
            this.dgvPhong.Location = new System.Drawing.Point(460, 203);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.Size = new System.Drawing.Size(455, 245);
            this.dgvPhong.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "maphong";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã phòng";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // slmax
            // 
            this.slmax.DataPropertyName = "slmax";
            this.slmax.HeaderText = "Số lượng Max";
            this.slmax.Name = "slmax";
            this.slmax.Width = 114;
            // 
            // slo
            // 
            this.slo.DataPropertyName = "slo";
            this.slo.HeaderText = "Số lượng đang ở";
            this.slo.Name = "slo";
            this.slo.Width = 114;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "gioitinh";
            this.dataGridViewTextBoxColumn2.HeaderText = "Giới tính";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 114;
            // 
            // giaphong
            // 
            this.giaphong.DataPropertyName = "giaphong";
            this.giaphong.HeaderText = "Giá phòng";
            this.giaphong.Name = "giaphong";
            this.giaphong.Width = 200;
            // 
            // btntktp
            // 
            this.btntktp.Location = new System.Drawing.Point(274, 110);
            this.btntktp.Name = "btntktp";
            this.btntktp.Size = new System.Drawing.Size(85, 33);
            this.btntktp.TabIndex = 20;
            this.btntktp.Text = "Tìm kiếm";
            this.btntktp.UseVisualStyleBackColor = true;
            this.btntktp.Click += new System.EventHandler(this.btntktp_Click);
            // 
            // frmSmart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 450);
            this.Controls.Add(this.btntktp);
            this.Controls.Add(this.dgvPhong);
            this.Controls.Add(this.dgvQLSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtmaphong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btntktyc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdoNu);
            this.Controls.Add(this.rdoNam);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSmart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm thông minh";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btntktyc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmaphong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvQLSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn mssv;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dantoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn hokhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn maphong;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn slmax;
        private System.Windows.Forms.DataGridViewTextBoxColumn slo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaphong;
        private System.Windows.Forms.Button btntktp;
    }
}