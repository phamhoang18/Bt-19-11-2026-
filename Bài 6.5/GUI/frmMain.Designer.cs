namespace KaraokeManagement.GUI
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
            this.components = new System.ComponentModel.Container();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPhongHat = new System.Windows.Forms.TabPage();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.grpThanhToan = new System.Windows.Forms.GroupBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txtHoaDonPreview = new System.Windows.Forms.TextBox();
            this.grpDichVuPhong = new System.Windows.Forms.GroupBox();
            this.dgvChiTietDV = new System.Windows.Forms.DataGridView();
            this.btnXoaDV = new System.Windows.Forms.Button();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.nudSoLuongDV = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongDV = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.lblChonDV = new System.Windows.Forms.Label();
            this.grpThongTinPhong = new System.Windows.Forms.GroupBox();
            this.btnMoPhong = new System.Windows.Forms.Button();
            this.lblTamTinhPhong = new System.Windows.Forms.Label();
            this.lblGioVaoChon = new System.Windows.Forms.Label();
            this.lblTrangThaiChon = new System.Windows.Forms.Label();
            this.lblGiaGioChon = new System.Windows.Forms.Label();
            this.lblTenPhongChon = new System.Windows.Forms.Label();
            this.grpSoDoPhong = new System.Windows.Forms.GroupBox();
            this.flpPhongHat = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTaiLaiPhong = new System.Windows.Forms.Button();
            this.cboLocLoaiPhong = new System.Windows.Forms.ComboBox();
            this.lblChuThich = new System.Windows.Forms.Label();
            this.tabQuanLy = new System.Windows.Forms.TabPage();
            this.tlpQuanLy = new System.Windows.Forms.TableLayoutPanel();
            this.grpLichSuHD = new System.Windows.Forms.GroupBox();
            this.dgvLichSuHD = new System.Windows.Forms.DataGridView();
            this.btnTaiLichSuHD = new System.Windows.Forms.Button();
            this.grpKhoDichVu = new System.Windows.Forms.GroupBox();
            this.btnLamMoiDV = new System.Windows.Forms.Button();
            this.btnSuaKhoDV = new System.Windows.Forms.Button();
            this.btnThemKhoDV = new System.Windows.Forms.Button();
            this.nudTonKhoDV = new System.Windows.Forms.NumericUpDown();
            this.lblTonKhoDV = new System.Windows.Forms.Label();
            this.txtDonGiaDV = new System.Windows.Forms.TextBox();
            this.lblDonGiaDV = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.lblTenDV = new System.Windows.Forms.Label();
            this.dgvKhoDichVu = new System.Windows.Forms.DataGridView();
            this.tmrCapNhatGio = new System.Windows.Forms.Timer(this.components);
            this.tabControlMain.SuspendLayout();
            this.tabPhongHat.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.grpThanhToan.SuspendLayout();
            this.grpDichVuPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongDV)).BeginInit();
            this.grpThongTinPhong.SuspendLayout();
            this.grpSoDoPhong.SuspendLayout();
            this.tabQuanLy.SuspendLayout();
            this.tlpQuanLy.SuspendLayout();
            this.grpLichSuHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuHD)).BeginInit();
            this.grpKhoDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTonKhoDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoDichVu)).BeginInit();
            this.SuspendLayout();

            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPhongHat);
            this.tabControlMain.Controls.Add(this.tabQuanLy);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1156, 696);
            this.tabControlMain.TabIndex = 0;

            this.tabPhongHat.Controls.Add(this.tlpMain);
            this.tabPhongHat.Location = new System.Drawing.Point(4, 24);
            this.tabPhongHat.Name = "tabPhongHat";
            this.tabPhongHat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhongHat.Size = new System.Drawing.Size(1148, 668);
            this.tabPhongHat.TabIndex = 0;
            this.tabPhongHat.Text = "1. Sơ đồ Phòng Hát, Gọi Dịch Vụ && Thanh Toán";
            this.tabPhongHat.UseVisualStyleBackColor = true;

            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tlpMain.Controls.Add(this.grpSoDoPhong, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRight, 1, 0);
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1142, 662);
            this.tlpMain.TabIndex = 0;

            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.grpThongTinPhong, 0, 0);
            this.tlpRight.Controls.Add(this.grpDichVuPhong, 0, 1);
            this.tlpRight.Controls.Add(this.grpThanhToan, 0, 2);
            this.tlpRight.Location = new System.Drawing.Point(551, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 3;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpRight.Size = new System.Drawing.Size(588, 656);
            this.tlpRight.TabIndex = 1;

            this.grpThanhToan.Controls.Add(this.btnThanhToan);
            this.grpThanhToan.Controls.Add(this.txtHoaDonPreview);
            this.grpThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThanhToan.Location = new System.Drawing.Point(3, 442);
            this.grpThanhToan.Name = "grpThanhToan";
            this.grpThanhToan.Size = new System.Drawing.Size(582, 211);
            this.grpThanhToan.TabIndex = 2;
            this.grpThanhToan.TabStop = false;
            this.grpThanhToan.Text = "Chi tiết Tính Tiền && Thanh Toán (SqlTransaction)";

            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BackColor = System.Drawing.Color.PaleGreen;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.Location = new System.Drawing.Point(335, 160);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(235, 42);
            this.btnThanhToan.TabIndex = 1;
            this.btnThanhToan.Text = "Thanh Toán && Trả Phòng";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            this.txtHoaDonPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoaDonPreview.BackColor = System.Drawing.Color.Ivory;
            this.txtHoaDonPreview.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtHoaDonPreview.Location = new System.Drawing.Point(12, 22);
            this.txtHoaDonPreview.Multiline = true;
            this.txtHoaDonPreview.Name = "txtHoaDonPreview";
            this.txtHoaDonPreview.ReadOnly = true;
            this.txtHoaDonPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHoaDonPreview.Size = new System.Drawing.Size(558, 130);
            this.txtHoaDonPreview.TabIndex = 0;

            this.grpDichVuPhong.Controls.Add(this.dgvChiTietDV);
            this.grpDichVuPhong.Controls.Add(this.btnXoaDV);
            this.grpDichVuPhong.Controls.Add(this.btnThemDV);
            this.grpDichVuPhong.Controls.Add(this.nudSoLuongDV);
            this.grpDichVuPhong.Controls.Add(this.lblSoLuongDV);
            this.grpDichVuPhong.Controls.Add(this.cboDichVu);
            this.grpDichVuPhong.Controls.Add(this.lblChonDV);
            this.grpDichVuPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDichVuPhong.Location = new System.Drawing.Point(3, 167);
            this.grpDichVuPhong.Name = "grpDichVuPhong";
            this.grpDichVuPhong.Size = new System.Drawing.Size(582, 269);
            this.grpDichVuPhong.TabIndex = 1;
            this.grpDichVuPhong.TabStop = false;
            this.grpDichVuPhong.Text = "Gọi Dịch Vụ / Đồ Uống (Disconnected Model - SqlDataAdapter + DataTable)";

            this.dgvChiTietDV.AllowUserToAddRows = false;
            this.dgvChiTietDV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietDV.Location = new System.Drawing.Point(12, 62);
            this.dgvChiTietDV.MultiSelect = false;
            this.dgvChiTietDV.Name = "dgvChiTietDV";
            this.dgvChiTietDV.ReadOnly = true;
            this.dgvChiTietDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietDV.Size = new System.Drawing.Size(558, 195);
            this.dgvChiTietDV.TabIndex = 6;

            this.btnXoaDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaDV.Location = new System.Drawing.Point(490, 24);
            this.btnXoaDV.Name = "btnXoaDV";
            this.btnXoaDV.Size = new System.Drawing.Size(80, 27);
            this.btnXoaDV.TabIndex = 5;
            this.btnXoaDV.Text = "Xóa món";
            this.btnXoaDV.UseVisualStyleBackColor = true;
            this.btnXoaDV.Click += new System.EventHandler(this.btnXoaDV_Click);

            this.btnThemDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemDV.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnThemDV.Location = new System.Drawing.Point(400, 24);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(84, 27);
            this.btnThemDV.TabIndex = 4;
            this.btnThemDV.Text = "+ Thêm";
            this.btnThemDV.UseVisualStyleBackColor = false;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);

            this.nudSoLuongDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSoLuongDV.Location = new System.Drawing.Point(335, 26);
            this.nudSoLuongDV.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.nudSoLuongDV.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuongDV.Name = "nudSoLuongDV";
            this.nudSoLuongDV.Size = new System.Drawing.Size(55, 23);
            this.nudSoLuongDV.TabIndex = 3;
            this.nudSoLuongDV.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.lblSoLuongDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoLuongDV.AutoSize = true;
            this.lblSoLuongDV.Location = new System.Drawing.Point(305, 29);
            this.lblSoLuongDV.Name = "lblSoLuongDV";
            this.lblSoLuongDV.Size = new System.Drawing.Size(25, 15);
            this.lblSoLuongDV.TabIndex = 2;
            this.lblSoLuongDV.Text = "SL:";

            this.cboDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(75, 26);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(222, 23);
            this.cboDichVu.TabIndex = 1;

            this.lblChonDV.AutoSize = true;
            this.lblChonDV.Location = new System.Drawing.Point(12, 29);
            this.lblChonDV.Name = "lblChonDV";
            this.lblChonDV.Size = new System.Drawing.Size(52, 15);
            this.lblChonDV.TabIndex = 0;
            this.lblChonDV.Text = "Dịch vụ:";

            this.grpThongTinPhong.Controls.Add(this.btnMoPhong);
            this.grpThongTinPhong.Controls.Add(this.lblTamTinhPhong);
            this.grpThongTinPhong.Controls.Add(this.lblGioVaoChon);
            this.grpThongTinPhong.Controls.Add(this.lblTrangThaiChon);
            this.grpThongTinPhong.Controls.Add(this.lblGiaGioChon);
            this.grpThongTinPhong.Controls.Add(this.lblTenPhongChon);
            this.grpThongTinPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTinPhong.Location = new System.Drawing.Point(3, 3);
            this.grpThongTinPhong.Name = "grpThongTinPhong";
            this.grpThongTinPhong.Size = new System.Drawing.Size(582, 158);
            this.grpThongTinPhong.TabIndex = 0;
            this.grpThongTinPhong.TabStop = false;
            this.grpThongTinPhong.Text = "Thông tin Phòng Đang Chọn && Nhận Phòng";

            this.btnMoPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoPhong.BackColor = System.Drawing.Color.LightGreen;
            this.btnMoPhong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMoPhong.Location = new System.Drawing.Point(390, 28);
            this.btnMoPhong.Name = "btnMoPhong";
            this.btnMoPhong.Size = new System.Drawing.Size(180, 50);
            this.btnMoPhong.TabIndex = 5;
            this.btnMoPhong.Text = "Mở Phòng Hát";
            this.btnMoPhong.UseVisualStyleBackColor = false;
            this.btnMoPhong.Click += new System.EventHandler(this.btnMoPhong_Click);

            this.lblTamTinhPhong.AutoSize = true;
            this.lblTamTinhPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTamTinhPhong.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTamTinhPhong.Location = new System.Drawing.Point(15, 125);
            this.lblTamTinhPhong.Name = "lblTamTinhPhong";
            this.lblTamTinhPhong.Size = new System.Drawing.Size(166, 15);
            this.lblTamTinhPhong.TabIndex = 4;
            this.lblTamTinhPhong.Text = "Thời lượng & Tiền phòng: --";

            this.lblGioVaoChon.AutoSize = true;
            this.lblGioVaoChon.Location = new System.Drawing.Point(15, 100);
            this.lblGioVaoChon.Name = "lblGioVaoChon";
            this.lblGioVaoChon.Size = new System.Drawing.Size(113, 15);
            this.lblGioVaoChon.TabIndex = 3;
            this.lblGioVaoChon.Text = "Giờ bắt đầu hát: --";

            this.lblTrangThaiChon.AutoSize = true;
            this.lblTrangThaiChon.Location = new System.Drawing.Point(15, 75);
            this.lblTrangThaiChon.Name = "lblTrangThaiChon";
            this.lblTrangThaiChon.Size = new System.Drawing.Size(80, 15);
            this.lblTrangThaiChon.TabIndex = 2;
            this.lblTrangThaiChon.Text = "Trạng thái: --";

            this.lblGiaGioChon.AutoSize = true;
            this.lblGiaGioChon.Location = new System.Drawing.Point(15, 50);
            this.lblGiaGioChon.Name = "lblGiaGioChon";
            this.lblGiaGioChon.Size = new System.Drawing.Size(86, 15);
            this.lblGiaGioChon.TabIndex = 1;
            this.lblGiaGioChon.Text = "Giá theo giờ: --";

            this.lblTenPhongChon.AutoSize = true;
            this.lblTenPhongChon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenPhongChon.Location = new System.Drawing.Point(15, 24);
            this.lblTenPhongChon.Name = "lblTenPhongChon";
            this.lblTenPhongChon.Size = new System.Drawing.Size(218, 19);
            this.lblTenPhongChon.TabIndex = 0;
            this.lblTenPhongChon.Text = "Vui lòng chọn phòng trên sơ đồ";

            this.grpSoDoPhong.Controls.Add(this.flpPhongHat);
            this.grpSoDoPhong.Controls.Add(this.btnTaiLaiPhong);
            this.grpSoDoPhong.Controls.Add(this.cboLocLoaiPhong);
            this.grpSoDoPhong.Controls.Add(this.lblChuThich);
            this.grpSoDoPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSoDoPhong.Location = new System.Drawing.Point(3, 3);
            this.grpSoDoPhong.Name = "grpSoDoPhong";
            this.grpSoDoPhong.Size = new System.Drawing.Size(542, 656);
            this.grpSoDoPhong.TabIndex = 0;
            this.grpSoDoPhong.TabStop = false;
            this.grpSoDoPhong.Text = "Sơ Đồ Phòng Hát Trực Quan (Visual Room Grid)";

            this.flpPhongHat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpPhongHat.AutoScroll = true;
            this.flpPhongHat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpPhongHat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPhongHat.Location = new System.Drawing.Point(12, 62);
            this.flpPhongHat.Name = "flpPhongHat";
            this.flpPhongHat.Padding = new System.Windows.Forms.Padding(8);
            this.flpPhongHat.Size = new System.Drawing.Size(518, 582);
            this.flpPhongHat.TabIndex = 3;

            this.btnTaiLaiPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaiLaiPhong.Location = new System.Drawing.Point(435, 24);
            this.btnTaiLaiPhong.Name = "btnTaiLaiPhong";
            this.btnTaiLaiPhong.Size = new System.Drawing.Size(95, 27);
            this.btnTaiLaiPhong.TabIndex = 2;
            this.btnTaiLaiPhong.Text = "Làm mới";
            this.btnTaiLaiPhong.UseVisualStyleBackColor = true;
            this.btnTaiLaiPhong.Click += new System.EventHandler(this.btnTaiLaiPhong_Click);

            this.cboLocLoaiPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiPhong.FormattingEnabled = true;
            this.cboLocLoaiPhong.Items.AddRange(new object[] { "Tất cả", "Thường", "VIP" });
            this.cboLocLoaiPhong.Location = new System.Drawing.Point(310, 26);
            this.cboLocLoaiPhong.Name = "cboLocLoaiPhong";
            this.cboLocLoaiPhong.Size = new System.Drawing.Size(115, 23);
            this.cboLocLoaiPhong.TabIndex = 1;
            this.cboLocLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cboLocLoaiPhong_SelectedIndexChanged);

            this.lblChuThich.AutoSize = true;
            this.lblChuThich.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChuThich.Location = new System.Drawing.Point(12, 29);
            this.lblChuThich.Name = "lblChuThich";
            this.lblChuThich.Size = new System.Drawing.Size(215, 15);
            this.lblChuThich.TabIndex = 0;
            this.lblChuThich.Text = "🟢 Xanh: Phòng Trống | 🔴 Đỏ: Đang hát";

            this.tabQuanLy.Controls.Add(this.tlpQuanLy);
            this.tabQuanLy.Location = new System.Drawing.Point(4, 24);
            this.tabQuanLy.Name = "tabQuanLy";
            this.tabQuanLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuanLy.Size = new System.Drawing.Size(1148, 668);
            this.tabQuanLy.TabIndex = 1;
            this.tabQuanLy.Text = "2. Quản lý Kho Dịch Vụ && Lịch Sử Hóa Đơn";
            this.tabQuanLy.UseVisualStyleBackColor = true;
 
            this.tlpQuanLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuanLy.ColumnCount = 2;
            this.tlpQuanLy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpQuanLy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpQuanLy.Controls.Add(this.grpKhoDichVu, 0, 0);
            this.tlpQuanLy.Controls.Add(this.grpLichSuHD, 1, 0);
            this.tlpQuanLy.Location = new System.Drawing.Point(3, 3);
            this.tlpQuanLy.Name = "tlpQuanLy";
            this.tlpQuanLy.RowCount = 1;
            this.tlpQuanLy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuanLy.Size = new System.Drawing.Size(1142, 662);
            this.tlpQuanLy.TabIndex = 0;

            this.grpLichSuHD.Controls.Add(this.dgvLichSuHD);
            this.grpLichSuHD.Controls.Add(this.btnTaiLichSuHD);
            this.grpLichSuHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLichSuHD.Location = new System.Drawing.Point(516, 3);
            this.grpLichSuHD.Name = "grpLichSuHD";
            this.grpLichSuHD.Size = new System.Drawing.Size(623, 656);
            this.grpLichSuHD.TabIndex = 1;
            this.grpLichSuHD.TabStop = false;
            this.grpLichSuHD.Text = "Lịch Sử Hóa Đơn Đã Thanh Toán";

            this.dgvLichSuHD.AllowUserToAddRows = false;
            this.dgvLichSuHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLichSuHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuHD.Location = new System.Drawing.Point(12, 60);
            this.dgvLichSuHD.Name = "dgvLichSuHD";
            this.dgvLichSuHD.ReadOnly = true;
            this.dgvLichSuHD.Size = new System.Drawing.Size(599, 584);
            this.dgvLichSuHD.TabIndex = 1;

            this.btnTaiLichSuHD.Location = new System.Drawing.Point(12, 24);
            this.btnTaiLichSuHD.Name = "btnTaiLichSuHD";
            this.btnTaiLichSuHD.Size = new System.Drawing.Size(150, 28);
            this.btnTaiLichSuHD.TabIndex = 0;
            this.btnTaiLichSuHD.Text = "Tải Lại Lịch Sử";
            this.btnTaiLichSuHD.UseVisualStyleBackColor = true;
            this.btnTaiLichSuHD.Click += new System.EventHandler(this.btnTaiLichSuHD_Click);

            this.grpKhoDichVu.Controls.Add(this.btnLamMoiDV);
            this.grpKhoDichVu.Controls.Add(this.btnSuaKhoDV);
            this.grpKhoDichVu.Controls.Add(this.btnThemKhoDV);
            this.grpKhoDichVu.Controls.Add(this.nudTonKhoDV);
            this.grpKhoDichVu.Controls.Add(this.lblTonKhoDV);
            this.grpKhoDichVu.Controls.Add(this.txtDonGiaDV);
            this.grpKhoDichVu.Controls.Add(this.lblDonGiaDV);
            this.grpKhoDichVu.Controls.Add(this.txtTenDV);
            this.grpKhoDichVu.Controls.Add(this.lblTenDV);
            this.grpKhoDichVu.Controls.Add(this.dgvKhoDichVu);
            this.grpKhoDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKhoDichVu.Location = new System.Drawing.Point(3, 3);
            this.grpKhoDichVu.Name = "grpKhoDichVu";
            this.grpKhoDichVu.Size = new System.Drawing.Size(507, 656);
            this.grpKhoDichVu.TabIndex = 0;
            this.grpKhoDichVu.TabStop = false;
            this.grpKhoDichVu.Text = "Quản Lý Kho Đồ Uống && Dịch Vụ";

            this.btnLamMoiDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLamMoiDV.Location = new System.Drawing.Point(255, 595);
            this.btnLamMoiDV.Name = "btnLamMoiDV";
            this.btnLamMoiDV.Size = new System.Drawing.Size(110, 38);
            this.btnLamMoiDV.TabIndex = 9;
            this.btnLamMoiDV.Text = "Làm mới";
            this.btnLamMoiDV.UseVisualStyleBackColor = true;
            this.btnLamMoiDV.Click += new System.EventHandler(this.btnLamMoiDV_Click);

            this.btnSuaKhoDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaKhoDV.Location = new System.Drawing.Point(135, 595);
            this.btnSuaKhoDV.Name = "btnSuaKhoDV";
            this.btnSuaKhoDV.Size = new System.Drawing.Size(110, 38);
            this.btnSuaKhoDV.TabIndex = 8;
            this.btnSuaKhoDV.Text = "Cập nhật Kho";
            this.btnSuaKhoDV.UseVisualStyleBackColor = true;
            this.btnSuaKhoDV.Click += new System.EventHandler(this.btnSuaKhoDV_Click);

            this.btnThemKhoDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemKhoDV.Location = new System.Drawing.Point(15, 595);
            this.btnThemKhoDV.Name = "btnThemKhoDV";
            this.btnThemKhoDV.Size = new System.Drawing.Size(110, 38);
            this.btnThemKhoDV.TabIndex = 7;
            this.btnThemKhoDV.Text = "Thêm Dịch Vụ";
            this.btnThemKhoDV.UseVisualStyleBackColor = true;
            this.btnThemKhoDV.Click += new System.EventHandler(this.btnThemKhoDV_Click);

            this.nudTonKhoDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudTonKhoDV.Location = new System.Drawing.Point(115, 545);
            this.nudTonKhoDV.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudTonKhoDV.Name = "nudTonKhoDV";
            this.nudTonKhoDV.Size = new System.Drawing.Size(160, 23);
            this.nudTonKhoDV.TabIndex = 6;

            this.lblTonKhoDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTonKhoDV.AutoSize = true;
            this.lblTonKhoDV.Location = new System.Drawing.Point(15, 548);
            this.lblTonKhoDV.Name = "lblTonKhoDV";
            this.lblTonKhoDV.Size = new System.Drawing.Size(81, 15);
            this.lblTonKhoDV.TabIndex = 5;
            this.lblTonKhoDV.Text = "Số lượng tồn:";

            this.txtDonGiaDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDonGiaDV.Location = new System.Drawing.Point(115, 505);
            this.txtDonGiaDV.Name = "txtDonGiaDV";
            this.txtDonGiaDV.Size = new System.Drawing.Size(220, 23);
            this.txtDonGiaDV.TabIndex = 4;

            this.lblDonGiaDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDonGiaDV.AutoSize = true;
            this.lblDonGiaDV.Location = new System.Drawing.Point(15, 508);
            this.lblDonGiaDV.Name = "lblDonGiaDV";
            this.lblDonGiaDV.Size = new System.Drawing.Size(53, 15);
            this.lblDonGiaDV.TabIndex = 3;
            this.lblDonGiaDV.Text = "Đơn giá:";

            this.txtTenDV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenDV.Location = new System.Drawing.Point(115, 465);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(377, 23);
            this.txtTenDV.TabIndex = 2;

            this.lblTenDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTenDV.AutoSize = true;
            this.lblTenDV.Location = new System.Drawing.Point(15, 468);
            this.lblTenDV.Name = "lblTenDV";
            this.lblTenDV.Size = new System.Drawing.Size(72, 15);
            this.lblTenDV.TabIndex = 1;
            this.lblTenDV.Text = "Tên dịch vụ:";

            this.dgvKhoDichVu.AllowUserToAddRows = false;
            this.dgvKhoDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhoDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoDichVu.Location = new System.Drawing.Point(15, 25);
            this.dgvKhoDichVu.MultiSelect = false;
            this.dgvKhoDichVu.Name = "dgvKhoDichVu";
            this.dgvKhoDichVu.ReadOnly = true;
            this.dgvKhoDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoDichVu.Size = new System.Drawing.Size(477, 425);
            this.dgvKhoDichVu.TabIndex = 0;
            this.dgvKhoDichVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoDichVu_CellClick);

            this.tmrCapNhatGio.Interval = 15000;
            this.tmrCapNhatGio.Tick += new System.EventHandler(this.tmrCapNhatGio_Tick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.MinimumSize = new System.Drawing.Size(1180, 680);
            this.Controls.Add(this.tabControlMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Đặt Phòng && Dịch Vụ Karaoke (Bài 6.5 - 3-Tier)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPhongHat.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.grpThanhToan.ResumeLayout(false);
            this.grpThanhToan.PerformLayout();
            this.grpDichVuPhong.ResumeLayout(false);
            this.grpDichVuPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongDV)).EndInit();
            this.grpThongTinPhong.ResumeLayout(false);
            this.grpThongTinPhong.PerformLayout();
            this.grpSoDoPhong.ResumeLayout(false);
            this.grpSoDoPhong.PerformLayout();
            this.tabQuanLy.ResumeLayout(false);
            this.tlpQuanLy.ResumeLayout(false);
            this.grpLichSuHD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuHD)).EndInit();
            this.grpKhoDichVu.ResumeLayout(false);
            this.grpKhoDichVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTonKhoDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoDichVu)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPhongHat;
        private System.Windows.Forms.TabPage tabQuanLy;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox grpSoDoPhong;
        private System.Windows.Forms.Label lblChuThich;
        private System.Windows.Forms.ComboBox cboLocLoaiPhong;
        private System.Windows.Forms.Button btnTaiLaiPhong;
        private System.Windows.Forms.FlowLayoutPanel flpPhongHat;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.GroupBox grpThongTinPhong;
        private System.Windows.Forms.Label lblTenPhongChon;
        private System.Windows.Forms.Label lblGiaGioChon;
        private System.Windows.Forms.Label lblTrangThaiChon;
        private System.Windows.Forms.Label lblGioVaoChon;
        private System.Windows.Forms.Label lblTamTinhPhong;
        private System.Windows.Forms.Button btnMoPhong;
        private System.Windows.Forms.GroupBox grpDichVuPhong;
        private System.Windows.Forms.Label lblChonDV;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label lblSoLuongDV;
        private System.Windows.Forms.NumericUpDown nudSoLuongDV;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.Button btnXoaDV;
        private System.Windows.Forms.DataGridView dgvChiTietDV;
        private System.Windows.Forms.GroupBox grpThanhToan;
        private System.Windows.Forms.TextBox txtHoaDonPreview;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TableLayoutPanel tlpQuanLy;
        private System.Windows.Forms.GroupBox grpKhoDichVu;
        private System.Windows.Forms.DataGridView dgvKhoDichVu;
        private System.Windows.Forms.Label lblTenDV;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label lblDonGiaDV;
        private System.Windows.Forms.TextBox txtDonGiaDV;
        private System.Windows.Forms.Label lblTonKhoDV;
        private System.Windows.Forms.NumericUpDown nudTonKhoDV;
        private System.Windows.Forms.Button btnThemKhoDV;
        private System.Windows.Forms.Button btnSuaKhoDV;
        private System.Windows.Forms.Button btnLamMoiDV;
        private System.Windows.Forms.GroupBox grpLichSuHD;
        private System.Windows.Forms.Button btnTaiLichSuHD;
        private System.Windows.Forms.DataGridView dgvLichSuHD;
        private System.Windows.Forms.Timer tmrCapNhatGio;
    }
}
