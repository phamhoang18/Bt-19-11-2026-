using System.Collections.Generic;
using GarageManagement.DAL;
using GarageManagement.DTO;

namespace GarageManagement.BUS
{
    public class PhuTungBUS
    {
        private readonly PhuTungDAL _dal = new PhuTungDAL();

        public List<PhuTungDTO> GetAll() => _dal.GetAll();

        public bool Add(PhuTungDTO pt, out string error)
        {
            if (string.IsNullOrWhiteSpace(pt.TenPhuTung))
            {
                error = "Tên phụ tùng không được để trống!";
                return false;
            }
            if (pt.DonGia < 0 || pt.SoLuongTon < 0)
            {
                error = "Đơn giá và số lượng tồn phải lớn hơn hoặc bằng 0!";
                return false;
            }
            error = string.Empty;
            return _dal.Insert(pt);
        }

        public bool Update(PhuTungDTO pt, out string error)
        {
            if (pt.MaPhuTung <= 0)
            {
                error = "Vui lòng chọn phụ tùng cần cập nhật!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(pt.TenPhuTung))
            {
                error = "Tên phụ tùng không được để trống!";
                return false;
            }
            if (pt.DonGia < 0 || pt.SoLuongTon < 0)
            {
                error = "Đơn giá và số lượng tồn phải lớn hơn hoặc bằng 0!";
                return false;
            }
            error = string.Empty;
            return _dal.Update(pt);
        }

        public bool Delete(int maPhuTung) => maPhuTung > 0 && _dal.Delete(maPhuTung);
    }
}