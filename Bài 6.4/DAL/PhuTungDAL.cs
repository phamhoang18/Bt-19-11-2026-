using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GarageManagement.DTO;

namespace GarageManagement.DAL
{
    public class PhuTungDAL
    {
        public List<PhuTungDTO> GetAll()
        {
            var list = new List<PhuTungDTO>();
            string sql = "SELECT MaPhuTung, TenPhuTung, DonGia, SoLuongTon FROM PhuTung ORDER BY TenPhuTung ASC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhuTungDTO
                        {
                            MaPhuTung = reader.GetInt32(0),
                            TenPhuTung = reader.GetString(1),
                            DonGia = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                            SoLuongTon = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(PhuTungDTO pt)
        {
            string sql = "INSERT INTO PhuTung (TenPhuTung, DonGia, SoLuongTon) VALUES (@Ten, @DonGia, @Ton)";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Ten", pt.TenPhuTung);
                cmd.Parameters.AddWithValue("@DonGia", pt.DonGia);
                cmd.Parameters.AddWithValue("@Ton", pt.SoLuongTon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(PhuTungDTO pt)
        {
            string sql = @"UPDATE PhuTung 
                           SET TenPhuTung = @Ten, DonGia = @DonGia, SoLuongTon = @Ton 
                           WHERE MaPhuTung = @MaPT";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPT", pt.MaPhuTung);
                cmd.Parameters.AddWithValue("@Ten", pt.TenPhuTung);
                cmd.Parameters.AddWithValue("@DonGia", pt.DonGia);
                cmd.Parameters.AddWithValue("@Ton", pt.SoLuongTon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maPhuTung)
        {
            string sql = "DELETE FROM PhuTung WHERE MaPhuTung = @MaPT";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPT", maPhuTung);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
