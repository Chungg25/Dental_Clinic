using Xunit;
using System.Data;
using Dental_Clinic.DAO.Login;
using Dental_Clinic.DTO.Login;
using Dental_Clinic.DTO.Admin;
using System.Data.SqlClient;

namespace Dental_Clinic.Tests.DAO.DangNhap
{
    public class DangNhapTests
    {
        private readonly DangNhapDAO _dangNhapDAO;

        public DangNhapTests()
        {
            _dangNhapDAO = new DangNhapDAO();
        }

        [Fact]
        public void KiemTraDangNhap_ThongTinHopLe_TraVeDuLieuNguoiDung()
        {
            // Arrange
            var thongTinDangNhapDung = new DangNhapDTO { TenDangNhap = "admin1", Matkhau = "pass123" };
            var thongTinDangNhapSai = new DangNhapDTO { TenDangNhap = "tenDangNhapSai", Matkhau = "matKhauSai" };

            // Act
            DataRow ketQuaDung = _dangNhapDAO.KiemTraDangNhap(thongTinDangNhapDung);
            DataRow ketQuaSai = _dangNhapDAO.KiemTraDangNhap(thongTinDangNhapSai);

            // Assert
            Assert.NotNull(ketQuaDung);
            Assert.Null(ketQuaSai); 
            Assert.Equal(thongTinDangNhapDung.TenDangNhap, ketQuaDung["ten_dang_nhap"].ToString());
        }

        [Fact]
        public void LayThongTinTheoID_TraVeThongTinNguoiDungTheoID()
        {
            // Arrange
            int maNguoiDung = 1; 

            // Act
            QuanTriVienDTO ketQua = _dangNhapDAO.LayThongTinTheoID(maNguoiDung);

            // Assert
            Assert.NotNull(ketQua);
            Assert.Equal(maNguoiDung, ketQua.Id);
            Assert.False(string.IsNullOrEmpty(ketQua.HoVaTen)); 
            Assert.Equal("admin1", ketQua.TenDangNhap); 
        }
    }
}
