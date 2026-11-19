using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using KaraokeManagement.BUS;
using KaraokeManagement.DTO;

namespace KaraokeManagement.GUI
{
    public partial class frmMain : Form
    {
        private readonly PhongHatBUS _phongBus = new PhongHatBUS();
        private readonly DichVuBUS _dvBus = new DichVuBUS();
        private readonly HoaDonBUS _hdBus = new HoaDonBUS();

        private PhongHatDTO _selectedPhong = null;
        private HoaDonDTO _currentHoaDon = null;
        private List<DichVuDTO> _danhSachDichVu = new List<DichVuDTO>();

        private SqlDataAdapter _daChiTietDV;
        private DataTable _dtChiTietDV;

        private int _selectedMaDV = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cboLocLoaiPhong.SelectedIndex = 0;
            LoadDanhSachDichVu();
            LoadSoDoPhong();
            LoadLichSuHoaDon();
            tmrCapNhatGio.Start();
        }

        #region 1. SƠ ĐỒ PHÒNG HÁT & MỞ PHÒNG (VISUAL ROOM GRID)
        private void LoadSoDoPhong()
        {
            flpPhongHat.Controls.Clear();
            var listPhong = _phongBus.GetAll(cboLocLoaiPhong.Text);

            foreach (var phong in listPhong)
            {
                bool isTrong = phong.TrangThai == "Trống";
                Button btn = new Button
                {
                    Width = 152,
                    Height = 105,
                    Margin = new Padding(8),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Text = $"{phong.TenPhong}\n[{phong.LoaiPhong}]\n{phong.GiaTheoGio:N0}đ/giờ\n● {phong.TrangThai}",
                    Tag = phong,
                    BackColor = isTrong ? Color.LightGreen : Color.IndianRed,
                    ForeColor = isTrong ? Color.DarkGreen : Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btn.FlatAppearance.BorderSize = (_selectedPhong != null && _selectedPhong.MaPhong == phong.MaPhong) ? 3 : 1;
                btn.FlatAppearance.BorderColor = Color.Navy;

                btn.Click += BtnPhong_Click;
                flpPhongHat.Controls.Add(btn);
            }

            if (_selectedPhong != null)
            {
                var updated = listPhong.Find(p => p.MaPhong == _selectedPhong.MaPhong);
                if (updated != null)
                {
                    ChonPhong(updated);
                }
            }
        }

        private void BtnPhong_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is PhongHatDTO phong)
            {
                foreach (Control ctrl in flpPhongHat.Controls)
                {
                    if (ctrl is Button b) b.FlatAppearance.BorderSize = 1;
                }
                btn.FlatAppearance.BorderSize = 3;

                ChonPhong(phong);
            }
        }

        private void ChonPhong(PhongHatDTO phong)
        {
            _selectedPhong = phong;
            lblTenPhongChon.Text = $"{phong.TenPhong} ({phong.LoaiPhong})";
            lblGiaGioChon.Text = $"Giá theo giờ: {phong.GiaTheoGio:N0} VNĐ/giờ";
            lblTrangThaiChon.Text = $"Trạng thái: {phong.TrangThai}";

            bool isTrong = phong.TrangThai == "Trống";
            btnMoPhong.Enabled = isTrong;
            btnThemDV.Enabled = !isTrong;
            btnXoaDV.Enabled = !isTrong;
            btnThanhToan.Enabled = !isTrong;

            if (isTrong)
            {
                _currentHoaDon = null;
                _dtChiTietDV = null;
                dgvChiTietDV.DataSource = null;
                lblGioVaoChon.Text = "Giờ bắt đầu hát: Chưa mở phòng";
                lblTamTinhPhong.Text = "Thời lượng & Tiền phòng: 0 VNĐ";
                txtHoaDonPreview.Text = $"Phòng {phong.TenPhong} đang trống.\r\nBấm nút 'Mở Phòng Hát' để bắt đầu tính giờ.";
            }
            else
            {
                _currentHoaDon = _hdBus.GetHoaDonDangMo(phong.MaPhong);
                if (_currentHoaDon != null)
                {
                    lblGioVaoChon.Text = $"Giờ bắt đầu hát: {_currentHoaDon.GioVao:dd/MM/yyyy HH:mm:ss}";
                    LoadDichVuPhongDisconnected(_currentHoaDon.MaHD);
                    CapNhatTamTinhVaPreview();
                }
            }
        }

        private void btnMoPhong_Click(object sender, EventArgs e)
        {
            if (_selectedPhong == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng trống trên sơ đồ!");
                return;
            }

            if (_hdBus.MoPhong(_selectedPhong.MaPhong, out string msg))
            {
                MessageBox.Show(msg, "Mở phòng thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSoDoPhong();
            }
            else
            {
                MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboLocLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSoDoPhong();
        }

        private void btnTaiLaiPhong_Click(object sender, EventArgs e)
        {
            LoadSoDoPhong();
        }
        #endregion

        #region 2. GỌI DỊCH VỤ / ĐỒ UỐNG (DISCONNECTED MODEL - DATAADAPTER & DATATABLE)
        private void LoadDanhSachDichVu()
        {
            _danhSachDichVu = _dvBus.GetAll();

            cboDichVu.DataSource = new List<DichVuDTO>(_danhSachDichVu);
            cboDichVu.DisplayMember = "DisplayDV";
            cboDichVu.ValueMember = "MaDV";

            dgvKhoDichVu.DataSource = new List<DichVuDTO>(_danhSachDichVu);
            if (dgvKhoDichVu.Columns["DisplayDV"] != null) dgvKhoDichVu.Columns["DisplayDV"].Visible = false;
            if (dgvKhoDichVu.Columns["MaDV"] != null) dgvKhoDichVu.Columns["MaDV"].HeaderText = "Mã DV";
            if (dgvKhoDichVu.Columns["TenDV"] != null) dgvKhoDichVu.Columns["TenDV"].HeaderText = "Tên Dịch Vụ / Đồ Uống";
            if (dgvKhoDichVu.Columns["DonGia"] != null)
            {
                dgvKhoDichVu.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvKhoDichVu.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvKhoDichVu.Columns["TonKho"] != null) dgvKhoDichVu.Columns["TonKho"].HeaderText = "Tồn Kho";
        }

        private void LoadDichVuPhongDisconnected(int maHD)
        {
            _daChiTietDV = _hdBus.GetDisconnectedChiTiet(maHD, out _dtChiTietDV);

            dgvChiTietDV.AutoGenerateColumns = false;
            dgvChiTietDV.Columns.Clear();

            var colTenDV = new DataGridViewComboBoxColumn
            {
                Name = "colTenDV",
                HeaderText = "Tên Dịch Vụ",
                DataSource = _danhSachDichVu,
                DisplayMember = "TenDV",
                ValueMember = "MaDV",
                DataPropertyName = "MaDV",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                FillWeight = 45
            };

            var colSoLuong = new DataGridViewTextBoxColumn
            {
                Name = "colSoLuong",
                HeaderText = "SL",
                DataPropertyName = "SoLuong",
                FillWeight = 15
            };

            var colDonGia = new DataGridViewTextBoxColumn
            {
                Name = "colDonGia",
                HeaderText = "Đơn Giá",
                DataPropertyName = "DonGia",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                FillWeight = 20
            };

            var colThanhTien = new DataGridViewTextBoxColumn
            {
                Name = "colThanhTien",
                HeaderText = "Thành Tiền",
                DataPropertyName = "ThanhTien",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                FillWeight = 20
            };

            dgvChiTietDV.Columns.AddRange(colTenDV, colSoLuong, colDonGia, colThanhTien);
            dgvChiTietDV.DataSource = _dtChiTietDV;
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (_currentHoaDon == null || _dtChiTietDV == null)
            {
                MessageBox.Show("Vui lòng chọn phòng đang hát trước khi gọi dịch vụ!");
                return;
            }
            if (!(cboDichVu.SelectedItem is DichVuDTO dv)) return;

            int soLuongThem = (int)nudSoLuongDV.Value;

            DataRow existingRow = _dtChiTietDV.Rows.Find(new object[] { _currentHoaDon.MaHD, dv.MaDV });
            if (existingRow != null)
            {
                existingRow["SoLuong"] = Convert.ToInt32(existingRow["SoLuong"]) + soLuongThem;
            }
            else
            {
                DataRow newRow = _dtChiTietDV.NewRow();
                newRow["MaHD"] = _currentHoaDon.MaHD;
                newRow["MaDV"] = dv.MaDV;
                newRow["SoLuong"] = soLuongThem;
                newRow["DonGia"] = dv.DonGia;
                _dtChiTietDV.Rows.Add(newRow);
            }

            _daChiTietDV.Update(_dtChiTietDV);
            CapNhatTamTinhVaPreview();
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (_dtChiTietDV == null || dgvChiTietDV.CurrentRow == null) return;

            if (dgvChiTietDV.CurrentRow.DataBoundItem is DataRowView drv)
            {
                drv.Row.Delete();
                _daChiTietDV.Update(_dtChiTietDV);
                CapNhatTamTinhVaPreview();
            }
        }
        #endregion

        #region 3. TÍNH TIỀN TỰ ĐỘNG & THANH TOÁN (SQLTRANSACTION)
        private void tmrCapNhatGio_Tick(object sender, EventArgs e)
        {
            if (_selectedPhong != null && _selectedPhong.TrangThai == "Đang hát" && _currentHoaDon != null)
            {
                CapNhatTamTinhVaPreview();
            }
        }

        private void CapNhatTamTinhVaPreview()
        {
            if (_selectedPhong == null || _currentHoaDon == null) return;

            DateTime gioHienTai = DateTime.Now;
            decimal tienPhong = _hdBus.TinhTienPhong(_currentHoaDon.GioVao, gioHienTai, _selectedPhong.GiaTheoGio, out double soGio);
            decimal tienDV = _hdBus.TinhTongTienDichVu(_dtChiTietDV);
            decimal tongCong = tienPhong + tienDV;

            TimeSpan thoiGian = gioHienTai - _currentHoaDon.GioVao;
            lblTamTinhPhong.Text = $"Thời lượng: {(int)thoiGian.TotalHours}h {thoiGian.Minutes}p ({soGio:0.##}h) → Tiền phòng: {tienPhong:N0} VNĐ";

            var sb = new StringBuilder();
            sb.AppendLine($"HÓA ĐƠN TẠM TÍNH - PHÒNG: {_selectedPhong.TenPhong.ToUpper()} (Mã HĐ: #{_currentHoaDon.MaHD})");
            sb.AppendLine($"Giờ vào : {_currentHoaDon.GioVao:dd/MM/yyyy HH:mm:ss} | Giờ ra dự kiến: {gioHienTai:HH:mm:ss}");
            sb.AppendLine($"Thời gian tính tiền (tối thiểu 15p = 0.25h): {soGio:0.##} giờ x {_selectedPhong.GiaTheoGio:N0}đ");
            sb.AppendLine("------------------------------------------------------------------");
            sb.AppendLine($"1. Tiền phòng hát : {tienPhong,18:N0} VNĐ");
            sb.AppendLine($"2. Tiền dịch vụ   : {tienDV,18:N0} VNĐ");
            sb.AppendLine($"TỔNG THANH TOÁN   : {tongCong,18:N0} VNĐ");

            txtHoaDonPreview.Text = sb.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_selectedPhong == null || _currentHoaDon == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng đang hát để thanh toán!");
                return;
            }

            DateTime gioRa = DateTime.Now;
            decimal tienPhong = _hdBus.TinhTienPhong(_currentHoaDon.GioVao, gioRa, _selectedPhong.GiaTheoGio, out double soGio);
            decimal tienDV = _hdBus.TinhTongTienDichVu(_dtChiTietDV);
            decimal tongCong = tienPhong + tienDV;

            string confirmMsg = $"Xác nhận thanh toán cho {_selectedPhong.TenPhong}?\n\n" +
                                $"• Thời gian hát: {soGio:0.##} giờ\n" +
                                $"• Tiền phòng: {tienPhong:N0} VNĐ\n" +
                                $"• Tiền dịch vụ: {tienDV:N0} VNĐ\n" +
                                $"• TỔNG CỘNG: {tongCong:N0} VNĐ";

            if (MessageBox.Show(confirmMsg, "Xác nhận Thanh toán Hóa đơn",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_hdBus.ThanhToan(_currentHoaDon.MaHD, _selectedPhong.MaPhong, gioRa,
                                      tienPhong, tienDV, _dtChiTietDV, out string msg))
                {
                    MessageBox.Show(msg, "Thanh toán hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDichVu(); 
                    LoadSoDoPhong();     
                    LoadLichSuHoaDon();   
                }
                else
                {
                    MessageBox.Show(msg, "Lỗi Thanh toán (Transaction Rollback)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 4. QUẢN LÝ KHO DỊCH VỤ & LỊCH SỬ HÓA ĐƠN
        private void dgvKhoDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvKhoDichVu.Rows[e.RowIndex].DataBoundItem is DichVuDTO dv)
            {
                _selectedMaDV = dv.MaDV;
                txtTenDV.Text = dv.TenDV;
                txtDonGiaDV.Text = dv.DonGia.ToString("0");
                nudTonKhoDV.Value = dv.TonKho;
            }
        }

        private void btnThemKhoDV_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDonGiaDV.Text.Trim(), out decimal donGia))
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ!");
                return;
            }

            var dv = new DichVuDTO
            {
                TenDV = txtTenDV.Text.Trim(),
                DonGia = donGia,
                TonKho = (int)nudTonKhoDV.Value
            };

            if (_dvBus.Add(dv, out string error))
            {
                MessageBox.Show("Thêm dịch vụ mới thành công!");
                LoadDanhSachDichVu();
                ClearKhoInputs();
            }
            else
            {
                MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaKhoDV_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDonGiaDV.Text.Trim(), out decimal donGia))
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ!");
                return;
            }

            var dv = new DichVuDTO
            {
                MaDV = _selectedMaDV,
                TenDV = txtTenDV.Text.Trim(),
                DonGia = donGia,
                TonKho = (int)nudTonKhoDV.Value
            };

            if (_dvBus.Update(dv, out string error))
            {
                MessageBox.Show("Cập nhật kho dịch vụ thành công!");
                LoadDanhSachDichVu();
            }
            else
            {
                MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoiDV_Click(object sender, EventArgs e)
        {
            ClearKhoInputs();
            LoadDanhSachDichVu();
        }

        private void ClearKhoInputs()
        {
            _selectedMaDV = 0;
            txtTenDV.Clear();
            txtDonGiaDV.Clear();
            nudTonKhoDV.Value = 0;
        }

        private void LoadLichSuHoaDon()
        {
            var listHD = _hdBus.GetLichSuHoaDon();
            dgvLichSuHD.DataSource = listHD;

            if (dgvLichSuHD.Columns["MaPhong"] != null) dgvLichSuHD.Columns["MaPhong"].Visible = false;
            if (dgvLichSuHD.Columns["TrangThai"] != null) dgvLichSuHD.Columns["TrangThai"].Visible = false;

            if (dgvLichSuHD.Columns["MaHD"] != null) dgvLichSuHD.Columns["MaHD"].HeaderText = "Mã HĐ";
            if (dgvLichSuHD.Columns["TenPhong"] != null) dgvLichSuHD.Columns["TenPhong"].HeaderText = "Phòng Hát";
            if (dgvLichSuHD.Columns["GioVao"] != null) dgvLichSuHD.Columns["GioVao"].HeaderText = "Giờ Vào";
            if (dgvLichSuHD.Columns["GioRa"] != null) dgvLichSuHD.Columns["GioRa"].HeaderText = "Giờ Ra";
            if (dgvLichSuHD.Columns["TongTienPhong"] != null)
            {
                dgvLichSuHD.Columns["TongTienPhong"].HeaderText = "Tiền Phòng";
                dgvLichSuHD.Columns["TongTienPhong"].DefaultCellStyle.Format = "N0";
            }
            if (dgvLichSuHD.Columns["TongTienDichVu"] != null)
            {
                dgvLichSuHD.Columns["TongTienDichVu"].HeaderText = "Tiền Dịch Vụ";
                dgvLichSuHD.Columns["TongTienDichVu"].DefaultCellStyle.Format = "N0";
            }
            if (dgvLichSuHD.Columns["TongThanhToan"] != null)
            {
                dgvLichSuHD.Columns["TongThanhToan"].HeaderText = "Tổng Cộng";
                dgvLichSuHD.Columns["TongThanhToan"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnTaiLichSuHD_Click(object sender, EventArgs e)
        {
            LoadLichSuHoaDon();
        }
        #endregion
    }
}