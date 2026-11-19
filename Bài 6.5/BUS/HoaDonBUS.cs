using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using KaraokeManagement.DAL;
using KaraokeManagement.DTO;

namespace KaraokeManagement.BUS
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL _dal = new HoaDonDAL();

        public bool MoPhong(int maPhong, out string message)
        {
            if (maPhong <= 0)
            {
                message = "Vui lòng chọn phòng cần mở!";
                return false;
            }
            return _dal.MoPhong(maPhong, out message);
        }

        public HoaDonDTO GetHoaDonDangMo(int maPhong) => _dal.GetHoaDonChuaThanhToan(maPhong);

        public SqlDataAdapter GetDisconnectedChiTiet(int maHD, out DataTable dtChiTiet)
        {
            return _dal.CreateChiTietDichVuAdapter(maHD, out dtChiTiet);
        }

        public decimal TinhTienPhong(DateTime gioVao, DateTime gioRa, decimal giaTheoGio, out double soGioTinhTien)
        {
            double thoiGianThuc = (gioRa - gioVao).TotalHours;
            soGioTinhTien = Math.Max(0.25, Math.Round(thoiGianThuc, 2));
            return Math.Round((decimal)soGioTinhTien * giaTheoGio, 0);
        }

        public decimal TinhTongTienDichVu(DataTable dtChiTiet)
        {
            if (dtChiTiet == null || dtChiTiet.Rows.Count == 0) return 0m;
            decimal tong = 0m;
            foreach (DataRow row in dtChiTiet.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    tong += Convert.ToDecimal(row["SoLuong"]) * Convert.ToDecimal(row["DonGia"]);
                }
            }
            return tong;
        }

        public bool ThanhToan(int maHD, int maPhong, DateTime gioRa, decimal tongTienPhong,
                              decimal tongTienDichVu, DataTable dtDichVuDaGoi, out string message)
        {
            if (maHD <= 0 || maPhong <= 0)
            {
                message = "Không tìm thấy thông tin hóa đơn hoặc phòng hát!";
                return false;
            }
            return _dal.ThanhToanHoaDon(maHD, maPhong, gioRa, tongTienPhong, tongTienDichVu, dtDichVuDaGoi, out message);
        }

        public List<HoaDonDTO> GetLichSuHoaDon() => _dal.GetLichSuHoaDon();
    }
}