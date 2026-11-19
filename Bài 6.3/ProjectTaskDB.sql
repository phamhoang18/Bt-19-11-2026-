USE master;
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'ProjectTaskDB')
BEGIN
    ALTER DATABASE ProjectTaskDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ProjectTaskDB;
END
GO

CREATE DATABASE ProjectTaskDB;
GO
USE ProjectTaskDB;
GO

CREATE TABLE DuAn (
    MaDuAn INT IDENTITY(1,1) PRIMARY KEY,
    TenDuAn NVARCHAR(150) NOT NULL,
    NgayBatDau DATETIME,
    NgayKetThuc DATETIME,
    TrangThai NVARCHAR(50)
);

CREATE TABLE ThanhVien (
    MaThanhVien INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    ChuyenMon NVARCHAR(100)
);

CREATE TABLE CongViec (
    MaTask INT IDENTITY(1,1) PRIMARY KEY,
    MaDuAn INT FOREIGN KEY REFERENCES DuAn(MaDuAn) ON DELETE CASCADE,
    TenTask NVARCHAR(200) NOT NULL,
    MoTa NVARCHAR(MAX),
    HanNop DATETIME,
    DoUuTien NVARCHAR(20),
    TrangThai NVARCHAR(50)
);

CREATE TABLE PhanCong (
    MaTask INT FOREIGN KEY REFERENCES CongViec(MaTask) ON DELETE CASCADE,
    MaThanhVien INT FOREIGN KEY REFERENCES ThanhVien(MaThanhVien) ON DELETE CASCADE,
    NgayGiao DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (MaTask, MaThanhVien)
);
GO

-- Dữ liệu mẫu
INSERT INTO DuAn (TenDuAn, NgayBatDau, NgayKetThuc, TrangThai) VALUES
(N'Hệ thống Thương mại Điện tử B2B', '2026-01-01', '2026-06-30', N'Đang chạy'),
(N'Ứng dụng Mobile Đặt lịch Khám bệnh', '2026-02-15', '2026-08-15', N'Đang chạy');

INSERT INTO ThanhVien (HoTen, Email, ChuyenMon) VALUES
(N'Nguyễn Văn An', 'an.nv@company.com', N'Backend C#/.NET'),
(N'Trần Thị Bình', 'binh.tt@company.com', N'Frontend / UI-UX'),
(N'Lê Hoàng Cường', 'cuong.lh@company.com', N'Database & DevOps'),
(N'Phạm Minh Dung', 'dung.pm@company.com', N'QA / Tester');

INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai) VALUES
(1, N'Thiết kế CSDL SQL Server', N'Tạo ERD và script bảng', DATEADD(DAY, -5, GETDATE()), N'Cao', N'Done'),
(1, N'Xây dựng API Giỏ hàng', N'RESTful API xử lý giỏ hàng', DATEADD(DAY, -2, GETDATE()), N'Cao', N'In Progress'), -- Trễ hạn
(1, N'Thiết kế giao diện Trang chủ', N'Responsive UI theo Figma', DATEADD(DAY, 5, GETDATE()), N'Trung bình', N'Review'),
(1, N'Kiểm thử tích hợp thanh toán', N'Test cổng VNPay/Momo', DATEADD(DAY, 10, GETDATE()), N'Thấp', N'To Do'),
(2, N'Phân tích nghiệp vụ đặt lịch', N'Viết tài liệu SRS', DATEADD(DAY, -1, GETDATE()), N'Cao', N'To Do'); -- Trễ hạn

INSERT INTO PhanCong (MaTask, MaThanhVien) VALUES
(1, 1), (1, 3),
(2, 1),
(3, 2),
(4, 4), (4, 1),
(5, 2), (5, 4);
GO