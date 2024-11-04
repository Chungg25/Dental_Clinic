
use master

-- Drop the database if it exists
IF EXISTS (SELECT 1
FROM sys.databases
WHERE name = 'DentalClinic')
BEGIN
    ALTER DATABASE DentalClinic SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DentalClinic;
END
GO


create database DentalClinic
go

use DentalClinic
go

----------------Tạo bảng----------------

-- 1. Bảng người dùng
CREATE TABLE [nguoi_dung]
(
    [ma] INT NOT NULL IDENTITY(1, 1),
    [ma_nguoi_dung] INT NOT NULL,
    [ho_ten] NVARCHAR(255) NOT NULL,
    [cccd] VARCHAR(12) NOT NULL,
    [so_dien_thoai] VARCHAR(10) NOT NULL,
    [dia_chi] NVARCHAR(50) NOT NULL,
    [gioi_tinh] BIT NOT NULL,
    [ngay_sinh] DATE NOT NULL,
    [vai_tro] NVARCHAR(10) NOT NULL,
    [ten_dang_nhap] NVARCHAR(50) NOT NULL,
    [mat_khau] NVARCHAR(255) NOT NULL,
    [email] NVARCHAR(50) NOT NULL,
    [he_so_luong] FLOAT NOT NULL,
    [trang_thai] INT NOT NULL,
    PRIMARY KEY ([ma_nguoi_dung])
)
GO
-- 2. Bảng lễ tân
CREATE TABLE [le_tan]
(
    [ma_nguoi_dung] INT NOT NULL,
    PRIMARY KEY ([ma_nguoi_dung])
)
GO
-- 3. Bảng quản trị viên
CREATE TABLE [quan_tri_vien]
(
    [ma_nguoi_dung] INT NOT NULL,
    PRIMARY KEY ([ma_nguoi_dung])
)
GO
-- 4. Bảng bác sĩ chuyên môn
CREATE TABLE [bac_si_chuyen_mon]
(
    [ma_chuyen_mon] INT PRIMARY KEY IDENTITY(1, 1),
    [ten_chuyen_mon] NVARCHAR(100) UNIQUE NOT NULL
)
GO
-- 5. Bảng bác sĩ
CREATE TABLE [bac_si]
(
    [ma_nguoi_dung] INT NOT NULL,
    [ma_chuyen_mon] INT,
    PRIMARY KEY ([ma_nguoi_dung])
)
GO
-- 6. Bảng lịch làm việc
CREATE TABLE [lich_lam_viec]
(
    [ma_lich] INT NOT NULL IDENTITY(1, 1),
    [ngay] DATE NOT NULL,
    [ca] INT NOT NULL,
    [ma_nguoi_dung] INT not null,
    PRIMARY KEY ([ma_lich])
)
GO

CREATE TABLE [cham_cong]
(
    [ma_lich] INT NOT NULL IDENTITY(1, 1),
    [ngay] DATE NOT NULL,
    [gio_vao] TIME NOT NULL,
    [gio_ra] TIME not null,
    [ghi_chu] NVARCHAR(255) NOT NULL,
    [ma_nguoi_dung] INT NOT NULL,
    PRIMARY KEY ([ma_lich])
)
GO
-- 7. Bảng lương
CREATE TABLE [luong]
(
    [ma_luong] INT NOT NULL,
    [ma_nguoi_dung] INT NOT NULL,
    [luong_co_ban] FLOAT NOT NULL,
    [thuong] FLOAT NOT NULL,
    [phat] FLOAT NOT NULL,
    [phu_cap] FLOAT NOT NULL,
    [ngay] DATE,
    PRIMARY KEY ([ma_luong])
)
GO
-- 8. Bảng bệnh nhân
CREATE TABLE [benh_nhan]
(
    [ma_benh_nhan] INT NOT NULL,
    [ho_ten] NVARCHAR(50) NOT NULL,
    [gioi_tinh] BIT NOT NULL,
    [tuoi] INT NOT NULL,
    [so_dien_thoai] NVARCHAR(10) NOT NULL,
    [dia_chi] NVARCHAR(50) NOT NULL,
    PRIMARY KEY ([ma_benh_nhan])
)
GO
-- 9. Bảng tiếp nhận bệnh nhân
CREATE TABLE [tiep_nhan]
(
    [ma_nguoi_dung] INT NOT NULL,
    [ma_benh_nhan] INT NOT NULL,
    PRIMARY KEY ([ma_nguoi_dung], [ma_benh_nhan])
)
GO
-- 10. Bảng lịch hẹn
CREATE TABLE [lich_hen]
(
    [ma_lich_hen] INT NOT NULL IDENTITY(1, 1),
    [ghi_chu] NVARCHAR(MAX) NULL,
    [trang_thai] BIT NOT NULL,
    [ngay_hen] DATE NULL,
    [ca] INT NULL,
    [ma_nguoi_dung] INT NULL,
    [ma_benh_nhan] INT NOT NULL,
    PRIMARY KEY ([ma_lich_hen])
)
GO
-- 11. Bảng hồ sơ bệnh án
CREATE TABLE [ho_so_benh_an]
(
    [ma_ho_so] INT NOT NULL IDENTITY(1, 1),
    [chan_doan] NVARCHAR(50) NOT NULL,
    [phuong_phap_dieu_tri] NVARCHAR(50) NOT NULL,
    [trieu_chung] NVARCHAR(50) NOT NULL,
    [ma_benh_nhan] INT NOT NULL,
    PRIMARY KEY ([ma_ho_so])
)
GO
-- 12. Bảng loại hàng tồn kho
CREATE TABLE [loai_hang_ton_kho]
(
    [ma_loai] INT PRIMARY KEY,
    [ten_loai] NVARCHAR(50) NOT NULL
)
GO
-- 13. Bảng hàng tồn kho
CREATE TABLE [hang_ton_kho]
(
    [ma_kho] INT PRIMARY KEY,
    [ten] NVARCHAR(255) NOT NULL,
    [loai] NVARCHAR(255) NOT NULL,
    [so_luong] INT NOT NULL,
    [don_vi] NVARCHAR(255) NOT NULL,
    [lieu_luong] NVARCHAR(255),
    [ngay_san_xuat] DATE NOT NULL,
    [ngay_het_han] DATE NOT NULL,
    [ngay_nhap] DATE NOT NULL,
    [gia] DECIMAL(18,2) NOT NULL,
    [ma_loai] INT NOT NULL
)
GO
-- 14. Bảng đơn thuốc
CREATE TABLE [don_thuoc]
(
    [ma_don_thuoc] INT,
    [ngay] DATE NOT NULL,
    [ma_benh_nhan] INT NOT NULL,
    [ma_nguoi_dung] INT NOT NULL,
    PRIMARY KEY ([ma_don_thuoc])
)
GO
-- 15. Bảng chi tiết đơn thuốc
CREATE TABLE [chi_tiet_don_thuoc]
(
    [ma_chi_tiet_don_thuoc] INT NOT NULL IDENTITY(1, 1),
    [ma_kho] int,
    [so_luong] INT NOT NULL,
    [thoi_gian] INT NOT NULL,
    [lieu_luong] INT NOT NULL,
    [tan_suat] INT NOT NULL,
    [ghi_chu] NVARCHAR(50) NOT NULL,
    [ma_don_thuoc] INT NOT NULL,
    PRIMARY KEY ([ma_chi_tiet_don_thuoc])
)
GO
-- 16. Bảng loại dịch vụ
CREATE TABLE [loai_dich_vu]
(
    [ma_loai_dich_vu] INT PRIMARY KEY IDENTITY(1, 1),
    [ten_ten_dich] NVARCHAR(255) UNIQUE NOT NULL
)
GO
-- 17. Bảng dịch vụ
CREATE TABLE [dich_vu]
(
    [ma_dich_vu] INT PRIMARY KEY IDENTITY(1, 1),
    [ma_loai] INT NOT NULL,
    [ten] NVARCHAR(255) NOT NULL,
    [don_vi] NVARCHAR(255) NOT NULL,
    [gia] DECIMAL(18,2) NOT NULL
)
GO
-- 18. Bảng điều trị
CREATE TABLE [dieu_tri]
(
    [ma_dieu_tri] INT PRIMARY KEY IDENTITY(1, 1),
    [ten_bac_si_thay_the] NVARCHAR(50) NOT NULL,
    [ma_bac_si] INT NOT NULL,
    [ma_benh_nhan] INT,
    [ngay_dieu_tri] DATE NOT NULL,
    [ghi_chu] NVARCHAR(255)
)
GO
-- 19. Bảng hóa đơn
CREATE TABLE [hoa_don]
(
    [ma_hoa_don] INT,
    [phuong_thuc_thanh_toan] INT NOT NULL DEFAULT -1,
    [tong_gia] FLOAT NOT NULL,
    [ma_don_thuoc] INT NOT NULL,
    [ma_benh_nhan] INT NOT NULL,
    [ngay] date,
    [trang_thai_thanh_toan] BIT DEFAULT 0,
    -- 0: Chưa thanh toán, 1: Đã thanh toán
    PRIMARY KEY ([ma_hoa_don])
)
GO
-- 20. Bảng chi tiết hóa đơn
CREATE TABLE [chi_tiet_hoa_don]
(
    [ma_chi_tiet_hoa_don] INT PRIMARY KEY IDENTITY(1, 1),
    [ma_hoa_don] INT NOT NULL,
    [ma_dich_vu] INT NOT NULL,
    [so_luong] INT NOT NULL,
    [gia_don_vi] DECIMAL(18,2) NOT NULL
)
GO

ALTER TABLE [lich_lam_viec] ADD FOREIGN KEY ([ma_nguoi_dung]) REFERENCES [nguoi_dung] ([ma_nguoi_dung])
GO

ALTER TABLE [cham_cong] ADD FOREIGN KEY ([ma_nguoi_dung]) REFERENCES [nguoi_dung] ([ma_nguoi_dung])
GO

ALTER TABLE [luong] ADD FOREIGN KEY ([ma_nguoi_dung]) REFERENCES [nguoi_dung] ([ma_nguoi_dung])
GO

ALTER TABLE [le_tan] ADD FOREIGN KEY ([ma_nguoi_dung]) REFERENCES [nguoi_dung] ([ma_nguoi_dung])
GO

ALTER TABLE [quan_tri_vien] ADD FOREIGN KEY ([ma_nguoi_dung]) REFERENCES [nguoi_dung] ([ma_nguoi_dung])
GO

ALTER TABLE [bac_si] ADD FOREIGN KEY ([ma_nguoi_dung]) REFERENCES [nguoi_dung] ([ma_nguoi_dung])
GO

ALTER TABLE [bac_si] ADD FOREIGN KEY ([ma_chuyen_mon]) REFERENCES [bac_si_chuyen_mon] ([ma_chuyen_mon])
GO

ALTER TABLE [tiep_nhan] ADD FOREIGN KEY ([ma_nguoi_dung]) REFERENCES [le_tan] ([ma_nguoi_dung])
GO

ALTER TABLE [tiep_nhan] ADD FOREIGN KEY ([ma_benh_nhan]) REFERENCES [benh_nhan] ([ma_benh_nhan])
GO

ALTER TABLE [lich_hen] ADD FOREIGN KEY ([ma_nguoi_dung]) REFERENCES [bac_si] ([ma_nguoi_dung])
GO

ALTER TABLE [lich_hen] ADD FOREIGN KEY ([ma_benh_nhan]) REFERENCES [benh_nhan] ([ma_benh_nhan])
GO

ALTER TABLE [ho_so_benh_an] ADD FOREIGN KEY ([ma_benh_nhan]) REFERENCES [benh_nhan] ([ma_benh_nhan]) ON DELETE CASCADE
GO

ALTER TABLE [don_thuoc] ADD FOREIGN KEY ([ma_benh_nhan]) REFERENCES [benh_nhan] ([ma_benh_nhan])
GO

ALTER TABLE [don_thuoc] ADD FOREIGN KEY ([ma_nguoi_dung]) REFERENCES [bac_si] ([ma_nguoi_dung])
GO

ALTER TABLE [chi_tiet_don_thuoc] ADD FOREIGN KEY ([ma_don_thuoc]) REFERENCES [don_thuoc] ([ma_don_thuoc])
GO

ALTER TABLE [dich_vu] ADD FOREIGN KEY ([ma_loai]) REFERENCES [loai_dich_vu] ([ma_loai_dich_vu])
GO

ALTER TABLE [dieu_tri] ADD FOREIGN KEY ([ma_bac_si]) REFERENCES [bac_si] ([ma_nguoi_dung]) ON DELETE CASCADE
GO

ALTER TABLE [dieu_tri] ADD FOREIGN KEY ([ma_benh_nhan]) REFERENCES [benh_nhan] ([ma_benh_nhan]) ON DELETE CASCADE
GO

ALTER TABLE [hang_ton_kho] ADD FOREIGN KEY ([ma_loai]) REFERENCES [loai_hang_ton_kho] ([ma_loai]) ON DELETE CASCADE
GO

ALTER TABLE [chi_tiet_don_thuoc] ADD FOREIGN KEY ([ma_kho]) REFERENCES [hang_ton_kho] ([ma_kho]) ON DELETE CASCADE
GO

ALTER TABLE [hoa_don] ADD FOREIGN KEY ([ma_don_thuoc]) REFERENCES [don_thuoc] ([ma_don_thuoc])
GO

ALTER TABLE [hoa_don] ADD FOREIGN KEY ([ma_benh_nhan]) REFERENCES [benh_nhan] ([ma_benh_nhan])
GO

ALTER TABLE [chi_tiet_hoa_don] ADD FOREIGN KEY ([ma_hoa_don]) REFERENCES [hoa_don] ([ma_hoa_don]) ON DELETE CASCADE
GO

ALTER TABLE [chi_tiet_hoa_don] ADD FOREIGN KEY ([ma_dich_vu]) REFERENCES [dich_vu] ([ma_dich_vu]) ON DELETE CASCADE
GO
