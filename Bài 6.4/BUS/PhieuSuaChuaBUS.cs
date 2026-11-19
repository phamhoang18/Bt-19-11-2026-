using System.Collections.Generic;
using System.Linq;
using GarageManagement.DAL;
using GarageManagement.DTO;

namespace GarageManagement.BUS
{
    public class PhieuSuaChuaBUS
    {
        private readonly PhieuSuaChuaDAL _dal = new PhieuSuaChuaDAL();

        public bool TaoPhieuSuaChua(PhieuSuaChuaDTO phieu, List<ChiTietSuaChuaDTO> chiTiets, out string message)
        {
            if (string.IsNullOrWhiteSpace(phieu.BienSo))
            {
                message = "Vui lòng chọn biển số xe cần lập phiếu!";
                return false;
            }
            if (chiTiets == null || chiTiets.Count == 0)
            {
                message = "Vui lòng thêm ít nhất 1 phụ tùng/dịch vụ vào phiếu sửa chữa!";
                return false;
            }
            return _dal.LapPhieuSuaChua(phieu, chiTiets, out message);
        }

        public List<PhieuSuaChuaDTO> GetAllPhieu(string trangThai) => _dal.GetAllPhieu(trangThai);

        public List<ChiTietSuaChuaDTO> GetChiTiet(int maPhieu) => _dal.GetChiTietByMaPhieu(maPhieu);

        public decimal TinhTongChiPhi(List<ChiTietSuaChuaDTO> chiTiets)
        {
            if (chiTiets == null || chiTiets.Count == 0) return 0;
            return chiTiets.Sum(x => (x.SoLuong * x.DonGia) + x.TienCong);
        }

        public bool HoanThanhSuaChua(int maPhieu, decimal tongTien)
        {
            return maPhieu > 0 && _dal.CapNhatTrangThaiVaThanhToan(maPhieu, tongTien, "Đã hoàn thành");
        }

        public bool ThanhToanHoaDon(int maPhieu, decimal tongTien)
        {
            return maPhieu > 0 && _dal.CapNhatTrangThaiVaThanhToan(maPhieu, tongTien, "Đã thanh toán");
        }
    }
}