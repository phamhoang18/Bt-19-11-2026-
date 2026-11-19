using System.Collections.Generic;
using ProjectTaskManagement.DAL;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.BUS
{
    public class CongViecBUS
    {
        private readonly CongViecDAL _cvDal = new CongViecDAL();
        private readonly PhanCongDAL _pcDal = new PhanCongDAL();

        public List<CongViecDTO> GetTasks(int? maDuAn, string trangThai) => _cvDal.GetTasks(maDuAn, trangThai);

        public bool AddTaskWithAssignments(CongViecDTO cv, List<int> memberIds, out string error)
        {
            if (cv.MaDuAn <= 0)
            {
                error = "Vui lòng chọn dự án cho công việc!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(cv.TenTask))
            {
                error = "Tên công việc (Task) không được để trống!";
                return false;
            }

            int newTaskId = _cvDal.InsertAndGetId(cv);
            if (newTaskId > 0 && memberIds != null && memberIds.Count > 0)
            {
                _pcDal.AssignMembersToTask(newTaskId, memberIds);
            }

            error = string.Empty;
            return newTaskId > 0;
        }

        public bool Update(CongViecDTO cv, out string error)
        {
            if (cv.MaTask <= 0)
            {
                error = "Vui lòng chọn công việc cần cập nhật!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(cv.TenTask))
            {
                error = "Tên công việc không được để trống!";
                return false;
            }
            error = string.Empty;
            return _cvDal.Update(cv);
        }

        public bool Delete(int maTask) => maTask > 0 && _cvDal.Delete(maTask);

        public bool ChangeStatus(int maTask, string trangThaiMoi)
        {
            if (maTask <= 0 || string.IsNullOrWhiteSpace(trangThaiMoi)) return false;
            return _cvDal.UpdateTrangThai(maTask, trangThaiMoi);
        }

        public List<CongViecDTO> GetOverdueTasks() => _cvDal.GetOverdueTasks();
    }
}