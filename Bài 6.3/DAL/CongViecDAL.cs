using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.DAL
{
    public class CongViecDAL
    {
        // Lọc danh sách Task theo Dự án và Trạng thái
        public List<CongViecDTO> GetTasks(int? maDuAn, string trangThai)
        {
            var list = new List<CongViecDTO>();
            string sql = @"
                SELECT cv.MaTask, cv.MaDuAn, da.TenDuAn, cv.TenTask, cv.MoTa, 
                       cv.HanNop, cv.DoUuTien, cv.TrangThai,
                       ISNULL(STUFF((
                           SELECT ', ' + tv.HoTen
                           FROM PhanCong pc
                           JOIN ThanhVien tv ON pc.MaThanhVien = tv.MaThanhVien
                           WHERE pc.MaTask = cv.MaTask
                           FOR XML PATH('')
                       ), 1, 2, ''), N'Chưa giao') AS NguoiThucHien
                FROM CongViec cv
                JOIN DuAn da ON cv.MaDuAn = da.MaDuAn
                WHERE (@MaDuAn IS NULL OR cv.MaDuAn = @MaDuAn)
                  AND (@TrangThai = N'Tất cả' OR cv.TrangThai = @TrangThai)
                ORDER BY cv.HanNop ASC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDuAn", (object)maDuAn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", string.IsNullOrEmpty(trangThai) ? "Tất cả" : trangThai);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CongViecDTO
                        {
                            MaTask = reader.GetInt32(0),
                            MaDuAn = reader.GetInt32(1),
                            TenDuAn = reader.GetString(2),
                            TenTask = reader.GetString(3),
                            MoTa = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            HanNop = reader.IsDBNull(5) ? DateTime.Now : reader.GetDateTime(5),
                            DoUuTien = reader.IsDBNull(6) ? "Trung bình" : reader.GetString(6),
                            TrangThai = reader.IsDBNull(7) ? "To Do" : reader.GetString(7),
                            NguoiThucHien = reader.GetString(8)
                        });
                    }
                }
            }
            return list;
        }

        // Thêm Task và trả về MaTask vừa tạo (để phân công ngay nếu có)
        public int InsertAndGetId(CongViecDTO cv)
        {
            string sql = @"INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai)
                           OUTPUT INSERTED.MaTask
                           VALUES (@MaDuAn, @TenTask, @MoTa, @HanNop, @DoUuTien, @TrangThai)";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDuAn", cv.MaDuAn);
                cmd.Parameters.AddWithValue("@TenTask", cv.TenTask);
                cmd.Parameters.AddWithValue("@MoTa", (object)cv.MoTa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HanNop", cv.HanNop);
                cmd.Parameters.AddWithValue("@DoUuTien", cv.DoUuTien);
                cmd.Parameters.AddWithValue("@TrangThai", cv.TrangThai);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public bool Update(CongViecDTO cv)
        {
            string sql = @"UPDATE CongViec 
                           SET MaDuAn = @MaDuAn, TenTask = @TenTask, MoTa = @MoTa,
                               HanNop = @HanNop, DoUuTien = @DoUuTien, TrangThai = @TrangThai
                           WHERE MaTask = @MaTask";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTask", cv.MaTask);
                cmd.Parameters.AddWithValue("@MaDuAn", cv.MaDuAn);
                cmd.Parameters.AddWithValue("@TenTask", cv.TenTask);
                cmd.Parameters.AddWithValue("@MoTa", (object)cv.MoTa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HanNop", cv.HanNop);
                cmd.Parameters.AddWithValue("@DoUuTien", cv.DoUuTien);
                cmd.Parameters.AddWithValue("@TrangThai", cv.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maTask)
        {
            string sql = "DELETE FROM CongViec WHERE MaTask = @MaTask";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTask", maTask);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Chuyển trạng thái công việc bằng Parameterized SQL Update
        public bool UpdateTrangThai(int maTask, string trangThaiMoi)
        {
            string sql = "UPDATE CongViec SET TrangThai = @TrangThai WHERE MaTask = @MaTask";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                cmd.Parameters.AddWithValue("@MaTask", maTask);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Dùng SqlDataReader hiển thị các công việc đã quá HanNop mà TrangThai != 'Done'
        public List<CongViecDTO> GetOverdueTasks()
        {
            var list = new List<CongViecDTO>();
            string sql = @"SELECT cv.MaTask, cv.MaDuAn, da.TenDuAn, cv.TenTask, cv.MoTa, 
                                  cv.HanNop, cv.DoUuTien, cv.TrangThai
                           FROM CongViec cv
                           JOIN DuAn da ON cv.MaDuAn = da.MaDuAn
                           WHERE cv.HanNop < GETDATE() AND cv.TrangThai != N'Done'
                           ORDER BY cv.HanNop ASC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CongViecDTO
                        {
                            MaTask = reader.GetInt32(0),
                            MaDuAn = reader.GetInt32(1),
                            TenDuAn = reader.GetString(2),
                            TenTask = reader.GetString(3),
                            MoTa = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            HanNop = reader.GetDateTime(5),
                            DoUuTien = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            TrangThai = reader.GetString(7)
                        });
                    }
                }
            }
            return list;
        }
    }
}