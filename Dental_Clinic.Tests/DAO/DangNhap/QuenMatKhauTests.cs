using Xunit;
using Dental_Clinic.DAO.Login;
using System.Data.SqlClient;

namespace Dental_Clinic.Tests.DAO.DangNhap
{
    public class QuenMatKhauTests
    {
        private readonly QuenMatKhauDAO _quenMatKhauDAO;

        public QuenMatKhauTests()
        {
            _quenMatKhauDAO = new QuenMatKhauDAO();
        }

        [Fact]
        public void DangNhapDAO_KiemTraTenDangNhap_TrueNeuTonTaiNguocLaiFalse()
        {
            // Arrange
            string tenDangNhapDung = "doctor1";
            string tenDangNhapSai = "abcxyz12341324";

            // Act
            bool resultTrue = _quenMatKhauDAO.KiemTraTenDangNhap(tenDangNhapDung);
            bool resultFalse = _quenMatKhauDAO.KiemTraTenDangNhap(tenDangNhapSai);

            // Assert
            Assert.True(resultTrue);
            Assert.False(resultFalse);
        }

        [Fact]
        public void QuenMatKhauDAO_KiemTraEmailTonTai_TrueNeuTonTaiNguocLaiFalse()
        {
            // Arrange
            string emailDung = "admin1@gmail.com";
            string emailSai = "emailSaiDuDanLuon@example.com"; 

            // Act
            bool ketQuaDung = _quenMatKhauDAO.KiemTraMail(emailDung);
            bool ketQuaSai = _quenMatKhauDAO.KiemTraMail(emailSai);

            // Assert
            Assert.True(ketQuaDung);
            Assert.False(ketQuaSai);
        }

        [Fact]
        public void QuenMatKhauDAO_MatKhau_TraVeMatKhau()
        {
            // Arrange
            string email = "admin1@gmail.com"; 
            string tenDangNhap = "admin1";

            // Act
            string matKhau = _quenMatKhauDAO.MatKhau(email, tenDangNhap);

            // Assert
            Assert.NotNull(matKhau);
            Assert.Equal("pass123", matKhau); 
        }
    }
}
