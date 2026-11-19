using System;
using System.Collections.Generic;
using GarageManagement.DAL;
using GarageManagement.DTO;

namespace GarageManagement.BUS
{
    public class XeKhachHangBUS
    {
        private readonly XeKhachHangDAL _dal = new XeKhachHangDAL();

        public XeDTO TimXe(string bienSo)
        {
            if (string.IsNullOrWhiteSpace(bienSo)) return null;
            return _dal.TimXeTheoBienSo(bienSo.Trim().ToUpper());
        }

        public List<XeDTO> GetAllXe() => _dal.GetAllXe();

        public bool LuuTiepNhan(KhachHangDTO kh, XeDTO xe, out string message)
        {
            if (string.IsNullOrWhiteSpace(xe.BienSo))
            {
                message = "Biển số xe không được để trống!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(kh.TenKH))
            {
                message = "Tên chủ xe không được để trống!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(kh.DienThoai))
            {
                message = "Số điện thoại chủ xe không được để trống!";
                return false;
            }
            if (xe.NamSanXuat < 1950 || xe.NamSanXuat > DateTime.Now.Year + 1)
            {
                message = "Năm sản xuất không hợp lệ!";
                return false;
            }

            xe.BienSo = xe.BienSo.Trim().ToUpper();
            return _dal.LuuTiepNhanXe(kh, xe, out message);
        }
    }
}