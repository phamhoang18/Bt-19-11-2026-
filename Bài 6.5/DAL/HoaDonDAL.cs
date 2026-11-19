using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using KaraokeManagement.DTO;

namespace KaraokeManagement.DAL
{
    public class HoaDonDAL
    {
        public bool MoPhong(int maPhong, out string message)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlCheck = "SELECT TrangThai FROM PhongHat WHERE MaPhong = @MaPhong";
                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn, trans))
                    {
                        cmdCheck.Parameters.AddWithValue("@MaPhong", maPhong);
                        string trangThai = cmdCheck.ExecuteScalar()?.ToString();
                        if (trangThai != "Trống")
                        {
                            trans.Rollback();
                            message = "Phòng này hiện không ở trạng thái Trống!";
                            return false;
                        }
                    }

                    string sqlHD = @"INSERT INTO HoaDon (MaPhong, GioVao, TongTienPhong, TongTienDichVu, TrangThai)
                                     VALUES (@MaPhong, GETDATE(), 0, 0, 0)";
                    using (SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans))
                    {
                        cmdHD.Parameters.AddWithValue("@MaPhong", maPhong);
                        cmdHD.ExecuteNonQuery();
                    }

                    string sqlPhong = "UPDATE PhongHat SET TrangThai = N'Đang hát' WHERE MaPhong = @MaPhong";
                    using (SqlCommand cmdPhong = new SqlCommand(sqlPhong, conn, trans))
                    {
                        cmdPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                        cmdPhong.ExecuteNonQuery();
                    }

                    trans.Commit();
                    message = "Mở phòng thành công!";
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    message = "Lỗi khi mở phòng: " + ex.Message;
                    return false;
                }
            }
        }

        public HoaDonDTO GetHoaDonChuaThanhToan(int maPhong)
        {
            string sql = @"
                SELECT TOP 1 hd.MaHD, hd.MaPhong, p.TenPhong, hd.GioVao, hd.GioRa, 
                       hd.TongTienPhong, hd.TongTienDichVu, hd.TrangThai
                FROM HoaDon hd
                JOIN PhongHat p ON hd.MaPhong = p.MaPhong
                WHERE hd.MaPhong = @MaPhong AND hd.TrangThai = 0
                ORDER BY hd.MaHD DESC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new HoaDonDTO
                        {
                            MaHD = reader.GetInt32(0),
                            MaPhong = reader.GetInt32(1),
                            TenPhong = reader.GetString(2),
                            GioVao = reader.GetDateTime(3),
                            GioRa = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            TongTienPhong = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5),
                            TongTienDichVu = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                            TrangThai = reader.GetBoolean(7)
                        };
                    }
                }
            }
            return null;
        }

        public SqlDataAdapter CreateChiTietDichVuAdapter(int maHD, out DataTable dtChiTiet)
        {
            string sql = "SELECT MaHD, MaDV, SoLuong, DonGia FROM ChiTietDichVu WHERE MaHD = @MaHD";
            SqlConnection conn = DBConnection.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@MaHD", maHD);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.DeleteCommand = builder.GetDeleteCommand();

            dtChiTiet = new DataTable();
            adapter.Fill(dtChiTiet);
            dtChiTiet.PrimaryKey = new DataColumn[] { dtChiTiet.Columns["MaHD"], dtChiTiet.Columns["MaDV"] };

            if (!dtChiTiet.Columns.Contains("ThanhTien"))
            {
                dtChiTiet.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * DonGia");
            }

            return adapter;
        }

        public bool ThanhToanHoaDon(int maHD, int maPhong, DateTime gioRa, decimal tongTienPhong,
                                    decimal tongTienDichVu, DataTable dtDichVuDaGoi, out string message)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlHD = @"
                        UPDATE HoaDon
                        SET GioRa = @GioRa,
                            TongTienPhong = @TongTienPhong,
                            TongTienDichVu = @TongTienDichVu,
                            TrangThai = 1
                        WHERE MaHD = @MaHD AND TrangThai = 0";

                    using (SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans))
                    {
                        cmdHD.Parameters.AddWithValue("@GioRa", gioRa);
                        cmdHD.Parameters.AddWithValue("@TongTienPhong", tongTienPhong);
                        cmdHD.Parameters.AddWithValue("@TongTienDichVu", tongTienDichVu);
                        cmdHD.Parameters.AddWithValue("@MaHD", maHD);

                        if (cmdHD.ExecuteNonQuery() == 0)
                        {
                            trans.Rollback();
                            message = "Hóa đơn không hợp lệ hoặc đã được thanh toán trước đó!";
                            return false;
                        }
                    }

                    if (dtDichVuDaGoi != null)
                    {
                        foreach (DataRow row in dtDichVuDaGoi.Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;

                            int maDV = Convert.ToInt32(row["MaDV"]);
                            int soLuong = Convert.ToInt32(row["SoLuong"]);

                            string sqlKho = @"
                                UPDATE DichVu
                                SET TonKho = TonKho - @SoLuong
                                WHERE MaDV = @MaDV AND TonKho >= @SoLuong";

                            using (SqlCommand cmdKho = new SqlCommand(sqlKho, conn, trans))
                            {
                                cmdKho.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmdKho.Parameters.AddWithValue("@MaDV", maDV);

                                if (cmdKho.ExecuteNonQuery() == 0)
                                {
                                    trans.Rollback();
                                    message = $"Dịch vụ mã #{maDV} không đủ số lượng tồn kho để thanh toán!\nGiao dịch đã hoàn tác (Rollback).";
                                    return false;
                                }
                            }
                        }
                    }

                    string sqlPhong = "UPDATE PhongHat SET TrangThai = N'Trống' WHERE MaPhong = @MaPhong";
                    using (SqlCommand cmdPhong = new SqlCommand(sqlPhong, conn, trans))
                    {
                        cmdPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                        cmdPhong.ExecuteNonQuery();
                    }

                    trans.Commit();
                    message = $"Thanh toán hóa đơn #{maHD} thành công!";
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    message = "Lỗi giao dịch thanh toán (Đã Rollback): " + ex.Message;
                    return false;
                }
            }
        }

        public List<HoaDonDTO> GetLichSuHoaDon()
        {
            var list = new List<HoaDonDTO>();
            string sql = @"
                SELECT hd.MaHD, hd.MaPhong, p.TenPhong, hd.GioVao, hd.GioRa, 
                       hd.TongTienPhong, hd.TongTienDichVu, hd.TrangThai
                FROM HoaDon hd
                JOIN PhongHat p ON hd.MaPhong = p.MaPhong
                WHERE hd.TrangThai = 1
                ORDER BY hd.GioRa DESC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new HoaDonDTO
                        {
                            MaHD = reader.GetInt32(0),
                            MaPhong = reader.GetInt32(1),
                            TenPhong = reader.GetString(2),
                            GioVao = reader.GetDateTime(3),
                            GioRa = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            TongTienPhong = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5),
                            TongTienDichVu = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                            TrangThai = reader.GetBoolean(7)
                        });
                    }
                }
            }
            return list;
        }
    }
}