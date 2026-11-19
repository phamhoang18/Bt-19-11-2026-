USE master;
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'KaraokeDB')
BEGIN
    ALTER DATABASE KaraokeDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE KaraokeDB;
END
GO

CREATE DATABASE KaraokeDB;
GO
USE KaraokeDB;
GO

CREATE TABLE PhongHat (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(50) NOT NULL,
    LoaiPhong NVARCHAR(30),
    GiaTheoGio DECIMAL(18,2) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Trống'
);

CREATE TABLE DichVu (
    MaDV INT IDENTITY(1,1) PRIMARY KEY,
    TenDV NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    TonKho INT CHECK (TonKho >= 0)
);

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong INT FOREIGN KEY REFERENCES PhongHat(MaPhong),
    GioVao DATETIME NOT NULL DEFAULT GETDATE(),
    GioRa DATETIME NULL,
    TongTienPhong DECIMAL(18,2) DEFAULT 0,
    TongTienDichVu DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán
);

CREATE TABLE ChiTietDichVu (
    MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV),
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHD, MaDV)
);
GO

-- Dữ liệu mẫu
INSERT INTO PhongHat (TenPhong, LoaiPhong, GiaTheoGio, TrangThai) VALUES
(N'Phòng Thường 01', N'Thường', 150000, N'Trống'),
(N'Phòng Thường 02', N'Thường', 150000, N'Đang hát'),
(N'Phòng Thường 03', N'Thường', 180000, N'Trống'),
(N'Phòng VIP 01', N'VIP', 300000, N'Đang hát'),
(N'Phòng VIP 02', N'VIP', 300000, N'Trống'),
(N'Phòng Super VIP', N'VIP', 500000, N'Trống');

INSERT INTO DichVu (TenDV, DonGia, TonKho) VALUES
(N'Bia Heineken (Lon)', 28000, 120),
(N'Bia Tiger Bạc (Lon)', 24000, 150),
(N'Nước suối Aquafina', 15000, 80),
(N'Trái cây dĩa đặc biệt', 120000, 15),
(N'Khô bò xé cay', 85000, 20),
(N'Combo Snack & Hạt điều', 65000, 3); -- Tồn kho ít để dễ test Rollback

-- Tạo sẵn 2 hóa đơn chưa thanh toán cho 2 phòng đang hát
INSERT INTO HoaDon (MaPhong, GioVao, TrangThai) VALUES
(2, DATEADD(MINUTE, -90, GETDATE()), 0),
(4, DATEADD(MINUTE, -45, GETDATE()), 0);

INSERT INTO ChiTietDichVu (MaHD, MaDV, SoLuong, DonGia) VALUES
(1, 1, 6, 28000),
(1, 4, 1, 120000),
(2, 2, 4, 24000),
(2, 5, 1, 85000);
GO