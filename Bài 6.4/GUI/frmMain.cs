using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GarageManagement.BUS;
using GarageManagement.DTO;

namespace GarageManagement.GUI
{
    public partial class frmMain : Form
    {
        private readonly XeKhachHangBUS _xeBus = new XeKhachHangBUS();
        private readonly PhuTungBUS _ptBus = new PhuTungBUS();
        private readonly PhieuSuaChuaBUS _phieuBus = new PhieuSuaChuaBUS();

        private int _selectedMaPT = 0;
        private PhieuSuaChuaDTO _selectedPhieu = null;
        private readonly List<ChiTietSuaChuaDTO> _gioPhuTungTam = new List<ChiTietSuaChuaDTO>();
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            cboLocTrangThaiPhieu.SelectedIndex = 0;
            LoadDanhSachXe();
            LoadDanhSachPhuTung();
            LoadDanhSachPhieu();
        }

        #region 1. TIẾP NHẬN XE & QUẢN LÝ CHỦ XE
        private void LoadDanhSachXe()
        {
            var listXe = _xeBus.GetAllXe();
            dgvXe.DataSource = listXe;

            if (dgvXe.Columns["MaKH"] != null) dgvXe.Columns["MaKH"].Visible = false;
            if (dgvXe.Columns["DisplayXe"] != null) dgvXe.Columns["DisplayXe"].Visible = false;

            if (dgvXe.Columns["BienSo"] != null) dgvXe.Columns["BienSo"].HeaderText = "Biển Số";
            if (dgvXe.Columns["HieuXe"] != null) dgvXe.Columns["HieuXe"].HeaderText = "Hiệu Xe";
            if (dgvXe.Columns["NamSanXuat"] != null) dgvXe.Columns["NamSanXuat"].HeaderText = "Năm SX";
            if (dgvXe.Columns["TenKH"] != null) dgvXe.Columns["TenKH"].HeaderText = "Chủ Xe";
            if (dgvXe.Columns["DienThoai"] != null) dgvXe.Columns["DienThoai"].HeaderText = "Điện Thoại";
            if (dgvXe.Columns["DiaChi"] != null) dgvXe.Columns["DiaChi"].HeaderText = "Địa Chỉ";

            cboBienSoPhieu.DataSource = new List<XeDTO>(listXe);
            cboBienSoPhieu.DisplayMember = "DisplayXe";
            cboBienSoPhieu.ValueMember = "BienSo";
        }

        private void btnTraCuuXe_Click(object sender, EventArgs e)
        {
            string bienSo = txtTraCuuBienSo.Text.Trim();
            if (string.IsNullOrEmpty(bienSo))
            {
                MessageBox.Show("Vui lòng nhập biển số xe cần tra cứu!", "Thông báo");
                return;
            }

            var xe = _xeBus.TimXe(bienSo);
            if (xe != null)
            {
                txtBienSo.Text = xe.BienSo;
                txtHieuXe.Text = xe.HieuXe;
                nudNamSX.Value = xe.NamSanXuat;
                txtTenKH.Text = xe.TenKH;
                txtDienThoaiKH.Text = xe.DienThoai;
                txtDiaChiKH.Text = xe.DiaChi;
                MessageBox.Show($"Đã tìm thấy xe {xe.BienSo} của chủ xe {xe.TenKH}!", "Kết quả tra cứu",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ClearXeInputs();
                txtBienSo.Text = bienSo.ToUpper();
                txtHieuXe.Focus();
                MessageBox.Show("Xe mới chưa có trong hệ thống! Vui lòng nhập thông tin Chủ xe và Xe bên dưới để tiếp nhận.",
                    "Xe mới", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuuTiepNhan_Click(object sender, EventArgs e)
        {
            var kh = new KhachHangDTO
            {
                TenKH = txtTenKH.Text.Trim(),
                DienThoai = txtDienThoaiKH.Text.Trim(),
                DiaChi = txtDiaChiKH.Text.Trim()
            };

            var xe = new XeDTO
            {
                BienSo = txtBienSo.Text.Trim(),
                HieuXe = txtHieuXe.Text.Trim(),
                NamSanXuat = (int)nudNamSX.Value
            };

            if (_xeBus.LuuTiepNhan(kh, xe, out string msg))
            {
                MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachXe();
                cboBienSoPhieu.SelectedValue = xe.BienSo.ToUpper();
            }
            else
            {
                MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvXe.Rows[e.RowIndex].DataBoundItem is XeDTO xe)
            {
                txtBienSo.Text = xe.BienSo;
                txtHieuXe.Text = xe.HieuXe;
                nudNamSX.Value = xe.NamSanXuat;
                txtTenKH.Text = xe.TenKH;
                txtDienThoaiKH.Text = xe.DienThoai;
                txtDiaChiKH.Text = xe.DiaChi;
            }
        }

        private void btnLamMoiXe_Click(object sender, EventArgs e)
        {
            txtTraCuuBienSo.Clear();
            ClearXeInputs();
        }

        private void ClearXeInputs()
        {
            txtBienSo.Clear();
            txtHieuXe.Clear();
            nudNamSX.Value = DateTime.Now.Year;
            txtTenKH.Clear();
            txtDienThoaiKH.Clear();
            txtDiaChiKH.Clear();
        }
        #endregion

        #region 2. QUẢN LÝ PHỤ TÙNG & TỒN KHO
        private void LoadDanhSachPhuTung()
        {
            var listPT = _ptBus.GetAll();
            dgvPhuTung.DataSource = listPT;

            if (dgvPhuTung.Columns["DisplayPhuTung"] != null) dgvPhuTung.Columns["DisplayPhuTung"].Visible = false;
            if (dgvPhuTung.Columns["MaPhuTung"] != null) dgvPhuTung.Columns["MaPhuTung"].HeaderText = "Mã PT";
            if (dgvPhuTung.Columns["TenPhuTung"] != null) dgvPhuTung.Columns["TenPhuTung"].HeaderText = "Tên Phụ Tùng";
            if (dgvPhuTung.Columns["DonGia"] != null)
            {
                dgvPhuTung.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvPhuTung.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvPhuTung.Columns["SoLuongTon"] != null) dgvPhuTung.Columns["SoLuongTon"].HeaderText = "Tồn Kho";

            cboPhuTung.DataSource = new List<PhuTungDTO>(listPT);
            cboPhuTung.DisplayMember = "DisplayPhuTung";
            cboPhuTung.ValueMember = "MaPhuTung";
        }

        private void dgvPhuTung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvPhuTung.Rows[e.RowIndex].DataBoundItem is PhuTungDTO pt)
            {
                _selectedMaPT = pt.MaPhuTung;
                txtTenPT.Text = pt.TenPhuTung;
                txtDonGiaPT.Text = pt.DonGia.ToString("0");
                nudTonKhoPT.Value = pt.SoLuongTon;
            }
        }

        private void btnThemPT_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDonGiaPT.Text.Trim(), out decimal donGia))
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ!");
                return;
            }

            var pt = new PhuTungDTO
            {
                TenPhuTung = txtTenPT.Text.Trim(),
                DonGia = donGia,
                SoLuongTon = (int)nudTonKhoPT.Value
            };

            if (_ptBus.Add(pt, out string error))
            {
                MessageBox.Show("Thêm phụ tùng thành công!");
                LoadDanhSachPhuTung();
                ClearPhuTungInputs();
            }
            else
            {
                MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaPT_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDonGiaPT.Text.Trim(), out decimal donGia))
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ!");
                return;
            }

            var pt = new PhuTungDTO
            {
                MaPhuTung = _selectedMaPT,
                TenPhuTung = txtTenPT.Text.Trim(),
                DonGia = donGia,
                SoLuongTon = (int)nudTonKhoPT.Value
            };

            if (_ptBus.Update(pt, out string error))
            {
                MessageBox.Show("Cập nhật phụ tùng thành công!");
                LoadDanhSachPhuTung();
            }
            else
            {
                MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaPT_Click(object sender, EventArgs e)
        {
            if (_selectedMaPT <= 0)
            {
                MessageBox.Show("Vui lòng chọn phụ tùng cần xóa!");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa phụ tùng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_ptBus.Delete(_selectedMaPT))
                {
                    LoadDanhSachPhuTung();
                    ClearPhuTungInputs();
                }
            }
        }

        private void btnLamMoiPT_Click(object sender, EventArgs e)
        {
            ClearPhuTungInputs();
            LoadDanhSachPhuTung();
        }

        private void ClearPhuTungInputs()
        {
            _selectedMaPT = 0;
            txtTenPT.Clear();
            txtDonGiaPT.Clear();
            nudTonKhoPT.Value = 0;
        }
        #endregion

        #region 3. LẬP PHIẾU SỬA CHỮA (SQLTRANSACTION)
        private void btnThemVaoPhieu_Click(object sender, EventArgs e)
        {
            if (!(cboPhuTung.SelectedItem is PhuTungDTO pt)) return;

            if (!decimal.TryParse(txtTienCong.Text.Trim(), out decimal tienCong) || tienCong < 0)
            {
                MessageBox.Show("Tiền công phải là số lớn hơn hoặc bằng 0!");
                return;
            }

            int soLuong = (int)nudSoLuongThay.Value;

            // Cộng dồn nếu phụ tùng đã có trong danh sách tạm
            var existing = _gioPhuTungTam.FirstOrDefault(x => x.MaPhuTung == pt.MaPhuTung);
            if (existing != null)
            {
                existing.SoLuong += soLuong;
                existing.TienCong += tienCong;
            }
            else
            {
                _gioPhuTungTam.Add(new ChiTietSuaChuaDTO
                {
                    MaPhuTung = pt.MaPhuTung,
                    TenPhuTung = pt.TenPhuTung,
                    SoLuong = soLuong,
                    DonGia = pt.DonGia,
                    TienCong = tienCong
                });
            }

            RefreshGioPhuTungTam();
        }

        private void btnXoaKhoiPhieu_Click(object sender, EventArgs e)
        {
            if (dgvChiTietTam.CurrentRow?.DataBoundItem is ChiTietSuaChuaDTO item)
            {
                _gioPhuTungTam.Remove(item);
                RefreshGioPhuTungTam();
            }
        }

        private void RefreshGioPhuTungTam()
        {
            dgvChiTietTam.DataSource = null;
            dgvChiTietTam.DataSource = new List<ChiTietSuaChuaDTO>(_gioPhuTungTam);

            if (dgvChiTietTam.Columns["MaPhieu"] != null) dgvChiTietTam.Columns["MaPhieu"].Visible = false;
            if (dgvChiTietTam.Columns["MaPhuTung"] != null) dgvChiTietTam.Columns["MaPhuTung"].HeaderText = "Mã PT";
            if (dgvChiTietTam.Columns["TenPhuTung"] != null) dgvChiTietTam.Columns["TenPhuTung"].HeaderText = "Tên Phụ Tùng";
            if (dgvChiTietTam.Columns["SoLuong"] != null) dgvChiTietTam.Columns["SoLuong"].HeaderText = "Số Lượng";
            if (dgvChiTietTam.Columns["DonGia"] != null)
            {
                dgvChiTietTam.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvChiTietTam.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTietTam.Columns["TienCong"] != null)
            {
                dgvChiTietTam.Columns["TienCong"].HeaderText = "Tiền Công";
                dgvChiTietTam.Columns["TienCong"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTietTam.Columns["ThanhTien"] != null)
            {
                dgvChiTietTam.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvChiTietTam.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            decimal tong = _phieuBus.TinhTongChiPhi(_gioPhuTungTam);
            lblTongTamTinh.Text = $"Tổng tiền tạm tính: {tong:N0} VNĐ";
        }

        private void btnXacNhanLapPhieu_Click(object sender, EventArgs e)
        {
            if (!(cboBienSoPhieu.SelectedValue is string bienSo))
            {
                MessageBox.Show("Vui lòng chọn biển số xe!");
                return;
            }

            var phieu = new PhieuSuaChuaDTO
            {
                BienSo = bienSo,
                NoiDungSua = txtNoiDungSua.Text.Trim()
            };

            if (_phieuBus.TaoPhieuSuaChua(phieu, _gioPhuTungTam, out string msg))
            {
                MessageBox.Show(msg, "Giao dịch thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _gioPhuTungTam.Clear();
                txtNoiDungSua.Clear();
                RefreshGioPhuTungTam();
                LoadDanhSachPhuTung(); // Cập nhật lại số lượng tồn kho hiển thị
                LoadDanhSachPhieu();
            }
            else
            {
                // Hiển thị thông báo khi tồn kho không đủ và Transaction đã Rollback
                MessageBox.Show(msg, "Cảnh báo Tồn kho (Transaction Rollback)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 4. THANH TOÁN & XUẤT HÓA ĐƠN DỊCH VỤ
        private void LoadDanhSachPhieu()
        {
            var listPhieu = _phieuBus.GetAllPhieu(cboLocTrangThaiPhieu.Text);
            dgvPhieuSuaChua.DataSource = listPhieu;

            if (dgvPhieuSuaChua.Columns["MaPhieu"] != null) dgvPhieuSuaChua.Columns["MaPhieu"].HeaderText = "Mã Phiếu";
            if (dgvPhieuSuaChua.Columns["BienSo"] != null) dgvPhieuSuaChua.Columns["BienSo"].HeaderText = "Biển Số";
            if (dgvPhieuSuaChua.Columns["TenKH"] != null) dgvPhieuSuaChua.Columns["TenKH"].HeaderText = "Chủ Xe";
            if (dgvPhieuSuaChua.Columns["HieuXe"] != null) dgvPhieuSuaChua.Columns["HieuXe"].HeaderText = "Hiệu Xe";
            if (dgvPhieuSuaChua.Columns["NgayNhan"] != null) dgvPhieuSuaChua.Columns["NgayNhan"].HeaderText = "Ngày Nhận";
            if (dgvPhieuSuaChua.Columns["NoiDungSua"] != null) dgvPhieuSuaChua.Columns["NoiDungSua"].HeaderText = "Nội Dung Sửa";
            if (dgvPhieuSuaChua.Columns["TongTien"] != null)
            {
                dgvPhieuSuaChua.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvPhieuSuaChua.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }
            if (dgvPhieuSuaChua.Columns["TrangThai"] != null) dgvPhieuSuaChua.Columns["TrangThai"].HeaderText = "Trạng Thái";

            foreach (DataGridViewRow row in dgvPhieuSuaChua.Rows)
            {
                string tt = row.Cells["TrangThai"].Value?.ToString();
                if (tt == "Đã thanh toán")
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                else if (tt == "Đã hoàn thành")
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void btnLocPhieu_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhieu();
        }

        private void dgvPhieuSuaChua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedPhieu = dgvPhieuSuaChua.Rows[e.RowIndex].DataBoundItem as PhieuSuaChuaDTO;
            if (_selectedPhieu == null) return;

            var chiTiets = _phieuBus.GetChiTiet(_selectedPhieu.MaPhieu);
            dgvChiTietPhieu.DataSource = chiTiets;

            if (dgvChiTietPhieu.Columns["MaPhieu"] != null) dgvChiTietPhieu.Columns["MaPhieu"].Visible = false;
            if (dgvChiTietPhieu.Columns["MaPhuTung"] != null) dgvChiTietPhieu.Columns["MaPhuTung"].Visible = false;
            if (dgvChiTietPhieu.Columns["TenPhuTung"] != null) dgvChiTietPhieu.Columns["TenPhuTung"].HeaderText = "Phụ Tùng";
            if (dgvChiTietPhieu.Columns["SoLuong"] != null) dgvChiTietPhieu.Columns["SoLuong"].HeaderText = "SL";
            if (dgvChiTietPhieu.Columns["DonGia"] != null)
            {
                dgvChiTietPhieu.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvChiTietPhieu.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTietPhieu.Columns["TienCong"] != null)
            {
                dgvChiTietPhieu.Columns["TienCong"].HeaderText = "Tiền Công";
                dgvChiTietPhieu.Columns["TienCong"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTietPhieu.Columns["ThanhTien"] != null)
            {
                dgvChiTietPhieu.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvChiTietPhieu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            HienThiHoaDonPreview(_selectedPhieu, chiTiets);
        }

        private void HienThiHoaDonPreview(PhieuSuaChuaDTO phieu, List<ChiTietSuaChuaDTO> chiTiets)
        {
            decimal tongPhuTung = chiTiets.Sum(x => x.SoLuong * x.DonGia);
            decimal tongTienCong = chiTiets.Sum(x => x.TienCong);
            decimal tongChiPhi = tongPhuTung + tongTienCong;

            var sb = new StringBuilder();
            sb.AppendLine("=================================================");
            sb.AppendLine("        HÓA ĐƠN DỊCH VỤ SỬA CHỮA Ô TÔ");
            sb.AppendLine("=================================================");
            sb.AppendLine($"Mã phiếu   : #{phieu.MaPhieu} ({phieu.TrangThai})");
            sb.AppendLine($"Ngày nhận  : {phieu.NgayNhan:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Khách hàng : {phieu.TenKH}");
            sb.AppendLine($"Biển số xe : {phieu.BienSo} ({phieu.HieuXe})");
            sb.AppendLine($"Nội dung   : {phieu.NoiDungSua}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("CHI TIẾT PHỤ TÙNG & TIỀN CÔNG:");

            foreach (var ct in chiTiets)
            {
                sb.AppendLine($"- {ct.TenPhuTung}");
                sb.AppendLine($"  SL: {ct.SoLuong} x {ct.DonGia:N0}đ + Công: {ct.TienCong:N0}đ = {ct.ThanhTien:N0}đ");
            }

            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine($"Tổng tiền phụ tùng : {tongPhuTung,18:N0} VNĐ");
            sb.AppendLine($"Tổng tiền công     : {tongTienCong,18:N0} VNĐ");
            sb.AppendLine($"TỔNG THANH TOÁN    : {tongChiPhi,18:N0} VNĐ");
            sb.AppendLine("=================================================");

            txtHoaDonPreview.Text = sb.ToString();
        }

        private void btnHoanThanhSua_Click(object sender, EventArgs e)
        {
            if (_selectedPhieu == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu sửa chữa trên bảng!");
                return;
            }
            if (_selectedPhieu.TrangThai == "Đã thanh toán")
            {
                MessageBox.Show("Phiếu này đã thanh toán, không thể thay đổi!");
                return;
            }

            var chiTiets = _phieuBus.GetChiTiet(_selectedPhieu.MaPhieu);
            decimal tongTien = _phieuBus.TinhTongChiPhi(chiTiets);

            if (_phieuBus.HoanThanhSuaChua(_selectedPhieu.MaPhieu, tongTien))
            {
                MessageBox.Show($"Đã cập nhật phiếu #{_selectedPhieu.MaPhieu} sang trạng thái 'Đã hoàn thành'!");
                LoadDanhSachPhieu();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_selectedPhieu == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu sửa chữa cần thanh toán!");
                return;
            }
            if (_selectedPhieu.TrangThai == "Đã thanh toán")
            {
                MessageBox.Show("Phiếu sửa chữa này đã được thanh toán trước đó!");
                return;
            }

            var chiTiets = _phieuBus.GetChiTiet(_selectedPhieu.MaPhieu);
            decimal tongChiPhi = _phieuBus.TinhTongChiPhi(chiTiets);

            if (MessageBox.Show($"Xác nhận thanh toán hóa đơn #{_selectedPhieu.MaPhieu} với tổng số tiền {tongChiPhi:N0} VNĐ?",
                "Xác nhận Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_phieuBus.ThanhToanHoaDon(_selectedPhieu.MaPhieu, tongChiPhi))
                {
                    _selectedPhieu.TrangThai = "Đã thanh toán";
                    _selectedPhieu.TongTien = tongChiPhi;
                    HienThiHoaDonPreview(_selectedPhieu, chiTiets);
                    LoadDanhSachPhieu();
                    MessageBox.Show("Thanh toán và xuất hóa đơn thành công!", "Hoàn tất",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
    }
}
