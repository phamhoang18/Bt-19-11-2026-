namespace GarageManagement.DTO
{
    public class PhuTungDTO
    {
        public int MaPhuTung { get; set; }
        public string TenPhuTung { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }

        public string DisplayPhuTung => $"{TenPhuTung} | Giá: {DonGia:N0}đ (Tồn: {SoLuongTon})";
    }
}