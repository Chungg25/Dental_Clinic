
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
    @ngay_hen DATE,
    -- Ngày hẹn
    @ca INT,
    -- Ca làm việc
    @ghi_chu NVARCHAR(255)
AS
BEGIN
    DECLARE @ma_benh_nhan INT;
    -- 1. Tạo mã bệnh nhân mới bằng cách lấy giá trị lớn nhất của ma_benh_nhan và tăng lên 1
    SELECT @ma_benh_nhan = ISNULL(MAX(ma_benh_nhan), 0) + 1
    FROM benh_nhan;
    -- 2. Thêm bệnh nhân mới vào bảng benh_nhan với mã bệnh nhân mới
    INSERT INTO benh_nhan
        (ma_benh_nhan, ho_ten, gioi_tinh, tuoi, so_dien_thoai, dia_chi)
    VALUES
        (@ma_benh_nhan, @ho_ten, @gioi_tinh, @tuoi, @so_dien_thoai, @dia_chi);
    -- 3. Thêm lịch hẹn vào bảng lich_hen với mã bệnh nhân, mã bác sĩ, ngày hẹn, ca và ghi chú
    INSERT INTO lich_hen
        (ma_benh_nhan, ma_nguoi_dung, ngay_hen, ca, ghi_chu, trang_thai)
    VALUES
        (@ma_benh_nhan, @ma_bac_si, @ngay_hen, @ca, @ghi_chu, 0);
    -- 0: Chưa khám
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

CREATE PROCEDURE LayDanhSachBenhNhanChuaThanhToan
    @ngay DATE
AS
BEGIN
    SELECT
        bn.ma_benh_nhan,
        bn.ho_ten,
        bn.so_dien_thoai,
        nd.ho_ten AS ten_bac_si,
        hd.ma_hoa_don,
        CASE 
            WHEN lh.trang_thai = 1 THEN N'Đã khám' 
            ELSE N'Chưa khám' 
        END AS trang_thai_kham,
        CASE 
            WHEN hd.trang_thai_thanh_toan = 1 THEN N'Đã thanh toán' 
            ELSE N'Chưa thanh toán' 
        END AS trang_thai_thanh_toan
    FROM
        benh_nhan bn
        INNER JOIN
        lich_hen lh ON bn.ma_benh_nhan = lh.ma_benh_nhan
        INNER JOIN
        bac_si bs ON lh.ma_nguoi_dung = bs.ma_nguoi_dung
        INNER JOIN
        nguoi_dung nd ON bs.ma_nguoi_dung = nd.ma_nguoi_dung -- Lấy tên bác sĩ từ bảng người dùng
        INNER JOIN
        hoa_don hd ON bn.ma_benh_nhan = hd.ma_benh_nhan
    WHERE 
        hd.trang_thai_thanh_toan = 0 -- Lọc bệnh nhân chưa thanh toán
        AND hd.ngay = @ngay
-- Lọc theo ngày cung cấp
END
GO

CREATE PROCEDURE LayThongTinBenhNhan
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
        lh.ca,
        bs.ho_ten AS ten_bac_si,
        CASE 
            WHEN lh.trang_thai = 1 THEN N'Đã khám'
            ELSE N'Chưa khám'
        END AS trang_thai_kham
    FROM
        benh_nhan bn
        LEFT JOIN
        lich_hen lh ON bn.ma_benh_nhan = lh.ma_benh_nhan
        LEFT JOIN
        nguoi_dung bs ON lh.ma_nguoi_dung = bs.ma_nguoi_dung
    WHERE 
        bn.ma_benh_nhan = @ma_benh_nhan;
END;
GO

CREATE PROCEDURE LayChiTietHoaDonBenhNhan
    @ma_benh_nhan INT
AS
BEGIN
    -- Bảng tạm để lưu chi tiết hóa đơn
    DECLARE @ChiTietHoaDon TABLE (
        loai_muc NVARCHAR(50),
        ten_muc NVARCHAR(255),
        so_luong INT,
        don_gia DECIMAL(18,2),
        thanh_tien DECIMAL(18,2)
    );

    -- Lấy chi tiết các dịch vụ trong hóa đơn
    INSERT INTO @ChiTietHoaDon
        (loai_muc, ten_muc, so_luong, don_gia, thanh_tien)
    SELECT
        N'Dịch vụ' AS loai_muc,
        dv.ten AS ten_muc,
        cthd.so_luong,
        cthd.gia_don_vi AS don_gia,
        (cthd.so_luong * cthd.gia_don_vi) AS thanh_tien
    FROM
        chi_tiet_hoa_don cthd
        INNER JOIN
        dich_vu dv ON cthd.ma_dich_vu = dv.ma_dich_vu
        INNER JOIN
        hoa_don hd ON cthd.ma_hoa_don = hd.ma_hoa_don
    WHERE 
        hd.ma_benh_nhan = @ma_benh_nhan;

    -- Lấy chi tiết các thuốc trong đơn thuốc của hóa đơn
    INSERT INTO @ChiTietHoaDon
        (loai_muc, ten_muc, so_luong, don_gia, thanh_tien)
    SELECT
        N'Thuốc' AS loai_muc,
        htk.ten AS ten_muc,
        ctdt.so_luong,
        htk.gia AS don_gia,
        (ctdt.so_luong * htk.gia) AS thanh_tien
    FROM
        chi_tiet_don_thuoc ctdt
        INNER JOIN
        don_thuoc dt ON ctdt.ma_don_thuoc = dt.ma_don_thuoc
        INNER JOIN
        hoa_don hd ON dt.ma_don_thuoc = hd.ma_don_thuoc
        INNER JOIN
        hang_ton_kho htk ON ctdt.ma_kho = htk.ma_kho
    WHERE 
        hd.ma_benh_nhan = @ma_benh_nhan;

    -- Trả về chi tiết hóa đơn theo từng mục (dịch vụ, thuốc)
    SELECT *
    FROM
        @ChiTietHoaDon;
END
GO
CREATE PROCEDURE CapNhatTrangThaiVaPhuongThucThanhToan
    @ma_hoa_don INT,
    @phuong_thuc_thanh_toan BIT,
    -- 1: Thanh toán qua thẻ, 0: Thanh toán bằng tiền mặt
    @tong_tien FLOAT
-- Tổng tiền hóa đơn
AS
BEGIN
    -- Kiểm tra xem hóa đơn có tồn tại hay không
    IF EXISTS (SELECT 1
    FROM hoa_don
    WHERE ma_hoa_don = @ma_hoa_don)
    BEGIN
        -- Cập nhật trạng thái thanh toán, phương thức thanh toán, và tổng tiền
        UPDATE hoa_don
        SET trang_thai_thanh_toan = 1,                  -- Đặt thành 'Đã thanh toán'
            phuong_thuc_thanh_toan = @phuong_thuc_thanh_toan,  -- Cập nhật phương thức thanh toán
            tong_gia = @tong_tien                        -- Cập nhật tổng tiền
        WHERE ma_hoa_don = @ma_hoa_don;

        PRINT N'Hóa đơn đã được cập nhật thành công.';
    END
    ELSE
    BEGIN
        PRINT N'Hóa đơn không tồn tại.';
    END
END
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



CREATE PROCEDURE LayTongThuocDaBanTrongThang
    @ngay DATETIME
AS
BEGIN
    DECLARE @TongThuoc INT;

    SELECT @TongThuoc = SUM(ctdt.so_luong)
    FROM chi_tiet_don_thuoc ctdt
        INNER JOIN don_thuoc dt ON ctdt.ma_don_thuoc = dt.ma_don_thuoc
        INNER JOIN hoa_don hd ON dt.ma_don_thuoc = hd.ma_don_thuoc
    WHERE MONTH(hd.ngay) = MONTH(@ngay) -- Lọc theo tháng của tham số @ngay
        AND YEAR(hd.ngay) = YEAR(@ngay);

    SELECT @TongThuoc AS TongThuocDaBan;
END
GO


CREATE PROCEDURE LayTongVatTuDaSuDungTrongThang
    @thang INT,
    @nam INT
AS
BEGIN
    DECLARE @TongVatTu INT;

    SELECT @TongVatTu = SUM(ctvt.so_luong)
    FROM chi_tiet_vat_tu ctvt
        INNER JOIN vat_tu vt ON ctvt.ma_vat_tu = vt.ma_vat_tu
        INNER JOIN hoa_don hd ON ctvt.ma_hoa_don = hd.ma_hoa_don
    WHERE MONTH(hd.ngay) = @thang
        AND YEAR(hd.ngay) = @nam;

    -- Nếu không có vật tư nào bán trong tháng thì trả về 0
    IF @TongVatTu IS NULL 
        SET @TongVatTu = 0;

    SELECT @TongVatTu AS TongVatTuDaSuDung;
END
GO

CREATE PROCEDURE ThongTinLeTanTheoThang
    @ma_nguoi_dung INT,
    -- Mã người dùng của lễ tân
    @thang INT,
    -- Tháng cần truy xuất
    @nam INT
-- Năm cần truy xuất
AS
BEGIN
    -- Số ngày làm việc trong tháng
    DECLARE @so_ngay_lam INT;
    SELECT @so_ngay_lam = COUNT(DISTINCT ngay)
    FROM cham_cong
    WHERE ma_nguoi_dung = @ma_nguoi_dung
        AND MONTH(ngay) = @thang
        AND YEAR(ngay) = @nam;

    -- Lấy thông tin lương, thưởng, phạt, và phụ cấp cho tháng đã chọn
    DECLARE @luong_co_ban FLOAT, @thuong FLOAT, @phat FLOAT, @phu_cap FLOAT;
    SELECT
        @luong_co_ban = luong_co_ban,
        @thuong = thuong,
        @phat = phat,
        @phu_cap = phu_cap
    FROM luong
    WHERE ma_nguoi_dung = @ma_nguoi_dung
        AND MONTH(ngay) = @thang
        AND YEAR(ngay) = @nam;

    -- Tổng lương tính toán bao gồm thưởng
    DECLARE @tong_luong FLOAT;
    SET @tong_luong = (@luong_co_ban + @thuong + @phu_cap - @phat) * @so_ngay_lam / 26.0;
    -- Giả định 26 ngày công chuẩn

    -- Lấy tổng số lỗi trong tháng
    DECLARE @tong_loi INT;
    SELECT
        @tong_loi = COUNT(*)
    FROM cham_cong
    WHERE ma_nguoi_dung = @ma_nguoi_dung
        AND MONTH(ngay) = @thang
        AND YEAR(ngay) = @nam
        AND ghi_chu IS NOT NULL;
    -- Chỉ đếm các ngày có lỗi/phạt

    -- Trả về kết quả
    SELECT
        nd.ma_nguoi_dung,
        nd.ho_ten,
        @so_ngay_lam AS so_ca,
        ROUND(@tong_luong, 2) AS tong_luong,
        ROUND(@thuong, 2) AS tong_thuong, -- Làm tròn thưởng đến 2 chữ số
        @tong_loi AS tong_so_loi,
        ROUND(@phat, 2) AS tong_tien_phat
    -- Làm tròn phạt đến 2 chữ số
    FROM nguoi_dung nd
    WHERE nd.ma_nguoi_dung = @ma_nguoi_dung;
END;
GO

DECLARE @ma_bac_si INT = 6
DECLARE @ngay DATE = '2024-11-03'

    SELECT DISTINCT
        bn.ma_benh_nhan,
        bn.ho_ten,
        bn.gioi_tinh,
        bn.tuoi,
        bn.so_dien_thoai,
        bn.dia_chi
    FROM
        lich_hen lh
        INNER JOIN benh_nhan bn ON lh.ma_benh_nhan = bn.ma_benh_nhan
        INNER JOIN bac_si bs ON lh.ma_nguoi_dung = bs.ma_nguoi_dung
    WHERE 
    bs.ma_nguoi_dung = @ma_bac_si
        AND lh.ngay_hen = @ngay

UNION

    SELECT DISTINCT
        bn.ma_benh_nhan,
        bn.ho_ten,
        bn.gioi_tinh,
        bn.tuoi,
        bn.so_dien_thoai,
        bn.dia_chi
    FROM
        dieu_tri dt
        INNER JOIN benh_nhan bn ON dt.ma_benh_nhan = bn.ma_benh_nhan
        INNER JOIN bac_si bs ON dt.ma_bac_si = bs.ma_nguoi_dung
    WHERE 
    bs.ma_nguoi_dung = @ma_bac_si
        AND dt.ngay_dieu_tri = @ngay
