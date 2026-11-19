namespace GarageManagement.DTO
{
    public class XeDTO
    {
        public string BienSo { get; set; }
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string HieuXe { get; set; }
        public int NamSanXuat { get; set; }

        public string DisplayXe => $"{BienSo} - {HieuXe} ({TenKH})";
    }
}