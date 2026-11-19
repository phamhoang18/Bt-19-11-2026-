USE master;
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'GarageDB')
BEGIN
    ALTER DATABASE GarageDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE GarageDB;
END
GO

CREATE DATABASE GarageDB;
GO
USE GarageDB;
GO

CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiaChi NVARCHAR(200)
);

CREATE TABLE Xe (
    BienSo VARCHAR(20) PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    HieuXe NVARCHAR(50),
    NamSanXuat INT
);

CREATE TABLE PhuTung (
    MaPhuTung INT IDENTITY(1,1) PRIMARY KEY,
    TenPhuTung NVARCHAR(150) NOT NULL,
    DonGia DECIMAL(18,2),
    SoLuongTon INT CHECK (SoLuongTon >= 0)
);

CREATE TABLE PhieuSuaChua (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    BienSo VARCHAR(20) FOREIGN KEY REFERENCES Xe(BienSo),
    NgayNhan DATETIME DEFAULT GETDATE(),
    NoiDungSua NVARCHAR(MAX),
    TongTien DECIMAL(18,2),
    TrangThai NVARCHAR(30)
);

CREATE TABLE ChiTietSuaChua (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuSuaChua(MaPhieu) ON DELETE CASCADE,
    MaPhuTung INT FOREIGN KEY REFERENCES PhuTung(MaPhuTung),
    SoLuong INT CHECK (SoLuong > 0),
    TienCong DECIMAL(18,2),
    PRIMARY KEY (MaPhieu, MaPhuTung)
);
GO

-- Dữ liệu mẫu
INSERT INTO KhachHang (TenKH, DienThoai, DiaChi) VALUES
(N'Nguyễn Hoàng Nam', '0901234567', N'123 Cầu Giấy, Hà Nội'),
(N'Trần Minh Tuấn', '0912345678', N'45 Lê Lợi, Quận 1, TP.HCM');

INSERT INTO Xe (BienSo, MaKH, HieuXe, NamSanXuat) VALUES
('30A-123.45', 1, N'Toyota Camry', 2021),
('51H-888.99', 2, N'VinFast VF8', 2023);

INSERT INTO PhuTung (TenPhuTung, DonGia, SoLuongTon) VALUES
(N'Dầu nhớt tổng hợp Castrol 4L', 850000, 25),
(N'Lọc nhớt động cơ chính hãng', 220000, 40),
(N'Má phanh trước (Bộ)', 1450000, 10),
(N'Bugi Iridium Denso', 320000, 3), -- Tồn kho ít để dễ test Rollback
(N'Lọc gió điều hòa than hoạt tính', 350000, 18);

INSERT INTO PhieuSuaChua (BienSo, NgayNhan, NoiDungSua, TongTien, TrangThai) VALUES
('30A-123.45', DATEADD(HOUR, -3, GETDATE()), N'Bảo dưỡng định kỳ 20.000km, thay dầu và lọc nhớt', 1370000, N'Đang sửa');

INSERT INTO ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong) VALUES
(1, 1, 1, 200000),
(1, 2, 1, 100000);
GO