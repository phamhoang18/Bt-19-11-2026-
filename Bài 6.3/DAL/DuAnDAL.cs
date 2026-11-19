using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.DAL
{
    public class DuAnDAL
    {
        public List<DuAnDTO> GetAll()
        {
            var list = new List<DuAnDTO>();
            string sql = "SELECT MaDuAn, TenDuAn, NgayBatDau, NgayKetThuc, TrangThai FROM DuAn ORDER BY MaDuAn DESC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DuAnDTO
                        {
                            MaDuAn = reader.GetInt32(0),
                            TenDuAn = reader.GetString(1),
                            NgayBatDau = reader.IsDBNull(2) ? DateTime.Now : reader.GetDateTime(2),
                            NgayKetThuc = reader.IsDBNull(3) ? DateTime.Now : reader.GetDateTime(3),
                            TrangThai = reader.IsDBNull(4) ? "" : reader.GetString(4)
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(DuAnDTO da)
        {
            string sql = @"INSERT INTO DuAn (TenDuAn, NgayBatDau, NgayKetThuc, TrangThai)
                           VALUES (@TenDuAn, @NgayBatDau, @NgayKetThuc, @TrangThai)";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenDuAn", da.TenDuAn);
                cmd.Parameters.AddWithValue("@NgayBatDau", da.NgayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", da.NgayKetThuc);
                cmd.Parameters.AddWithValue("@TrangThai", da.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(DuAnDTO da)
        {
            string sql = @"UPDATE DuAn 
                           SET TenDuAn = @TenDuAn, NgayBatDau = @NgayBatDau, 
                               NgayKetThuc = @NgayKetThuc, TrangThai = @TrangThai
                           WHERE MaDuAn = @MaDuAn";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDuAn", da.MaDuAn);
                cmd.Parameters.AddWithValue("@TenDuAn", da.TenDuAn);
                cmd.Parameters.AddWithValue("@NgayBatDau", da.NgayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", da.NgayKetThuc);
                cmd.Parameters.AddWithValue("@TrangThai", da.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maDuAn)
        {
            string sql = "DELETE FROM DuAn WHERE MaDuAn = @MaDuAn";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDuAn", maDuAn);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}