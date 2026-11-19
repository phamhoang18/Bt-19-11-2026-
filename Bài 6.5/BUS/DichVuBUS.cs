using System.Collections.Generic;
using KaraokeManagement.DAL;
using KaraokeManagement.DTO;

namespace KaraokeManagement.BUS
{
    public class DichVuBUS
    {
        private readonly DichVuDAL _dal = new DichVuDAL();

        public List<DichVuDTO> GetAll() => _dal.GetAll();

        public bool Add(DichVuDTO dv, out string error)
        {
            if (string.IsNullOrWhiteSpace(dv.TenDV))
            {
                error = "Tên dịch vụ không được để trống!";
                return false;
            }
            if (dv.DonGia < 0 || dv.TonKho < 0)
            {
                error = "Đơn giá và tồn kho phải >= 0!";
                return false;
            }
            error = string.Empty;
            return _dal.Insert(dv);
        }

        public bool Update(DichVuDTO dv, out string error)
        {
            if (dv.MaDV <= 0)
            {
                error = "Vui lòng chọn dịch vụ cần cập nhật!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(dv.TenDV))
            {
                error = "Tên dịch vụ không được để trống!";
                return false;
            }
            if (dv.DonGia < 0 || dv.TonKho < 0)
            {
                error = "Đơn giá và tồn kho phải >= 0!";
                return false;
            }
            error = string.Empty;
            return _dal.Update(dv);
        }
    }
}