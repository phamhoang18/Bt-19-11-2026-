using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.DAL
{
    public class PhanCongDAL
    {
        // Lấy danh sách MaThanhVien đã được phân công cho 1 Task
        public List<int> GetAssignedMemberIds(int maTask)
        {
            var ids = new List<int>();
            string sql = "SELECT MaThanhVien FROM PhanCong WHERE MaTask = @MaTask";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTask", maTask);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt32(0));
                    }
                }
            }
            return ids;
        }

        // Giao việc cho một hoặc nhiều thành viên (cập nhật lại danh sách phân công của Task)
        public bool AssignMembersToTask(int maTask, List<int> memberIds)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlDel = "DELETE FROM PhanCong WHERE MaTask = @MaTask";
                    using (SqlCommand cmdDel = new SqlCommand(sqlDel, conn, trans))
                    {
                        cmdDel.Parameters.AddWithValue("@MaTask", maTask);
                        cmdDel.ExecuteNonQuery();
                    }

                    string sqlIns = "INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (@MaTask, @MaTV, GETDATE())";
                    foreach (int maTV in memberIds)
                    {
                        using (SqlCommand cmdIns = new SqlCommand(sqlIns, conn, trans))
                        {
                            cmdIns.Parameters.AddWithValue("@MaTask", maTask);
                            cmdIns.Parameters.AddWithValue("@MaTV", maTV);
                            cmdIns.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        // Thống kê tỷ lệ % hoàn thành của từng thành viên trong dự án bằng GROUP BY
        public List<ThongKeThanhVienDTO> GetThongKeThanhVienTheoDuAn(int maDuAn)
        {
            var list = new List<ThongKeThanhVienDTO>();
            string sql = @"
                SELECT tv.MaThanhVien, tv.HoTen, tv.ChuyenMon,
                       COUNT(cv.MaTask) AS TongSoTask,
                       SUM(CASE WHEN cv.TrangThai = N'Done' THEN 1 ELSE 0 END) AS SoTaskHoanThanh,
                       CAST(ISNULL(SUM(CASE WHEN cv.TrangThai = N'Done' THEN 1.0 ELSE 0 END) * 100.0 
                            / NULLIF(COUNT(cv.MaTask), 0), 0) AS DECIMAL(5,2)) AS TyLeHoanThanh
                FROM ThanhVien tv
                JOIN PhanCong pc ON tv.MaThanhVien = pc.MaThanhVien
                JOIN CongViec cv ON pc.MaTask = cv.MaTask
                WHERE cv.MaDuAn = @MaDuAn
                GROUP BY tv.MaThanhVien, tv.HoTen, tv.ChuyenMon
                ORDER BY TyLeHoanThanh DESC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDuAn", maDuAn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ThongKeThanhVienDTO
                        {
                            MaThanhVien = reader.GetInt32(0),
                            HoTen = reader.GetString(1),
                            ChuyenMon = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            TongSoTask = reader.GetInt32(3),
                            SoTaskHoanThanh = reader.GetInt32(4),
                            TyLeHoanThanh = reader.GetDecimal(5)
                        });
                    }
                }
            }
            return list;
        }

        // Dùng ExecuteScalar tính tổng % hoàn thành chung của toàn dự án
        public decimal GetTyLeHoanThanhChungDuAn(int maDuAn)
        {
            string sql = @"
                SELECT CAST(ISNULL(SUM(CASE WHEN TrangThai = N'Done' THEN 1.0 ELSE 0 END) * 100.0 
                       / NULLIF(COUNT(MaTask), 0), 0) AS DECIMAL(5,2))
                FROM CongViec
                WHERE MaDuAn = @MaDuAn";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDuAn", maDuAn);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? 0m : Convert.ToDecimal(result);
            }
        }
    }
}