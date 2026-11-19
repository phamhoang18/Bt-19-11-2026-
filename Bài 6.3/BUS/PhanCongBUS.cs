using System.Collections.Generic;
using ProjectTaskManagement.DAL;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.BUS
{
    public class PhanCongBUS
    {
        private readonly PhanCongDAL _dal = new PhanCongDAL();

        public List<int> GetAssignedMemberIds(int maTask) => _dal.GetAssignedMemberIds(maTask);

        public bool AssignMembers(int maTask, List<int> memberIds)
        {
            if (maTask <= 0) return false;
            return _dal.AssignMembersToTask(maTask, memberIds ?? new List<int>());
        }

        public List<ThongKeThanhVienDTO> GetThongKeThanhVien(int maDuAn) => _dal.GetThongKeThanhVienTheoDuAn(maDuAn);

        public decimal GetTyLeHoanThanhDuAn(int maDuAn) => _dal.GetTyLeHoanThanhChungDuAn(maDuAn);
    }
}