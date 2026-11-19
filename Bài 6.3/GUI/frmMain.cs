using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProjectTaskManagement.BUS;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.GUI
{
    public partial class frmMain : Form
    {
        private readonly DuAnBUS _duAnBus = new DuAnBUS();
        private readonly ThanhVienBUS _tvBus = new ThanhVienBUS();
        private readonly CongViecBUS _cvBus = new CongViecBUS();
        private readonly PhanCongBUS _pcBus = new PhanCongBUS();

        private int _selectedMaDuAn = 0;
        private int _selectedMaTask = 0;
        private bool _isUpdatingKanbanSelection = false;

        private readonly string[] _statusFlow = { "To Do", "In Progress", "Review", "Done" };
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cboTrangThaiDA.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;
            cboDoUuTien.SelectedIndex = 1;
            cboTrangThaiTask.SelectedIndex = 0;

            LoadDanhSachThanhVien();
            LoadDanhSachDuAn();
            LoadTasks();
            LoadKanbanBoard();
            LoadOverdueTasks();
            LoadThongKe();
        }

        #region 1. QUẢN LÝ DỰ ÁN
        private void LoadDanhSachDuAn()
        {
            var listDuAn = _duAnBus.GetAll();
            dgvDuAn.DataSource = listDuAn;

            if (dgvDuAn.Columns["MaDuAn"] != null) dgvDuAn.Columns["MaDuAn"].HeaderText = "Mã DA";
            if (dgvDuAn.Columns["TenDuAn"] != null) dgvDuAn.Columns["TenDuAn"].HeaderText = "Tên Dự Án";
            if (dgvDuAn.Columns["NgayBatDau"] != null) dgvDuAn.Columns["NgayBatDau"].HeaderText = "Bắt Đầu";
            if (dgvDuAn.Columns["NgayKetThuc"] != null) dgvDuAn.Columns["NgayKetThuc"].HeaderText = "Kết Thúc";
            if (dgvDuAn.Columns["TrangThai"] != null) dgvDuAn.Columns["TrangThai"].HeaderText = "Trạng Thái";

            // Cập nhật các ComboBox chọn Dự án ở 3 tab
            BindProjectComboBox(cboLocDuAn, listDuAn);
            BindProjectComboBox(cboKanbanDuAn, listDuAn);
            BindProjectComboBox(cboThongKeDuAn, listDuAn);
        }

        private void BindProjectComboBox(ComboBox cbo, List<DuAnDTO> list)
        {
            var copy = new List<DuAnDTO>(list);
            cbo.DataSource = copy;
            cbo.DisplayMember = "TenDuAn";
            cbo.ValueMember = "MaDuAn";
        }

        private void dgvDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvDuAn.Rows[e.RowIndex].DataBoundItem as DuAnDTO;
            if (row == null) return;

            _selectedMaDuAn = row.MaDuAn;
            txtTenDuAn.Text = row.TenDuAn;
            dtpNgayBD.Value = row.NgayBatDau;
            dtpNgayKT.Value = row.NgayKetThuc;
            cboTrangThaiDA.SelectedItem = row.TrangThai;

            // Đồng bộ lọc task theo dự án vừa chọn
            cboLocDuAn.SelectedValue = _selectedMaDuAn;
            LoadTasks();
        }

        private void btnThemDA_Click(object sender, EventArgs e)
        {
            var da = new DuAnDTO
            {
                TenDuAn = txtTenDuAn.Text.Trim(),
                NgayBatDau = dtpNgayBD.Value.Date,
                NgayKetThuc = dtpNgayKT.Value.Date,
                TrangThai = cboTrangThaiDA.Text
            };

            if (_duAnBus.Add(da, out string error))
            {
                MessageBox.Show("Thêm dự án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachDuAn();
                ClearDuAnInputs();
            }
            else
            {
                MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaDA_Click(object sender, EventArgs e)
        {
            var da = new DuAnDTO
            {
                MaDuAn = _selectedMaDuAn,
                TenDuAn = txtTenDuAn.Text.Trim(),
                NgayBatDau = dtpNgayBD.Value.Date,
                NgayKetThuc = dtpNgayKT.Value.Date,
                TrangThai = cboTrangThaiDA.Text
            };

            if (_duAnBus.Update(da, out string error))
            {
                MessageBox.Show("Cập nhật dự án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachDuAn();
            }
            else
            {
                MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaDA_Click(object sender, EventArgs e)
        {
            if (_selectedMaDuAn <= 0)
            {
                MessageBox.Show("Vui lòng chọn dự án cần xóa!", "Thông báo");
                return;
            }
            if (MessageBox.Show("Xóa dự án sẽ xóa toàn bộ công việc thuộc dự án này. Tiếp tục?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_duAnBus.Delete(_selectedMaDuAn))
                {
                    LoadDanhSachDuAn();
                    LoadTasks();
                    ClearDuAnInputs();
                }
            }
        }

        private void btnLamMoiDA_Click(object sender, EventArgs e)
        {
            ClearDuAnInputs();
            LoadDanhSachDuAn();
        }

        private void ClearDuAnInputs()
        {
            _selectedMaDuAn = 0;
            txtTenDuAn.Clear();
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now.AddMonths(1);
            cboTrangThaiDA.SelectedIndex = 0;
        }
        #endregion

        #region 2. QUẢN LÝ TASK & PHÂN CÔNG THÀNH VIÊN
        private void LoadDanhSachThanhVien()
        {
            clbThanhVien.Items.Clear();
            foreach (var tv in _tvBus.GetAll())
            {
                clbThanhVien.Items.Add(tv, false);
            }
        }

        private void LoadTasks()
        {
            int? maDuAn = cboLocDuAn.SelectedValue is int id ? id : (int?)null;
            string trangThai = cboLocTrangThai.Text;

            var tasks = _cvBus.GetTasks(maDuAn, trangThai);
            dgvCongViec.DataSource = tasks;

            if (dgvCongViec.Columns["MaDuAn"] != null) dgvCongViec.Columns["MaDuAn"].Visible = false;
            if (dgvCongViec.Columns["MoTa"] != null) dgvCongViec.Columns["MoTa"].Visible = false;
            if (dgvCongViec.Columns["KanbanDisplay"] != null) dgvCongViec.Columns["KanbanDisplay"].Visible = false;

            if (dgvCongViec.Columns["MaTask"] != null) dgvCongViec.Columns["MaTask"].HeaderText = "Mã";
            if (dgvCongViec.Columns["TenDuAn"] != null) dgvCongViec.Columns["TenDuAn"].HeaderText = "Dự Án";
            if (dgvCongViec.Columns["TenTask"] != null) dgvCongViec.Columns["TenTask"].HeaderText = "Tên Công Việc";
            if (dgvCongViec.Columns["HanNop"] != null) dgvCongViec.Columns["HanNop"].HeaderText = "Hạn Nộp";
            if (dgvCongViec.Columns["DoUuTien"] != null) dgvCongViec.Columns["DoUuTien"].HeaderText = "Ưu Tiên";
            if (dgvCongViec.Columns["TrangThai"] != null) dgvCongViec.Columns["TrangThai"].HeaderText = "Trạng Thái";
            if (dgvCongViec.Columns["NguoiThucHien"] != null) dgvCongViec.Columns["NguoiThucHien"].HeaderText = "Người Thực Hiện";
        }

        private void btnLocTask_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void dgvCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var task = dgvCongViec.Rows[e.RowIndex].DataBoundItem as CongViecDTO;
            if (task == null) return;

            _selectedMaTask = task.MaTask;
            txtTenTask.Text = task.TenTask;
            txtMoTa.Text = task.MoTa;
            dtpHanNop.Value = task.HanNop;
            cboDoUuTien.SelectedItem = task.DoUuTien;
            cboTrangThaiTask.SelectedItem = task.TrangThai;

            // Tick các thành viên đã được phân công cho Task này
            var assignedIds = _pcBus.GetAssignedMemberIds(_selectedMaTask);
            for (int i = 0; i < clbThanhVien.Items.Count; i++)
            {
                var tv = (ThanhVienDTO)clbThanhVien.Items[i];
                clbThanhVien.SetItemChecked(i, assignedIds.Contains(tv.MaThanhVien));
            }
        }

        private List<int> GetCheckedMemberIds()
        {
            var ids = new List<int>();
            foreach (var item in clbThanhVien.CheckedItems)
            {
                if (item is ThanhVienDTO tv)
                {
                    ids.Add(tv.MaThanhVien);
                }
            }
            return ids;
        }

        private void btnThemTask_Click(object sender, EventArgs e)
        {
            if (!(cboLocDuAn.SelectedValue is int maDuAn))
            {
                MessageBox.Show("Vui lòng chọn dự án ở bộ lọc phía trên trước khi thêm Task!");
                return;
            }

            var cv = new CongViecDTO
            {
                MaDuAn = maDuAn,
                TenTask = txtTenTask.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                HanNop = dtpHanNop.Value,
                DoUuTien = cboDoUuTien.Text,
                TrangThai = cboTrangThaiTask.Text
            };

            if (_cvBus.AddTaskWithAssignments(cv, GetCheckedMemberIds(), out string error))
            {
                MessageBox.Show("Thêm công việc và phân công thành công!", "Thông báo");
                LoadTasks();
                LoadKanbanBoard();
            }
            else
            {
                MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaTask_Click(object sender, EventArgs e)
        {
            if (!(cboLocDuAn.SelectedValue is int maDuAn)) return;

            var cv = new CongViecDTO
            {
                MaTask = _selectedMaTask,
                MaDuAn = maDuAn,
                TenTask = txtTenTask.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                HanNop = dtpHanNop.Value,
                DoUuTien = cboDoUuTien.Text,
                TrangThai = cboTrangThaiTask.Text
            };

            if (_cvBus.Update(cv, out string error))
            {
                MessageBox.Show("Cập nhật công việc thành công!", "Thông báo");
                LoadTasks();
                LoadKanbanBoard();
            }
            else
            {
                MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaTask_Click(object sender, EventArgs e)
        {
            if (_selectedMaTask <= 0)
            {
                MessageBox.Show("Vui lòng chọn công việc cần xóa!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa công việc này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_cvBus.Delete(_selectedMaTask))
                {
                    _selectedMaTask = 0;
                    LoadTasks();
                    LoadKanbanBoard();
                }
            }
        }

        private void btnLuuPhanCong_Click(object sender, EventArgs e)
        {
            if (_selectedMaTask <= 0)
            {
                MessageBox.Show("Vui lòng chọn một công việc trên bảng trước khi phân công!");
                return;
            }

            if (_pcBus.AssignMembers(_selectedMaTask, GetCheckedMemberIds()))
            {
                MessageBox.Show("Cập nhật phân công thành viên thành công!", "Thông báo");
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu phân công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChuyenTrangThai_Click(object sender, EventArgs e)
        {
            if (_selectedMaTask <= 0)
            {
                MessageBox.Show("Vui lòng chọn công việc cần chuyển trạng thái!");
                return;
            }

            int idx = Array.IndexOf(_statusFlow, cboTrangThaiTask.Text);
            string nextStatus = (idx >= 0 && idx < _statusFlow.Length - 1) ? _statusFlow[idx + 1] : "Done";

            if (_cvBus.ChangeStatus(_selectedMaTask, nextStatus))
            {
                cboTrangThaiTask.SelectedItem = nextStatus;
                LoadTasks();
                LoadKanbanBoard();
            }
        }
        #endregion

        #region 3. KANBAN BOARD VIEW
        private void LoadKanbanBoard()
        {
            if (!(cboKanbanDuAn.SelectedValue is int maDuAn)) return;

            var allTasks = _cvBus.GetTasks(maDuAn, "Tất cả");

            BindKanbanColumn(lstToDo, allTasks.FindAll(t => t.TrangThai == "To Do"));
            BindKanbanColumn(lstInProgress, allTasks.FindAll(t => t.TrangThai == "In Progress"));
            BindKanbanColumn(lstReview, allTasks.FindAll(t => t.TrangThai == "Review"));
            BindKanbanColumn(lstDone, allTasks.FindAll(t => t.TrangThai == "Done"));
        }

        private void BindKanbanColumn(ListBox lst, List<CongViecDTO> items)
        {
            lst.DataSource = null;
            lst.DataSource = items;
            lst.DisplayMember = "KanbanDisplay";
            lst.ValueMember = "MaTask";
            lst.ClearSelected();
        }

        private void btnTaiKanban_Click(object sender, EventArgs e)
        {
            LoadKanbanBoard();
        }

        private void KanbanList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isUpdatingKanbanSelection) return;
            var current = sender as ListBox;
            if (current == null || current.SelectedIndex == -1) return;

            _isUpdatingKanbanSelection = true;
            if (current != lstToDo) lstToDo.ClearSelected();
            if (current != lstInProgress) lstInProgress.ClearSelected();
            if (current != lstReview) lstReview.ClearSelected();
            if (current != lstDone) lstDone.ClearSelected();
            _isUpdatingKanbanSelection = false;
        }

        private CongViecDTO GetSelectedKanbanTask()
        {
            if (lstToDo.SelectedItem is CongViecDTO t1) return t1;
            if (lstInProgress.SelectedItem is CongViecDTO t2) return t2;
            if (lstReview.SelectedItem is CongViecDTO t3) return t3;
            if (lstDone.SelectedItem is CongViecDTO t4) return t4;
            return null;
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            var task = GetSelectedKanbanTask();
            if (task == null)
            {
                MessageBox.Show("Hãy chọn một thẻ công việc trên bảng Kanban!");
                return;
            }
            int idx = Array.IndexOf(_statusFlow, task.TrangThai);
            if (idx >= 0 && idx < _statusFlow.Length - 1)
            {
                _cvBus.ChangeStatus(task.MaTask, _statusFlow[idx + 1]);
                LoadKanbanBoard();
                LoadTasks();
            }
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            var task = GetSelectedKanbanTask();
            if (task == null)
            {
                MessageBox.Show("Hãy chọn một thẻ công việc trên bảng Kanban!");
                return;
            }
            int idx = Array.IndexOf(_statusFlow, task.TrangThai);
            if (idx > 0)
            {
                _cvBus.ChangeStatus(task.MaTask, _statusFlow[idx - 1]);
                LoadKanbanBoard();
                LoadTasks();
            }
        }

        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            var task = GetSelectedKanbanTask();
            if (task == null)
            {
                MessageBox.Show("Hãy chọn một thẻ công việc trên bảng Kanban!");
                return;
            }
            _cvBus.ChangeStatus(task.MaTask, "Done");
            LoadKanbanBoard();
            LoadTasks();
        }
        #endregion

        #region 4. CẢNH BÁO TRỄ HẠN & BÁO CÁO TIẾN ĐỘ
        private void LoadOverdueTasks()
        {
            var overdueList = _cvBus.GetOverdueTasks();
            dgvOverdue.DataSource = overdueList;

            if (dgvOverdue.Columns["MaDuAn"] != null) dgvOverdue.Columns["MaDuAn"].Visible = false;
            if (dgvOverdue.Columns["NguoiThucHien"] != null) dgvOverdue.Columns["NguoiThucHien"].Visible = false;
            if (dgvOverdue.Columns["KanbanDisplay"] != null) dgvOverdue.Columns["KanbanDisplay"].Visible = false;

            if (dgvOverdue.Columns["MaTask"] != null) dgvOverdue.Columns["MaTask"].HeaderText = "Mã Task";
            if (dgvOverdue.Columns["TenDuAn"] != null) dgvOverdue.Columns["TenDuAn"].HeaderText = "Dự Án";
            if (dgvOverdue.Columns["TenTask"] != null) dgvOverdue.Columns["TenTask"].HeaderText = "Công Việc Trễ Hạn";
            if (dgvOverdue.Columns["MoTa"] != null) dgvOverdue.Columns["MoTa"].HeaderText = "Mô Tả";
            if (dgvOverdue.Columns["HanNop"] != null) dgvOverdue.Columns["HanNop"].HeaderText = "Hạn Nộp";
            if (dgvOverdue.Columns["DoUuTien"] != null) dgvOverdue.Columns["DoUuTien"].HeaderText = "Độ Ưu Tiên";
            if (dgvOverdue.Columns["TrangThai"] != null) dgvOverdue.Columns["TrangThai"].HeaderText = "Trạng Thái Hiện Tại";

            // Tô đỏ nhẹ các dòng trễ hạn để cảnh báo trực quan
            foreach (DataGridViewRow row in dgvOverdue.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }

        private void btnTaiOverdue_Click(object sender, EventArgs e)
        {
            LoadOverdueTasks();
            MessageBox.Show($"Phát hiện {dgvOverdue.Rows.Count} công việc đã quá hạn nộp!", "Cảnh báo Tiến độ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void LoadThongKe()
        {
            if (!(cboThongKeDuAn.SelectedValue is int maDuAn)) return;

            // 1. Lấy tỷ lệ % hoàn thành chung của dự án bằng ExecuteScalar
            decimal tyLeChung = _pcBus.GetTyLeHoanThanhDuAn(maDuAn);
            lblTongTienDoDA.Text = $"Tiến độ hoàn thành chung của dự án: {tyLeChung}%";

            // 2. Lấy bảng thống kê chi tiết từng thành viên bằng GROUP BY
            var stats = _pcBus.GetThongKeThanhVien(maDuAn);
            dgvThongKe.DataSource = stats;

            if (dgvThongKe.Columns["MaThanhVien"] != null) dgvThongKe.Columns["MaThanhVien"].HeaderText = "Mã TV";
            if (dgvThongKe.Columns["HoTen"] != null) dgvThongKe.Columns["HoTen"].HeaderText = "Họ Tên Thành Viên";
            if (dgvThongKe.Columns["ChuyenMon"] != null) dgvThongKe.Columns["ChuyenMon"].HeaderText = "Chuyên Môn";
            if (dgvThongKe.Columns["TongSoTask"] != null) dgvThongKe.Columns["TongSoTask"].HeaderText = "Tổng Task Được Giao";
            if (dgvThongKe.Columns["SoTaskHoanThanh"] != null) dgvThongKe.Columns["SoTaskHoanThanh"].HeaderText = "Số Task Hoàn Thành (Done)";
            if (dgvThongKe.Columns["TyLeHoanThanh"] != null) dgvThongKe.Columns["TyLeHoanThanh"].HeaderText = "Tỷ Lệ Hoàn Thành (%)";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }
        #endregion
    }
}
