using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using KaraokeManagement.DTO;

namespace KaraokeManagement.DAL
{
    public class PhongHatDAL
    {
        public List<PhongHatDTO> GetAll(string loaiPhongFilter = "Tất cả")
        {
            var list = new List<PhongHatDTO>();
            string sql = @"
                SELECT MaPhong, TenPhong, LoaiPhong, GiaTheoGio, TrangThai
                FROM PhongHat
                WHERE (@LoaiPhong = N'Tất cả' OR LoaiPhong = @LoaiPhong)
                ORDER BY MaPhong ASC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@LoaiPhong", string.IsNullOrEmpty(loaiPhongFilter) ? "Tất cả" : loaiPhongFilter);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhongHatDTO
                        {
                            MaPhong = reader.GetInt32(0),
                            TenPhong = reader.GetString(1),
                            LoaiPhong = reader.IsDBNull(2) ? "Thường" : reader.GetString(2),
                            GiaTheoGio = reader.GetDecimal(3),
                            TrangThai = reader.IsDBNull(4) ? "Trống" : reader.GetString(4)
                        });
                    }
                }
            }
            return list;
        }
    }
}