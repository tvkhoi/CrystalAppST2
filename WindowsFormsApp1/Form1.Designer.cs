namespace WindowsFormsApp1
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_inbangdiem = new System.Windows.Forms.Button();
            this.btn_group = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.tb_tencvht = new System.Windows.Forms.TextBox();
            this.cb_malop = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_inDDSV = new System.Windows.Forms.Button();
            this.dt_ngaysinh = new System.Windows.Forms.DateTimePicker();
            this.mask_ngaysinh = new System.Windows.Forms.MaskedTextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_huybo = new System.Windows.Forms.Button();
            this.btn_xoabo = new System.Windows.Forms.Button();
            this.tb_sdt = new System.Windows.Forms.TextBox();
            this.btn_chinhsua = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_diachi = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.rb_nu = new System.Windows.Forms.RadioButton();
            this.rb_nam = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_tensv = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.tb_masv = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_dssv = new System.Windows.Forms.DataGridView();
            this.MaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dssv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_inbangdiem);
            this.groupBox1.Controls.Add(this.btn_group);
            this.groupBox1.Controls.Add(this.btn_thoat);
            this.groupBox1.Controls.Add(this.tb_tencvht);
            this.groupBox1.Controls.Add(this.cb_malop);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btn_inDDSV);
            this.groupBox1.Controls.Add(this.dt_ngaysinh);
            this.groupBox1.Controls.Add(this.mask_ngaysinh);
            this.groupBox1.Controls.Add(this.btn_timkiem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_huybo);
            this.groupBox1.Controls.Add(this.btn_xoabo);
            this.groupBox1.Controls.Add(this.tb_sdt);
            this.groupBox1.Controls.Add(this.btn_chinhsua);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_diachi);
            this.groupBox1.Controls.Add(this.btn_them);
            this.groupBox1.Controls.Add(this.rb_nu);
            this.groupBox1.Controls.Add(this.rb_nam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_tensv);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.tb_masv);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 520);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // btn_inbangdiem
            // 
            this.btn_inbangdiem.BackColor = System.Drawing.SystemColors.Control;
            this.btn_inbangdiem.Location = new System.Drawing.Point(800, 400);
            this.btn_inbangdiem.Name = "btn_inbangdiem";
            this.btn_inbangdiem.Size = new System.Drawing.Size(201, 48);
            this.btn_inbangdiem.TabIndex = 23;
            this.btn_inbangdiem.Text = "In bảng điểm";
            this.btn_inbangdiem.UseVisualStyleBackColor = false;
            this.btn_inbangdiem.Click += new System.EventHandler(this.btn_inbangdiem_Click);
            // 
            // btn_group
            // 
            this.btn_group.BackColor = System.Drawing.SystemColors.Control;
            this.btn_group.Location = new System.Drawing.Point(800, 346);
            this.btn_group.Name = "btn_group";
            this.btn_group.Size = new System.Drawing.Size(201, 48);
            this.btn_group.TabIndex = 22;
            this.btn_group.Text = "In nhóm lớp";
            this.btn_group.UseVisualStyleBackColor = false;
            this.btn_group.Click += new System.EventHandler(this.btn_group_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.BackColor = System.Drawing.SystemColors.Control;
            this.btn_thoat.Location = new System.Drawing.Point(800, 454);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(201, 48);
            this.btn_thoat.TabIndex = 21;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = false;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // tb_tencvht
            // 
            this.tb_tencvht.Location = new System.Drawing.Point(222, 459);
            this.tb_tencvht.Name = "tb_tencvht";
            this.tb_tencvht.ReadOnly = true;
            this.tb_tencvht.Size = new System.Drawing.Size(543, 39);
            this.tb_tencvht.TabIndex = 20;
            // 
            // cb_malop
            // 
            this.cb_malop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_malop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_malop.FormattingEnabled = true;
            this.cb_malop.Location = new System.Drawing.Point(222, 401);
            this.cb_malop.Name = "cb_malop";
            this.cb_malop.Size = new System.Drawing.Size(247, 40);
            this.cb_malop.TabIndex = 19;
            this.cb_malop.SelectedIndexChanged += new System.EventHandler(this.cb_malop_SelectedIndexChanged);
            this.cb_malop.TextChanged += new System.EventHandler(this.cb_malop_TextChanged);
            this.cb_malop.Validating += new System.ComponentModel.CancelEventHandler(this.cb_malop_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 466);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 32);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tên CVHT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 32);
            this.label6.TabIndex = 17;
            this.label6.Text = "Mã lớp HC";
            // 
            // btn_inDDSV
            // 
            this.btn_inDDSV.BackColor = System.Drawing.SystemColors.Control;
            this.btn_inDDSV.Location = new System.Drawing.Point(800, 292);
            this.btn_inDDSV.Name = "btn_inDDSV";
            this.btn_inDDSV.Size = new System.Drawing.Size(201, 48);
            this.btn_inDDSV.TabIndex = 16;
            this.btn_inDDSV.Text = "In DDSV";
            this.btn_inDDSV.UseVisualStyleBackColor = false;
            this.btn_inDDSV.Click += new System.EventHandler(this.btn_inDSSV_Click);
            // 
            // dt_ngaysinh
            // 
            this.dt_ngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_ngaysinh.Location = new System.Drawing.Point(433, 276);
            this.dt_ngaysinh.Name = "dt_ngaysinh";
            this.dt_ngaysinh.Size = new System.Drawing.Size(36, 39);
            this.dt_ngaysinh.TabIndex = 15;
            this.dt_ngaysinh.ValueChanged += new System.EventHandler(this.dt_ngaysinh_ValueChanged);
            // 
            // mask_ngaysinh
            // 
            this.mask_ngaysinh.Location = new System.Drawing.Point(222, 276);
            this.mask_ngaysinh.Mask = "00/00/0000";
            this.mask_ngaysinh.Name = "mask_ngaysinh";
            this.mask_ngaysinh.Size = new System.Drawing.Size(247, 39);
            this.mask_ngaysinh.TabIndex = 14;
            this.mask_ngaysinh.ValidatingType = typeof(System.DateTime);
            this.mask_ngaysinh.Validating += new System.ComponentModel.CancelEventHandler(this.mask_ngaysinh_Validating);
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.BackColor = System.Drawing.SystemColors.Control;
            this.btn_timkiem.Location = new System.Drawing.Point(800, 238);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(201, 48);
            this.btn_timkiem.TabIndex = 13;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = false;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Số điện thoại";
            // 
            // btn_huybo
            // 
            this.btn_huybo.BackColor = System.Drawing.SystemColors.Control;
            this.btn_huybo.Location = new System.Drawing.Point(800, 76);
            this.btn_huybo.Name = "btn_huybo";
            this.btn_huybo.Size = new System.Drawing.Size(201, 48);
            this.btn_huybo.TabIndex = 12;
            this.btn_huybo.Text = "Bỏ qua";
            this.btn_huybo.UseVisualStyleBackColor = false;
            this.btn_huybo.Click += new System.EventHandler(this.btn_huybo_Click);
            // 
            // btn_xoabo
            // 
            this.btn_xoabo.BackColor = System.Drawing.SystemColors.Control;
            this.btn_xoabo.Location = new System.Drawing.Point(800, 184);
            this.btn_xoabo.Name = "btn_xoabo";
            this.btn_xoabo.Size = new System.Drawing.Size(201, 48);
            this.btn_xoabo.TabIndex = 11;
            this.btn_xoabo.Text = "Xoá bỏ";
            this.btn_xoabo.UseVisualStyleBackColor = false;
            this.btn_xoabo.Click += new System.EventHandler(this.btn_xoabo_Click);
            // 
            // tb_sdt
            // 
            this.tb_sdt.Location = new System.Drawing.Point(222, 161);
            this.tb_sdt.Name = "tb_sdt";
            this.tb_sdt.Size = new System.Drawing.Size(543, 39);
            this.tb_sdt.TabIndex = 11;
            this.tb_sdt.TextChanged += new System.EventHandler(this.tb_sdt_TextChanged);
            this.tb_sdt.Validating += new System.ComponentModel.CancelEventHandler(this.tb_sdt_Validating);
            // 
            // btn_chinhsua
            // 
            this.btn_chinhsua.BackColor = System.Drawing.SystemColors.Control;
            this.btn_chinhsua.Location = new System.Drawing.Point(800, 130);
            this.btn_chinhsua.Name = "btn_chinhsua";
            this.btn_chinhsua.Size = new System.Drawing.Size(201, 48);
            this.btn_chinhsua.TabIndex = 10;
            this.btn_chinhsua.Text = "Chỉnh sửa";
            this.btn_chinhsua.UseVisualStyleBackColor = false;
            this.btn_chinhsua.Click += new System.EventHandler(this.btn_chinhsua_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Địa chỉ";
            // 
            // tb_diachi
            // 
            this.tb_diachi.Location = new System.Drawing.Point(222, 217);
            this.tb_diachi.Name = "tb_diachi";
            this.tb_diachi.Size = new System.Drawing.Size(543, 39);
            this.tb_diachi.TabIndex = 9;
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.SystemColors.Control;
            this.btn_them.Enabled = false;
            this.btn_them.Location = new System.Drawing.Point(800, 22);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(201, 48);
            this.btn_them.TabIndex = 9;
            this.btn_them.Text = "Thêm mới";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // rb_nu
            // 
            this.rb_nu.AutoSize = true;
            this.rb_nu.Location = new System.Drawing.Point(392, 340);
            this.rb_nu.Name = "rb_nu";
            this.rb_nu.Size = new System.Drawing.Size(77, 36);
            this.rb_nu.TabIndex = 8;
            this.rb_nu.TabStop = true;
            this.rb_nu.Text = "Nữ";
            this.rb_nu.UseVisualStyleBackColor = true;
            // 
            // rb_nam
            // 
            this.rb_nam.AutoSize = true;
            this.rb_nam.Location = new System.Drawing.Point(222, 342);
            this.rb_nam.Name = "rb_nam";
            this.rb_nam.Size = new System.Drawing.Size(96, 36);
            this.rb_nam.TabIndex = 7;
            this.rb_nam.TabStop = true;
            this.rb_nam.Text = "Nam";
            this.rb_nam.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Giới tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày sinh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Họ tên sinh viên";
            // 
            // tb_tensv
            // 
            this.tb_tensv.Location = new System.Drawing.Point(222, 105);
            this.tb_tensv.Name = "tb_tensv";
            this.tb_tensv.Size = new System.Drawing.Size(543, 39);
            this.tb_tensv.TabIndex = 2;
            this.tb_tensv.TextChanged += new System.EventHandler(this.tb_tensv_TextChanged);
            this.tb_tensv.Validating += new System.ComponentModel.CancelEventHandler(this.tb_tensv_Validating);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(25, 51);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(151, 32);
            this.label.TabIndex = 1;
            this.label.Text = "Mã sinh viên";
            // 
            // tb_masv
            // 
            this.tb_masv.Location = new System.Drawing.Point(222, 48);
            this.tb_masv.Name = "tb_masv";
            this.tb_masv.Size = new System.Drawing.Size(543, 39);
            this.tb_masv.TabIndex = 0;
            this.tb_masv.TextChanged += new System.EventHandler(this.tb_masv_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_dssv);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 539);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1050, 521);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sinh viên";
            // 
            // dgv_dssv
            // 
            this.dgv_dssv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_dssv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dssv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSV,
            this.TenSV});
            this.dgv_dssv.Location = new System.Drawing.Point(0, 38);
            this.dgv_dssv.Name = "dgv_dssv";
            this.dgv_dssv.RowHeadersWidth = 82;
            this.dgv_dssv.RowTemplate.Height = 33;
            this.dgv_dssv.Size = new System.Drawing.Size(1029, 459);
            this.dgv_dssv.TabIndex = 0;
            this.dgv_dssv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dssv_CellClick);
            // 
            // MaSV
            // 
            this.MaSV.DataPropertyName = "sMaSV";
            this.MaSV.HeaderText = "Mã sinh viên";
            this.MaSV.MinimumWidth = 10;
            this.MaSV.Name = "MaSV";
            this.MaSV.Width = 236;
            // 
            // TenSV
            // 
            this.TenSV.DataPropertyName = "sHoTen";
            this.TenSV.HeaderText = "Họ tên sinh viên";
            this.TenSV.MinimumWidth = 10;
            this.TenSV.Name = "TenSV";
            this.TenSV.Width = 237;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 1072);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin sinh viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dssv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox tb_masv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_tensv;
        private System.Windows.Forms.DateTimePicker dt_ngaysinh;
        private System.Windows.Forms.MaskedTextBox mask_ngaysinh;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_huybo;
        private System.Windows.Forms.Button btn_xoabo;
        private System.Windows.Forms.TextBox tb_sdt;
        private System.Windows.Forms.Button btn_chinhsua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_diachi;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.RadioButton rb_nu;
        private System.Windows.Forms.RadioButton rb_nam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_dssv;
        private System.Windows.Forms.Button btn_inDDSV;
        private System.Windows.Forms.TextBox tb_tencvht;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSV;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_inbangdiem;
        private System.Windows.Forms.Button btn_group;
        private System.Windows.Forms.ComboBox cb_malop;
    }
}

