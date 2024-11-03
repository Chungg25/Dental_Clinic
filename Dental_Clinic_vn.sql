
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
    [ma_benh_nhan] INT NOT NULL IDENTITY(1, 1),
    [ho_ten] NVARCHAR(50) NOT NULL,
    [gioi_tinh] BIT NULL,
    [tuoi] INT NULL,
    [so_dien_thoai] NVARCHAR(10) NOT NULL,
    [dia_chi] NVARCHAR(50) NULL,
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
    [ghi_chu] NVARCHAR(50) NULL,
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
    [phuong_thuc_thanh_toan] BIT NOT NULL,
    [tong_gia] FLOAT NOT NULL,
    [ma_don_thuoc] INT NOT NULL,
    [ma_benh_nhan] INT NOT NULL,
    [ngay] date,
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

----------------Thêm dữ liệu----------------
-- Thêm dữ liệu vào bảng người dùng
INSERT INTO nguoi_dung
    (ma_nguoi_dung, ho_ten, cccd, so_dien_thoai, dia_chi, gioi_tinh, ngay_sinh, vai_tro, ten_dang_nhap, mat_khau, email, he_so_luong, trang_thai)
VALUES

    (1, N'Nguyễn Văn An', '123456789001', '0901234561', N'123 Lê Lợi, Q1, TP.HCM', 1, '1990-01-15', 'Admin', 'admin1', 'pass123', 'admin1@gmail.com', 1.5, 1
),
    (2, N'Trần Thị Bình', '123456789002', '0901234562', N'456 Nguyễn Huệ, Q1, TP.HCM', 0, '1991-02-20', 'Admin', 'admin2', 'pass123', 'admin2@gmail.com', 1.5, 1),
    (3, N'Lê Văn Cường', '123456789003', '0901234563', N'789 Lê Duẩn, Q1, TP.HCM', 1, '1992-03-25', 'Reception', 'recep1', 'pass123', 'recep1@gmail.com', 1.2, 1),
    (4, N'Phạm Thị Dung', '123456789004', '0901234564', N'147 Nam Kỳ, Q3, TP.HCM', 0, '1993-04-30', 'Reception', 'recep2', 'pass123', 'recep2@gmail.com', 1.2, 1),
    (5, N'Hoàng Văn Em', '123456789005', '0901234565', N'258 Hai Bà Trưng, Q1, TP.HCM', 1, '1994-05-05', 'Reception', 'recep3', 'pass123', 'recep3@gmail.com', 1.2, 1),
    (6, N'Đỗ Thị Phương', '123456789006', '0901234566', N'369 Lê Văn Sỹ, Q3, TP.HCM', 0, '1985-06-10', 'Doctor', 'doctor1', 'pass123', 'hatrongnguyen04@gmail.com', 2.0, 1),
    (7, N'Vũ Văn Giang', '123456789007', '0901234567', N'147 Nguyễn Đình Chiểu, Q3, TP.HCM', 1, '1986-07-15', 'Doctor', 'doctor2', 'pass123', 'doctor2@gmail.com', 2.0, 1),
    (8, N'Mai Thị Hoa', '123456789008', '0901234568', N'258 Võ Văn Tần, Q3, TP.HCM', 0, '1987-08-20', 'Doctor', 'doctor3', 'pass123', 'doctor3@gmail.com', 2.0, 1),
    (9, N'Trịnh Văn Inh', '123456789009', '0901234569', N'369 Cách Mạng T8, Q3, TP.HCM', 1, '1988-09-25', 'Doctor', 'doctor4', 'pass123', 'doctor4@gmail.com', 2.0, 1),
    (10, N'Lý Thị Kim', '123456789010', '0901234570', N'147 Điện Biên Phủ, Q1, TP.HCM', 0, '1989-10-30', 'Doctor', 'doctor5', 'pass123', 'doctor5@gmail.com', 2.0, 1),
    (11, N'Ngô Văn Linh', '123456789011', '0901234571', N'258 Nguyễn Trãi, Q5, TP.HCM', 1, '1990-11-05', 'Doctor', 'doctor6', 'pass123', 'doctor6@gmail.com', 2.0, 1),
    (12, N'Phan Thị Mai', '123456789012', '0901234572', N'369 Lý Thường Kiệt, Q10, TP.HCM', 0, '1991-12-10', 'Doctor', 'doctor7', 'pass123', 'doctor7@gmail.com', 2.0, 1),
    (13, N'Đặng Văn Nam', '123456789013', '0901234573', N'147 Bà Hom, Q6, TP.HCM', 1, '1992-01-15', 'Doctor', 'doctor8', 'pass123', 'doctor8@gmail.com', 2.0, 1),
    (14, N'Bùi Thị Oanh', '123456789014', '0901234574', N'258 Hùng Vương, Q5, TP.HCM', 0, '1993-02-20', 'Doctor', 'doctor9', 'pass123', 'doctor9@gmail.com', 2.0, 1),
    (15, N'Hồ Văn Phát', '123456789015', '0901234575', N'369 Tân Kỳ Tân Quý, Q.TB, TP.HCM', 1, '1994-03-25', 'Doctor', 'doctor10', 'pass123', 'doctor10@gmail.com', 2.0, 1),
    (16, N'Trương Thị Quỳnh', '123456789016', '0901234576', N'147 Âu Cơ, Q.TB, TP.HCM', 0, '1995-04-30', 'Reception', 'recep4', 'pass123', 'recep4@gmail.com', 1.2, 1),
    (17, N'Lương Văn Rồng', '123456789017', '0901234577', N'258 Lạc Long Quân, Q11, TP.HCM', 1, '1996-05-05', 'Reception', 'recep5', 'pass123', 'recep5@gmail.com', 1.2, 1),
    (18, N'Dương Thị Sen', '123456789018', '0901234578', N'369 Hòa Bình, Q.TB, TP.HCM', 0, '1997-06-10', 'Reception', 'recep6', 'pass123', 'recep6@gmail.com', 1.2, 1),
    (19, N'Lại Văn Tâm', '123456789019', '0901234579', N'147 Trường Chinh, Q12, TP.HCM', 1, '1998-07-15', 'Admin', 'admin3', 'pass123', 'admin3@gmail.com', 1.5, 1),
    (20, N'Châu Thị Uyên', '123456789020', '0901234580', N'258 Quang Trung, Q.GV, TP.HCM', 0, '1999-08-20', 'Admin', 'admin4', 'pass123', 'admin4@gmail.com', 1.5, 1);
/*DELETE FROM [users];
DBCC CHECKIDENT ('users', RESEED, 0);*/

-- Thêm dữ liệu vào bảng quản trị viên và lễ tân
INSERT INTO quan_tri_vien
    (ma_nguoi_dung)
VALUES
    (1),
    (2),
    (19),
    (20);

INSERT INTO le_tan
    (ma_nguoi_dung)
VALUES
    (3),
    (4),
    (5),
    (16),
    (17),
    (18);

-- Thêm dữ liệu vào bảng bác sĩ chuyên môn
INSERT INTO bac_si_chuyen_mon
    (ten_chuyen_mon)
VALUES
    (N'Nha chu'),
    (N'Nhổ răng và tiểu phẫu'),
    (N'Phục hình'),
    (N'Chữa răng và nội nha'),
    (N'Răng trẻ em'),
    (N'Tổng quát');
/*DELETE FROM doctor_specializations;
DBCC CHECKIDENT ('doctor_specializations', RESEED, 0);*/

-- Thêm dữ liệu vào bảng bác sĩ
INSERT INTO bac_si
    (ma_nguoi_dung, ma_chuyen_mon)
VALUES
    (6, 1),
    (7, 2),
    (8, 3),
    (9, 4),
    (10, 5),
    (11, 6),
    (12, 1),
    (13, 2),
    (14, 3),
    (15, 4);
/*DELETE FROM doctors;
DBCC CHECKIDENT ('doctors', RESEED, 0);*/

-- Thêm dữ liệu vào bảng bệnh nhân
INSERT INTO benh_nhan
    (ho_ten, gioi_tinh, tuoi, so_dien_thoai, dia_chi)
VALUES
    (N'Phạm Văn Cường', 1, 29, '0903456789', N'789 Lê Lợi, Quận 5'),
    (N'Trần Văn Tùng', 1, 37, '0906789012', N'56 Võ Thị Sáu, Quận 2'),
    (N'Lê Thị Hoa', 0, 30, '0907890123', N'78 Nam Kỳ Khởi Nghĩa, Quận 3'),
    (N'Phạm Văn Bảo', 1, 33, '0900123456', N'23 Trường Chinh, Quận Tân Bình'),
    (N'Trần Văn Đức', 1, 32, '0903334455', N'67 Trường Sa, Phú Nhuận'),
    (N'Lê Thị Lan', 0, 31, '0904445566', N'78 Lê Văn Sỹ, Quận 3'),
    (N'Nguyễn Hoàng Long', 1, 33, '0905556677', N'89 Nguyễn Văn Trỗi, Quận Tân Phú'),
    (N'Phạm Thanh Bình', 1, 37, '0906667788', N'23 Lê Lợi, Quận 1'),
    (N'Võ Thị Quỳnh', 0, 31, '0907778899', N'34 Hai Bà Trưng, Quận 3'),
    (N'Nguyễn Văn Minh', 1, 32, '0905678901', N'34 Hai Bà Trưng, Quận 3'),
    (N'Trần Thị Hoa', 0, 39, '0902345678', N'456 Điện Biên Phủ, Quận 3'),
    (N'Lê Văn Tâm', 1, 50, '0903456567', N'56 Cách Mạng Tháng Tám, Quận 10'),
    (N'Trần Anh Dũng', 1, 28, '0908765432', N'101 Lý Chính Thắng, Quận 3'),
    (N'Lê Thị Bích', 0, 34, '0901234876', N'567 Nguyễn Tri Phương, Quận 10'),
    (N'Vũ Thị Minh Châu', 0, 40, '0906785432', N'200 Lê Hồng Phong, Quận 5'),
    (N'Nguyễn Hoàng Khôi', 1, 26, '0909087654', N'90 Nguyễn Trãi, Quận 1'),
    (N'Ngô Thị Hà', 0, 29, '0912345678', N'333 Hai Bà Trưng, Quận 1'),
    (N'Phạm Thị Thanh', 0, 35, '0903456789', N'222 Phan Xích Long, Quận Phú Nhuận'),
    (N'Lê Hữu Phước', 1, 32, '0909998877', N'345 Cộng Hòa, Quận Tân Bình'),
    (N'Nguyễn Thị Mai', 0, 27, '0901234567', N'567 Lý Thường Kiệt, Quận 10');
/*DELETE FROM patients;
DBCC CHECKIDENT ('patients', RESEED, 0);*/

-- Thêm dữ liệu vào bảng lương
INSERT INTO luong
    (ma_luong, ma_nguoi_dung, luong_co_ban, thuong, phat, phu_cap, ngay)
VALUES
    (1, 1, 500000, 0, 50000, 0, '2024-10-31'),
    (2, 2, 400000, 200000, 50000, 0, '2024-10-31'),
    (3, 3, 600000, 0, 80000, 0, '2024-10-31'),
    (4, 4, 550000, 300000, 80000, 0, '2024-10-31'),
    (5, 5, 700000, 0, 100000, 0, '2024-10-31'),
    (6, 6, 650000, 200000, 100000, 0, '2024-10-31'),
    (7, 7, 900000, 0, 150000, 0, '2024-10-31'),
    (8, 8, 850000, 500000, 150000, 0, '2024-10-31'),
    (9, 9, 120000, 0, 200000, 0, '2024-10-31'),
    (10, 10, 115000, 200000, 200000, 0, '2024-10-31'),
    (11, 11, 800000, 0, 120000, 0, '2024-10-31'),
    (12, 12, 750000, 300000, 120000, 0, '2024-10-31'),
    (13, 13, 100000, 0, 180000, 0, '2024-10-31'),
    (14, 14, 950000, 400000, 180000, 0, '2024-10-31'),
    (15, 15, 130000, 0, 250000, 0, '2024-10-31'),
    (16, 16, 125000, 300000, 250000, 0, '2024-10-31'),
    (17, 17, 150000, 0, 300000, 0, '2024-10-31'),
    (18, 18, 145000, 500000, 300000, 0, '2024-10-31'),
    (19, 19, 170000, 0, 350000, 0, '2024-10-31'),
    (20, 20, 165000, 400000, 350000, 0, '2024-10-31');
/*DELETE FROM [salaries];
DBCC CHECKIDENT ('salaries', RESEED, 0);*/

-- Thêm dữ liệu vào bảng lịch làm việc
-- Tháng 9
INSERT INTO lich_lam_viec
    (ngay, ca, ma_nguoi_dung)
VALUES
    ('2024-11-02', 1, 3),
    ('2024-11-02', 1, 5),
    ('2024-11-02', 1, 7),
    ('2024-11-02', 1, 9),
    ('2024-11-02', 2, 11),
    ('2024-11-02', 2, 13),
    ('2024-11-02', 2, 15),
    ('2024-11-02', 2, 17),

    ('2024-11-02', 1, 4),
    ('2024-11-02', 1, 6),
    ('2024-11-02', 1, 8),
    ('2024-11-02', 1, 10),
    ('2024-11-02', 2, 12),
    ('2024-11-02', 2, 14),
    ('2024-11-02', 2, 16),
    ('2024-11-02', 2, 18),

    ('2024-11-03', 1, 3),
    ('2024-11-03', 1, 5),
    ('2024-11-03', 1, 7),
    ('2024-11-03', 1, 9),
    ('2024-11-03', 2, 11),
    ('2024-11-03', 2, 13),
    ('2024-11-03', 2, 15),
    ('2024-11-03', 2, 17),

    ('2024-09-04', 1, 4),
    ('2024-09-04', 1, 6),
    ('2024-09-04', 1, 8),
    ('2024-09-04', 1, 10),
    ('2024-09-04', 2, 12),
    ('2024-09-04', 2, 14),
    ('2024-09-04', 2, 16),
    ('2024-09-04', 2, 18),

    ('2024-09-05', 1, 3),
    ('2024-09-05', 1, 5),
    ('2024-09-05', 1, 7),
    ('2024-09-05', 1, 9),
    ('2024-09-05', 2, 11),
    ('2024-09-05', 2, 13),
    ('2024-09-05', 2, 15),
    ('2024-09-05', 2, 17),

    ('2024-09-06', 1, 4),
    ('2024-09-06', 1, 6),
    ('2024-09-06', 1, 8),
    ('2024-09-06', 1, 10),
    ('2024-09-06', 2, 12),
    ('2024-09-06', 2, 14),
    ('2024-09-06', 2, 16),
    ('2024-09-06', 2, 18),

    ('2024-09-07', 1, 3),
    ('2024-09-07', 1, 5),
    ('2024-09-07', 1, 7),
    ('2024-09-07', 1, 9),
    ('2024-09-07', 2, 11),
    ('2024-09-07', 2, 13),
    ('2024-09-07', 2, 15),
    ('2024-09-07', 2, 17),

    ('2024-09-08', 1, 4),
    ('2024-09-08', 1, 6),
    ('2024-09-08', 1, 8),
    ('2024-09-08', 1, 10),
    ('2024-09-08', 2, 12),
    ('2024-09-08', 2, 14),
    ('2024-09-08', 2, 16),
    ('2024-09-08', 2, 18),

    ('2024-09-09', 1, 3),
    ('2024-09-09', 1, 5),
    ('2024-09-09', 1, 7),
    ('2024-09-09', 1, 9),
    ('2024-09-09', 2, 11),
    ('2024-09-09', 2, 13),
    ('2024-09-09', 2, 15),
    ('2024-09-09', 2, 17),

    ('2024-09-10', 1, 4),
    ('2024-09-10', 1, 6),
    ('2024-09-10', 1, 8),
    ('2024-09-10', 1, 10),
    ('2024-09-10', 2, 12),
    ('2024-09-10', 2, 14),
    ('2024-09-10', 2, 16),
    ('2024-09-10', 2, 18),

    ('2024-09-11', 1, 3),
    ('2024-09-11', 1, 5),
    ('2024-09-11', 1, 7),
    ('2024-09-11', 1, 9),
    ('2024-09-11', 2, 11),
    ('2024-09-11', 2, 13),
    ('2024-09-11', 2, 15),
    ('2024-09-11', 2, 17),

    ('2024-09-12', 1, 4),
    ('2024-09-12', 1, 6),
    ('2024-09-12', 1, 8),
    ('2024-09-12', 1, 10),
    ('2024-09-12', 2, 12),
    ('2024-09-12', 2, 14),
    ('2024-09-12', 2, 16),
    ('2024-09-12', 2, 18),

    ('2024-09-13', 1, 3),
    ('2024-09-13', 1, 5),
    ('2024-09-13', 1, 7),
    ('2024-09-13', 1, 9),
    ('2024-09-13', 2, 11),
    ('2024-09-13', 2, 13),
    ('2024-09-13', 2, 15),
    ('2024-09-13', 2, 17),

    ('2024-09-14', 1, 4),
    ('2024-09-14', 1, 6),
    ('2024-09-14', 1, 8),
    ('2024-09-14', 1, 10),
    ('2024-09-14', 2, 12),
    ('2024-09-14', 2, 14),
    ('2024-09-14', 2, 16),
    ('2024-09-14', 2, 18),

    ('2024-09-15', 1, 3),
    ('2024-09-15', 1, 5),
    ('2024-09-15', 1, 7),
    ('2024-09-15', 1, 9),
    ('2024-09-15', 2, 11),
    ('2024-09-15', 2, 13),
    ('2024-09-15', 2, 15),
    ('2024-09-15', 2, 17),

    ('2024-09-16', 1, 4),
    ('2024-09-16', 1, 6),
    ('2024-09-16', 1, 8),
    ('2024-09-16', 1, 10),
    ('2024-09-16', 2, 12),
    ('2024-09-16', 2, 14),
    ('2024-09-16', 2, 16),
    ('2024-09-16', 2, 18),

    ('2024-09-17', 1, 3),
    ('2024-09-17', 1, 5),
    ('2024-09-17', 1, 7),
    ('2024-09-17', 1, 9),
    ('2024-09-17', 2, 11),
    ('2024-09-17', 2, 13),
    ('2024-09-17', 2, 15),
    ('2024-09-17', 2, 17),

    ('2024-09-18', 1, 4),
    ('2024-09-18', 1, 6),
    ('2024-09-18', 1, 8),
    ('2024-09-18', 1, 10),
    ('2024-09-18', 2, 12),
    ('2024-09-18', 2, 14),
    ('2024-09-18', 2, 16),
    ('2024-09-18', 2, 18),

    ('2024-09-19', 1, 3),
    ('2024-09-19', 1, 5),
    ('2024-09-19', 1, 7),
    ('2024-09-19', 1, 9),
    ('2024-09-19', 2, 11),
    ('2024-09-19', 2, 13),
    ('2024-09-19', 2, 15),
    ('2024-09-19', 2, 17),

    ('2024-09-20', 1, 4),
    ('2024-09-20', 1, 6),
    ('2024-09-20', 1, 8),
    ('2024-09-20', 1, 10),
    ('2024-09-20', 2, 12),
    ('2024-09-20', 2, 14),
    ('2024-09-20', 2, 16),
    ('2024-09-20', 2, 18);


-- Tháng 10
INSERT INTO lich_lam_viec
    (ngay, ca, ma_nguoi_dung)
VALUES
    ('2024-10-01', 1, 3),
    ('2024-10-01', 1, 5),
    ('2024-10-01', 1, 7),
    ('2024-10-01', 1, 9),
    ('2024-10-01', 2, 11),
    ('2024-10-01', 2, 13),
    ('2024-10-01', 2, 15),
    ('2024-10-01', 2, 17),

    ('2024-10-02', 1, 4),
    ('2024-10-02', 1, 6),
    ('2024-10-02', 1, 8),
    ('2024-10-02', 1, 10),
    ('2024-10-02', 2, 12),
    ('2024-10-02', 2, 14),
    ('2024-10-02', 2, 16),
    ('2024-10-02', 2, 18),

    ('2024-10-03', 1, 3),
    ('2024-10-03', 1, 5),
    ('2024-10-03', 1, 7),
    ('2024-10-03', 1, 9),
    ('2024-10-03', 2, 11),
    ('2024-10-03', 2, 13),
    ('2024-10-03', 2, 15),
    ('2024-10-03', 2, 17),

    ('2024-10-04', 1, 4),
    ('2024-10-04', 1, 6),
    ('2024-10-04', 1, 8),
    ('2024-10-04', 1, 10),
    ('2024-10-04', 2, 12),
    ('2024-10-04', 2, 14),
    ('2024-10-04', 2, 16),
    ('2024-10-04', 2, 18),

    ('2024-10-05', 1, 3),
    ('2024-10-05', 1, 5),
    ('2024-10-05', 1, 7),
    ('2024-10-05', 1, 9),
    ('2024-10-05', 2, 11),
    ('2024-10-05', 2, 13),
    ('2024-10-05', 2, 15),
    ('2024-10-05', 2, 17),

    ('2024-10-06', 1, 4),
    ('2024-10-06', 1, 6),
    ('2024-10-06', 1, 8),
    ('2024-10-06', 1, 10),
    ('2024-10-06', 2, 12),
    ('2024-10-06', 2, 14),
    ('2024-10-06', 2, 16),
    ('2024-10-06', 2, 18),

    ('2024-10-07', 1, 3),
    ('2024-10-07', 1, 5),
    ('2024-10-07', 1, 7),
    ('2024-10-07', 1, 9),
    ('2024-10-07', 2, 11),
    ('2024-10-07', 2, 13),
    ('2024-10-07', 2, 15),
    ('2024-10-07', 2, 17),

    ('2024-10-08', 1, 4),
    ('2024-10-08', 1, 6),
    ('2024-10-08', 1, 8),
    ('2024-10-08', 1, 10),
    ('2024-10-08', 2, 12),
    ('2024-10-08', 2, 14),
    ('2024-10-08', 2, 16),
    ('2024-10-08', 2, 18),

    ('2024-10-09', 1, 3),
    ('2024-10-09', 1, 5),
    ('2024-10-09', 1, 7),
    ('2024-10-09', 1, 9),
    ('2024-10-09', 2, 11),
    ('2024-10-09', 2, 13),
    ('2024-10-09', 2, 15),
    ('2024-10-09', 2, 17),

    ('2024-10-10', 1, 4),
    ('2024-10-10', 1, 6),
    ('2024-10-10', 1, 8),
    ('2024-10-10', 1, 10),
    ('2024-10-10', 2, 12),
    ('2024-10-10', 2, 14),
    ('2024-10-10', 2, 16),
    ('2024-10-10', 2, 18),

    ('2024-10-11', 1, 3),
    ('2024-10-11', 1, 5),
    ('2024-10-11', 1, 7),
    ('2024-10-11', 1, 9),
    ('2024-10-11', 2, 11),
    ('2024-10-11', 2, 13),
    ('2024-10-11', 2, 15),
    ('2024-10-11', 2, 17),

    ('2024-10-12', 1, 4),
    ('2024-10-12', 1, 6),
    ('2024-10-12', 1, 8),
    ('2024-10-12', 1, 10),
    ('2024-10-12', 2, 12),
    ('2024-10-12', 2, 14),
    ('2024-10-12', 2, 16),
    ('2024-10-12', 2, 18),

    ('2024-10-13', 1, 3),
    ('2024-10-13', 1, 5),
    ('2024-10-13', 1, 7),
    ('2024-10-13', 1, 9),
    ('2024-10-13', 2, 11),
    ('2024-10-13', 2, 13),
    ('2024-10-13', 2, 15),
    ('2024-10-13', 2, 17),

    ('2024-10-14', 1, 4),
    ('2024-10-14', 1, 6),
    ('2024-10-14', 1, 8),
    ('2024-10-14', 1, 10),
    ('2024-10-14', 2, 12),
    ('2024-10-14', 2, 14),
    ('2024-10-14', 2, 16),
    ('2024-10-14', 2, 18),

    ('2024-10-15', 1, 3),
    ('2024-10-15', 1, 5),
    ('2024-10-15', 1, 7),
    ('2024-10-15', 1, 9),
    ('2024-10-15', 2, 11),
    ('2024-10-15', 2, 13),
    ('2024-10-15', 2, 15),
    ('2024-10-15', 2, 17),

    ('2024-10-16', 1, 4),
    ('2024-10-16', 1, 6),
    ('2024-10-16', 1, 8),
    ('2024-10-16', 1, 10),
    ('2024-10-16', 2, 12),
    ('2024-10-16', 2, 14),
    ('2024-10-16', 2, 16),
    ('2024-10-16', 2, 18),

    ('2024-10-17', 1, 3),
    ('2024-10-17', 1, 5),
    ('2024-10-17', 1, 7),
    ('2024-10-17', 1, 9),
    ('2024-10-17', 2, 11),
    ('2024-10-17', 2, 13),
    ('2024-10-17', 2, 15),
    ('2024-10-17', 2, 17),

    ('2024-10-18', 1, 4),
    ('2024-10-18', 1, 6),
    ('2024-10-18', 1, 8),
    ('2024-10-18', 1, 10),
    ('2024-10-18', 2, 12),
    ('2024-10-18', 2, 14),
    ('2024-10-18', 2, 16),
    ('2024-10-18', 2, 18),

    ('2024-10-19', 1, 3),
    ('2024-10-19', 1, 5),
    ('2024-10-19', 1, 7),
    ('2024-10-19', 1, 9),
    ('2024-10-19', 2, 11),
    ('2024-10-19', 2, 13),
    ('2024-10-19', 2, 15),
    ('2024-10-19', 2, 17),

    ('2024-10-20', 1, 4),
    ('2024-10-20', 1, 6),
    ('2024-10-20', 1, 8),
    ('2024-10-20', 1, 10),
    ('2024-10-20', 2, 12),
    ('2024-10-20', 2, 14),
    ('2024-10-20', 2, 16),
    ('2024-10-20', 2, 18);
/*DELETE FROM [work_schedules];
DBCC CHECKIDENT ('work_schedules', RESEED, 0);*/

INSERT INTO cham_cong
    (ngay, gio_vao, gio_ra, ghi_chu, ma_nguoi_dung)
VALUES
    ('2024-09-01', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-01', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-01', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-01', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-01', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-01', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-01', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-01', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-02', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-02', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-02', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-02', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-02', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-02', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-02', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-02', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-09-03', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-03', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-03', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-03', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-03', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-03', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-03', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-03', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-04', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-04', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-04', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-04', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-04', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-04', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-04', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-04', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-09-05', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-05', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-05', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-05', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-05', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-05', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-05', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-05', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-06', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-06', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-06', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-06', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-06', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-06', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-06', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-06', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-09-07', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-07', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-07', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-07', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-07', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-07', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-07', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-07', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-08', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-08', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-08', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-08', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-08', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-08', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-08', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-08', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-09-09', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-09', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-09', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-09', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-09', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-09', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-09', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-09', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-10', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-10', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-10', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-10', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-10', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-10', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-10', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-10', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-09-11', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-11', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-11', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-11', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-11', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-11', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-11', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-11', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-12', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-12', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-12', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-12', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-12', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-12', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-12', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-12', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-09-13', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-13', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-13', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-13', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-13', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-13', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-13', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-13', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-14', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-14', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-14', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-14', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-14', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-14', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-14', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-14', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-09-15', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-15', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-15', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-15', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-15', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-15', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-15', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-15', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-16', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-16', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-16', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-16', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-16', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-16', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-16', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-16', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-09-17', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-17', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-17', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-17', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-17', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-17', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-17', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-17', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-18', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-18', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-18', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-18', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-18', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-18', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-18', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-18', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-09-19', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-09-19', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-09-19', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-09-19', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-09-19', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-09-19', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-09-19', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-09-19', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-09-20', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-09-20', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-09-20', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-09-20', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-09-20', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-09-20', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-09-20', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-09-20', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18);
INSERT INTO cham_cong
    (ngay, gio_vao, gio_ra, ghi_chu, ma_nguoi_dung)
VALUES
    ('2024-10-01', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-01', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-01', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-01', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-10-01', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-01', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-01', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-10-01', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-02', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-10-02', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-10-02', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-10-02', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-10-02', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-02', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-02', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-02', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-10-03', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-03', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-03', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-03', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-10-03', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-03', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-03', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-01-03', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-04', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-10-04', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-10-04', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-10-04', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-10-04', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-04', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-04', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-04', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-10-05', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-05', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-05', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-05', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-10-05', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-05', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-05', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-10-05', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-06', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-10-06', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-10-06', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-10-06', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-10-06', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-06', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-06', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-06', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-10-07', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-07', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-07', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-07', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-10-07', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-07', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-07', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-10-07', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-08', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-10-08', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-10-08', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-10-08', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-10-08', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-08', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-08', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-08', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-10-09', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-09', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-09', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-09', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-10-09', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-09', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-09', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-10-09', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-10', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-10-10', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-10-10', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-10-10', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-10-10', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-10', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-10', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-10', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-10-11', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-11', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-11', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-11', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-10-11', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-11', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-11', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-10-11', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-12', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-10-12', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-10-12', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-10-12', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-10-12', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-12', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-12', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-12', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-10-13', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-13', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-13', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-13', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-10-13', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-13', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-13', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-10-13', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-14', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-10-14', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-10-14', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-10-14', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-10-14', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-14', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-14', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-14', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-10-15', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-15', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-15', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-15', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-10-15', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-15', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-15', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-10-15', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-16', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-10-16', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-10-16', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-10-16', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-10-16', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-16', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-16', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-16', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-10-17', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-17', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-17', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-17', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 9),
    ('2024-10-17', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-17', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-17', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-10-17', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-18', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 4),
    ('2024-10-18', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 6),
    ('2024-10-18', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 8),
    ('2024-10-18', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 10),
    ('2024-10-18', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-18', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-18', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-18', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18),
    ('2024-10-19', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 3),
    ('2024-10-19', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 5),
    ('2024-10-19', '08:00:00', '16:00:00', N'Làm việc đúng giờ', 7),
    ('2024-10-19', '08:15:00', '16:00:00', N'Đi làm trễ', 9),
    ('2024-10-19', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 11),
    ('2024-10-19', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 13),
    ('2024-10-19', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 15),
    ('2024-10-19', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 17),
    ('2024-10-20', '09:00:00', '16:00:00', N'Không đi làm', 4),
    ('2024-10-20', '16:00:00', '16:00:00', N'Không đi làm', 6),
    ('2024-10-20', '08:30:00', '16:00:00', N'Đi làm trễ', 8),
    ('2024-10-20', '08:00:00', '15:00:00', N'Về sớm', 10),
    ('2024-10-20', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 12),
    ('2024-10-20', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 14),
    ('2024-10-20', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 16),
    ('2024-10-20', '12:00:00', '20:00:00', N'Làm việc đúng giờ', 18);
-- Thêm dữ liệu vào bảng tiếp nhận
INSERT INTO tiep_nhan
    (ma_nguoi_dung, ma_benh_nhan)
VALUES
    (3, 1),
    (4, 2),
    (5, 3),
    (16, 4),
    (17, 5),
    (18, 6),
    (3, 7),
    (4, 8),
    (5, 9),
    (16, 10),
    (17, 11),
    (18, 12),
    (3, 13),
    (4, 14),
    (5, 15),
    (16, 16),
    (17, 17),
    (18, 18),
    (3, 19),
    (4, 20);
/*DELETE FROM receptions;
DBCC CHECKIDENT ('receptions', RESEED, 0);*/

-- Thêm dữ liệu vào bảng lịch hẹn
INSERT INTO lich_hen
    (ghi_chu, trang_thai, ngay_hen, ca, ma_nguoi_dung, ma_benh_nhan)
VALUES
    (N'Khám răng lần đầu', 0, '2024-10-25', 1, 6, 1),
    (N'Tái khám sau nhổ răng', 1, '2024-10-15', 2, 7, 2),
    (N'Khám nha chu', 0, '2024-11-05', 1, 8, 3),
    (N'Chỉnh hình răng mặt', 0, '2024-10-30', 2, 9, 4),
    (N'Cấy ghép Implant', 1, '2024-09-20', 1, 10, 5),
    (N'Khám tổng quát', 0, '2024-10-27', 2, 6, 6),
    (N'Khám răng miệng', 1, '2024-11-02', 1, 7, 7),
    (N'Tái khám sau cấy ghép', 0, '2024-11-10', 2, 8, 8),
    (N'Kiểm tra tình trạng răng', 0, '2024-10-22', 1, 9, 9),
    (N'Khám và lấy cao răng', 1, '2024-10-20', 2, 10, 10),
    (N'Tái khám sau điều trị', 0, '2024-11-05', 1, 11, 11),
    (N'Khám răng sữa', 1, '2024-10-25', 2, 12, 12),
    (N'Khám răng khôn', 0, '2024-10-15', 1, 13, 13),
    (N'Khám và làm răng giả', 0, '2024-11-01', 2, 14, 14),
    (N'Khám sức khỏe răng miệng', 1, '2024-10-28', 1, 15, 15),
    (N'Tái khám sau nhổ răng', 0, '2024-11-12', 2, 6, 16),
    (N'Khám răng cho trẻ em', 1, '2024-10-31', 1, 7, 17),
    (N'Khám và điều trị sâu răng', 0, '2024-11-04', 2, 8, 18),
    (N'Kiểm tra định kỳ', 0, '2024-10-29', 1, 9, 19),
    (N'Khám và làm sạch răng', 1, '2024-11-03', 2, 10, 20);

/*DELETE FROM appointments;
DBCC CHECKIDENT ('appointments', RESEED, 0);*/
-- Thêm dữ liệu vào bảng hồ sơ bệnh án
INSERT INTO ho_so_benh_an
    (chan_doan, phuong_phap_dieu_tri, trieu_chung, ma_benh_nhan)
VALUES
    (N'Sâu răng', N'Điều trị bằng thuốc', N'Đau nhức, cảm thấy khó chịu', 1),
    (N'Viêm nướu', N'Tẩy sạch và kê đơn thuốc', N'Sưng nướu, chảy máu khi đánh răng', 2),
    (N'Hơi thở có mùi', N'Tư vấn vệ sinh răng miệng', N'Khó chịu, mùi hôi', 3),
    (N'Sâu răng nghiêm trọng', N'Nhổ răng', N'Đau nhức, không ăn được', 4),
    (N'Răng khôn', N'Nhổ răng khôn', N'Đau ở vùng răng khôn', 5),
    (N'Tiêu xương hàm', N'Ghép xương', N'Không có dấu hiệu rõ ràng', 6),
    (N'Hypersensitivity', N'Sử dụng kem đánh răng cho răng nhạy cảm', N'Đau nhức khi ăn đồ lạnh', 7),
    (N'Khô miệng', N'Tư vấn và điều trị', N'Miệng khô, khó chịu', 8),
    (N'Khối u miệng', N'Phẫu thuật', N'Khó nuốt, đau', 9),
    (N'Viêm xoang hàm', N'Điều trị bằng thuốc', N'Đau hàm, nhức đầu', 10),
    (N'Tiểu đường', N'Tư vấn về chế độ ăn', N'Khát nước, tiểu nhiều', 11),
    (N'Trẻ em bị sâu răng', N'Điều trị bằng thuốc và hướng dẫn', N'Đau nhức, khó chịu', 12),
    (N'Viêm họng', N'Tư vấn điều trị', N'Đau họng, khó nuốt', 13),
    (N'Viêm quanh răng', N'Điều trị bằng thuốc và vệ sinh', N'Sưng nướu, đau nhức', 14),
    (N'Chấn thương răng', N'Khám và điều trị', N'Đau nhức, sưng', 15),
    (N'Sâu răng và viêm nướu', N'Điều trị kết hợp', N'Đau nhức, chảy máu', 16),
    (N'Hơi thở có mùi hôi', N'Tư vấn vệ sinh', N'Mùi hôi miệng', 17),
    (N'Răng nhạy cảm', N'Sử dụng sản phẩm phù hợp', N'Đau nhức khi ăn', 18),
    (N'Tình trạng răng miệng không tốt', N'Tư vấn điều trị', N'Tình trạng tổng quát xấu', 19),
    (N'Chấn thương hàm', N'Điều trị bằng thuốc và phẫu thuật', N'Đau nhức, sưng hàm', 20);
/*DELETE FROM medical_records;
DBCC CHECKIDENT ('medical_records', RESEED, 0);*/

-- Thêm dữ liệu vào bảng loại hàng tồn kho
INSERT INTO loai_hang_ton_kho
    (ma_loai, ten_loai)
VALUES
    (1, N'Thuốc'),
    (2, N'Vật tư'),
    (3, N'Dụng cụ'),
    (4, N'Thiết bị');
/*DELETE FROM type_inventory;
DBCC CHECKIDENT ('type_inventory', RESEED, 0);*/

-- Thêm dữ liệu vào bảng hàng tồn kho
INSERT INTO hang_ton_kho
    (ma_kho, ten, loai, so_luong, don_vi, lieu_luong, ngay_san_xuat, ngay_het_han, ngay_nhap, gia, ma_loai)
VALUES
    (1, N'Amoxicillin', N'Kháng sinh', 50, N'Viên', N'500mg', '2024-06-01', '2025-12-01', '2024-06-15', 10000, 1),
    (2, N'Amoxicillin', N'Kháng sinh', 100, N'Viên', N'500mg', '2024-06-15', '2026-06-15', '2024-06-20', 10000, 1),
    (3, N'Metronidazol', N'Kháng sinh', 75, N'Viên', N'250mg', '2023-11-01', '2024-11-01', '2023-11-15', 15000, 1),
    (4, N'Metronidazol', N'Kháng sinh', 150, N'Viên', N'250mg', '2024-04-01', '2026-04-01', '2024-04-15', 15000, 1),
    (5, N'Cephalexin', N'Kháng sinh', 60, N'Viên', N'500mg', '2024-10-01', '2025-10-01', '2024-10-15', 12000, 1),
    (6, N'Cephalexin', N'Kháng sinh', 120, N'Viên', N'500mg', '2024-05-01', '2026-05-01', '2024-05-15', 12000, 1),
    (7, N'Medrol', N'Kháng viêm', 50, N'Viên', N'16mg', '2024-01-01', '2026-01-01', '2024-01-20', 20000, 1),
    (8, N'Medrol', N'Kháng viêm', 90, N'Viên', N'16mg', '2023-08-01', '2025-08-01', '2023-08-20', 20000, 1),
    (9, N'Ibuprofen', N'Kháng viêm', 200, N'Viên', N'400mg', '2024-03-01', '2025-03-01', '2024-03-10', 5000, 1),
    (10, N'Ibuprofen', N'Kháng viêm', 150, N'Viên', N'400mg', '2024-12-01', '2025-12-01', '2024-12-10', 5000, 1),
    (11, N'Diclofenac', N'Kháng viêm', 100, N'Viên', N'50mg', '2023-09-01', '2025-09-01', '2024-09-10', 8000, 1),
    (12, N'Diclofenac', N'Kháng viêm', 100, N'Viên', N'50mg', '2023-09-01', '2025-09-01', '2024-09-10', 8000, 1),
    (13, N'Paracetamol', N'Giảm đau', 250, N'Viên', N'500mg', '2024-06-01', '2026-06-01', '2024-06-10', 2000, 1),
    (14, N'Paracetamol', N'Giảm đau', 250, N'Viên', N'500mg', '2024-02-01', '2027-02-01', '2024-02-10', 2000, 1),
    (15, N'Dexamethasone', N'Giảm đau', 120, N'Viên', N'0.5mg', '2024-07-01', '2025-07-01', '2024-07-10', 7000, 1),
    (16, N'Dexamethasone', N'Giảm đau', 150, N'Viên', N'0.5mg', '2024-09-01', '2026-09-01', '2024-10-01', 7000, 1),

    (17, N'Mũi cạo vôi', N'Vật liệu cố định', 10, N'Kg', '', '2024-01-01', '2029-01-01', '2024-01-10', 50000, 2),
    (18, N'Nạy', N'Vật liệu cố định', 20, N'Cây', '', '2024-01-20', '2025-01-20', '2024-01-25', 80000, 2),
    (19, N'Cây đo túi nướu', N'Vật liệu cố định', 10, N'Cây', '', '2024-03-20', '2025-03-20', '2024-03-25', 100000, 2),
    (20, N'Nạy', N'Vật liệu cố định', 20, N'Cây', '', '2024-01-20', '2025-01-20', '2024-01-25', 80000, 2),
    (21, N'Ống chích sắt', N'Vật liệu cố định', 50, N'Ống', '', '2024-05-20', '2025-05-20', '2024-05-25', 10000, 2),
    (22, N'Bông Gòn', N'Vật liệu tiêu hao', 50, N'Bịch', '', '2024-10-01', '2029-10-01', '2024-10-15', 20000, 2),
    (23, N'Mũi khoan kim cương', N'Vật liệu tiêu hao', 30, N'Cái', '', '2024-01-20', '2026-01-20', '2024-01-10', 50000, 2),
    (24, N'NaCl', N'Vật liệu tiêu hao', 5, N'Kg', '', '2024-10-01', '2027-10-01', '2024-10-15', 50000, 2),
    (25, N'Trâm tay', N'Vật liệu tiêu hao', 50, N'Cái', '', '2024-10-01', '2028-10-01', '2024-10-15', 30000, 2),
    (26, N'Trâm tay', N'Vật liệu tiêu hao', 50, N'Cái', '', '2024-10-01', '2029-10-01', '2024-10-15', 30000, 2),
    (27, N'Sò đánh bóng', N'Vật liệu tiêu hao', 60, N'Cái', '', '2024-10-01', '2026-10-01', '2024-10-15', 70000, 2),
    (28, N'Chỉ khâu', N'Vật liệu tiêu hao', 50, N'Cuộn', '', '2024-10-01', '2030-10-01', '2024-10-15', 35000, 2),
    (29, N'Thuốc tê', N'Vật liệu tiêu hao', 200, N'Viên', N'50mg', '2024-08-01', '2026-08-01', '2024-08-15', 35000, 2),

    (30, N'Bộ dụng cụ khám răng', N'Dụng cụ điều trị', 50, N'Bộ', '', '2024-04-01', '2027-04-01', '2024-04-15', 150000, 3),
    (31, N'Bộ dụng cụ trám răng', N'Dụng cụ điều trị', 50, N'Bộ', '', '2024-04-01', '2027-04-01', '2024-05-01', 200000, 3),
    (32, N'Bộ dụng cụ chỉnh hình', N'Dụng cụ thẩm mỹ', 5, N'Bộ', '', '2024-10-01', '2027-10-01', '2024-10-10', 300000, 3),

    (33, N'Máy X-Quang', N'Thiết bị chẩn đoán', 4, N'Máy', '', '2024-09-01', '2029-09-01', '2024-09-15', 15000000, 4),
    (34, N'Máy chụp CT', N'Thiết bị chẩn đoán', 3, N'Máy', '', '2024-09-01', '2029-09-01', '2024-09-15', 20000000, 4),
    (35, N'Ghế nha khoa', N'Thiết bị điều trị', 5, N'Ghế', '', '2024-08-01', '2032-08-01', '2024-09-15', 20000000, 4),
    (36, N'Máy trám răng', N'Thiết bị điều trị', 4, N'Máy', '', '2024-07-01', '2030-07-01', '2024-07-15', 10000000, 4),
    (37, N'Máy điều trị tủy', N'Thiết bị điều trị', 3, N'Máy', '', '2024-09-01', '2034-09-01', '2024-10-15', 20000000, 4),
    (38, N'Máy tẩy trắng răng', N'Thiết bị thẩm mỹ', 3, N'Máy', '', '2024-09-01', '2029-09-01', '2024-12-01', 12000000, 4);

/*DELETE FROM inventory;
DBCC CHECKIDENT ('inventory', RESEED, 0);*/

-- Thêm dữ liệu vào bảng đơn thuốc
INSERT INTO don_thuoc
    (ma_don_thuoc, ngay, ma_benh_nhan, ma_nguoi_dung)
VALUES
    (1, '2024-10-01', 1, 6),
    (2, '2024-10-01', 2, 7),
    (3, '2024-10-02', 3, 8),
    (4, '2024-10-02', 4, 9),
    (5, '2024-10-03', 5, 10),
    (6, '2024-10-03', 6, 11),
    (7, '2024-10-04', 7, 12),
    (8, '2024-10-04', 8, 13),
    (9, '2024-10-05', 9, 14),
    (10, '2024-10-05', 10, 15),
    (11, '2024-10-06', 11, 6),
    (12, '2024-10-06', 12, 7),
    (13, '2024-10-07', 13, 8),
    (14, '2024-10-07', 14, 9),
    (15, '2024-10-08', 15, 10),
    (16, '2024-10-08', 16, 11),
    (17, '2024-10-09', 17, 12),
    (18, '2024-10-09', 18, 13),
    (19, '2024-10-10', 19, 14),
    (20, '2024-10-10', 20, 15);

/*DELETE FROM prescriptions;
DBCC CHECKIDENT ('prescriptions', RESEED, 0);*/

-- Thêm dữ liệu vào bảng chi tiết đơn thuốc
INSERT INTO chi_tiet_don_thuoc
    (ma_kho, so_luong, thoi_gian, lieu_luong, tan_suat, ghi_chu, ma_don_thuoc)
VALUES
    (13, 10, 5, 500, 3, N'Uống sau khi ăn', 1),
    (1, 8, 4, 500, 3, N'Uống sau khi ăn', 1),
    (1, 14, 7, 500, 2, N'Uống trước khi ăn', 2),
    (3, 14, 7, 500, 2, N'Uống trước khi ăn', 2),
    (5, 14, 7, 500, 2, N'Uống sau khi ăn', 2),
    (3, 15, 5, 250, 2, N'Uống khi có triệu chứng', 3),
    (9, 20, 10, 400, 4, N'Uống sau khi ăn', 4),
    (11, 20, 10, 400, 4, N'Uống sau khi ăn', 4),
    (5, 10, 7, 500, 3, N'Uống sau khi ăn', 5),
    (9, 12, 6, 16, 1, N'Uống theo chỉ định', 6),
    (1, 10, 5, 500, 2, N'Uống sau khi ăn', 7),
    (11, 6, 2, 50, 2, N'Uống khi đau', 8),
    (9, 14, 7, 400, 3, N'Uống khi đau', 9),
    (1, 14, 7, 500, 3, N'Uống khi đau', 9),
    (15, 5, 7, 0.5, 1, N'Uống vào buổi sáng', 10),
    (13, 8, 5, 500, 3, N'Uống khi đau đầu', 11),
    (3, 10, 5, 250, 2, N'Uống trước khi ăn', 12),
    (5, 12, 10, 500, 3, N'Uống khi nhiễm khuẩn', 13),
    (9, 10, 7, 400, 4, N'Uống sau khi ăn', 14),
    (1, 20, 14, 500, 2, N'Uống sau bữa ăn', 15),
    (8, 10, 5, 16, 1, N'Uống theo chỉ định', 16),
    (11, 15, 7, 50, 3, N'Uống khi cần giảm đau', 17),
    (15, 8, 3, 0.5, 1, N'Uống vào buổi sáng', 18),
    (13, 20, 6, 500, 4, N'Uống khi sốt', 19),
    (3, 5, 7, 250, 2, N'Uống sau khi ăn', 20);
/*DELETE FROM prescription_details;
DBCC CHECKIDENT ('prescription_details', RESEED, 0);*/

-- Thêm dữ liệu vào bảng loại dịch vụ
INSERT INTO loai_dich_vu
    (ten_ten_dich)
VALUES
    (N'Khám - Hồ sơ'),
    (N'Nhổ răng'),
    (N'Nha chu'),
    (N'Chữa răng - Nội nha'),
    (N'Phục hình tháo lắp'),
    (N'Phục hình cố định'),
    (N'Diều trị răng sữa'),
    (N'Chỉnh hình răng mặt'),
    (N'Nha công cộng'),
    (N'Điều trị loạn năng hệ thống nhai'),
    (N'X-Quang răng'),
    (N'Cấy ghép Implant'),
    (N'Phục hình đơn lẻ'),
    (N'Phục hình bắt vít');
/*DELETE FROM service_categories;
DBCC CHECKIDENT ('service_categories', RESEED, 0);*/

-- Thêm dữ liệu vào bảng dịch vụ
-- Category: Khám - Hồ sơ (category_id = 1)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (1, N'Khám - Hồ sơ', N'Lượt', 5000);

-- Category: Nhổ răng (category_id = 2)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (2, N'Răng cửa, răng nanh', N'Cái', 100000),
    (2, N'Răng cối nhỏ', N'Cái', 120000),
    (2, N'Răng cối lớn trên', N'Cái', 140000),
    (2, N'Răng cối lớn dưới', N'Cái', 180000),
    (2, N'Nhổ răng lung lay', N'Cái', 100000),
    (2, N'Nhổ chân răng vĩnh viễn', N'Cái', 120000),
    (2, N'Khâu ổ răng', N'Cái', 100000);

-- Category: Nha chu (category_id = 3)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (3, N'Cạo vôi răng', N'2 hàm', 100000),
    (3, N'Diều trị viêm nha chu không phẫu thuật', N'Vùng hàm', 200000),
    (3, N'Phẫu thuật lật vạt làm sạch', N'Lần', 200000),
    (3, N'Cắt thăng', N'Lần', 200000),
    (3, N'Phẫu thuật nướu', N'Răng', 1000000);

-- Category: Chữa răng - Nội nha (category_id = 4)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (4, N'Tái tạo thân răng', N'Răng', 300000),
    (4, N'Trám composite xoang I, III', N'Xoang', 200000),
    (4, N'Trám composite xoang II, IV, V', N'Xoang', 240000),
    (4, N'Trám GIC', N'Xoang', 200000),
    (4, N'Trám đắp mặt, hố kẽ', N'Cái', 400000),
    (4, N'Trám phòng ngừa', N'Cái', 160000),
    (4, N'Chữa tủy - Răng cửa, răng nanh', N'Răng', 500000),
    (4, N'Chữa tủy - Răng cối nhỏ', N'Răng', 600000),
    (4, N'Chữa tủy - Răng cối lớn', N'Răng', 800000),
    (4, N'Chữa lại tủy (đóng thêm)', N'Răng', 300000);

-- Category: Phục hình tháo lắp (category_id = 5)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (5, N'Phục hình tháo lắp - 1 răng', N'Răng', 200000),
    (5, N'Phục hình tháo lắp - 1 hàm toàn hàm', N'Hàm', 3000000),
    (5, N'Phục hình tháo lắp - 2 hàm toàn hàm', N'Hàm', 6000000),
    (5, N'Sửa chữa hàm - Vá hàm', N'Hàm', 200000),
    (5, N'Sửa chữa hàm - Thay nền', N'Hàm', 600000),
    (5, N'Sửa chữa hàm - Đệm hàm nhựa nâu', N'Hàm', 500000),
    (5, N'Sửa chữa hàm - Thêm, thay móc', N'Cái', 100000),
    (5, N'Sửa chữa hàm - Thêm, thay răng', N'Cái', 100000),
    (5, N'Sửa chữa hàm - Chữa đau', N'Lần', 100000),
    (5, N'Sửa chữa hàm - Móc đeo', N'Cái', 400000),
    (5, N'Sửa chữa hàm - Hàm đeo', N'Cái', 1400000),
    (5, N'Hàm khung bộ (răng tính riêng)', N'Cái', 1500000);

-- Category: Phục hình cố định (category_id = 6)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (6, N'Tái tạo cùi răng (có chốt)', N'Răng', 300000),
    (6, N'Mão, cầu răng kim loại toàn diện', N'Răng', 700000),
    (6, N'Mão, cầu răng kim loại - sứ', N'Răng', 1000000),
    (6, N'Sứ titan', N'Răng', 1400000),
    (6, N'Hàm khung Ti (chưa bao gồm răng)', N'Răng', 3000000),
    (6, N'Sứ zirconia', N'Răng', 5000000),
    (6, N'Sứ cercon', N'Răng', 7000000),
    (6, N'Diều chỉnh, gắn lại, tháo PHCD', N'Răng', 200000),
    (6, N'Hàm tạm', N'Răng', 100000),
    (6, N'Mão tạm', N'Răng', 30000),
    (6, N'Cầu răng tạm', N'Răng', 30000),
    (6, N'Cùi giả đúc', N'Cái', 200000);

-- Category: Điều trị răng sữa (category_id = 7)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (7, N'Nhổ răng sữa (tê bôi)', N'Răng', 40000),
    (7, N'Nhổ răng sữa (tê chích)', N'Răng', 100000),
    (7, N'Trám răng sữa bằng GIC', N'Răng', 100000),
    (7, N'Trám răng sữa bằng composite', N'Răng', 160000),
    (7, N'Trám dự phòng hố rãnh mặt nhai', N'Răng', 160000),
    (7, N'Đặt gel Fluor phòng ngừa', N'Hàm', 100000),
    (7, N'Chữa tủy chân răng sữa', N'Răng', 400000),
    (7, N'Mão nhựa răng cửa (Strip crown)', N'Răng', 400000),
    (7, N'Mão kim loại làm sẵn', N'Răng', 500000),
    (7, N'Bộ giữ khoảng tháo lắp', N'Hàm', 500000),
    (7, N'Giữ khoảng cố định 1 bên', N'Cái', 800000),
    (7, N'Bộ giữ khoảng cố định 2 bên', N'Bộ', 1600000),
    (7, N'Mặt phẳng nghiêng', N'Cái', 1000000),
    (7, N'Tấm chặn môi', N'Cái', 2000000),
    (7, N'Khí cụ tháo lắp điều trị cắn chéo 1 răng', N'Cái', 2000000),
    (7, N'Khí cụ Quad Helix', N'Cái', 2000000),
    (7, N'Tiểu phẫu', N'Lần', 500000);

-- Category: Chỉnh hình răng mặt (category_id = 8)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (8, N'Khí cụ tháo lắp - 1 hàm', N'Hàm', 3000000),
    (8, N'Khí cụ tháo lắp - 2 hàm', N'Hàm', 6000000),
    (8, N'Làm lại khí cụ 1 hàm', N'Hàm', 600000),
    (8, N'Làm lại khí cụ 2 hàm', N'Hàm', 1200000),
    (8, N'Khí cụ duy trì kết quả - 1 hàm', N'Hàm', 600000),
    (8, N'Khí cụ cố định - 1 hàm', N'Hàm', 20000000),
    (8, N'Khí cụ cố định - 2 hàm', N'Hàm', 40000000),
    (8, N'Khí cụ cố định - 2 hàm điều trị trên 2 năm', N'Hàm', 52000000),
    (8, N'Khí cụ cố định - 2 hàm sử dụng mắc cài thế hệ mới', N'Hàm', 56000000),
    (8, N'Khí cụ cố định - 2 hàm sử dụng mắc cài sứ', N'Hàm', 56000000);

-- Category: Nha công cộng (category_id = 9)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (9, N'Mảng Fluor không thuốc', N'Mảng', 200000);

-- Category: Điều trị loạn năng hệ thống nhai (category_id = 10)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (10, N'Một máng nhai', N'Mảng', 1000000),
    (10, N'Mài chỉnh khớp cắn đơn giản', N'Lần', 300000),
    (10, N'Mài chỉnh khớp cắn phức tạp', N'Lần', 600000);

-- Category: X-Quang răng (category_id = 11)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (11, N'Phim quanh chóp', N'Phim', 60000),
    (11, N'Phim toàn cảnh', N'Phim', 200000);

-- Category: Cấy ghép Implant (category_id = 12)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (12, N'Chi phí cấy ghép 1 trụ Implant - OSSTEM (KOREA)', N'Trụ', 30000000),
    (12, N'Chi phí cấy ghép 1 trụ Implant - RITTER (GERMANY)', N'Trụ', 40000000),
    (12, N'Chi phí cấy ghép 1 trụ Implant - SIC (SWISS/GERMANY)', N'Trụ', 40000000),
    (12, N'Chi phí cấy ghép 1 trụ Implant - NOBEL BIOCARE (USA/SWEDEN)', N'Trụ', 48000000),
    (12, N'Chi phí cấy ghép 1 trụ Implant - NOBEL ACTIVE/PARALLEL (USA/SWEDEN)', N'Trụ', 58000000),
    (12, N'Chi phí cấy ghép 1 trụ Implant - STRAUMANN SLActive (SWISS)', N'Trụ', 64000000),
    (12, N'Chi phí cấy ghép 1 trụ Implant - NOBEL TiUltra - ACTIVE/PARALLEL (USA/SWEDEN)', N'Trụ', 64000000),
    (12, N'Chi phí cấy ghép 1 trụ Implant - STRAUMANN BLX (SWISS)', N'Trụ', 70000000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Xương Khử Khoáng', N'1 Đơn vị', 10000000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Màng Collagen 15x20mm', N'1 Đơn vị', 8000000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Màng Collagen 20x30mm', N'1 Đơn vị', 10000000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Màng Collagen 30x40mm', N'1 Đơn vị', 14000000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Màng Titan, PTFE', N'1 Đơn vị', 12000000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Vít (Tack) Neo Xương, Màng', N'1 Đơn vị', 1200000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Ghép Xương Tự Thân', N'1 Đơn vị', 12000000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Mô Liên Kết', N'1 Đơn vị', 10000000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Màng PRP (Tu Than)', N'1 Đơn vị', 10000000),
    (12, N'Chi phí ghép xương, màng và mô liên kết - Ghép Xương Mào Chậu', N'1 Đơn vị', 40000000),
    (12, N'Chi phí nâng xoang - Nâng Xoang Kín', N'1 Đơn vị', 8000000),
    (12, N'Chi phí nâng xoang - Nâng Xoang Hở', N'1 Đơn vị', 12000000),
    (12, N'Chi phí chụp CT CONE BEAM - Chụp CT Cone Beam 1 Hàm', N'Hàm', 1100000),
    (12, N'Chi phí chụp CT CONE BEAM - Chụp CT Cone Beam 2 Hàm', N'Hàm', 1800000),
    (12, N'Máng Hướng Dẫn/in Sọ Mặt - Giá Cơ Bản', N'1 Đơn vị', 6600000),
    (12, N'Máng Hướng Dẫn/in Sọ Mặt - Phụ thu thêm cho 1 đơn vị', N'1 Đơn vị', 1400000);

-- Category: Phục hình đơn lẻ (category_id = 13)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (13, N'Phục hình Răng Sứ Đan - Kim Loại', N'1 Đơn vị', 3000000),
    (13, N'Phục hình Răng Sứ Đan - Titan', N'1 Đơn vị', 6000000),
    (13, N'Phục hình Răng Sứ Đan - Zirco', N'1 Đơn vị', 12000000),
    (13, N'Phục hình Răng Sứ Đan - Bio HPP', N'1 Đơn vị', 16000000),
    (13, N'Giá răng sứ bắt vít trên Multi Unit - Trụ phục hình Multi Unit', N'1 Đơn vị', 20000000),
    (13, N'Giá răng sứ bắt vít trên Multi Unit - Răng sứ (Kim loại, Titan, Zirco, BioHPP)', N'1 Đơn vị', 0),
    -- Giá tùy chọn theo giá răng sứ
    (13, N'Abutment Zirconia', N'1 Đơn vị', 4400000);

-- Category: Phục hình bắt vít (category_id = 14)
INSERT INTO dich_vu
    (ma_loai, ten, don_vi, gia)
VALUES
    (14, N'Hàm phủ tháo lắp (Răng composite nền nhựa cường lực) - 2 Implant', N'Cái', 140000000),
    (14, N'Hàm phủ tháo lắp (Răng composite nền nhựa cường lực) - Thanh bar, nút bấm - 3 Implant', N'Cái', 150000000),
    (14, N'Hàm phủ tháo lắp (Răng composite nền nhựa cường lực) - Thanh bar, nút bấm - 4 Implant', N'Cái', 160000000),
    (14, N'Hàm phủ tháo lắp (Răng composite nền nhựa cường lực) - Thanh bar, nút bấm - 5 Implant', N'Cái', 180000000),
    (14, N'Hàm phủ tháo lắp (Răng composite nền nhựa cường lực) - Thanh bar, nút bấm - 6 Implant', N'Cái', 200000000),
    (14, N'Hàm Cố Định Bắt Vít (HYBRID) - 4 Implant - Sườn Titan - Răng Nhựa', N'Cái', 140000000),
    (14, N'Hàm Cố Định Bắt Vít (HYBRID) - 4 Implant - Sườn Titan - Răng Sứ', N'Cái', 300000000),
    (14, N'Hàm Cố Định Bắt Vít (HYBRID) - 4 Implant - Sườn Zirco/Bio - Răng Nhựa', N'Cái', 220000000),
    (14, N'Hàm Cố Định Bắt Vít (HYBRID) - 4 Implant - Sườn Zirco/Bio - Răng Sứ', N'Cái', 380000000),
    (14, N'Hàm Cố Định Bắt Vít (HYBRID) - 5 Implant', N'Cái', 28000000),
    -- Giá thêm cho mỗi loại phục hình
    (14, N'Hàm Cố Định Bắt Vít (HYBRID) - 6 Implant - Sườn Titan - Răng Nhựa', N'Cái', 180000000),
    (14, N'Hàm Cố Định Bắt Vít (HYBRID) - 6 Implant - Sườn Titan - Răng Sứ', N'Cái', 340000000),
    (14, N'Hàm Cố Định Bắt Vít (HYBRID) - 6 Implant - Sườn Zirco/Bio HPP - Răng Nhựa', N'Cái', 260000000),
    (14, N'Hàm Cố Định Bắt Vít (HYBRID) - 6 Implant - Sườn Zirco/Bio HPP - Răng Sứ', N'Cái', 420000000),
    (14, N'Phục hình tạm tức thì toàn hàm - Răng tạm toàn hàm', N'Cái', 40000000),
    (14, N'Phục hình tạm tức thì toàn hàm - Cylinder', N'Cái', 8000000);

/*DELETE FROM services;
DBCC CHECKIDENT ('services', RESEED, 0);*/

-- Thêm dữ liệu vào bảng điều trị
INSERT INTO dieu_tri
    (ten_bac_si_thay_the, ma_bac_si, ma_benh_nhan, ngay_dieu_tri, ghi_chu)
VALUES
    (N'Vũ Văn Giang', 6, 1, '2024-10-01', N'Tái khám sau 3 ngày'),
    (N'Mai Thị Hoa', 7, 2, '2024-10-02', N'Tái khám sau 1 tuần'),
    (N'Trịnh Văn Inh', 8, 3, '2024-10-03', N''),
    (N'Lý Thị Kim', 9, 4, '2024-10-04', N''),
    (N'Ngô Văn Linh', 10, 5, '2024-10-05', N'Uống thuốc theo lộ trình'),
    (N'Phan Thị Mai', 11, 6, '2024-10-06', N''),
    (N'Đặng Văn Nam', 12, 7, '2024-10-07', N''),
    (N'Bùi Thị Oanh', 13, 8, '2024-10-08', N'Tái khám sau 5 ngày'),
    (N'Hồ Văn Phát', 14, 9, '2024-10-09', N''),
    (N'Đỗ Thị Phương', 15, 10, '2024-10-10', N''),
    (N'Vũ Văn Giang', 6, 11, '2024-10-11', N''),
    (N'Mai Thị Hoa', 7, 12, '2024-10-12', N''),
    (N'Trịnh Văn Inh', 8, 13, '2024-10-13', N''),
    (N'Lý Thị Kim', 9, 14, '2024-10-14', N''),
    (N'Ngô Văn Linh', 10, 15, '2024-10-15', N'Kê đơn thuốc mới'),
    (N'Phan Thị Mai', 11, 16, '2024-10-16', N''),
    (N'Đặng Văn Nam', 12, 17, '2024-10-17', N''),
    (N'Bùi Thị Oanh', 13, 18, '2024-10-18', N'Lộ trình điều trị 2 tuần'),
    (N'Hồ Văn Phát', 14, 19, '2024-10-19', N''),
    (N'Đỗ Thị Phương', 15, 20, '2024-10-20', N'');

/*DELETE FROM treatments;
DBCC CHECKIDENT ('treatments', RESEED, 0);*/

-- Thêm dữ liệu vào bảng hóa đơn
INSERT INTO hoa_don
    (ma_hoa_don, phuong_thuc_thanh_toan, tong_gia, ma_don_thuoc, ma_benh_nhan, ngay)
VALUES
    (1, 0, 400000, 1, 1, '2024-09-01'),
    -- Ngày tháng 9
    (2, 0, 480000, 17, 17, '2024-09-02'),
    -- Ngày tháng 9
    (3, 0, 658000, 2, 2, '2024-09-05'),
    -- Ngày tháng 9
    (4, 1, 825000, 3, 3, '2024-09-10'),
    -- Ngày tháng 9
    (5, 0, 410000, 9, 9, '2024-09-15'),
    -- Ngày tháng 9
    (6, 1, 620000, 4, 4, '2024-09-20'),
    -- Ngày tháng 9
    (7, 1, 680000, 5, 5, '2024-09-25'),
    -- Ngày tháng 9
    (8, 1, 240000, 19, 19, '2024-09-30'),
    -- Ngày tháng 9
    (9, 1, 586000, 11, 11, '2024-10-01'),
    -- Ngày tháng 10
    (10, 0, 760000, 16, 16, '2024-10-02'),-- Ngày tháng 10
    (11, 0, 948000, 8, 8, '2024-10-05'),
    -- Ngày tháng 10
    (12, 0, 690000, 12, 12, '2024-10-10'),-- Ngày tháng 10
    (13, 1, 290000, 14, 14, '2024-10-15'),-- Ngày tháng 10
    (14, 0, 380000, 15, 15, '2024-10-20'),-- Ngày tháng 10
    (15, 1, 644000, 13, 13, '2024-10-21'),
    -- Ngày tháng 10
    (16, 1, 760000, 16, 16, '2024-10-22'),
    -- Ngày tháng 10
    (17, 0, 480000, 17, 17, '2024-10-23'),
    -- Ngày tháng 10
    (18, 0, 956000, 18, 18, '2024-10-24'),
    -- Ngày tháng 10
    (19, 1, 240000, 19, 19, '2024-10-24'),
    -- Ngày tháng 10
    (20, 1, 195000, 20, 20, '2024-10-25');
-- Ngày tháng 10

/*DELETE FROM invoices;
DBCC CHECKIDENT ('invoices', RESEED, 0);*/

-- Thêm dữ liệu vào bảng chi tiết hóa đơn
INSERT INTO chi_tiet_hoa_don
    (ma_hoa_don, ma_dich_vu, so_luong, gia_don_vi)
VALUES
    (1, 2, 3, 100000),
    (2, 2, 1, 140000),
    (3, 2, 5, 120000),
    (4, 2, 2, 180000),
    (5, 2, 4, 140000),
    (6, 2, 1, 100000),
    (7, 2, 3, 120000),
    (8, 2, 5, 180000),
    (9, 2, 2, 100000),
    (10, 2, 1, 120000),
    (11, 2, 4, 140000),
    (12, 2, 3, 180000),
    (13, 2, 5, 100000),
    (14, 2, 2, 120000),
    (15, 2, 1, 180000),
    (16, 2, 4, 140000),
    (17, 2, 3, 120000),
    (18, 2, 5, 180000),
    (19, 2, 2, 100000),
    (20, 2, 1, 120000);
GO


--------------------Dành cho đăng nhập, quên mật khẩu, kiểm tra tồn tại--------------------
--Procedure kiểm tra đăng nhập
CREATE PROCEDURE KiemTraDangNhap
    @username VARCHAR(100),
    @password VARCHAR(100),
    @id INT OUTPUT,
    @role VARCHAR(50) OUTPUT
AS
BEGIN
    -- Khai báo biến để lưu trữ thông tin tạm thời
    DECLARE @userCount INT;

    -- Kiểm tra số lượng người dùng khớp với thông tin đăng nhập
    SELECT @userCount = COUNT(*)
    FROM nguoi_dung
    WHERE ten_dang_nhap = @username AND mat_khau = @password AND trang_thai = 1;

    -- Nếu người dùng tồn tại, lấy id và role
    IF @userCount > 0
    BEGIN
        SELECT @id = ma, @role = vai_tro
        FROM nguoi_dung
        WHERE ten_dang_nhap = @username AND mat_khau = @password;
    END
    ELSE
    BEGIN
        SET @id = -1;
        -- Trả về giá trị -1 nếu không tìm thấy người dùng
        SET @role = NULL;
    -- Đặt role về NULL nếu không tìm thấy
    END
END;
GO

--Procedure lấy thông tin user
CREATE PROCEDURE LayThongTinBacSi
    @userId INT
-- Tham số đầu vào là ID của người dùng
AS
BEGIN
    -- Kiểm tra xem ID có hợp lệ không
    IF @userId IS NULL
    BEGIN
        RAISERROR('User ID cannot be NULL', 16, 1);
        RETURN;
    END

    -- Lấy thông tin người dùng từ bảng users
    SELECT *
    FROM nguoi_dung
        left join bac_si on nguoi_dung.ma_nguoi_dung = bac_si.ma_nguoi_dung
        left join bac_si_chuyen_mon on bac_si.ma_chuyen_mon = bac_si_chuyen_mon.ma_chuyen_mon
    WHERE nguoi_dung.ma_nguoi_dung = @userId;
END;
GO

-- Procedure lấy mật khẩu từ email và username
CREATE PROCEDURE LayThongTinEmailVaUserName
    @Email NVARCHAR(50),
    @Username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT mat_khau
    FROM nguoi_dung
    WHERE email = @Email AND ten_dang_nhap = @Username;
END;
GO

-- Procedure kiểm tra email tồn tại
CREATE PROCEDURE KiemTraEmail
    @Email NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1
    FROM nguoi_dung
    WHERE email = @Email)
    BEGIN
        SELECT 1;
    END
    ELSE
    BEGIN
        SELECT 0;
    END
END;
GO

-- Procedure kiểm tra username tồn tại
CREATE PROCEDURE KiemTraUserName
    @username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1
    FROM nguoi_dung
    WHERE ten_dang_nhap = @username)
    BEGIN
        SELECT 1;
    END
    ELSE
    BEGIN
        SELECT 0;
    END
END;

GO

--Kết thúc
--Admin

--Procedure danh sách bác sĩ
CREATE PROCEDURE DanhSachBacSi
AS
BEGIN
    SELECT *
    FROM nguoi_dung
        JOIN bac_si ON nguoi_dung.ma_nguoi_dung = bac_si.ma_nguoi_dung
        JOIN bac_si_chuyen_mon ON bac_si.ma_chuyen_mon = bac_si_chuyen_mon.ma_chuyen_mon
    ORDER BY nguoi_dung.ma_nguoi_dung;
END;
GO

--Procedure danh sách lễ tân
CREATE PROCEDURE DanhSachLeTan
AS
BEGIN
    SELECT *
    FROM nguoi_dung
        JOIN le_tan ON nguoi_dung.ma_nguoi_dung = le_tan.ma_nguoi_dung
    ORDER BY nguoi_dung.ma_nguoi_dung;
END;
GO


--Procedure danh sách bệnh nhân
CREATE PROCEDURE DanhSachBenhNhan
AS
BEGIN
    SELECT *
    FROM benh_nhan;
END;
GO

--Function đếm số lượng dữ liệu
CREATE FUNCTION SoLuongBacSi()
RETURNS INT
AS
BEGIN
    DECLARE @TotalDoctors INT;
    SELECT @TotalDoctors = COUNT(*)
    FROM bac_si join nguoi_dung on nguoi_dung.ma_nguoi_dung = bac_si.ma_nguoi_dung
    where nguoi_dung.trang_thai = 1;
    RETURN @TotalDoctors;
END;
GO


CREATE FUNCTION SoLuongBenhNhan()
RETURNS INT
AS
BEGIN
    DECLARE @TotalPatient INT;
    SELECT @TotalPatient = COUNT(*)
    FROM benh_nhan;
    RETURN @TotalPatient;
END;
GO

CREATE FUNCTION SoLuongLeTan()
RETURNS INT
AS
BEGIN
    DECLARE @SoLuongLeTan INT;
    SELECT @SoLuongLeTan = COUNT(*)
    FROM le_tan;
    RETURN @SoLuongLeTan;
END;
GO

CREATE FUNCTION TongDoanhThu()
RETURNS INT
AS
BEGIN
    DECLARE @Revenue INT;
    DECLARE @StartOfMonth DATE;
    DECLARE @EndOfMonth DATE;

    SET @StartOfMonth = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1);
    SET @EndOfMonth = EOMONTH(GETDATE());

    SELECT @Revenue = SUM(tong_gia)
    FROM hoa_don
    WHERE ngay BETWEEN @StartOfMonth AND @EndOfMonth;

    IF @Revenue IS NULL
		SET @Revenue = 0
    RETURN @Revenue;
END;
GO

CREATE PROCEDURE CapNhatTrangThai
    @userId INT
AS
BEGIN
    UPDATE nguoi_dung
    SET trang_thai = CASE WHEN trang_thai = 1 THEN 0 ELSE 1 END
    WHERE ma_nguoi_dung = @userId;
END;
GO


CREATE PROCEDURE CapNhatThongTinBacSi
    @userId INT,
    @fullName NVARCHAR(255),
    @citizenId NVARCHAR(12),
    @phoneNumber NVARCHAR(10),
    @address NVARCHAR(50),
    @gender BIT,
    @dob DATE,
    @email NVARCHAR(50),
    @salaryCoefficient FLOAT,
    @specializationID INT
AS
BEGIN
    UPDATE nguoi_dung
    SET ho_ten = @fullName,
        cccd = @citizenId,
        so_dien_thoai = @phoneNumber,
        dia_chi = @address,
        gioi_tinh = @gender,
        ngay_sinh = @dob,
        email = @email,
        he_so_luong = @salaryCoefficient
    WHERE ma_nguoi_dung = @userId;

    UPDATE bac_si
    SET 
        ma_chuyen_mon = @specializationID
    WHERE ma_nguoi_dung = @userId;
END;

GO

-- Hàm tự tạo tên đăng nhập
CREATE FUNCTION GenerateDoctorUsername()
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @doctorCount INT;
    DECLARE @username NVARCHAR(50);

    SELECT @doctorCount = COUNT(*)
    FROM bac_si;
    SET @username = 'doctor' + CAST(@doctorCount + 1 AS NVARCHAR(10));

    RETURN @username;
END;
GO

CREATE PROCEDURE ThemBacSi
    @fullName NVARCHAR(255),
    @citizenId NVARCHAR(12),
    @phoneNumber NVARCHAR(10),
    @address NVARCHAR(50),
    @gender BIT,
    @dob DATE,
    @email NVARCHAR(50),
    @salaryCoefficient FLOAT,
    @specializationId INT
AS
BEGIN
    DECLARE @newId INT;
    DECLARE @username NVARCHAR(50);
    DECLARE @password NVARCHAR(50) = 'pass123';

    SELECT @newId = ISNULL(MAX(ma_nguoi_dung), 0) + 1
    FROM nguoi_dung;
    SET @username = dbo.GenerateDoctorUsername();

    INSERT INTO nguoi_dung
        (ma_nguoi_dung, ho_ten, cccd, so_dien_thoai, dia_chi, gioi_tinh, ngay_sinh, vai_tro, ten_dang_nhap, mat_khau, email, he_so_luong, trang_thai)
    VALUES
        (@newId, @fullName, @citizenId, @phoneNumber, @address, @gender, @dob, 'Doctor', @username, @password, @email, @salaryCoefficient, 1);

    INSERT INTO bac_si
        (ma_nguoi_dung, ma_chuyen_mon)
    VALUES
        (@newId, @specializationId);
END;
GO

--Procedure lấy thông tin lễ tân
CREATE PROCEDURE ThongTinLeTan
    @userId INT
-- Tham số đầu vào là ID của người dùng
AS
BEGIN
    -- Kiểm tra xem ID có hợp lệ không
    IF @userId IS NULL
    BEGIN
        RAISERROR(N'Mã người dùng không được để trống', 16, 1);
        RETURN;
    END

    -- Lấy thông tin người dùng từ bảng users
    SELECT *
    FROM nguoi_dung JOIN le_tan
        ON nguoi_dung.ma_nguoi_dung = le_tan.ma_nguoi_dung
    WHERE nguoi_dung.ma_nguoi_dung = @userId;
END;
GO

--Procedure cập nhật thông tin lễ tân
CREATE PROCEDURE CapNhatThongTinLeTan
    @maNguoiDung INT,
    @hoTen NVARCHAR(255),
    @cccd NVARCHAR(12),
    @soDienThoai NVARCHAR(10),
    @diaChi NVARCHAR(50),
    @gioiTinh BIT,
    @ngaySinh DATE,
    @email NVARCHAR(50),
    @heSoLuong FLOAT
AS
BEGIN
    UPDATE nguoi_dung 
    SET 
        ho_ten = @hoTen,
        cccd = @cccd,
        so_dien_thoai = @soDienThoai,
        dia_chi = @diaChi,
        gioi_tinh = @gioiTinh,
        ngay_sinh = @ngaySinh,
        email = @email,	
        he_so_luong = @heSoLuong
    WHERE ma_nguoi_dung = @maNguoiDung;
END;
GO

--Hàm tự tạo tên đăng nhập
CREATE FUNCTION GenerateReceptionistUsername()
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @soLuongLeTan INT;
    DECLARE @tenDangNhap NVARCHAR(50);

    -- Tính toán số lượng lễ tân hiện tại
    SELECT @soLuongLeTan = COUNT(*)
    FROM le_tan;

    -- Tạo tên đăng nhập
    SET @tenDangNhap = 'le_tan' + CAST(@soLuongLeTan + 1 AS NVARCHAR(10));

    RETURN @tenDangNhap;
END;
GO

--Procedure thêm lễ tân
CREATE PROCEDURE ThemLeTan
    @hoTen NVARCHAR(255),
    -- Họ tên
    @cccd NVARCHAR(12),
    -- Số CCCD
    @soDienThoai NVARCHAR(10),
    -- Số điện thoại
    @diaChi NVARCHAR(50),
    -- Địa chỉ
    @gioiTinh BIT,
    -- Giới tính (0 cho nữ, 1 cho nam)
    @ngaySinh DATE,
    -- Ngày sinh
    @email NVARCHAR(50),
    -- Email
    @heSoLuong FLOAT
-- Hệ số lương
AS
BEGIN
    DECLARE @maNguoiDungMoi INT;
    DECLARE @tenDangNhap NVARCHAR(50);
    DECLARE @matKhau NVARCHAR(50) = 'pass123';

    SELECT @maNguoiDungMoi = ISNULL(MAX(ma_nguoi_dung), 0) + 1
    FROM nguoi_dung;
    SET @tenDangNhap = dbo.GenerateReceptionistUsername();

    INSERT INTO nguoi_dung
        (ma_nguoi_dung, ho_ten, cccd, so_dien_thoai, dia_chi, gioi_tinh, ngay_sinh, vai_tro, ten_dang_nhap, mat_khau, email, he_so_luong, trang_thai)
    VALUES
        (@maNguoiDungMoi, @hoTen, @cccd, @soDienThoai, @diaChi, @gioiTinh, @ngaySinh, N'Lễ Tân', @tenDangNhap, @matKhau, @email, @heSoLuong, 1);

    INSERT INTO le_tan
        (ma_nguoi_dung)
    VALUES
        (@maNguoiDungMoi);
END;
GO

--Procedure lấy thông tin bệnh nhân
CREATE PROCEDURE ThongTinBenhNhan
    @maBenhNhan INT
-- Tham số đầu vào là ID của bệnh nhân
AS
BEGIN
    -- Kiểm tra xem ID có hợp lệ không
    IF @maBenhNhan IS NULL
    BEGIN
        RAISERROR(N'Mã bệnh nhân không được để trống', 16, 1);
        RETURN;
    END

    -- Lấy thông tin người dùng từ bảng benh_nhan
    SELECT *
    FROM benh_nhan
    WHERE benh_nhan.ma_benh_nhan = @maBenhNhan;
END;
GO

--Procedure cập nhật thông tin bệnh nhân
CREATE PROCEDURE CapNhatBenhNhan
    @maBenhNhan INT,
    @hoTen NVARCHAR(255),
    @soDienThoai NVARCHAR(10),
    @diaChi NVARCHAR(50),
    @gioiTinh BIT,
    @tuoi INT
AS
BEGIN
    UPDATE benh_nhan 
    SET 
        ho_ten = @hoTen,
        so_dien_thoai = @soDienThoai,
        dia_chi = @diaChi,
        gioi_tinh = @gioiTinh,
        tuoi = @tuoi
    WHERE ma_benh_nhan = @maBenhNhan;
END;
GO

--Procedure thêm lễ tân
CREATE PROCEDURE ThemBenhNhan
    @hoTen NVARCHAR(255),
    -- Họ tên
    @soDienThoai NVARCHAR(10),
    -- Số điện thoại
    @diaChi NVARCHAR(50),
    -- Địa chỉ
    @gioiTinh BIT,
    -- Giới tính (0 cho nữ, 1 cho nam)
    @tuoi INT
-- Tuổi
AS
BEGIN
    DECLARE @maBenhNhanMoi INT;

    SELECT @maBenhNhanMoi = ISNULL(MAX(ma_benh_nhan), 0) + 1
    FROM benh_nhan;

    INSERT INTO benh_nhan
        (ma_benh_nhan, ho_ten, gioi_tinh, tuoi, so_dien_thoai, dia_chi)
    VALUES
        (@maBenhNhanMoi, @hoTen, @gioiTinh, @tuoi, @soDienThoai, @diaChi);
END;
GO

CREATE PROCEDURE DanhSachLichLamViecBacSi
    @StartOfMonth DATE,
    @EndOfMonth DATE
AS
BEGIN
    SELECT nguoi_dung.ma_nguoi_dung, nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, bac_si_chuyen_mon.ten_chuyen_mon, count(*) as so_ca
    from nguoi_dung
        left join lich_lam_viec on lich_lam_viec.ma_nguoi_dung = nguoi_dung.ma_nguoi_dung
        join bac_si on nguoi_dung.ma_nguoi_dung = bac_si.ma_nguoi_dung
        join bac_si_chuyen_mon on bac_si.ma_chuyen_mon = bac_si_chuyen_mon.ma_chuyen_mon
    WHERE lich_lam_viec.ngay BETWEEN @StartOfMonth AND @EndOfMonth
    GROUP BY nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, bac_si_chuyen_mon.ten_chuyen_mon, nguoi_dung.ma_nguoi_dung
    order by nguoi_dung.ma_nguoi_dung
END;

GO


CREATE PROCEDURE DanhSachLichLamViecBacSiKhongNgayLam
AS
BEGIN
    SELECT nguoi_dung.ma_nguoi_dung, nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, bac_si_chuyen_mon.ten_chuyen_mon, count(*) as so_ca
    from nguoi_dung
        join bac_si on nguoi_dung.ma_nguoi_dung = bac_si.ma_nguoi_dung
        join bac_si_chuyen_mon on bac_si.ma_chuyen_mon = bac_si_chuyen_mon.ma_chuyen_mon
    GROUP BY nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, bac_si_chuyen_mon.ten_chuyen_mon, nguoi_dung.ma_nguoi_dung
    order by nguoi_dung.ma_nguoi_dung
END;

GO

CREATE PROCEDURE LichLamViec
    @ID INT,
    @StartOfMonth DATE,
    @EndOfMonth DATE
AS
BEGIN
    SELECT
        nguoi_dung.ma_nguoi_dung,
        nguoi_dung.ho_ten,
        lich_lam_viec.ca,
        lich_lam_viec.ngay,
        CASE 
			WHEN cham_cong.ghi_chu = N'Làm việc đúng giờ' THEN 1 
			WHEN cham_cong.ghi_chu IS NULL THEN 2
			ELSE 0 
		END AS LamViecDungGio
    FROM
        nguoi_dung
        Left JOIN
        lich_lam_viec ON nguoi_dung.ma_nguoi_dung = lich_lam_viec.ma_nguoi_dung
        LEFT JOIN
        cham_cong ON nguoi_dung.ma_nguoi_dung = cham_cong.ma_nguoi_dung
            AND cham_cong.ngay = lich_lam_viec.ngay
    WHERE 
		lich_lam_viec.ngay BETWEEN @StartOfMonth AND @EndOfMonth
        AND nguoi_dung.ma_nguoi_dung = @ID
END;

GO

CREATE PROCEDURE ChiTietCaLam
    @ID INT,
    @day DATE
AS
BEGIN
    SELECT
        nguoi_dung.ma_nguoi_dung,
        nguoi_dung.ho_ten,
        nguoi_dung.gioi_tinh,
        nguoi_dung.email,
        nguoi_dung.so_dien_thoai,
        nguoi_dung.dia_chi,
        cham_cong.ghi_chu,
        cham_cong.gio_vao,
        cham_cong.gio_ra,
        cham_cong.ngay,
        lich_lam_viec.ca
    FROM
        nguoi_dung
        JOIN
        bac_si ON nguoi_dung.ma_nguoi_dung = bac_si.ma_nguoi_dung
        JOIN
        lich_lam_viec on nguoi_dung.ma_nguoi_dung = lich_lam_viec.ma_nguoi_dung
        JOIN
        cham_cong ON nguoi_dung.ma_nguoi_dung = cham_cong.ma_nguoi_dung
    WHERE 
		lich_lam_viec.ngay = @day
        AND cham_cong.ngay = @day
        AND nguoi_dung.ma_nguoi_dung = @ID
END;

GO


CREATE PROCEDURE LayThongTinBenhNhanCuaBacSi
    @MaBacSi INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        bn.ma_benh_nhan,
        bn.ho_ten,
        bn.dia_chi,
        bn.gioi_tinh,
        bn.tuoi
    FROM
        nguoi_dung AS nd
        JOIN
        dieu_tri AS dt ON nd.ma = dt.ma_bac_si
        JOIN
        benh_nhan AS bn ON dt.ma_benh_nhan = bn.ma_benh_nhan
    WHERE 
        nd.ma = @MaBacSi
END;
GO

CREATE PROCEDURE ThongTinLamViecChuaChamCong
    @userId INT,
    @ngay Date
AS
BEGIN
    SELECT
        nguoi_dung.ma_nguoi_dung,
        nguoi_dung.ho_ten,
        nguoi_dung.gioi_tinh,
        nguoi_dung.email,
        nguoi_dung.so_dien_thoai,
        nguoi_dung.dia_chi,
        lich_lam_viec.ca
    FROM nguoi_dung join lich_lam_viec on nguoi_dung.ma_nguoi_dung = lich_lam_viec.ma_nguoi_dung
    WHERE nguoi_dung.ma_nguoi_dung = @userId;
END;
GO

CREATE PROCEDURE ThemLichLamViec
    @ID INT,
    @ca INT,
    @day DATE
AS
BEGIN
    IF EXISTS (SELECT 1
    FROM lich_lam_viec
    WHERE ma_nguoi_dung = @ID AND ngay = @day)
    BEGIN
        UPDATE lich_lam_viec
        SET ngay = @day, ca = @ca
        WHERE ma_nguoi_dung = @ID AND ca = @ca AND ngay = @day;
    END
    ELSE
    BEGIN
        INSERT INTO lich_lam_viec
            (ngay, ca, ma_nguoi_dung)
        VALUES
            (@day, @ca, @ID);
    END
END;

GO

CREATE PROCEDURE XoaLichLamViec
    @ID INT,
    @day DATE
AS
BEGIN
    DELETE FROM lich_lam_viec
	WHERE ma_nguoi_dung = @ID and ngay = @day
END;

GO

CREATE PROCEDURE ThemBenhNhan_BacSi
    @hoTen NVARCHAR(255),
    -- Họ tên
    @soDienThoai NVARCHAR(10),
    -- Số điện thoại
    @diaChi NVARCHAR(50),
    -- Địa chỉ
    @gioiTinh BIT,
    -- Giới tính (0 cho nữ, 1 cho nam)
    @tuoi INT,
    -- Tuổi
    @maBacSi INT,
    -- Mã của bác sĩ điều trị
    @ngayDieuTri DATE,
    -- Ngày điều trị
    @TenBacSiThayThe NVARCHAR(50) = NULL
-- Tên bác sĩ thay thế (nếu có)
AS
BEGIN
    DECLARE @maBenhNhanMoi INT;

    -- Kiểm tra xem mã bác sĩ có tồn tại trong bảng bac_si hay không
    IF NOT EXISTS (SELECT 1
    FROM bac_si
    WHERE ma_nguoi_dung = @maBacSi)
    BEGIN
        PRINT 'Lỗi: Mã bác sĩ không tồn tại trong bảng bac_si.';
        RETURN;
    END

    -- Tạo mã bệnh nhân mới
    SELECT @maBenhNhanMoi = ISNULL(MAX(ma_benh_nhan), 0) + 1
    FROM benh_nhan;

    -- Thêm bệnh nhân mới vào bảng benh_nhan
    INSERT INTO benh_nhan
        (ma_benh_nhan, ho_ten, gioi_tinh, tuoi, so_dien_thoai, dia_chi)
    VALUES
        (@maBenhNhanMoi, @hoTen, @gioiTinh, @tuoi, @soDienThoai, @diaChi);

    -- Thêm thông tin điều trị vào bảng dieu_tri
    INSERT INTO dieu_tri
        (ma_bac_si, ma_benh_nhan, ngay_dieu_tri, ghi_chu, ten_bac_si_thay_the)
    VALUES
        (@maBacSi, @maBenhNhanMoi, @ngayDieuTri, N'Điều trị ban đầu',
            ISNULL(@TenBacSiThayThe, N'Không có'));

    -- Xác nhận thành công
    PRINT 'Thêm bệnh nhân và thông tin điều trị thành công.';
END;
GO
-- Lấy danh sách lịch hẹn trong ngày
CREATE PROCEDURE LayDanhSachLichHenTrongNgay
    @NgayHen DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        lh.ma_lich_hen AS maLichHen,
        bn.ma_benh_nhan AS maBenhNhan,
        bn.ho_ten AS tenBenhNhan,
        bn.so_dien_thoai AS soDienThoai,
        bn.dia_chi AS DiaChi,
        CASE bn.gioi_tinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS gioiTinh,
        bn.tuoi AS tuoi,
        bs.ma AS maBacSi,
        bs.ho_ten AS tenBacSi,
        lh.trang_thai AS trangThai,
        lh.ghi_chu AS ghiChu
    FROM
        lich_hen AS lh
        JOIN
        benh_nhan AS bn ON lh.ma_benh_nhan = bn.ma_benh_nhan
        JOIN
        nguoi_dung AS bs ON lh.ma_nguoi_dung = bs.ma
    -- `ma_nguoi_dung` được giả định là mã bác sĩ
    WHERE 
        lh.ngay_hen = @NgayHen
    ORDER BY 
        lh.ngay_hen ASC;
END;
GO


CREATE PROCEDURE DanhSachLichLamViecLeTan
    @StartOfMonth DATE,
    @EndOfMonth DATE
AS
BEGIN
    SELECT nguoi_dung.ma_nguoi_dung, nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, count(*) as so_ca
    from nguoi_dung
        left join lich_lam_viec on lich_lam_viec.ma_nguoi_dung = nguoi_dung.ma_nguoi_dung
        join le_tan on nguoi_dung.ma_nguoi_dung = le_tan.ma_nguoi_dung
    WHERE lich_lam_viec.ngay BETWEEN @StartOfMonth AND @EndOfMonth
    GROUP BY nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, nguoi_dung.ma_nguoi_dung
    order by nguoi_dung.ma_nguoi_dung
END;

GO

CREATE PROCEDURE DanhSachLichLamViecLeTanKhongNgayLam
AS
BEGIN
    SELECT nguoi_dung.ma_nguoi_dung, nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, count(*) as so_ca
    from nguoi_dung
        join le_tan on nguoi_dung.ma_nguoi_dung = le_tan.ma_nguoi_dung
    GROUP BY nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, nguoi_dung.ma_nguoi_dung
    order by nguoi_dung.ma_nguoi_dung
END;

GO
--Quản lý vật tư
CREATE PROCEDURE ThongTinThuoc
    @id INT
AS
BEGIN
    select *
    from hang_ton_kho
        join loai_hang_ton_kho on hang_ton_kho.ma_loai = loai_hang_ton_kho.ma_loai
    where hang_ton_kho.ma_loai = @id
    order by hang_ton_kho.ngay_het_han
END;

GO

--Thông tin vật tư
CREATE PROCEDURE ThongTinVatTu
    @id INT
AS
BEGIN
    select *
    from hang_ton_kho
        join loai_hang_ton_kho on hang_ton_kho.ma_loai = loai_hang_ton_kho.ma_loai
    where hang_ton_kho.ma_loai != @id
    order by hang_ton_kho.ngay_het_han
END;
GO

CREATE PROCEDURE ThongTinDichVu
AS
BEGIN
    select *
    from dich_vu
        join loai_dich_vu on dich_vu.ma_loai = loai_dich_vu.ma_loai_dich_vu
END;
GO

CREATE PROCEDURE ThongTinChiTietThuoc
    @id INT
AS
BEGIN
    SELECT *
    FROM hang_ton_kho
    where hang_ton_kho.ma_loai = 1
        AND hang_ton_kho.ma_kho = @id
END;
GO

CREATE PROCEDURE CapNhatThongTinThuoc
    @id INT,
    @donViTinh nvarchar(255),
    @gia float
AS
BEGIN
    UPDATE hang_ton_kho 
	SET don_vi = @donViTinh,
	gia = @gia
	where ma_kho = @id
END;
GO

CREATE PROCEDURE ThongTinChiTietVatTu
    @id INT
AS
BEGIN
    SELECT *
    FROM hang_ton_kho
    where ma_kho = @id
        and ma_loai != 1

END;
GO

CREATE PROCEDURE CapNhatThongTinVatTu
    @id INT,
    @donViTinh nvarchar(255),
    @gia float
AS
BEGIN
    UPDATE hang_ton_kho 
	SET don_vi = @donViTinh,
	gia = @gia
	where ma_kho = @id
END;
GO

CREATE PROCEDURE ThongTinChiTietDichVu
    @id INT
AS
BEGIN
    SELECT *
    FROM dich_vu
        join loai_dich_vu on dich_vu.ma_loai = loai_dich_vu.ma_loai_dich_vu
    where dich_vu.ma_loai = @id
END;
GO

CREATE PROCEDURE CapNhatThongTinDichVu
    @id INT,
    @donViTinh nvarchar(255),
    @gia float
AS
BEGIN
    UPDATE dich_vu 
	SET don_vi = @donViTinh,
	gia = @gia
	where ma_dich_vu = @id
END;

GO

CREATE PROCEDURE ThemDichVu
    @ten nvarchar(255),
    @donVi nvarchar(255),
    @gia float,
    @maLoai int
AS
BEGIN
    INSERT INTO dich_vu
    VALUES
        (@maLoai, @ten, @donVi, @gia)
END;

GO

CREATE FUNCTION DemSoLuongHangTonKho()
RETURNS INT
AS
BEGIN
    DECLARE @TongSoLuong INT;
    SELECT @TongSoLuong = Count(*)
    FROM hang_ton_kho

    RETURN @TongSoLuong;
END;
GO

CREATE PROCEDURE ThemVatTu
    @ten nvarchar(255),
    @loai nvarchar(255),
    @soLuong int,
    @donVi nvarchar(255),
    @lieuLuong nvarchar(255),
    @ngaySanXuat date,
    @ngayHetHan date,
    @ngayNhap date,
    @gia float,
    @maLoai int
AS
BEGIN
    DECLARE @TongSoLuong INT;
    SET @TongSoLuong = dbo.DemSoLuongHangTonKho() + 1;
    INSERT INTO hang_ton_kho
    VALUES
        (@TongSoLuong, @ten, @loai, @soLuong, @donVi, @lieuLuong, @ngaySanXuat, @ngayHetHan, @ngayNhap, @gia, @maLoai);
END;

GO

CREATE PROCEDURE ThemThuoc
    @ten nvarchar(255),
    @loai nvarchar(255),
    @soLuong int,
    @donVi nvarchar(255),
    @lieuLuong nvarchar(255),
    @ngaySanXuat date,
    @ngayHetHan date,
    @ngayNhap date,
    @gia float,
    @maLoai int
AS
BEGIN
    DECLARE @TongSoLuong INT;
    SET @TongSoLuong = dbo.DemSoLuongHangTonKho() + 1;
    INSERT INTO hang_ton_kho
    VALUES
        (@TongSoLuong, @ten, @loai, @soLuong, @donVi, @lieuLuong, @ngaySanXuat, @ngayHetHan, @ngayNhap, @gia, @maLoai);
END;

GO

CREATE PROC XoaHangTonKho
    @id int
AS
BEGIN
    DELETE FROM hang_ton_kho
	where ma_kho = @id
END;
GO

CREATE PROC XoaDichVu
    @id int
AS
BEGIN
    DELETE FROM dich_vu
	where ma_loai = @id
END;
GO


CREATE PROCEDURE LayThongTinBacSiTrongNgay
    @ngay DATE
AS
BEGIN
    SELECT 
        llv.ma_nguoi_dung AS ma_bac_si,
        nd.ho_ten AS ten_bac_si,
        bscm.ten_chuyen_mon,
        llv.ca,
        COUNT(lh.ma_benh_nhan) AS so_luong_benh_nhan,
        CASE 
            WHEN COUNT(lh.ma_benh_nhan) > 3 THEN N'Vượt quá giới hạn'
            ELSE N'Đủ điều kiện'
        END AS trang_thai_lam_viec
    FROM 
        lich_lam_viec AS llv
        LEFT JOIN lich_hen AS lh ON llv.ma_nguoi_dung = lh.ma_nguoi_dung 
            AND llv.ngay = lh.ngay_hen
        JOIN nguoi_dung AS nd ON llv.ma_nguoi_dung = nd.ma_nguoi_dung
        JOIN bac_si AS bs ON llv.ma_nguoi_dung = bs.ma_nguoi_dung
        JOIN bac_si_chuyen_mon AS bscm ON bs.ma_chuyen_mon = bscm.ma_chuyen_mon
    WHERE 
        llv.ngay = @ngay
    GROUP BY 
        llv.ma_nguoi_dung, nd.ho_ten, bscm.ten_chuyen_mon, llv.ca
    ORDER BY 
        llv.ca, nd.ho_ten;
END;
GO
CREATE PROCEDURE DanhSachBenhNhanTheoNgay
    @ngay DATE
AS
BEGIN
    SELECT 
        lh.ma_lich_hen,
        bn.ma_benh_nhan,
        bn.ho_ten AS ten_benh_nhan,
        bn.so_dien_thoai,
        lh.ma_nguoi_dung AS ma_bac_si,
        nd.ho_ten AS ten_bac_si,
        llv.ca,
        lh.ngay_hen,
        lh.ghi_chu,
        CASE 
            WHEN lh.trang_thai = 0 THEN N'Chưa khám'
            WHEN lh.trang_thai = 1 THEN N'Đã khám'
        END AS trang_thai
    FROM 
        lich_hen AS lh
        JOIN benh_nhan AS bn ON lh.ma_benh_nhan = bn.ma_benh_nhan
        JOIN nguoi_dung AS nd ON lh.ma_nguoi_dung = nd.ma_nguoi_dung
        JOIN lich_lam_viec AS llv ON lh.ma_nguoi_dung = llv.ma_nguoi_dung 
            AND lh.ngay_hen = llv.ngay
            AND llv.ngay = @ngay
    WHERE 
        lh.ngay_hen = @ngay
    ORDER BY 
        lh.ma_lich_hen
END;
GO
CREATE PROCEDURE TaoLichHenBenhNhan
    @ho_ten NVARCHAR(50),
    @gioi_tinh BIT,
    @tuoi INT,
    @so_dien_thoai NVARCHAR(10),
    @dia_chi NVARCHAR(50),
    @ma_bac_si INT,
    @ngay_hen DATE,               -- Ngày hẹn
    @ca INT,                      -- Ca làm việc
    @ghi_chu NVARCHAR(255)
AS
BEGIN
    DECLARE @ma_benh_nhan INT;
    -- 1. Tạo mã bệnh nhân mới bằng cách lấy giá trị lớn nhất của ma_benh_nhan và tăng lên 1
    SELECT @ma_benh_nhan = ISNULL(MAX(ma_benh_nhan), 0) + 1
    FROM benh_nhan;   
    -- 2. Thêm bệnh nhân mới vào bảng benh_nhan với mã bệnh nhân mới
    INSERT INTO benh_nhan (ma_benh_nhan, ho_ten, gioi_tinh, tuoi, so_dien_thoai, dia_chi)
    VALUES (@ma_benh_nhan, @ho_ten, @gioi_tinh, @tuoi, @so_dien_thoai, @dia_chi);
    -- 3. Thêm lịch hẹn vào bảng lich_hen với mã bệnh nhân, mã bác sĩ, ngày hẹn, ca và ghi chú
    INSERT INTO lich_hen (ma_benh_nhan, ma_nguoi_dung, ngay_hen, ca, ghi_chu, trang_thai)
    VALUES (@ma_benh_nhan, @ma_bac_si, @ngay_hen, @ca, @ghi_chu, 0); -- 0: Chưa khám
    PRINT N'Lịch hẹn đã được thêm thành công!';
END;
GO
CREATE PROCEDURE LayThongTinBenhNhanVaBenhAn
    @ma_benh_nhan INT
AS
BEGIN
    SELECT 
        bn.ma_benh_nhan,
        bn.ho_ten,
        bn.gioi_tinh,
        bn.tuoi,
        bn.so_dien_thoai,
        bn.dia_chi,
        hsba.ma_ho_so,
        hsba.chan_doan,
        hsba.phuong_phap_dieu_tri,
        hsba.trieu_chung
    FROM 
        benh_nhan AS bn
    LEFT JOIN 
        ho_so_benh_an AS hsba ON bn.ma_benh_nhan = hsba.ma_benh_nhan
    WHERE 
        bn.ma_benh_nhan = @ma_benh_nhan;
END;
GO
EXEC LayThongTinBenhNhanVaBenhAn @ma_benh_nhan = 1;
GO
CREATE PROCEDURE CapNhatThongTinBenhNhanVaBenhAn
    @ma_benh_nhan INT,
    @ho_ten NVARCHAR(50) = NULL,
    @gioi_tinh BIT = NULL,
    @tuoi INT = NULL,
    @so_dien_thoai NVARCHAR(10) = NULL,
    @dia_chi NVARCHAR(50) = NULL,
    @ma_ho_so INT = NULL,
    @chan_doan NVARCHAR(50) = NULL,
    @phuong_phap_dieu_tri NVARCHAR(50) = NULL,
    @trieu_chung NVARCHAR(50) = NULL
AS
BEGIN
    -- Bắt đầu một giao dịch để đảm bảo tính toàn vẹn dữ liệu
    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Cập nhật thông tin trong bảng benh_nhan
        UPDATE benh_nhan
        SET 
            ho_ten = COALESCE(@ho_ten, ho_ten),
            gioi_tinh = COALESCE(@gioi_tinh, gioi_tinh),
            tuoi = COALESCE(@tuoi, tuoi),
            so_dien_thoai = COALESCE(@so_dien_thoai, so_dien_thoai),
            dia_chi = COALESCE(@dia_chi, dia_chi)
        WHERE 
            ma_benh_nhan = @ma_benh_nhan;
        -- 2. Cập nhật thông tin trong bảng ho_so_benh_an nếu ma_ho_so được cung cấp
        IF @ma_ho_so IS NOT NULL
        BEGIN
            UPDATE ho_so_benh_an
            SET 
                chan_doan = COALESCE(@chan_doan, chan_doan),
                phuong_phap_dieu_tri = COALESCE(@phuong_phap_dieu_tri, phuong_phap_dieu_tri),
                trieu_chung = COALESCE(@trieu_chung, trieu_chung)
            WHERE 
                ma_ho_so = @ma_ho_so
                AND ma_benh_nhan = @ma_benh_nhan;
        END
        -- Xác nhận giao dịch nếu không có lỗi xảy ra
        COMMIT TRANSACTION;
        
        PRINT N'Cập nhật thông tin bệnh nhân và bệnh án thành công!';
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi, hủy bỏ giao dịch
        ROLLBACK TRANSACTION;
        
        PRINT N'Có lỗi xảy ra. Giao dịch đã được hủy bỏ.';
        THROW; -- Ném lỗi để xem chi tiết
    END CATCH
END;
GO


CREATE PROCEDURE DanhSachLichLamViecBacSiDeTinhLuong
    @StartOfMonth DATE,
    @EndOfMonth DATE
AS
BEGIN
    SELECT nguoi_dung.ma_nguoi_dung, nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, bac_si_chuyen_mon.ten_chuyen_mon, nguoi_dung.he_so_luong,
	luong.luong_co_ban, luong.thuong, luong.phat, luong.phu_cap, count(*) as so_ca
    from nguoi_dung
        join lich_lam_viec on lich_lam_viec.ma_nguoi_dung = nguoi_dung.ma_nguoi_dung
        join bac_si on nguoi_dung.ma_nguoi_dung = bac_si.ma_nguoi_dung
        join bac_si_chuyen_mon on bac_si.ma_chuyen_mon = bac_si_chuyen_mon.ma_chuyen_mon
		join cham_cong on cham_cong.ma_nguoi_dung = bac_si.ma_nguoi_dung
		join luong on nguoi_dung.ma_nguoi_dung = luong.ma_nguoi_dung
    WHERE (lich_lam_viec.ngay BETWEEN @StartOfMonth AND @EndOfMonth) AND cham_cong.ghi_chu = N'Làm việc đúng giờ' AND lich_lam_viec.ngay = cham_cong.ngay
	AND (luong.ngay BETWEEN @StartOfMonth AND @EndOfMonth) AND nguoi_dung.trang_thai = 1
    GROUP BY nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, bac_si_chuyen_mon.ten_chuyen_mon, nguoi_dung.ma_nguoi_dung,
	luong.luong_co_ban, luong.thuong, luong.phat, luong.phu_cap, nguoi_dung.he_so_luong
    order by nguoi_dung.ma_nguoi_dung
END;
GO

CREATE PROCEDURE DanhSachLichLamViecLeTanDeTinhLuong
    @StartOfMonth DATE,
    @EndOfMonth DATE
AS
BEGIN
    SELECT nguoi_dung.ma_nguoi_dung, nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, nguoi_dung.he_so_luong,
	luong.luong_co_ban, luong.thuong, luong.phat, luong.phu_cap, count(*) as so_ca
    from nguoi_dung
        join lich_lam_viec on lich_lam_viec.ma_nguoi_dung = nguoi_dung.ma_nguoi_dung
        join le_tan on nguoi_dung.ma_nguoi_dung = le_tan.ma_nguoi_dung
		join cham_cong on cham_cong.ma_nguoi_dung = nguoi_dung.ma_nguoi_dung
		join luong on nguoi_dung.ma_nguoi_dung = luong.ma_nguoi_dung
    WHERE (lich_lam_viec.ngay BETWEEN @StartOfMonth AND @EndOfMonth) AND cham_cong.ghi_chu = N'Làm việc đúng giờ' AND lich_lam_viec.ngay = cham_cong.ngay
	AND (luong.ngay BETWEEN @StartOfMonth AND @EndOfMonth) AND nguoi_dung.trang_thai = 1
    GROUP BY nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, nguoi_dung.ma_nguoi_dung,
	luong.luong_co_ban, luong.thuong, luong.phat, luong.phu_cap, nguoi_dung.he_so_luong
    order by nguoi_dung.ma_nguoi_dung
END;
GO

CREATE PROCEDURE LichLamViecChiTietBacSi
	@Id int,
    @StartOfMonth DATE,
    @EndOfMonth DATE
AS
BEGIN
    SELECT nguoi_dung.ma_nguoi_dung, nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, bac_si_chuyen_mon.ten_chuyen_mon, nguoi_dung.he_so_luong,
	luong.luong_co_ban, luong.thuong, luong.phat, luong.phu_cap, count(*) as so_ca
    from nguoi_dung
        join lich_lam_viec on lich_lam_viec.ma_nguoi_dung = nguoi_dung.ma_nguoi_dung
        join bac_si on nguoi_dung.ma_nguoi_dung = bac_si.ma_nguoi_dung
        join bac_si_chuyen_mon on bac_si.ma_chuyen_mon = bac_si_chuyen_mon.ma_chuyen_mon
		join cham_cong on cham_cong.ma_nguoi_dung = bac_si.ma_nguoi_dung
		join luong on nguoi_dung.ma_nguoi_dung = luong.ma_nguoi_dung
    WHERE (lich_lam_viec.ngay BETWEEN @StartOfMonth AND @EndOfMonth) AND cham_cong.ghi_chu = N'Làm việc đúng giờ' AND lich_lam_viec.ngay = cham_cong.ngay
	AND (luong.ngay BETWEEN @StartOfMonth AND @EndOfMonth) AND nguoi_dung.trang_thai = 1
	AND nguoi_dung.ma = @id
    GROUP BY nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, bac_si_chuyen_mon.ten_chuyen_mon, nguoi_dung.ma_nguoi_dung,
	luong.luong_co_ban, luong.thuong, luong.phat, luong.phu_cap, nguoi_dung.he_so_luong
    order by nguoi_dung.ma_nguoi_dung
END;
GO

CREATE PROCEDURE CapNhatLuong
	@Id INT,
	@heSoLuong float,
	@luongCoBan float,
	@thuong float,
	@phat float,
	@phuCap float
AS 
BEGIN 
	UPDATE nguoi_dung
	SET he_so_luong = @heSoLuong
	where ma = @id

	UPDATE luong
	SET luong_co_ban = @luongCoBan, thuong = @thuong, phat = @phat, phu_cap = @phuCap
	where ma_nguoi_dung = @id
END;
GO

CREATE PROCEDURE LichLamViecChiTietLeTan
	@Id int,
    @StartOfMonth DATE,
    @EndOfMonth DATE
AS
BEGIN
    SELECT nguoi_dung.ma_nguoi_dung, nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, nguoi_dung.he_so_luong,
	luong.luong_co_ban, luong.thuong, luong.phat, luong.phu_cap, count(*) as so_ca
    from nguoi_dung
        join lich_lam_viec on lich_lam_viec.ma_nguoi_dung = nguoi_dung.ma_nguoi_dung
        join le_tan on nguoi_dung.ma_nguoi_dung = le_tan.ma_nguoi_dung
		join cham_cong on cham_cong.ma_nguoi_dung = nguoi_dung.ma_nguoi_dung
		join luong on nguoi_dung.ma_nguoi_dung = luong.ma_nguoi_dung
    WHERE (lich_lam_viec.ngay BETWEEN @StartOfMonth AND @EndOfMonth) AND cham_cong.ghi_chu = N'Làm việc đúng giờ' AND lich_lam_viec.ngay = cham_cong.ngay
	AND (luong.ngay BETWEEN @StartOfMonth AND @EndOfMonth) AND nguoi_dung.trang_thai = 1
	AND nguoi_dung.ma = @id
    GROUP BY nguoi_dung.ho_ten, nguoi_dung.gioi_tinh, nguoi_dung.email, nguoi_dung.ma_nguoi_dung,
	luong.luong_co_ban, luong.thuong, luong.phat, luong.phu_cap, nguoi_dung.he_so_luong
    order by nguoi_dung.ma_nguoi_dung
END;
GO


exec DanhSachLichLamViecLeTanDeTinhLuong '2024-10-1', '2024-10-29'