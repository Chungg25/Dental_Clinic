
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


CREATE FUNCTION dbo.LayTongTienVatTuDaSuDungTrongThang
(
    @ngay DATETIME
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongTien DECIMAL(18, 2);

    SELECT @TongTien = SUM(ctvt.so_luong * vt.gia)
    FROM chi_tiet_vat_tu ctvt
        INNER JOIN vat_tu vt ON ctvt.ma_vat_tu = vt.ma_vat_tu
        INNER JOIN hoa_don hd ON ctvt.ma_hoa_don = hd.ma_hoa_don
    WHERE MONTH(hd.ngay) = MONTH(@ngay) -- Lọc theo tháng của tham số @ngay
        AND YEAR(hd.ngay) = YEAR(@ngay);
    -- Lọc theo năm được truyền vào

    -- Nếu không có vật tư nào sử dụng trong tháng thì trả về 0
    IF @TongTien IS NULL 
        SET @TongTien = 0;

    RETURN @TongTien;
END
GO


CREATE FUNCTION dbo.LayTongTienVatTuDaSuDungTrongThang
(
    @ngay DATETIME
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongTien DECIMAL(18, 2);

    SELECT @TongTien = SUM(ctvt.so_luong * vt.gia)
    FROM chi_tiet_vat_tu ctvt
        INNER JOIN vat_tu vt ON ctvt.ma_vat_tu = vt.ma_vat_tu
        INNER JOIN hoa_don hd ON ctvt.ma_hoa_don = hd.ma_hoa_don
    WHERE MONTH(hd.ngay) = MONTH(@ngay) -- Lọc theo tháng của tham số @ngay
        AND YEAR(hd.ngay) = YEAR(@ngay);
    -- Lọc theo năm được truyền vào

    -- Nếu không có vật tư nào sử dụng trong tháng thì trả về 0
    IF @TongTien IS NULL 
        SET @TongTien = 0;

    RETURN @TongTien;
END
GO