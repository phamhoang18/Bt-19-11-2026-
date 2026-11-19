using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.DAL
{
    public class ThanhVienDAL
    {
        public List<ThanhVienDTO> GetAll()
        {
            var list = new List<ThanhVienDTO>();
            string sql = "SELECT MaThanhVien, HoTen, Email, ChuyenMon FROM ThanhVien";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ThanhVienDTO
                        {
                            MaThanhVien = reader.GetInt32(0),
                            HoTen = reader.GetString(1),
                            Email = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            ChuyenMon = reader.IsDBNull(3) ? "" : reader.GetString(3)
                        });
                    }
                }
            }
            return list;
        }
    }
}