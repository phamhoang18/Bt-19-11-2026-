using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GarageManagement.DTO;

namespace GarageManagement.DAL
{
    public class XeKhachHangDAL
    {
        public XeDTO TimXeTheoBienSo(string bienSo)
        {
            string sql = @"
                SELECT x.BienSo, x.MaKH, kh.TenKH, kh.DienThoai, kh.DiaChi, x.HieuXe, x.NamSanXuat
                FROM Xe x
                JOIN KhachHang kh ON x.MaKH = kh.MaKH
                WHERE x.BienSo = @BienSo";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@BienSo", bienSo);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new XeDTO
                        {
                            BienSo = reader.GetString(0),
                            MaKH = reader.GetInt32(1),
                            TenKH = reader.GetString(2),
                            DienThoai = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            DiaChi = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            HieuXe = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            NamSanXuat = reader.IsDBNull(6) ? DateTime.Now.Year : reader.GetInt32(6)
                        };
                    }
                }
            }
            return null;
        }

        public List<XeDTO> GetAllXe()
        {
            var list = new List<XeDTO>();
            string sql = @"
                SELECT x.BienSo, x.MaKH, kh.TenKH, kh.DienThoai, kh.DiaChi, x.HieuXe, x.NamSanXuat
                FROM Xe x
                JOIN KhachHang kh ON x.MaKH = kh.MaKH
                ORDER BY x.BienSo ASC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new XeDTO
                        {
                            BienSo = reader.GetString(0),
                            MaKH = reader.GetInt32(1),
                            TenKH = reader.GetString(2),
                            DienThoai = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            DiaChi = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            HieuXe = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            NamSanXuat = reader.IsDBNull(6) ? 2020 : reader.GetInt32(6)
                        });
                    }
                }
            }
            return list;
        }

        public bool LuuTiepNhanXe(KhachHangDTO kh, XeDTO xe, out string message)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    int maKH = 0;
                    string sqlCheckKH = "SELECT MaKH FROM KhachHang WHERE DienThoai = @DienThoai";
                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheckKH, conn, trans))
                    {
                        cmdCheck.Parameters.AddWithValue("@DienThoai", kh.DienThoai);
                        object res = cmdCheck.ExecuteScalar();
                        if (res != null && res != DBNull.Value)
                        {
                            maKH = Convert.ToInt32(res);
                            string sqlUpdKH = "UPDATE KhachHang SET TenKH = @TenKH, DiaChi = @DiaChi WHERE MaKH = @MaKH";
                            using (SqlCommand cmdUpdKH = new SqlCommand(sqlUpdKH, conn, trans))
                            {
                                cmdUpdKH.Parameters.AddWithValue("@TenKH", kh.TenKH);
                                cmdUpdKH.Parameters.AddWithValue("@DiaChi", (object)kh.DiaChi ?? DBNull.Value);
                                cmdUpdKH.Parameters.AddWithValue("@MaKH", maKH);
                                cmdUpdKH.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string sqlInsKH = @"INSERT INTO KhachHang (TenKH, DienThoai, DiaChi)
                                                OUTPUT INSERTED.MaKH
                                                VALUES (@TenKH, @DienThoai, @DiaChi)";
                            using (SqlCommand cmdInsKH = new SqlCommand(sqlInsKH, conn, trans))
                            {
                                cmdInsKH.Parameters.AddWithValue("@TenKH", kh.TenKH);
                                cmdInsKH.Parameters.AddWithValue("@DienThoai", kh.DienThoai);
                                cmdInsKH.Parameters.AddWithValue("@DiaChi", (object)kh.DiaChi ?? DBNull.Value);
                                maKH = (int)cmdInsKH.ExecuteScalar();
                            }
                        }
                    }

                    string sqlCheckXe = "SELECT COUNT(*) FROM Xe WHERE BienSo = @BienSo";
                    using (SqlCommand cmdCheckXe = new SqlCommand(sqlCheckXe, conn, trans))
                    {
                        cmdCheckXe.Parameters.AddWithValue("@BienSo", xe.BienSo);
                        int count = (int)cmdCheckXe.ExecuteScalar();

                        if (count > 0)
                        {
                            string sqlUpdXe = @"UPDATE Xe SET MaKH = @MaKH, HieuXe = @HieuXe, NamSanXuat = @NamSX
                                                WHERE BienSo = @BienSo";
                            using (SqlCommand cmdUpdXe = new SqlCommand(sqlUpdXe, conn, trans))
                            {
                                cmdUpdXe.Parameters.AddWithValue("@MaKH", maKH);
                                cmdUpdXe.Parameters.AddWithValue("@HieuXe", xe.HieuXe);
                                cmdUpdXe.Parameters.AddWithValue("@NamSX", xe.NamSanXuat);
                                cmdUpdXe.Parameters.AddWithValue("@BienSo", xe.BienSo);
                                cmdUpdXe.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string sqlInsXe = @"INSERT INTO Xe (BienSo, MaKH, HieuXe, NamSanXuat)
                                                VALUES (@BienSo, @MaKH, @HieuXe, @NamSX)";
                            using (SqlCommand cmdInsXe = new SqlCommand(sqlInsXe, conn, trans))
                            {
                                cmdInsXe.Parameters.AddWithValue("@BienSo", xe.BienSo);
                                cmdInsXe.Parameters.AddWithValue("@MaKH", maKH);
                                cmdInsXe.Parameters.AddWithValue("@HieuXe", xe.HieuXe);
                                cmdInsXe.Parameters.AddWithValue("@NamSX", xe.NamSanXuat);
                                cmdInsXe.ExecuteNonQuery();
                            }
                        }
                    }

                    trans.Commit();
                    message = "Lưu thông tin tiếp nhận xe & chủ xe thành công!";
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    message = "Lỗi lưu tiếp nhận xe: " + ex.Message;
                    return false;
                }
            }
        }
    }
}
