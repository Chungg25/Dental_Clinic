﻿use master

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
CREATE TABLE [users]
(
    [id] INT NOT NULL IDENTITY(1, 1),
    [user_id] INT NOT NULL,
    [full_name] NVARCHAR(255) NOT NULL,
    [citizen_id] VARCHAR(12) NOT NULL,
    [phone_number] VARCHAR(10) NOT NULL,
    [address] NVARCHAR(50) NOT NULL,
    [gender] BIT NOT NULL,
    [dob] DATE NOT NULL,
    [role] NVARCHAR(10) NOT NULL,
    [username] NVARCHAR(50) NOT NULL,
    [PASSWORD] NVARCHAR(255) NOT NULL,
    [email] NVARCHAR(50) NOT NULL,
    [salary_coefficient] FLOAT NOT NULL,
    [status] INT NOT NULL,
    PRIMARY KEY ([user_id])
)
GO
-- 2. Bảng lễ tân
CREATE TABLE [receptionists]
(
    [user_id] INT NOT NULL,
    PRIMARY KEY ([user_id])
)
GO
-- 3. Bảng quản trị viên
CREATE TABLE [administrators]
(
    [user_id] INT NOT NULL,
    PRIMARY KEY ([user_id])
)
GO
-- 4. Bảng bác sĩ chuyên môn
CREATE TABLE [doctor_specializations]
(
    [specialization_id] INT PRIMARY KEY IDENTITY(1, 1),
    [specialization_name] NVARCHAR(100) UNIQUE NOT NULL
)
GO
-- 5. Bảng bác sĩ
CREATE TABLE [doctors]
(
    [user_id] INT NOT NULL,
    [specialization_id] INT,
    PRIMARY KEY ([user_id])
)
GO
-- 6. Bảng lịch làm việc
CREATE TABLE [work_schedules]
(
    [id] INT NOT NULL IDENTITY(1, 1),
    [DAY] DATE NOT NULL,
    [shift] INT NOT NULL,
    [user_id] INT not null,
    PRIMARY KEY ([id])
)
GO
-- 7. Bảng lương
CREATE TABLE [salaries]
(
    [salary_id] INT,
    [user_id] INT NOT NULL,
    [basic_salary] FLOAT NOT NULL,
    [bonus] FLOAT NOT NULL,
    [fine] FLOAT NOT NULL,
    [allowance] FLOAT NOT NULL,
    [day] DATE,
    PRIMARY KEY ([salary_id])
)
GO
-- 8. Bảng bệnh nhân
CREATE TABLE [patients]
(
    [id] INT,
    [full_name] NVARCHAR(50) NOT NULL,
    [gender] BIT NOT NULL,
    [age] INT NOT NULL,
    [phone_number] NVARCHAR(10) NOT NULL,
    [address] NVARCHAR(50) NOT NULL,
    PRIMARY KEY ([id])
)
GO
-- 9. Bảng tiếp nhận bệnh nhân
CREATE TABLE [receptions]
(
    [user_id] INT NOT NULL,
    [patient_id] INT NOT NULL,
    PRIMARY KEY ([user_id], [patient_id])
)
GO
-- 10. Bảng lịch hẹn
CREATE TABLE [appointments]
(
    [id] INT NOT NULL IDENTITY(1, 1),
    [notes] NVARCHAR(50) NOT NULL,
    [STATUS] BIT NOT NULL,
    [appointment_date] DATE NOT NULL,
    [user_id] INT NOT NULL,
    [patient_id] INT NOT NULL,
    PRIMARY KEY ([id])
)
GO
-- 11. Bảng hồ sơ bệnh án
CREATE TABLE [medical_records]
(
    [id] INT NOT NULL IDENTITY(1, 1),
    [diagnosis] NVARCHAR(50) NOT NULL,
    [treatment] NVARCHAR(50) NOT NULL,
    [symptoms] NVARCHAR(50) NOT NULL,
    [patient_id] INT NOT NULL,
    PRIMARY KEY ([id])
)
GO
-- 12. Bảng loại hàng tồn kho
CREATE TABLE [type_inventory]
(
    [id] INT PRIMARY KEY,
    [name] NVARCHAR(255) NOT NULL,
)
GO
-- 13. Bảng hàng tồn kho
CREATE TABLE [inventory]
(
    [id] INT PRIMARY KEY,
    [name] NVARCHAR(255) NOT NULL,
    [category] NVARCHAR(255) NOT NULL,
    [quantity] INT NOT NULL,
    [unit] NVARCHAR(255) NOT NULL,
    [dosage] NVARCHAR(255),
    [production_date] DATE NOT NULL,
    [expiration_date] DATE NOT NULL,
    [import_date] DATE NOT NULL,
    [price] DECIMAL(18,2) NOT NULL,
    [type_id] INT NOT NULL
)
GO
-- 14. Bảng đơn thuốc
CREATE TABLE [prescriptions]
(
    [id] INT,
    [DAY] DATE NOT NULL,
    [patient_id] INT NOT NULL,
    [user_id] INT NOT NULL,
    PRIMARY KEY ([id])
)
GO
-- 15. Bảng chi tiết đơn thuốc
CREATE TABLE [prescription_details]
(
    [id] INT NOT NULL IDENTITY(1, 1),
    [inventory_id] int,
    [quantity] INT NOT NULL,
    [duration] INT NOT NULL,
    [dosage] INT NOT NULL,
    [frequency] INT NOT NULL,
    [notes] NVARCHAR(50) NOT NULL,
    [prescription_id] INT NOT NULL,
    PRIMARY KEY ([id])
)
GO
-- 16. Bảng loại dịch vụ
CREATE TABLE [service_categories]
(
    [id] INT PRIMARY KEY IDENTITY(1, 1),
    [name] NVARCHAR(255) UNIQUE NOT NULL
)
GO
-- 17. Bảng dịch vụ
CREATE TABLE [services]
(
    [id] INT PRIMARY KEY IDENTITY(1, 1),
    [category_id] INT NOT NULL,
    [name] NVARCHAR(255) NOT NULL,
    [unit] NVARCHAR(255) NOT NULL,
    [price] DECIMAL(18,2) NOT NULL
)
GO
-- 18. Bảng điều trị
CREATE TABLE [treatments]
(
    [id] INT PRIMARY KEY IDENTITY(1, 1),
    [substitute_doctor_name] NVARCHAR(50) NOT NULL,
    [doctor_id] INT NOT NULL,
    [patient_id] INT NOT NULL,
    [treatment_date] DATE NOT NULL,
    [notes] NVARCHAR(255)
)
GO
-- 19. Bảng hóa đơn
CREATE TABLE [invoices]
(
    [id] INT,
    [payment_method] BIT NOT NULL,
    [total_price] FLOAT NOT NULL,
    [prescription_id] INT NOT NULL,
    [patient_id] INT NOT NULL,
    [date] date,
    PRIMARY KEY ([id])
)
GO
-- 20. Bảng chi tiết hóa đơn
CREATE TABLE [invoice_details]
(
    [id] INT PRIMARY KEY IDENTITY(1, 1),
    [invoice_id] INT NOT NULL,
    [service_id] INT NOT NULL,
    [quantity] INT NOT NULL,
    [unit_price] DECIMAL(18,2) NOT NULL
)
GO


ALTER TABLE [work_schedules] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([user_id])
GO

ALTER TABLE [salaries] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([user_id])
GO

ALTER TABLE [receptionists] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([user_id])
GO

ALTER TABLE [administrators] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([user_id])
GO

ALTER TABLE [doctors] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([user_id])
GO

ALTER TABLE [doctors] ADD FOREIGN KEY ([specialization_id]) REFERENCES [doctor_specializations] ([specialization_id])
GO

ALTER TABLE [receptions] ADD FOREIGN KEY ([user_id]) REFERENCES [receptionists] ([user_id])
GO

ALTER TABLE [receptions] ADD FOREIGN KEY ([patient_id]) REFERENCES [patients] ([id])
GO

ALTER TABLE [appointments] ADD FOREIGN KEY ([user_id]) REFERENCES [doctors] ([user_id])
GO

ALTER TABLE [appointments] ADD FOREIGN KEY ([patient_id]) REFERENCES [patients] ([id])
GO

ALTER TABLE [medical_records] ADD FOREIGN KEY ([patient_id]) REFERENCES [patients] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [prescriptions] ADD FOREIGN KEY ([patient_id]) REFERENCES [patients] ([id])
GO

ALTER TABLE [prescriptions] ADD FOREIGN KEY ([user_id]) REFERENCES [doctors] ([user_id])
GO

ALTER TABLE [prescription_details] ADD FOREIGN KEY ([prescription_id]) REFERENCES [prescriptions] ([id])
GO

ALTER TABLE [services] ADD FOREIGN KEY ([category_id]) REFERENCES [service_categories] ([id])
GO

ALTER TABLE [treatments] ADD FOREIGN KEY ([doctor_id]) REFERENCES [doctors] ([user_id]) ON DELETE CASCADE
GO

ALTER TABLE [treatments] ADD FOREIGN KEY ([patient_id]) REFERENCES [patients] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [inventory] ADD FOREIGN KEY([type_id]) REFERENCES [type_inventory] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [prescription_details] ADD FOREIGN KEY([inventory_id]) REFERENCES [inventory] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [invoices] ADD FOREIGN KEY ([prescription_id]) REFERENCES [prescriptions] ([id])
GO

ALTER TABLE [invoices] ADD FOREIGN KEY ([patient_id]) REFERENCES [patients] ([id])
GO

ALTER TABLE [invoice_details] ADD FOREIGN KEY ([invoice_id]) REFERENCES [invoices] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [invoice_details] ADD FOREIGN KEY ([service_id]) REFERENCES [services] ([id]) ON DELETE CASCADE
GO


--Insert dữ liệu

--Người dùng
INSERT INTO users
    (user_id, full_name, citizen_id, phone_number, address, gender, dob, role, username, PASSWORD, email, salary_coefficient, status)
VALUES
    (1, N'Nguyễn Văn An', '123456789001', '0901234561', N'123 Lê Lợi, Q1, TP.HCM', 1, '1990-01-15', 'Admin', 'admin1', 'pass123', 'admin1@gmail.com', 1.5, 1),
    (2, N'Trần Thị Bình', '123456789002', '0901234562', N'456 Nguyễn Huệ, Q1, TP.HCM', 0, '1991-02-20', 'Admin', 'admin2', 'pass123', 'admin2@gmail.com', 1.5, 1),
    (3, N'Lê Văn Cường', '123456789003', '0901234563', N'789 Lê Duẩn, Q1, TP.HCM', 1, '1992-03-25', 'Reception', 'recep1', 'pass123', 'recep1@gmail.com', 1.2, 1),
    (4, N'Phạm Thị Dung', '123456789004', '0901234564', N'147 Nam Kỳ, Q3, TP.HCM', 0, '1993-04-30', 'Reception', 'recep2', 'pass123', 'recep2@gmail.com', 1.2, 1),
    (5, N'Hoàng Văn Em', '123456789005', '0901234565', N'258 Hai Bà Trưng, Q1, TP.HCM', 1, '1994-05-05', 'Reception', 'recep3', 'pass123', 'recep3@gmail.com', 1.2, 1),
    (6, N'Đỗ Thị Phương', '123456789006', '0901234566', N'369 Lê Văn Sỹ, Q3, TP.HCM', 0, '1985-06-10', 'Doctor', 'doctor1', 'pass123', 'doctor1@gmail.com', 2.0, 1),
    (7, N'Vũ Văn Giang', '123456789007', '0901234567', N'147 Nguyễn Đình Chiểu, Q3, TP.HCM', 1, '1986-07-15', 'Doctor', 'doctor2', 'pass123', 'doctor2@gmail.com', 2.0, 1),
    (8, N'Mai Thị Hoa', '123456789008', '0901234568', N'258 Võ Văn Tần, Q3, TP.HCM', 0, '1987-08-20', 'Doctor', 'doctor3', 'pass123', 'doctor3@gmail.com', 2.0, 1),
    (9, N'Trịnh Văn Inh', '123456789009', '0901234569', N'369 Cách Mạng T8, Q3, TP.HCM', 1, '1988-09-25', 'Doctor', 'doctor4', 'pass123', 'doctor4@gmail.com', 2.0, 1),
    (10, N'Lý Thị Kim', '123456789010', '0901234570', N'147 Điện Biên Phủ, Q1, TP.HCM', 0, '1989-10-30', 'Doctor', 'doctor5', 'pass123', 'doctor5@gmail.com', 2.0, 1),
    (11, N'Ngô Văn Linh', '123456789011', '0901234571', N'258 Nguyễn Trãi, Q5, TP.HCM', 1, '1990-11-05', 'Doctor', 'doctor6', 'pass123', 'doctor6@gmail.com', 2.0, 1),
    (12, N'Phan Thị Mai', '123456789012', '0901234572', N'369 Lý Thường Kiệt, Q10, TP.HCM', 0, '1991-12-10', 'Doctor', 'doctor7', 'pass123', 'doctor7@gmail.com', 2.0, 11),
    (13, N'Đặng Văn Nam', '123456789013', '0901234573', N'147 Bà Hom, Q6, TP.HCM', 1, '1992-01-15', 'Doctor', 'doctor8', 'pass123', 'doctor8@gmail.com', 2.0, 1),
    (14, N'Bùi Thị Oanh', '123456789014', '0901234574', N'258 Hùng Vương, Q5, TP.HCM', 0, '1993-02-20', 'Doctor', 'doctor9', 'pass123', 'doctor9@gmail.com', 2.0, 11),
    (15, N'Hồ Văn Phát', '123456789015', '0901234575', N'369 Tân Kỳ Tân Quý, Q.TB, TP.HCM', 1, '1994-03-25', 'Doctor', 'doctor10', 'pass123', 'doctor10@gmail.com', 2.0, 1),
    (16, N'Trương Thị Quỳnh', '123456789016', '0901234576', N'147 Âu Cơ, Q.TB, TP.HCM', 0, '1995-04-30', 'Reception', 'recep4', 'pass123', 'recep4@gmail.com', 1.2, 1),
    (17, N'Lương Văn Rồng', '123456789017', '0901234577', N'258 Lạc Long Quân, Q11, TP.HCM', 1, '1996-05-05', 'Reception', 'recep5', 'pass123', 'recep5@gmail.com', 1.2, 1),
    (18, N'Dương Thị Sen', '123456789018', '0901234578', N'369 Hòa Bình, Q.TB, TP.HCM', 0, '1997-06-10', 'Reception', 'recep6', 'pass123', 'recep6@gmail.com', 1.2, 1),
    (19, N'Lại Văn Tâm', '123456789019', '0901234579', N'147 Trường Chinh, Q12, TP.HCM', 1, '1998-07-15', 'Admin', 'admin3', 'pass123', 'admin3@gmail.com', 1.5, 1),
    (20, N'Châu Thị Uyên', '123456789020', '0901234580', N'258 Quang Trung, Q.GV, TP.HCM', 0, '1999-08-20', 'Admin', 'admin4', 'pass123', 'admin4@gmail.com', 1.5, 1);
/*DELETE FROM [users];
DBCC CHECKIDENT ('users', RESEED, 0);*/

INSERT INTO administrators
    (user_id)
VALUES
    (1),
    (2),
    (19),
    (20);

INSERT INTO receptionists
    (user_id)
VALUES
    (3),
    (4),
    (5),
    (16),
    (17),
    (18);

--Bác sĩ - Chuyên ngành
INSERT INTO doctor_specializations
    (specialization_name)
VALUES
    (N'Nha chu'),
    (N'Nhổ răng và tiểu phẫu'),
    (N'Phục hình'),
    (N'Chữa răng và nội nha'),
    (N'Răng trẻ em'),
    (N'Tổng quát');
/*DELETE FROM doctor_specializations;
DBCC CHECKIDENT ('doctor_specializations', RESEED, 0);*/

INSERT INTO doctors
    (user_id, specialization_id)
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

--Bệnh nhân
INSERT INTO patients
    (id, full_name, gender, age, phone_number, address)
VALUES
    (1, N'Phạm Văn Cường', 1, 29, '0903456789', N'789 Lê Lợi, Quận 5'),
    (2, N'Trần Văn Tùng', 1, 37, '0906789012', N'56 Võ Thị Sáu, Quận 2'),
    (3, N'Lê Thị Hoa', 0, 30, '0907890123', N'78 Nam Kỳ Khởi Nghĩa, Quận 3'),
    (4, N'Phạm Văn Bảo', 1, 33, '0900123456', N'23 Trường Chinh, Quận Tân Bình'),
    (5, N'Trần Văn Đức', 1, 32, '0903334455', N'67 Trường Sa, Phú Nhuận'),
    (6, N'Lê Thị Lan', 0, 31, '0904445566', N'78 Lê Văn Sỹ, Quận 3'),
    (7, N'Nguyễn Hoàng Long', 1, 33, '0905556677', N'89 Nguyễn Văn Trỗi, Quận Tân Phú'),
    (8, N'Phạm Thanh Bình', 1, 37, '0906667788', N'23 Lê Lợi, Quận 1'),
    (9, N'Võ Thị Quỳnh', 0, 31, '0907778899', N'34 Hai Bà Trưng, Quận 3'),
    (10, N'Nguyễn Văn Minh', 1, 32, '0905678901', N'34 Hai Bà Trưng, Quận 3'),
    (11, N'Trần Thị Hoa', 0, 39, '0902345678', N'456 Điện Biên Phủ, Quận 3'),
    (12, N'Lê Văn Tâm', 1, 50, '0903456567', N'56 Cách Mạng Tháng Tám, Quận 10'),
    (13, N'Trần Anh Dũng', 1, 28, '0908765432', N'101 Lý Chính Thắng, Quận 3'),
    (14, N'Lê Thị Bích', 0, 34, '0901234876', N'567 Nguyễn Tri Phương, Quận 10'),
    (15, N'Vũ Thị Minh Châu', 0, 40, '0906785432', N'200 Lê Hồng Phong, Quận 5'),
    (16, N'Nguyễn Hoàng Khôi', 1, 26, '0909087654', N'90 Nguyễn Trãi, Quận 1'),
    (17, N'Ngô Thị Hà', 0, 29, '0912345678', N'333 Hai Bà Trưng, Quận 1'),
    (18, N'Phạm Thị Thanh', 0, 35, '0903456789', N'222 Phan Xích Long, Quận Phú Nhuận'),
    (19, N'Lê Hữu Phước', 1, 32, '0909998877', N'345 Cộng Hòa, Quận Tân Bình'),
    (20, N'Nguyễn Thị Mai', 0, 27, '0901234567', N'567 Lý Thường Kiệt, Quận 10');
/*DELETE FROM patients;
DBCC CHECKIDENT ('patients', RESEED, 0);*/

--Lương
INSERT INTO salaries
    (salary_id, user_id, basic_salary, bonus, fine, allowance, day)
VALUES
    (1, 1, 5000000, 0, 500000, 0, '2024-09-01'),
    (2, 2, 4000000, 200000, 500000, 0, '2024-09-01'),
    (3, 3, 6000000, 0, 800000, 0, '2024-09-01'),
    (4, 4, 5500000, 300000, 800000, 0, '2024-09-01'),
    (5, 5, 7000000, 0, 1000000, 0, '2024-09-01'),
    (6, 6, 6500000, 200000, 1000000, 0, '2024-09-01'),
    (7, 7, 9000000, 0, 1500000, 0, '2024-09-01'),
    (8, 8, 8500000, 500000, 1500000, 0, '2024-09-01'),
    (9, 9, 12000000, 0, 2000000, 0, '2024-09-01'),
    (10, 10, 11500000, 200000, 2000000, 0, '2024-09-01'),
    (11, 11, 8000000, 0, 1200000, 0, '2024-09-01'),
    (12, 12, 7500000, 300000, 1200000, 0, '2024-09-01'),
    (13, 13, 10000000, 0, 1800000, 0, '2024-09-01'),
    (14, 14, 9500000, 400000, 1800000, 0, '2024-09-01'),
    (15, 15, 13000000, 0, 2500000, 0, '2024-09-01'),
    (16, 16, 12500000, 300000, 2500000, 0, '2024-09-01'),
    (17, 17, 15000000, 0, 3000000, 0, '2024-09-01'),
    (18, 18, 14500000, 500000, 3000000, 0, '2024-09-01'),
    (19, 19, 17000000, 0, 3500000, 0, '2024-09-01'),
    (20, 20, 16500000, 400000, 3500000, 0, '2024-09-01');

/*DELETE FROM [salaries];
DBCC CHECKIDENT ('salaries', RESEED, 0);*/


--Lịch làm việc
-- Tháng 9
INSERT INTO work_schedules
    (DAY, shift, user_id)
VALUES
    ('2024-09-01', 1, 3),
    ('2024-09-01', 1, 5),
    ('2024-09-01', 1, 7),
    ('2024-09-01', 1, 9),
    ('2024-09-01', 2, 11),
    ('2024-09-01', 2, 13),
    ('2024-09-01', 2, 15),
    ('2024-09-01', 2, 17),

    ('2024-09-02', 1, 4),
    ('2024-09-02', 1, 6),
    ('2024-09-02', 1, 8),
    ('2024-09-02', 1, 10),
    ('2024-09-02', 2, 12),
    ('2024-09-02', 2, 14),
    ('2024-09-02', 2, 16),
    ('2024-09-02', 2, 18),

    ('2024-09-03', 1, 3),
    ('2024-09-03', 1, 5),
    ('2024-09-03', 1, 7),
    ('2024-09-03', 1, 9),
    ('2024-09-03', 2, 11),
    ('2024-09-03', 2, 13),
    ('2024-09-03', 2, 15),
    ('2024-09-03', 2, 17),

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
INSERT INTO work_schedules
    (DAY, shift, user_id)
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

--Tiếp nhận bệnh nhân
INSERT INTO receptions
    (user_id, patient_id)
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

--Lịch hẹn
INSERT INTO appointments
    (notes, STATUS, appointment_date, user_id, patient_id)
VALUES
    (N'Khám răng lần đầu', 0, '2024-10-25', 6, 1),
    (N'Tái khám sau nhổ răng', 1, '2024-10-15', 7, 2),
    (N'Khám nha chu', 0, '2024-11-05', 8, 3),
    (N'Chỉnh hình răng mặt', 0, '2024-10-30', 9, 4),
    (N'Cấy ghép Implant', 1, '2024-09-20', 10, 5),
    (N'Khám tổng quát', 0, '2024-10-27', 6, 6),
    (N'Khám răng miệng', 1, '2024-11-02', 7, 7),
    (N'Tái khám sau cấy ghép', 0, '2024-11-10', 8, 8),
    (N'Kiểm tra tình trạng răng', 0, '2024-10-22', 9, 9),
    (N'Khám và lấy cao răng', 1, '2024-10-20', 10, 10),
    (N'Tái khám sau điều trị', 0, '2024-11-05', 11, 11),
    (N'Khám răng sữa', 1, '2024-10-25', 12, 12),
    (N'Khám răng khôn', 0, '2024-10-15', 13, 13),
    (N'Khám và làm răng giả', 0, '2024-11-01', 14, 14),
    (N'Khám sức khỏe răng miệng', 1, '2024-10-28', 15, 15),
    (N'Tái khám sau nhổ răng', 0, '2024-11-12', 6, 16),
    (N'Khám răng cho trẻ em', 1, '2024-10-31', 7, 17),
    (N'Khám và điều trị sâu răng', 0, '2024-11-04', 8, 18),
    (N'Kiểm tra định kỳ', 0, '2024-10-29', 9, 19),
    (N'Khám và làm sạch răng', 1, '2024-11-03', 10, 20);
/*DELETE FROM appointments;
DBCC CHECKIDENT ('appointments', RESEED, 0);*/

--Hồ sơ bệnh án
INSERT INTO medical_records
    (diagnosis, treatment, symptoms, patient_id)
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

--Loại hàng tồn kho
INSERT INTO type_inventory
    (id, name)
VALUES
    (1, N'Thuốc'),
    (2, N'Vật tư'),
    (3, N'Dụng cụ'),
    (4, N'Thiết bị');
/*DELETE FROM type_inventory;
DBCC CHECKIDENT ('type_inventory', RESEED, 0);*/

--Hàng tồn kho
INSERT INTO inventory
    (id, name, category, quantity, unit, dosage, production_date, expiration_date, import_date, price, type_id)
VALUES
    (1, N'Amocixillin', N'Kháng sinh', 50, N'Viên', N'500mg', '2024-06-01', '2025-12-01', '2024-06-15', 10000, 1),
    (2, N'Amocixillin', N'Kháng sinh', 100, N'Viên', N'500mg', '2024-06-15', '2026-06-15', '2024-06-20', 10000, 1),
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
    (18, N'Nạy', 'Vật liệu cố định', 20, N'Cây', '', '2024-01-20', '2025-01-20', '2024-01-25', 80000, 2),
    (19, N'Cây đo túi nướu', 'Vật liệu cố định', 10, N'Cây', '', '2024-03-20', '2025-03-20', '2024-03-25', 100000, 2),
    (20, 'Nạy', 'Vật liệu cố định', 20, N'Cây', '', '2024-01-20', '2025-01-20', '2024-01-25', 80000, 2),
    (21, N'Ống chích sắt', 'Vật liệu cố định', 50, N'Ống', '', '2024-05-20', '2025-05-20', '2024-05-25', 10000, 2),
    (22, N'Bông Gòn', 'Vật liệu tiêu hao', 50, N'Bịch', '', '2024-10-01', '2029-10-01', '2024-10-15', 20000, 2),
    (23, N'Mũi khoan kim cương', 'Vật liệu tiêu hao', 30, N'Cái', '', '2024-01-20', '2026-01-20', '2024-01-10', 50000, 2),
    (24, N'NaCl', 'Vật liệu tiêu hao', 5, N'Kg', '', '2024-10-01', '2027-10-01', '2024-10-15', 50000, 2),
    (25, N'Trâm tay', 'Vật liệu tiêu hao', 50, N'Cái', '', '2024-10-01', '2028-10-01', '2024-10-15', 30000, 2),
    (26, N'Trâm tay', 'Vật liệu tiêu hao', 50, N'Cái', '', '2024-10-01', '2029-10-01', '2024-10-15', 30000, 2),
    (27, N'Sò đánh bóng', 'Vật liệu tiêu hao', 60, N'Cái', '', '2024-10-01', '2026-10-01', '2024-10-15', 70000, 2),
    (28, N'Chỉ khâu', 'Vật liệu tiêu hao', 50, N'Cuộn', '', '2024-10-01', '2030-10-01', '2024-10-15', 35000, 2),
    (29, N'Thuốc tê', 'Vật liệu tiêu hao', 200, N'Viên', N'50mg', '2024-08-01', '2026-08-01', '2024-08-15', 35000, 2),

    (30, N'Bộ dụng cụ khám răng', N'Dụng cụ điều trị', 50, N'Bộ', '', '2024-04-01', '2027-04-01', '2024-04-15', 150000, 3),
    (31, N'Bộ dụng cụ trám răng', N'Dụng cụ điều trị', 50, N'Bộ', '', '2024-04-01', '2027-04-01', '2024-05-01', 200000, 3),
    (32, N'Bộ dụng cụ chỉnh hình', N'Dụng cụ thẩm mỹ', 5, N'Bộ', '', '2024-10-01', '2027-10-01', '2024-10-10', 300000, 3),

    (33, N'Máy X-Quang', N'Thiết bị chẩn đoán', 4, N'Máy', '', '2024-09-01', '2029-09-01', '2024-09-15', 15000000, 4),
    (34, N'Máy chụp CT', N'Thiết bị chẩn đoán', 3, N'Máy', '', '2024-09-01', '2029-09-01', '2024-09-15', 20000000, 4),
    (45, N'Ghế nha khoa', N'Thiết bị điều trị', 5, N'Ghế', '', '2024-08-01', '2032-08-01', '2024-09-15', 20000000, 4),
    (36, N'Máy trám răng', N'Thiết bị điều trị', 4, N'Máy', '', '2024-07-01', '2030-07-01', '2024-07-15', 10000000, 4),
    (37, N'Máy điều trị tủy', N'Thiết bị điều trị', 3, N'Máy', '', '2024-09-01', '2034-09-01', '2024-10-15', 20000000, 4),
    (38, N'Máy tẩy trắng răng', N'Thiết bị thẩm mỹ', 3, N'Máy', '', '2024-09-01', '2029-09-01', '2024-12-01', 12000000, 4);

/*DELETE FROM inventory;
DBCC CHECKIDENT ('inventory', RESEED, 0);*/

--Đơn thuốc
INSERT INTO prescriptions
    (id, day, patient_id, user_id)
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

--Chi tiết đơn thuốc
INSERT INTO prescription_details
    (inventory_id, quantity, duration, dosage, frequency, notes, prescription_id)
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

--Loại dịch vụ
INSERT INTO service_categories
    (name)
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

--Dịch vụ
-- Category: Khám - Hồ sơ (category_id = 1)
INSERT INTO services
    (category_id, name, unit, price)
VALUES
    (1, N'Khám - Hồ sơ', 'Lượt', 5000);

-- Category: Nhổ răng (category_id = 2)
INSERT INTO services
    (category_id, name, unit, price)
VALUES
    (2, N'Răng cửa, răng nanh', N'Cái', 100000),
    (2, N'Răng cối nhỏ', N'Cái', 120000),
    (2, N'Răng cối lớn trên', N'Cái', 140000),
    (2, N'Răng cối lớn dưới', N'Cái', 180000),
    (2, N'Nhổ răng lung lay', N'Cái', 100000),
    (2, N'Nhổ chân răng vĩnh viễn', N'Cái', 120000),
    (2, N'Khâu ổ răng', N'Cái', 100000);

-- Category: Nha chu (category_id = 3)
INSERT INTO services
    (category_id, name, unit, price)
VALUES
    (3, N'Cạo vôi răng', N'2 hàm', 100000),
    (3, N'Diều trị viêm nha chu không phẫu thuật', N'Vùng hàm', 200000),
    (3, N'Phẫu thuật lật vạt làm sạch', N'Lần', 200000),
    (3, N'Cắt thăng', N'Lần', 200000),
    (3, N'Phẫu thuật nướu', N'Răng', 1000000);

-- Category: Chữa răng - Nội nha (category_id = 4)
INSERT INTO services
    (category_id, name, unit, price)
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
INSERT INTO services
    (category_id, name, unit, price)
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
INSERT INTO services
    (category_id, name, unit, price)
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
INSERT INTO services
    (category_id, name, unit, price)
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
INSERT INTO services
    (category_id, name, unit, price)
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
INSERT INTO services
    (category_id, name, unit, price)
VALUES
    (9, N'Mảng Fluor không thuốc', N'Mảng', 200000);

-- Category: Điều trị loạn năng hệ thống nhai (category_id = 10)
INSERT INTO services
    (category_id, name, unit, price)
VALUES
    (10, N'Một máng nhai', N'Mảng', 1000000),
    (10, N'Mài chỉnh khớp cắn đơn giản', N'Lần', 300000),
    (10, N'Mài chỉnh khớp cắn phức tạp', N'Lần', 600000);

-- Category: X-Quang răng (category_id = 11)
INSERT INTO services
    (category_id, name, unit, price)
VALUES
    (11, N'Phim quanh chóp', N'Phim', 60000),
    (11, N'Phim toàn cảnh', N'Phim', 200000);

-- Category: Cấy ghép Implant (category_id = 12)
INSERT INTO services
    (category_id, name, unit, price)
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
INSERT INTO services
    (category_id, name, unit, price)
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
INSERT INTO services
    (category_id, name, unit, price)
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

--Điều trị
INSERT INTO treatments
    (substitute_doctor_name, doctor_id, patient_id, treatment_date, notes)
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


--Hóa đơn
INSERT INTO invoices
    (id, payment_method, total_price, prescription_id, patient_id, date)
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

--Chi tiết hóa đơn
INSERT INTO invoice_details
    (invoice_id, service_id, quantity, unit_price)
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


--Dành cho đăng nhập, quên mật khẩu
--Procedure kiểm tra đăng nhập
CREATE PROCEDURE CheckLogin
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
    FROM users
    WHERE username = @username AND PASSWORD = @password AND status = 1;

    -- Nếu người dùng tồn tại, lấy id và role
    IF @userCount > 0
    BEGIN
        SELECT @id = id, @role = role
        FROM users
        WHERE username = @username AND PASSWORD = @password;
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
CREATE PROCEDURE GetUserInfo
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
    FROM users left join doctors
        on users.user_id = doctors.user_id
        left join doctor_specializations
        on doctors.specialization_id = doctor_specializations.specialization_id
    WHERE users.user_id = @userId;
END;
GO



-- Procedurre lấy mật khẩu từ email và username
CREATE PROCEDURE GetPasswordByEmailAndUsername
    @Email NVARCHAR(50),
    @Username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Truy vấn lấy mật khẩu từ bảng users dựa trên email và username
    SELECT [password]
    FROM [users]
    WHERE [email] = @Email AND [username] = @Username;
END
GO


-- Procedure kiểm tra email tồn tại
CREATE PROCEDURE CheckEmailExists
    @Email NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra email có tồn tại trong bảng users hay không
    IF EXISTS (SELECT 1
    FROM [users]
    WHERE [email] = @Email)
    BEGIN
        SELECT 1
    -- Email tồn tại
    END
    ELSE
    BEGIN
        SELECT 0
    -- Email không tồn tại
    END
END
GO

-- Procedure kiểm tra username tồn tại
CREATE PROCEDURE CheckUsernameExists
    @Username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra username có tồn tại trong bảng users hay không
    IF EXISTS (SELECT 1
    FROM [users]
    WHERE [username] = @Username)
    BEGIN
        SELECT 1
    -- username tồn tại
    END
    ELSE
    BEGIN
        SELECT 0
    -- username không tồn tại
    END
END
GO

--Kết thúc
--Admin

--Procedure danh sách bác sĩ
CREATE PROCEDURE GetDoctorList
AS
BEGIN
    SELECT *
    FROM users
        join doctors on users.user_id = doctors.user_id
        join doctor_specializations on doctors.specialization_id = doctor_specializations.specialization_id
    ORDER BY users.user_id;
END;
GO

--Procedure danh sách lễ tân
CREATE PROCEDURE GetRepceptionistList
AS
BEGIN
    SELECT *
    FROM users
        join receptionists on users.user_id = receptionists.user_id
    ORDER BY users.user_id;
END;
GO

--Procedure danh sách bệnh nhân
CREATE PROCEDURE GetPatienttListForAdmin
AS
BEGIN
    SELECT *
    FROM patients
END;
GO

--Function đếm số lượng dữ liệu
CREATE FUNCTION CountDoctors()
RETURNS INT
AS
BEGIN
    DECLARE @TotalDoctors INT;

    SELECT @TotalDoctors = COUNT(*)
    FROM doctors;

    RETURN @TotalDoctors;
END;

GO

CREATE FUNCTION CountPatient()
RETURNS INT
AS
BEGIN
    DECLARE @TotalPatient INT;

    SELECT @TotalPatient = COUNT(*)
    FROM patients;

    RETURN @TotalPatient;
END;

GO

CREATE FUNCTION CountRevenue()
RETURNS INT
AS
BEGIN
    DECLARE @Revenue INT;

    DECLARE @StartOfMonth DATE;
    DECLARE @EndOfMonth DATE;

    -- Ngày bắt đầu của tháng hiện tại
    SET @StartOfMonth = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1);

    -- Ngày kết thúc của tháng hiện tại
    SET @EndOfMonth = EOMONTH(GETDATE());

    SELECT @Revenue = SUM(total_price)
    FROM invoices
    WHERE DATE BETWEEN @StartOfMonth AND @EndOfMonth;

    RETURN @Revenue;
END;

GO

--Procedure cập nhật trạng thái
CREATE PROCEDURE UpdateStatus
    @userId INT
AS
BEGIN
    UPDATE users 
    SET status = CASE WHEN status = 1 THEN 0 ELSE 1 END
    WHERE user_id = @userId;
END;

GO

--Procedure cập nhật thông tin bác sĩ
CREATE PROCEDURE UpdateUserInfo
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
    UPDATE users 
    SET 
        full_name = @fullName,
        citizen_id = @citizenId,
        phone_number = @phoneNumber,
        address = @address,
        gender = @gender,
        dob = @dob,
        email = @email,	
        salary_coefficient = @salaryCoefficient
    WHERE user_id = @userId;

    UPDATE doctors
    SET 
        specialization_id = @specializationID
    WHERE user_id = @userId;
END;

GO

--Hàm tự tạo tên đăng nhập
CREATE FUNCTION GenerateDoctorUsername()
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @doctorCount INT;
    DECLARE @username NVARCHAR(50);

    -- Tính toán số lượng bác sĩ hiện tại
    SELECT @doctorCount = COUNT(*)
    FROM doctors;

    -- Tạo tên đăng nhập
    SET @username = 'doctor' + CAST(@doctorCount + 1 AS NVARCHAR(10));

    RETURN @username;
END;
GO

--Hàm thêm bác sĩ
CREATE PROCEDURE AddDoctor
    @fullName NVARCHAR(255),
    -- Họ tên
    @citizenId NVARCHAR(12),
    -- Số CCCD
    @phoneNumber NVARCHAR(10),
    -- Số điện thoại
    @address NVARCHAR(50),
    -- Địa chỉ
    @gender BIT,
    -- Giới tính (0 cho nữ, 1 cho nam)
    @dob DATE,
    -- Ngày sinh
    @email NVARCHAR(50),
    -- Email
    @salaryCoefficient FLOAT,
    -- Hệ số lương
    @specializationId INT
AS
BEGIN
    DECLARE @newId INT;
    DECLARE @doctorCount INT;
    DECLARE @username NVARCHAR(50);
    DECLARE @password NVARCHAR(50) = 'pass123';

    SELECT @newId = ISNULL(MAX(user_id), 0) + 1
    FROM users;
    SET @username = dbo.GenerateDoctorUsername();

    INSERT INTO users
        (user_id, full_name, citizen_id, phone_number, address, gender, dob, role, username, password, email, salary_coefficient, status)
    VALUES
        (@newId, @fullName, @citizenId, @phoneNumber, @address, @gender, @dob, 'Doctor', @username, @password, @email, @salaryCoefficient, 1);

    INSERT INTO doctors
        (user_id, specialization_id)
    VALUES
        (@newId, @specializationId);
END;
GO

--Procedure lấy thông tin lễ tân
CREATE PROCEDURE GetReceptionistInfo
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
    FROM users join receptionists
        on users.user_id = receptionists.user_id
    WHERE users.user_id = @userId;
END;
GO

--Procedure cập nhật thông tin lễ tân
CREATE PROCEDURE UpdateReceptionistInfo
    @userId INT,
    @fullName NVARCHAR(255),
    @citizenId NVARCHAR(12),
    @phoneNumber NVARCHAR(10),
    @address NVARCHAR(50),
    @gender BIT,
    @dob DATE,
    @email NVARCHAR(50),
    @salaryCoefficient FLOAT
AS
BEGIN
    UPDATE users 
    SET 
        full_name = @fullName,
        citizen_id = @citizenId,
        phone_number = @phoneNumber,
        address = @address,
        gender = @gender,
        dob = @dob,
        email = @email,	
        salary_coefficient = @salaryCoefficient
    WHERE user_id = @userId;
END;

GO

--Hàm tự tạo tên đăng nhập
CREATE FUNCTION GenerateReceptionistUsername()
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @receptionistCount INT;
    DECLARE @username NVARCHAR(50);

    -- Tính toán số lượng bác sĩ hiện tại
    SELECT @receptionistCount = COUNT(*)
    FROM receptionists;

    -- Tạo tên đăng nhập
    SET @username = 'recep' + CAST(@receptionistCount + 1 AS NVARCHAR(10));

    RETURN @username;
END;

GO

--Procedure thêm lễ tân
CREATE PROCEDURE AddReceptionist
    @fullName NVARCHAR(255),
    -- Họ tên
    @citizenId NVARCHAR(12),
    -- Số CCCD
    @phoneNumber NVARCHAR(10),
    -- Số điện thoại
    @address NVARCHAR(50),
    -- Địa chỉ
    @gender BIT,
    -- Giới tính (0 cho nữ, 1 cho nam)
    @dob DATE,
    -- Ngày sinh
    @email NVARCHAR(50),
    -- Email
    @salaryCoefficient FLOAT
-- Hệ số lương
AS
BEGIN
    DECLARE @newId INT;
    DECLARE @doctorCount INT;
    DECLARE @username NVARCHAR(50);
    DECLARE @password NVARCHAR(50) = 'pass123';

    SELECT @newId = ISNULL(MAX(user_id), 0) + 1
    FROM users;
    SET @username = dbo.GenerateReceptionistUsername();

    INSERT INTO users
        (user_id, full_name, citizen_id, phone_number, address, gender, dob, role, username, password, email, salary_coefficient, status)
    VALUES
        (@newId, @fullName, @citizenId, @phoneNumber, @address, @gender, @dob, 'Reception', @username, @password, @email, @salaryCoefficient, 1);

    INSERT INTO receptionists
        (user_id)
    VALUES
        (@newId);
END;
GO

--Procedure lấy thông tin bệnh nhân
CREATE PROCEDURE GetPatientInfo
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
    FROM patients
    WHERE patients.id = @userId;
END;
GO

--Procedure cập nhật thông tin bệnh nhân
CREATE PROCEDURE UpdatePatientInfo
    @userId INT,
    @fullName NVARCHAR(255),
    @phoneNumber NVARCHAR(10),
    @address NVARCHAR(50),
    @gender BIT,
    @age INT
AS
BEGIN
    UPDATE patients 
    SET 
        full_name = @fullName,
        phone_number = @phoneNumber,
        address = @address,
        gender = @gender,
        age = @age
    WHERE id = @userId;
END;

GO

--Procedure thêm lễ tân
CREATE PROCEDURE AddPatient
    @fullName NVARCHAR(255),
    -- Họ tên
    @phoneNumber NVARCHAR(10),
    -- Số điện thoại
    @address NVARCHAR(50),
    -- Địa chỉ
    @gender BIT,
    -- Giới tính (0 cho nữ, 1 cho nam)
    @age INT
-- Tuổi
AS
BEGIN
    DECLARE @newId INT;
    DECLARE @doctorCount INT;

    SELECT @newId = ISNULL(MAX(id), 0) + 1
    FROM patients;

    INSERT INTO patients
        (id, full_name, gender, age, phone_number, address)
    VALUES
        (@newId, @fullName, @gender, @age, @phoneNumber, @address);
END;
GO
select *
from patients


