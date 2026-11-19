namespace ProjectTaskManagement.GUI
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabQuanLy = new System.Windows.Forms.TabPage();
            this.grpCongViec = new System.Windows.Forms.GroupBox();
            this.btnLuuPhanCong = new System.Windows.Forms.Button();
            this.btnXoaTask = new System.Windows.Forms.Button();
            this.btnSuaTask = new System.Windows.Forms.Button();
            this.btnThemTask = new System.Windows.Forms.Button();
            this.clbThanhVien = new System.Windows.Forms.CheckedListBox();
            this.lblPhanCong = new System.Windows.Forms.Label();
            this.btnChuyenTrangThai = new System.Windows.Forms.Button();
            this.cboTrangThaiTask = new System.Windows.Forms.ComboBox();
            this.lblTrangThaiTask = new System.Windows.Forms.Label();
            this.cboDoUuTien = new System.Windows.Forms.ComboBox();
            this.lblDoUuTien = new System.Windows.Forms.Label();
            this.dtpHanNop = new System.Windows.Forms.DateTimePicker();
            this.lblHanNop = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtTenTask = new System.Windows.Forms.TextBox();
            this.lblTenTask = new System.Windows.Forms.Label();
            this.dgvCongViec = new System.Windows.Forms.DataGridView();
            this.btnLocTask = new System.Windows.Forms.Button();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblLocTT = new System.Windows.Forms.Label();
            this.cboLocDuAn = new System.Windows.Forms.ComboBox();
            this.lblLocDA = new System.Windows.Forms.Label();
            this.grpDuAn = new System.Windows.Forms.GroupBox();
            this.btnLamMoiDA = new System.Windows.Forms.Button();
            this.btnXoaDA = new System.Windows.Forms.Button();
            this.btnSuaDA = new System.Windows.Forms.Button();
            this.btnThemDA = new System.Windows.Forms.Button();
            this.cboTrangThaiDA = new System.Windows.Forms.ComboBox();
            this.lblTrangThaiDA = new System.Windows.Forms.Label();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.txtTenDuAn = new System.Windows.Forms.TextBox();
            this.lblTenDuAn = new System.Windows.Forms.Label();
            this.dgvDuAn = new System.Windows.Forms.DataGridView();
            this.tabKanban = new System.Windows.Forms.TabPage();
            this.tlpKanban = new System.Windows.Forms.TableLayoutPanel();
            this.grpDone = new System.Windows.Forms.GroupBox();
            this.lstDone = new System.Windows.Forms.ListBox();
            this.grpReview = new System.Windows.Forms.GroupBox();
            this.lstReview = new System.Windows.Forms.ListBox();
            this.grpInProgress = new System.Windows.Forms.GroupBox();
            this.lstInProgress = new System.Windows.Forms.ListBox();
            this.grpToDo = new System.Windows.Forms.GroupBox();
            this.lstToDo = new System.Windows.Forms.ListBox();
            this.btnMarkDone = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnTaiKanban = new System.Windows.Forms.Button();
            this.cboKanbanDuAn = new System.Windows.Forms.ComboBox();
            this.lblKanbanDA = new System.Windows.Forms.Label();
            this.tabBaoCao = new System.Windows.Forms.TabPage();
            this.tlpBaoCao = new System.Windows.Forms.TableLayoutPanel();
            this.grpThongKe = new System.Windows.Forms.GroupBox();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.lblTongTienDoDA = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.cboThongKeDuAn = new System.Windows.Forms.ComboBox();
            this.lblThongKeDA = new System.Windows.Forms.Label();
            this.grpOverdue = new System.Windows.Forms.GroupBox();
            this.dgvOverdue = new System.Windows.Forms.DataGridView();
            this.btnTaiOverdue = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabQuanLy.SuspendLayout();
            this.grpCongViec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongViec)).BeginInit();
            this.grpDuAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuAn)).BeginInit();
            this.tabKanban.SuspendLayout();
            this.tlpKanban.SuspendLayout();
            this.grpDone.SuspendLayout();
            this.grpReview.SuspendLayout();
            this.grpInProgress.SuspendLayout();
            this.grpToDo.SuspendLayout();
            this.tabBaoCao.SuspendLayout();
            this.tlpBaoCao.SuspendLayout();
            this.grpThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.grpOverdue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabQuanLy);
            this.tabControlMain.Controls.Add(this.tabKanban);
            this.tabControlMain.Controls.Add(this.tabBaoCao);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1156, 696);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabQuanLy
            // 
            this.tabQuanLy.Controls.Add(this.grpCongViec);
            this.tabQuanLy.Controls.Add(this.grpDuAn);
            this.tabQuanLy.Location = new System.Drawing.Point(4, 24);
            this.tabQuanLy.Name = "tabQuanLy";
            this.tabQuanLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuanLy.Size = new System.Drawing.Size(1148, 668);
            this.tabQuanLy.TabIndex = 0;
            this.tabQuanLy.Text = "1. Quản lý Dự án & Công việc (List View)";
            this.tabQuanLy.UseVisualStyleBackColor = true;
            // 
            // grpCongViec
            // 
            this.grpCongViec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCongViec.Controls.Add(this.btnLuuPhanCong);
            this.grpCongViec.Controls.Add(this.btnXoaTask);
            this.grpCongViec.Controls.Add(this.btnSuaTask);
            this.grpCongViec.Controls.Add(this.btnThemTask);
            this.grpCongViec.Controls.Add(this.clbThanhVien);
            this.grpCongViec.Controls.Add(this.lblPhanCong);
            this.grpCongViec.Controls.Add(this.btnChuyenTrangThai);
            this.grpCongViec.Controls.Add(this.cboTrangThaiTask);
            this.grpCongViec.Controls.Add(this.lblTrangThaiTask);
            this.grpCongViec.Controls.Add(this.cboDoUuTien);
            this.grpCongViec.Controls.Add(this.lblDoUuTien);
            this.grpCongViec.Controls.Add(this.dtpHanNop);
            this.grpCongViec.Controls.Add(this.lblHanNop);
            this.grpCongViec.Controls.Add(this.txtMoTa);
            this.grpCongViec.Controls.Add(this.lblMoTa);
            this.grpCongViec.Controls.Add(this.txtTenTask);
            this.grpCongViec.Controls.Add(this.lblTenTask);
            this.grpCongViec.Controls.Add(this.dgvCongViec);
            this.grpCongViec.Controls.Add(this.btnLocTask);
            this.grpCongViec.Controls.Add(this.cboLocTrangThai);
            this.grpCongViec.Controls.Add(this.lblLocTT);
            this.grpCongViec.Controls.Add(this.cboLocDuAn);
            this.grpCongViec.Controls.Add(this.lblLocDA);
            this.grpCongViec.Location = new System.Drawing.Point(440, 10);
            this.grpCongViec.Name = "grpCongViec";
            this.grpCongViec.Size = new System.Drawing.Size(698, 645);
            this.grpCongViec.TabIndex = 1;
            this.grpCongViec.TabStop = false;
            this.grpCongViec.Text = "Danh sách Công việc (Task) & Phân công Thành viên";
            // 
            // btnLuuPhanCong
            // 
            this.btnLuuPhanCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuPhanCong.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLuuPhanCong.Location = new System.Drawing.Point(450, 585);
            this.btnLuuPhanCong.Name = "btnLuuPhanCong";
            this.btnLuuPhanCong.Size = new System.Drawing.Size(236, 38);
            this.btnLuuPhanCong.TabIndex = 22;
            this.btnLuuPhanCong.Text = "Lưu Phân Công Cho Task";
            this.btnLuuPhanCong.UseVisualStyleBackColor = false;
            this.btnLuuPhanCong.Click += new System.EventHandler(this.btnLuuPhanCong_Click);
            // 
            // btnXoaTask
            // 
            this.btnXoaTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaTask.Location = new System.Drawing.Point(252, 585);
            this.btnXoaTask.Name = "btnXoaTask";
            this.btnXoaTask.Size = new System.Drawing.Size(110, 38);
            this.btnXoaTask.TabIndex = 21;
            this.btnXoaTask.Text = "Xóa Task";
            this.btnXoaTask.UseVisualStyleBackColor = true;
            this.btnXoaTask.Click += new System.EventHandler(this.btnXoaTask_Click);
            // 
            // btnSuaTask
            // 
            this.btnSuaTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaTask.Location = new System.Drawing.Point(132, 585);
            this.btnSuaTask.Name = "btnSuaTask";
            this.btnSuaTask.Size = new System.Drawing.Size(110, 38);
            this.btnSuaTask.TabIndex = 20;
            this.btnSuaTask.Text = "Cập nhật Task";
            this.btnSuaTask.UseVisualStyleBackColor = true;
            this.btnSuaTask.Click += new System.EventHandler(this.btnSuaTask_Click);
            // 
            // btnThemTask
            // 
            this.btnThemTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemTask.Location = new System.Drawing.Point(12, 585);
            this.btnThemTask.Name = "btnThemTask";
            this.btnThemTask.Size = new System.Drawing.Size(110, 38);
            this.btnThemTask.TabIndex = 19;
            this.btnThemTask.Text = "Thêm Task";
            this.btnThemTask.UseVisualStyleBackColor = true;
            this.btnThemTask.Click += new System.EventHandler(this.btnThemTask_Click);
            // 
            // clbThanhVien
            // 
            this.clbThanhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clbThanhVien.CheckOnClick = true;
            this.clbThanhVien.FormattingEnabled = true;
            this.clbThanhVien.Location = new System.Drawing.Point(450, 425);
            this.clbThanhVien.Name = "clbThanhVien";
            this.clbThanhVien.Size = new System.Drawing.Size(236, 139);
            this.clbThanhVien.TabIndex = 18;
            // 
            // lblPhanCong
            // 
            this.lblPhanCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhanCong.AutoSize = true;
            this.lblPhanCong.Location = new System.Drawing.Point(450, 403);
            this.lblPhanCong.Name = "lblPhanCong";
            this.lblPhanCong.Size = new System.Drawing.Size(134, 15);
            this.lblPhanCong.TabIndex = 17;
            this.lblPhanCong.Text = "Phân công thành viên:";
            // 
            // btnChuyenTrangThai
            // 
            this.btnChuyenTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChuyenTrangThai.BackColor = System.Drawing.Color.PaleGreen;
            this.btnChuyenTrangThai.Location = new System.Drawing.Point(265, 534);
            this.btnChuyenTrangThai.Name = "btnChuyenTrangThai";
            this.btnChuyenTrangThai.Size = new System.Drawing.Size(170, 27);
            this.btnChuyenTrangThai.TabIndex = 16;
            this.btnChuyenTrangThai.Text = "Chuyển trạng thái tiếp >>";
            this.btnChuyenTrangThai.UseVisualStyleBackColor = false;
            this.btnChuyenTrangThai.Click += new System.EventHandler(this.btnChuyenTrangThai_Click);
            // 
            // cboTrangThaiTask
            // 
            this.cboTrangThaiTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboTrangThaiTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiTask.FormattingEnabled = true;
            this.cboTrangThaiTask.Items.AddRange(new object[] { "To Do", "In Progress", "Review", "Done" });
            this.cboTrangThaiTask.Location = new System.Drawing.Point(105, 535);
            this.cboTrangThaiTask.Name = "cboTrangThaiTask";
            this.cboTrangThaiTask.Size = new System.Drawing.Size(150, 23);
            this.cboTrangThaiTask.TabIndex = 15;
            // 
            // lblTrangThaiTask
            // 
            this.lblTrangThaiTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrangThaiTask.AutoSize = true;
            this.lblTrangThaiTask.Location = new System.Drawing.Point(12, 538);
            this.lblTrangThaiTask.Name = "lblTrangThaiTask";
            this.lblTrangThaiTask.Size = new System.Drawing.Size(65, 15);
            this.lblTrangThaiTask.TabIndex = 14;
            this.lblTrangThaiTask.Text = "Trạng thái:";
            // 
            // cboDoUuTien
            // 
            this.cboDoUuTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDoUuTien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoUuTien.FormattingEnabled = true;
            this.cboDoUuTien.Items.AddRange(new object[] { "Cao", "Trung bình", "Thấp" });
            this.cboDoUuTien.Location = new System.Drawing.Point(330, 500);
            this.cboDoUuTien.Name = "cboDoUuTien";
            this.cboDoUuTien.Size = new System.Drawing.Size(105, 23);
            this.cboDoUuTien.TabIndex = 13;
            // 
            // lblDoUuTien
            // 
            this.lblDoUuTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDoUuTien.AutoSize = true;
            this.lblDoUuTien.Location = new System.Drawing.Point(265, 503);
            this.lblDoUuTien.Name = "lblDoUuTien";
            this.lblDoUuTien.Size = new System.Drawing.Size(57, 15);
            this.lblDoUuTien.TabIndex = 12;
            this.lblDoUuTien.Text = "Ưu tiên:";
            // 
            // dtpHanNop
            // 
            this.dtpHanNop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpHanNop.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHanNop.Location = new System.Drawing.Point(105, 500);
            this.dtpHanNop.Name = "dtpHanNop";
            this.dtpHanNop.Size = new System.Drawing.Size(150, 23);
            this.dtpHanNop.TabIndex = 11;
            // 
            // lblHanNop
            // 
            this.lblHanNop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHanNop.AutoSize = true;
            this.lblHanNop.Location = new System.Drawing.Point(12, 503);
            this.lblHanNop.Name = "lblHanNop";
            this.lblHanNop.Size = new System.Drawing.Size(59, 15);
            this.lblHanNop.TabIndex = 10;
            this.lblHanNop.Text = "Hạn nộp:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(105, 435);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(330, 55);
            this.txtMoTa.TabIndex = 9;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(12, 438);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(42, 15);
            this.lblMoTa.TabIndex = 8;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtTenTask
            // 
            this.txtTenTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenTask.Location = new System.Drawing.Point(105, 400);
            this.txtTenTask.Name = "txtTenTask";
            this.txtTenTask.Size = new System.Drawing.Size(330, 23);
            this.txtTenTask.TabIndex = 7;
            // 
            // lblTenTask
            // 
            this.lblTenTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTenTask.AutoSize = true;
            this.lblTenTask.Location = new System.Drawing.Point(12, 403);
            this.lblTenTask.Name = "lblTenTask";
            this.lblTenTask.Size = new System.Drawing.Size(59, 15);
            this.lblTenTask.TabIndex = 6;
            this.lblTenTask.Text = "Tên Task:";
            // 
            // dgvCongViec
            // 
            this.dgvCongViec.AllowUserToAddRows = false;
            this.dgvCongViec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCongViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongViec.Location = new System.Drawing.Point(12, 62);
            this.dgvCongViec.MultiSelect = false;
            this.dgvCongViec.Name = "dgvCongViec";
            this.dgvCongViec.ReadOnly = true;
            this.dgvCongViec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongViec.Size = new System.Drawing.Size(674, 325);
            this.dgvCongViec.TabIndex = 5;
            this.dgvCongViec.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCongViec_CellClick);
            // 
            // btnLocTask
            // 
            this.btnLocTask.Location = new System.Drawing.Point(560, 24);
            this.btnLocTask.Name = "btnLocTask";
            this.btnLocTask.Size = new System.Drawing.Size(126, 27);
            this.btnLocTask.TabIndex = 4;
            this.btnLocTask.Text = "Lọc Danh Sách";
            this.btnLocTask.UseVisualStyleBackColor = true;
            this.btnLocTask.Click += new System.EventHandler(this.btnLocTask_Click);
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "To Do", "In Progress", "Review", "Done" });
            this.cboLocTrangThai.Location = new System.Drawing.Point(395, 25);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(150, 23);
            this.cboLocTrangThai.TabIndex = 3;
            // 
            // lblLocTT
            // 
            this.lblLocTT.AutoSize = true;
            this.lblLocTT.Location = new System.Drawing.Point(320, 28);
            this.lblLocTT.Name = "lblLocTT";
            this.lblLocTT.Size = new System.Drawing.Size(65, 15);
            this.lblLocTT.TabIndex = 2;
            this.lblLocTT.Text = "Trạng thái:";
            // 
            // cboLocDuAn
            // 
            this.cboLocDuAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocDuAn.FormattingEnabled = true;
            this.cboLocDuAn.Location = new System.Drawing.Point(85, 25);
            this.cboLocDuAn.Name = "cboLocDuAn";
            this.cboLocDuAn.Size = new System.Drawing.Size(220, 23);
            this.cboLocDuAn.TabIndex = 1;
            // 
            // lblLocDA
            // 
            this.lblLocDA.AutoSize = true;
            this.lblLocDA.Location = new System.Drawing.Point(12, 28);
            this.lblLocDA.Name = "lblLocDA";
            this.lblLocDA.Size = new System.Drawing.Size(44, 15);
            this.lblLocDA.TabIndex = 0;
            this.lblLocDA.Text = "Dự án:";
            // 
            // grpDuAn
            // 
            this.grpDuAn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpDuAn.Controls.Add(this.btnLamMoiDA);
            this.grpDuAn.Controls.Add(this.btnXoaDA);
            this.grpDuAn.Controls.Add(this.btnSuaDA);
            this.grpDuAn.Controls.Add(this.btnThemDA);
            this.grpDuAn.Controls.Add(this.cboTrangThaiDA);
            this.grpDuAn.Controls.Add(this.lblTrangThaiDA);
            this.grpDuAn.Controls.Add(this.dtpNgayKT);
            this.grpDuAn.Controls.Add(this.lblNgayKT);
            this.grpDuAn.Controls.Add(this.dtpNgayBD);
            this.grpDuAn.Controls.Add(this.lblNgayBD);
            this.grpDuAn.Controls.Add(this.txtTenDuAn);
            this.grpDuAn.Controls.Add(this.lblTenDuAn);
            this.grpDuAn.Controls.Add(this.dgvDuAn);
            this.grpDuAn.Location = new System.Drawing.Point(10, 10);
            this.grpDuAn.Name = "grpDuAn";
            this.grpDuAn.Size = new System.Drawing.Size(420, 645);
            this.grpDuAn.TabIndex = 0;
            this.grpDuAn.TabStop = false;
            this.grpDuAn.Text = "Quản lý Dự án";
            // 
            // btnLamMoiDA
            // 
            this.btnLamMoiDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLamMoiDA.Location = new System.Drawing.Point(315, 585);
            this.btnLamMoiDA.Name = "btnLamMoiDA";
            this.btnLamMoiDA.Size = new System.Drawing.Size(93, 38);
            this.btnLamMoiDA.TabIndex = 12;
            this.btnLamMoiDA.Text = "Làm mới";
            this.btnLamMoiDA.UseVisualStyleBackColor = true;
            this.btnLamMoiDA.Click += new System.EventHandler(this.btnLamMoiDA_Click);
            // 
            // btnXoaDA
            // 
            this.btnXoaDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaDA.Location = new System.Drawing.Point(214, 585);
            this.btnXoaDA.Name = "btnXoaDA";
            this.btnXoaDA.Size = new System.Drawing.Size(92, 38);
            this.btnXoaDA.TabIndex = 11;
            this.btnXoaDA.Text = "Xóa DA";
            this.btnXoaDA.UseVisualStyleBackColor = true;
            this.btnXoaDA.Click += new System.EventHandler(this.btnXoaDA_Click);
            // 
            // btnSuaDA
            // 
            this.btnSuaDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaDA.Location = new System.Drawing.Point(113, 585);
            this.btnSuaDA.Name = "btnSuaDA";
            this.btnSuaDA.Size = new System.Drawing.Size(92, 38);
            this.btnSuaDA.TabIndex = 10;
            this.btnSuaDA.Text = "Sửa DA";
            this.btnSuaDA.UseVisualStyleBackColor = true;
            this.btnSuaDA.Click += new System.EventHandler(this.btnSuaDA_Click);
            // 
            // btnThemDA
            // 
            this.btnThemDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemDA.Location = new System.Drawing.Point(12, 585);
            this.btnThemDA.Name = "btnThemDA";
            this.btnThemDA.Size = new System.Drawing.Size(92, 38);
            this.btnThemDA.TabIndex = 9;
            this.btnThemDA.Text = "Thêm DA";
            this.btnThemDA.UseVisualStyleBackColor = true;
            this.btnThemDA.Click += new System.EventHandler(this.btnThemDA_Click);
            // 
            // cboTrangThaiDA
            // 
            this.cboTrangThaiDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboTrangThaiDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiDA.FormattingEnabled = true;
            this.cboTrangThaiDA.Items.AddRange(new object[] { "Đang chạy", "Hoàn thành", "Tạm dừng" });
            this.cboTrangThaiDA.Location = new System.Drawing.Point(115, 532);
            this.cboTrangThaiDA.Name = "cboTrangThaiDA";
            this.cboTrangThaiDA.Size = new System.Drawing.Size(293, 23);
            this.cboTrangThaiDA.TabIndex = 8;
            // 
            // lblTrangThaiDA
            // 
            this.lblTrangThaiDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrangThaiDA.AutoSize = true;
            this.lblTrangThaiDA.Location = new System.Drawing.Point(12, 535);
            this.lblTrangThaiDA.Name = "lblTrangThaiDA";
            this.lblTrangThaiDA.Size = new System.Drawing.Size(65, 15);
            this.lblTrangThaiDA.TabIndex = 7;
            this.lblTrangThaiDA.Text = "Trạng thái:";
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKT.Location = new System.Drawing.Point(115, 492);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(293, 23);
            this.dtpNgayKT.TabIndex = 6;
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNgayKT.AutoSize = true;
            this.lblNgayKT.Location = new System.Drawing.Point(12, 495);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(84, 15);
            this.lblNgayKT.TabIndex = 5;
            this.lblNgayKT.Text = "Ngày kết thúc:";
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(115, 452);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(293, 23);
            this.dtpNgayBD.TabIndex = 4;
            // 
            // lblNgayBD
            // 
            this.lblNgayBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNgayBD.AutoSize = true;
            this.lblNgayBD.Location = new System.Drawing.Point(12, 455);
            this.lblNgayBD.Name = "lblNgayBD";
            this.lblNgayBD.Size = new System.Drawing.Size(83, 15);
            this.lblNgayBD.TabIndex = 3;
            this.lblNgayBD.Text = "Ngày bắt đầu:";
            // 
            // txtTenDuAn
            // 
            this.txtTenDuAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTenDuAn.Location = new System.Drawing.Point(115, 412);
            this.txtTenDuAn.Name = "txtTenDuAn";
            this.txtTenDuAn.Size = new System.Drawing.Size(293, 23);
            this.txtTenDuAn.TabIndex = 2;
            // 
            // lblTenDuAn
            // 
            this.lblTenDuAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTenDuAn.AutoSize = true;
            this.lblTenDuAn.Location = new System.Drawing.Point(12, 415);
            this.lblTenDuAn.Name = "lblTenDuAn";
            this.lblTenDuAn.Size = new System.Drawing.Size(65, 15);
            this.lblTenDuAn.TabIndex = 1;
            this.lblTenDuAn.Text = "Tên dự án:";
            // 
            // dgvDuAn
            // 
            this.dgvDuAn.AllowUserToAddRows = false;
            this.dgvDuAn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDuAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDuAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuAn.Location = new System.Drawing.Point(12, 25);
            this.dgvDuAn.MultiSelect = false;
            this.dgvDuAn.Name = "dgvDuAn";
            this.dgvDuAn.ReadOnly = true;
            this.dgvDuAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDuAn.Size = new System.Drawing.Size(396, 370);
            this.dgvDuAn.TabIndex = 0;
            this.dgvDuAn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDuAn_CellClick);
            // 
            // tabKanban
            // 
            this.tabKanban.Controls.Add(this.tlpKanban);
            this.tabKanban.Controls.Add(this.btnMarkDone);
            this.tabKanban.Controls.Add(this.btnMoveRight);
            this.tabKanban.Controls.Add(this.btnMoveLeft);
            this.tabKanban.Controls.Add(this.btnTaiKanban);
            this.tabKanban.Controls.Add(this.cboKanbanDuAn);
            this.tabKanban.Controls.Add(this.lblKanbanDA);
            this.tabKanban.Location = new System.Drawing.Point(4, 24);
            this.tabKanban.Name = "tabKanban";
            this.tabKanban.Padding = new System.Windows.Forms.Padding(3);
            this.tabKanban.Size = new System.Drawing.Size(1148, 668);
            this.tabKanban.TabIndex = 1;
            this.tabKanban.Text = "2. Bảng Tiến Độ (Kanban View)";
            this.tabKanban.UseVisualStyleBackColor = true;
            // 
            // tlpKanban
            // 
            this.tlpKanban.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpKanban.ColumnCount = 4;
            this.tlpKanban.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKanban.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKanban.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKanban.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKanban.Controls.Add(this.grpToDo, 0, 0);
            this.tlpKanban.Controls.Add(this.grpInProgress, 1, 0);
            this.tlpKanban.Controls.Add(this.grpReview, 2, 0);
            this.tlpKanban.Controls.Add(this.grpDone, 3, 0);
            this.tlpKanban.Location = new System.Drawing.Point(15, 55);
            this.tlpKanban.Name = "tlpKanban";
            this.tlpKanban.RowCount = 1;
            this.tlpKanban.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKanban.Size = new System.Drawing.Size(1118, 598);
            this.tlpKanban.TabIndex = 10;
            // 
            // grpDone
            // 
            this.grpDone.Controls.Add(this.lstDone);
            this.grpDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDone.Location = new System.Drawing.Point(842, 5);
            this.grpDone.Margin = new System.Windows.Forms.Padding(5);
            this.grpDone.Name = "grpDone";
            this.grpDone.Padding = new System.Windows.Forms.Padding(8);
            this.grpDone.Size = new System.Drawing.Size(271, 588);
            this.grpDone.TabIndex = 9;
            this.grpDone.TabStop = false;
            this.grpDone.Text = "DONE (Hoàn thành)";
            // 
            // lstDone
            // 
            this.lstDone.BackColor = System.Drawing.Color.Honeydew;
            this.lstDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDone.FormattingEnabled = true;
            this.lstDone.ItemHeight = 15;
            this.lstDone.Location = new System.Drawing.Point(8, 22);
            this.lstDone.Name = "lstDone";
            this.lstDone.Size = new System.Drawing.Size(255, 558);
            this.lstDone.TabIndex = 0;
            this.lstDone.SelectedIndexChanged += new System.EventHandler(this.KanbanList_SelectedIndexChanged);
            // 
            // grpReview
            // 
            this.grpReview.Controls.Add(this.lstReview);
            this.grpReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReview.Location = new System.Drawing.Point(563, 5);
            this.grpReview.Margin = new System.Windows.Forms.Padding(5);
            this.grpReview.Name = "grpReview";
            this.grpReview.Padding = new System.Windows.Forms.Padding(8);
            this.grpReview.Size = new System.Drawing.Size(269, 588);
            this.grpReview.TabIndex = 8;
            this.grpReview.TabStop = false;
            this.grpReview.Text = "REVIEW (Đang kiểm tra)";
            // 
            // lstReview
            // 
            this.lstReview.BackColor = System.Drawing.Color.LavenderBlush;
            this.lstReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstReview.FormattingEnabled = true;
            this.lstReview.ItemHeight = 15;
            this.lstReview.Location = new System.Drawing.Point(8, 22);
            this.lstReview.Name = "lstReview";
            this.lstReview.Size = new System.Drawing.Size(253, 558);
            this.lstReview.TabIndex = 0;
            this.lstReview.SelectedIndexChanged += new System.EventHandler(this.KanbanList_SelectedIndexChanged);
            // 
            // grpInProgress
            // 
            this.grpInProgress.Controls.Add(this.lstInProgress);
            this.grpInProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInProgress.Location = new System.Drawing.Point(284, 5);
            this.grpInProgress.Margin = new System.Windows.Forms.Padding(5);
            this.grpInProgress.Name = "grpInProgress";
            this.grpInProgress.Padding = new System.Windows.Forms.Padding(8);
            this.grpInProgress.Size = new System.Drawing.Size(269, 588);
            this.grpInProgress.TabIndex = 7;
            this.grpInProgress.TabStop = false;
            this.grpInProgress.Text = "IN PROGRESS (Đang làm)";
            // 
            // lstInProgress
            // 
            this.lstInProgress.BackColor = System.Drawing.Color.LightYellow;
            this.lstInProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInProgress.FormattingEnabled = true;
            this.lstInProgress.ItemHeight = 15;
            this.lstInProgress.Location = new System.Drawing.Point(8, 22);
            this.lstInProgress.Name = "lstInProgress";
            this.lstInProgress.Size = new System.Drawing.Size(253, 558);
            this.lstInProgress.TabIndex = 0;
            this.lstInProgress.SelectedIndexChanged += new System.EventHandler(this.KanbanList_SelectedIndexChanged);
            // 
            // grpToDo
            // 
            this.grpToDo.Controls.Add(this.lstToDo);
            this.grpToDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpToDo.Location = new System.Drawing.Point(5, 5);
            this.grpToDo.Margin = new System.Windows.Forms.Padding(5);
            this.grpToDo.Name = "grpToDo";
            this.grpToDo.Padding = new System.Windows.Forms.Padding(8);
            this.grpToDo.Size = new System.Drawing.Size(269, 588);
            this.grpToDo.TabIndex = 6;
            this.grpToDo.TabStop = false;
            this.grpToDo.Text = "TO DO (Cần làm)";
            // 
            // lstToDo
            // 
            this.lstToDo.BackColor = System.Drawing.Color.AliceBlue;
            this.lstToDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstToDo.FormattingEnabled = true;
            this.lstToDo.ItemHeight = 15;
            this.lstToDo.Location = new System.Drawing.Point(8, 22);
            this.lstToDo.Name = "lstToDo";
            this.lstToDo.Size = new System.Drawing.Size(253, 558);
            this.lstToDo.TabIndex = 0;
            this.lstToDo.SelectedIndexChanged += new System.EventHandler(this.KanbanList_SelectedIndexChanged);
            // 
            // btnMarkDone
            // 
            this.btnMarkDone.BackColor = System.Drawing.Color.PaleGreen;
            this.btnMarkDone.Location = new System.Drawing.Point(855, 14);
            this.btnMarkDone.Name = "btnMarkDone";
            this.btnMarkDone.Size = new System.Drawing.Size(160, 28);
            this.btnMarkDone.TabIndex = 5;
            this.btnMarkDone.Text = "Đánh dấu Done ✔";
            this.btnMarkDone.UseVisualStyleBackColor = false;
            this.btnMarkDone.Click += new System.EventHandler(this.btnMarkDone_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Location = new System.Drawing.Point(700, 14);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(145, 28);
            this.btnMoveRight.TabIndex = 4;
            this.btnMoveRight.Text = "Chuyển bước tiếp >>";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Location = new System.Drawing.Point(555, 14);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(135, 28);
            this.btnMoveLeft.TabIndex = 3;
            this.btnMoveLeft.Text = "<< Lùi bước trước";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // btnTaiKanban
            // 
            this.btnTaiKanban.Location = new System.Drawing.Point(425, 14);
            this.btnTaiKanban.Name = "btnTaiKanban";
            this.btnTaiKanban.Size = new System.Drawing.Size(110, 28);
            this.btnTaiKanban.TabIndex = 2;
            this.btnTaiKanban.Text = "Tải Bảng Kanban";
            this.btnTaiKanban.UseVisualStyleBackColor = true;
            this.btnTaiKanban.Click += new System.EventHandler(this.btnTaiKanban_Click);
            // 
            // cboKanbanDuAn
            // 
            this.cboKanbanDuAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKanbanDuAn.FormattingEnabled = true;
            this.cboKanbanDuAn.Location = new System.Drawing.Point(110, 16);
            this.cboKanbanDuAn.Name = "cboKanbanDuAn";
            this.cboKanbanDuAn.Size = new System.Drawing.Size(300, 23);
            this.cboKanbanDuAn.TabIndex = 1;
            // 
            // lblKanbanDA
            // 
            this.lblKanbanDA.AutoSize = true;
            this.lblKanbanDA.Location = new System.Drawing.Point(15, 19);
            this.lblKanbanDA.Name = "lblKanbanDA";
            this.lblKanbanDA.Size = new System.Drawing.Size(76, 15);
            this.lblKanbanDA.TabIndex = 0;
            this.lblKanbanDA.Text = "Chọn Dự án:";
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.tlpBaoCao);
            this.tabBaoCao.Location = new System.Drawing.Point(4, 24);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao.Size = new System.Drawing.Size(1148, 668);
            this.tabBaoCao.TabIndex = 2;
            this.tabBaoCao.Text = "3. Cảnh báo Trễ hạn & Báo cáo Tiến độ";
            this.tabBaoCao.UseVisualStyleBackColor = true;
            // 
            // tlpBaoCao
            // 
            this.tlpBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpBaoCao.ColumnCount = 1;
            this.tlpBaoCao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBaoCao.Controls.Add(this.grpOverdue, 0, 0);
            this.tlpBaoCao.Controls.Add(this.grpThongKe, 0, 1);
            this.tlpBaoCao.Location = new System.Drawing.Point(15, 15);
            this.tlpBaoCao.Name = "tlpBaoCao";
            this.tlpBaoCao.RowCount = 2;
            this.tlpBaoCao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tlpBaoCao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tlpBaoCao.Size = new System.Drawing.Size(1118, 638);
            this.tlpBaoCao.TabIndex = 2;
            // 
            // grpThongKe
            // 
            this.grpThongKe.Controls.Add(this.dgvThongKe);
            this.grpThongKe.Controls.Add(this.lblTongTienDoDA);
            this.grpThongKe.Controls.Add(this.btnThongKe);
            this.grpThongKe.Controls.Add(this.cboThongKeDuAn);
            this.grpThongKe.Controls.Add(this.lblThongKeDA);
            this.grpThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongKe.Location = new System.Drawing.Point(3, 309);
            this.grpThongKe.Name = "grpThongKe";
            this.grpThongKe.Size = new System.Drawing.Size(1112, 326);
            this.grpThongKe.TabIndex = 1;
            this.grpThongKe.TabStop = false;
            this.grpThongKe.Text = "Thống kê Tỷ lệ % Hoàn thành Công việc của Thành viên (GROUP BY & ExecuteScalar)";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(15, 62);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.Size = new System.Drawing.Size(1082, 251);
            this.dgvThongKe.TabIndex = 4;
            // 
            // lblTongTienDoDA
            // 
            this.lblTongTienDoDA.AutoSize = true;
            this.lblTongTienDoDA.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongTienDoDA.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTongTienDoDA.Location = new System.Drawing.Point(550, 28);
            this.lblTongTienDoDA.Name = "lblTongTienDoDA";
            this.lblTongTienDoDA.Size = new System.Drawing.Size(219, 17);
            this.lblTongTienDoDA.TabIndex = 3;
            this.lblTongTienDoDA.Text = "Tiến độ hoàn thành dự án: 0%";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(400, 24);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(130, 28);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Xem Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // cboThongKeDuAn
            // 
            this.cboThongKeDuAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThongKeDuAn.FormattingEnabled = true;
            this.cboThongKeDuAn.Location = new System.Drawing.Point(105, 25);
            this.cboThongKeDuAn.Name = "cboThongKeDuAn";
            this.cboThongKeDuAn.Size = new System.Drawing.Size(280, 23);
            this.cboThongKeDuAn.TabIndex = 1;
            // 
            // lblThongKeDA
            // 
            this.lblThongKeDA.AutoSize = true;
            this.lblThongKeDA.Location = new System.Drawing.Point(15, 28);
            this.lblThongKeDA.Name = "lblThongKeDA";
            this.lblThongKeDA.Size = new System.Drawing.Size(76, 15);
            this.lblThongKeDA.TabIndex = 0;
            this.lblThongKeDA.Text = "Chọn Dự án:";
            // 
            // grpOverdue
            // 
            this.grpOverdue.Controls.Add(this.dgvOverdue);
            this.grpOverdue.Controls.Add(this.btnTaiOverdue);
            this.grpOverdue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOverdue.Location = new System.Drawing.Point(3, 3);
            this.grpOverdue.Name = "grpOverdue";
            this.grpOverdue.Size = new System.Drawing.Size(1112, 300);
            this.grpOverdue.TabIndex = 0;
            this.grpOverdue.TabStop = false;
            this.grpOverdue.Text = "Cảnh báo Công việc Trễ hạn (Quá HanNop & Trạng thái != Done - Đọc bằng SqlDataReader)";
            // 
            // dgvOverdue
            // 
            this.dgvOverdue.AllowUserToAddRows = false;
            this.dgvOverdue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOverdue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOverdue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdue.Location = new System.Drawing.Point(15, 58);
            this.dgvOverdue.Name = "dgvOverdue";
            this.dgvOverdue.ReadOnly = true;
            this.dgvOverdue.Size = new System.Drawing.Size(1082, 229);
            this.dgvOverdue.TabIndex = 1;
            // 
            // btnTaiOverdue
            // 
            this.btnTaiOverdue.BackColor = System.Drawing.Color.MistyRose;
            this.btnTaiOverdue.Location = new System.Drawing.Point(15, 22);
            this.btnTaiOverdue.Name = "btnTaiOverdue";
            this.btnTaiOverdue.Size = new System.Drawing.Size(210, 28);
            this.btnTaiOverdue.TabIndex = 0;
            this.btnTaiOverdue.Text = "Kiểm tra Task Trễ Hạn";
            this.btnTaiOverdue.UseVisualStyleBackColor = false;
            this.btnTaiOverdue.Click += new System.EventHandler(this.btnTaiOverdue_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.MinimumSize = new System.Drawing.Size(1180, 680);
            this.Controls.Add(this.tabControlMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Công Việc & Tiến Độ Dự Án (Bài 6.3 - 3-Tier)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabQuanLy.ResumeLayout(false);
            this.grpCongViec.ResumeLayout(false);
            this.grpCongViec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongViec)).EndInit();
            this.grpDuAn.ResumeLayout(false);
            this.grpDuAn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuAn)).EndInit();
            this.tabKanban.ResumeLayout(false);
            this.tabKanban.PerformLayout();
            this.tlpKanban.ResumeLayout(false);
            this.grpDone.ResumeLayout(false);
            this.grpReview.ResumeLayout(false);
            this.grpInProgress.ResumeLayout(false);
            this.grpToDo.ResumeLayout(false);
            this.tabBaoCao.ResumeLayout(false);
            this.tlpBaoCao.ResumeLayout(false);
            this.grpThongKe.ResumeLayout(false);
            this.grpThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.grpOverdue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabQuanLy;
        private System.Windows.Forms.TabPage tabKanban;
        private System.Windows.Forms.TabPage tabBaoCao;
        private System.Windows.Forms.GroupBox grpDuAn;
        private System.Windows.Forms.DataGridView dgvDuAn;
        private System.Windows.Forms.Label lblTenDuAn;
        private System.Windows.Forms.TextBox txtTenDuAn;
        private System.Windows.Forms.Label lblNgayBD;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.Label lblTrangThaiDA;
        private System.Windows.Forms.ComboBox cboTrangThaiDA;
        private System.Windows.Forms.Button btnThemDA;
        private System.Windows.Forms.Button btnSuaDA;
        private System.Windows.Forms.Button btnXoaDA;
        private System.Windows.Forms.Button btnLamMoiDA;
        private System.Windows.Forms.GroupBox grpCongViec;
        private System.Windows.Forms.Label lblLocDA;
        private System.Windows.Forms.ComboBox cboLocDuAn;
        private System.Windows.Forms.Label lblLocTT;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnLocTask;
        private System.Windows.Forms.DataGridView dgvCongViec;
        private System.Windows.Forms.Label lblTenTask;
        private System.Windows.Forms.TextBox txtTenTask;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblHanNop;
        private System.Windows.Forms.DateTimePicker dtpHanNop;
        private System.Windows.Forms.Label lblDoUuTien;
        private System.Windows.Forms.ComboBox cboDoUuTien;
        private System.Windows.Forms.Label lblTrangThaiTask;
        private System.Windows.Forms.ComboBox cboTrangThaiTask;
        private System.Windows.Forms.Button btnChuyenTrangThai;
        private System.Windows.Forms.Label lblPhanCong;
        private System.Windows.Forms.CheckedListBox clbThanhVien;
        private System.Windows.Forms.Button btnThemTask;
        private System.Windows.Forms.Button btnSuaTask;
        private System.Windows.Forms.Button btnXoaTask;
        private System.Windows.Forms.Button btnLuuPhanCong;
        private System.Windows.Forms.Label lblKanbanDA;
        private System.Windows.Forms.ComboBox cboKanbanDuAn;
        private System.Windows.Forms.Button btnTaiKanban;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMarkDone;
        private System.Windows.Forms.TableLayoutPanel tlpKanban;
        private System.Windows.Forms.GroupBox grpToDo;
        private System.Windows.Forms.ListBox lstToDo;
        private System.Windows.Forms.GroupBox grpInProgress;
        private System.Windows.Forms.ListBox lstInProgress;
        private System.Windows.Forms.GroupBox grpReview;
        private System.Windows.Forms.ListBox lstReview;
        private System.Windows.Forms.GroupBox grpDone;
        private System.Windows.Forms.ListBox lstDone;
        private System.Windows.Forms.TableLayoutPanel tlpBaoCao;
        private System.Windows.Forms.GroupBox grpOverdue;
        private System.Windows.Forms.Button btnTaiOverdue;
        private System.Windows.Forms.DataGridView dgvOverdue;
        private System.Windows.Forms.GroupBox grpThongKe;
        private System.Windows.Forms.Label lblThongKeDA;
        private System.Windows.Forms.ComboBox cboThongKeDuAn;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label lblTongTienDoDA;
        private System.Windows.Forms.DataGridView dgvThongKe;
    }
}
