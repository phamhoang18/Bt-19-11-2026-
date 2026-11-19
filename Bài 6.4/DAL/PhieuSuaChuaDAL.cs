using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using GarageManagement.DTO;

namespace GarageManagement.DAL
{
    public class PhieuSuaChuaDAL
    {
        // Lập phiếu sửa chữa, thêm chi tiết và trừ kho trong 1 SqlTransaction
        public bool LapPhieuSuaChua(PhieuSuaChuaDTO phieu, List<ChiTietSuaChuaDTO> chiTiets, out string message)
        {
            decimal tongTien = chiTiets.Sum(x => (x.SoLuong * x.DonGia) + x.TienCong);

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Tạo bản ghi PhieuSuaChua
                    string sqlPhieu = @"
                        INSERT INTO PhieuSuaChua (BienSo, NgayNhan, NoiDungSua, TongTien, TrangThai)
                        OUTPUT INSERTED.MaPhieu
                        VALUES (@BienSo, GETDATE(), @NoiDung, @TongTien, N'Đang sửa')";

                    int maPhieuMoi;
                    using (SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, conn, trans))
                    {
                        cmdPhieu.Parameters.AddWithValue("@BienSo", phieu.BienSo);
                        cmdPhieu.Parameters.AddWithValue("@NoiDung", (object)phieu.NoiDungSua ?? DBNull.Value);
                        cmdPhieu.Parameters.AddWithValue("@TongTien", tongTien);
                        maPhieuMoi = (int)cmdPhieu.ExecuteScalar();
                    }

                    // 2 & 3. Trừ tồn kho PhuTung và tạo ChiTietSuaChua
                    foreach (var ct in chiTiets)
                    {
                        string sqlTruKho = @"
                            UPDATE PhuTung 
                            SET SoLuongTon = SoLuongTon - @SoLuong 
                            WHERE MaPhuTung = @MaPT AND SoLuongTon >= @SoLuong";

                        using (SqlCommand cmdKho = new SqlCommand(sqlTruKho, conn, trans))
                        {
                            cmdKho.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                            cmdKho.Parameters.AddWithValue("@MaPT", ct.MaPhuTung);
                            int rows = cmdKho.ExecuteNonQuery();

                            // 4. Nếu không đủ số lượng trong kho -> Rollback và báo lỗi
                            if (rows == 0)
                            {
                                trans.Rollback();
                                message = $"Phụ tùng '{ct.TenPhuTung}' (Mã {ct.MaPhuTung}) không đủ số lượng tồn kho!\nGiao dịch đã được hoàn tác (Rollback).";
                                return false;
                            }
                        }

                        string sqlChiTiet = @"
                            INSERT INTO ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong)
                            VALUES (@MaPhieu, @MaPT, @SoLuong, @TienCong)";

                        using (SqlCommand cmdCT = new SqlCommand(sqlChiTiet, conn, trans))
                        {
                            cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieuMoi);
                            cmdCT.Parameters.AddWithValue("@MaPT", ct.MaPhuTung);
                            cmdCT.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                            cmdCT.Parameters.AddWithValue("@TienCong", ct.TienCong);
                            cmdCT.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    message = $"Lập phiếu sửa chữa #{maPhieuMoi} thành công và đã trừ tồn kho!";
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    message = "Lỗi giao dịch CSDL (Đã Rollback): " + ex.Message;
                    return false;
                }
            }
        }

        public List<PhieuSuaChuaDTO> GetAllPhieu(string trangThaiFilter)
        {
            var list = new List<PhieuSuaChuaDTO>();
            string sql = @"
                SELECT p.MaPhieu, p.BienSo, kh.TenKH, x.HieuXe, p.NgayNhan, p.NoiDungSua, p.TongTien, p.TrangThai
                FROM PhieuSuaChua p
                JOIN Xe x ON p.BienSo = x.BienSo
                JOIN KhachHang kh ON x.MaKH = kh.MaKH
                WHERE (@TrangThai = N'Tất cả' OR p.TrangThai = @TrangThai)
                ORDER BY p.MaPhieu DESC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TrangThai", string.IsNullOrEmpty(trangThaiFilter) ? "Tất cả" : trangThaiFilter);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhieuSuaChuaDTO
                        {
                            MaPhieu = reader.GetInt32(0),
                            BienSo = reader.GetString(1),
                            TenKH = reader.GetString(2),
                            HieuXe = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            NgayNhan = reader.GetDateTime(4),
                            NoiDungSua = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            TongTien = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                            TrangThai = reader.GetString(7)
                        });
                    }
                }
            }
            return list;
        }

        public List<ChiTietSuaChuaDTO> GetChiTietByMaPhieu(int maPhieu)
        {
            var list = new List<ChiTietSuaChuaDTO>();
            string sql = @"
                SELECT ct.MaPhieu, ct.MaPhuTung, pt.TenPhuTung, ct.SoLuong, pt.DonGia, ct.TienCong
                FROM ChiTietSuaChua ct
                JOIN PhuTung pt ON ct.MaPhuTung = pt.MaPhuTung
                WHERE ct.MaPhieu = @MaPhieu";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChiTietSuaChuaDTO
                        {
                            MaPhieu = reader.GetInt32(0),
                            MaPhuTung = reader.GetInt32(1),
                            TenPhuTung = reader.GetString(2),
                            SoLuong = reader.GetInt32(3),
                            DonGia = reader.GetDecimal(4),
                            TienCong = reader.GetDecimal(5)
                        });
                    }
                }
            }
            return list;
        }

        public bool CapNhatTrangThaiVaThanhToan(int maPhieu, decimal tongTienChinhXac, string trangThaiMoi)
        {
            string sql = @"UPDATE PhieuSuaChua 
                           SET TongTien = @TongTien, TrangThai = @TrangThai 
                           WHERE MaPhieu = @MaPhieu";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TongTien", tongTienChinhXac);
                cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}