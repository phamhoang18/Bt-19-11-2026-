using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using KaraokeManagement.DTO;

namespace KaraokeManagement.DAL
{
    public class DichVuDAL
    {
        public List<DichVuDTO> GetAll()
        {
            var list = new List<DichVuDTO>();
            string sql = "SELECT MaDV, TenDV, DonGia, TonKho FROM DichVu ORDER BY TenDV ASC";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DichVuDTO
                        {
                            MaDV = reader.GetInt32(0),
                            TenDV = reader.GetString(1),
                            DonGia = reader.GetDecimal(2),
                            TonKho = reader.GetInt32(3)
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(DichVuDTO dv)
        {
            string sql = "INSERT INTO DichVu (TenDV, DonGia, TonKho) VALUES (@TenDV, @DonGia, @TonKho)";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenDV", dv.TenDV);
                cmd.Parameters.AddWithValue("@DonGia", dv.DonGia);
                cmd.Parameters.AddWithValue("@TonKho", dv.TonKho);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(DichVuDTO dv)
        {
            string sql = "UPDATE DichVu SET TenDV = @TenDV, DonGia = @DonGia, TonKho = @TonKho WHERE MaDV = @MaDV";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDV", dv.MaDV);
                cmd.Parameters.AddWithValue("@TenDV", dv.TenDV);
                cmd.Parameters.AddWithValue("@DonGia", dv.DonGia);
                cmd.Parameters.AddWithValue("@TonKho", dv.TonKho);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}