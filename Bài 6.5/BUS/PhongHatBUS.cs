using System.Collections.Generic;
using KaraokeManagement.DAL;
using KaraokeManagement.DTO;

namespace KaraokeManagement.BUS
{
    public class PhongHatBUS
    {
        private readonly PhongHatDAL _dal = new PhongHatDAL();
        public List<PhongHatDTO> GetAll(string loaiPhong = "Tất cả") => _dal.GetAll(loaiPhong);
    }
}