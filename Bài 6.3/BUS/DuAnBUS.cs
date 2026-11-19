using System;
using System.Collections.Generic;
using ProjectTaskManagement.DAL;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.BUS
{
    public class DuAnBUS
    {
        private readonly DuAnDAL _dal = new DuAnDAL();

        public List<DuAnDTO> GetAll() => _dal.GetAll();

        public bool Add(DuAnDTO da, out string error)
        {
            if (string.IsNullOrWhiteSpace(da.TenDuAn))
            {
                error = "Tên dự án không được để trống!";
                return false;
            }
            if (da.NgayKetThuc < da.NgayBatDau)
            {
                error = "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!";
                return false;
            }
            error = string.Empty;
            return _dal.Insert(da);
        }

        public bool Update(DuAnDTO da, out string error)
        {
            if (da.MaDuAn <= 0)
            {
                error = "Vui lòng chọn dự án cần sửa!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(da.TenDuAn))
            {
                error = "Tên dự án không được để trống!";
                return false;
            }
            if (da.NgayKetThuc < da.NgayBatDau)
            {
                error = "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!";
                return false;
            }
            error = string.Empty;
            return _dal.Update(da);
        }

        public bool Delete(int maDuAn) => maDuAn > 0 && _dal.Delete(maDuAn);
    }
}