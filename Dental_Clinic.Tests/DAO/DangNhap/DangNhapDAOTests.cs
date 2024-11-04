using Xunit;
using System.Data;
using Dental_Clinic.DAO.Login;
using Dental_Clinic.DTO.Login;
using Dental_Clinic.DTO.Admin;
using System.Data.SqlClient;

// TODO: Viet test kieu gi bay gio ???
namespace Dental_Clinic.Tests.DAO.DangNhap
{
    public class DangNhapDAOIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly SqlConnection _ketNoiKiemThu;
        private readonly DangNhapDAO _dangNhapDAO;

        public DangNhapDAOIntegrationTests(DatabaseFixture fixture)
        {
            _ketNoiKiemThu = fixture.TestDatabaseConnection;
            _dangNhapDAO = new DangNhapDAO();
        }

        [Fact]
        public void KiemTraDangNhap_ThongTinHopLe_TraVeDuLieuNguoiDung()
        {
            // Sắp xếp
            var thongTinDangNhap = new DangNhapDTO
            {
                TenDangNhap = "admin1",  // Thay bằng tên đăng nhập hợp lệ trong cơ sở dữ liệu kiểm thử
                Matkhau = "pass123"           // Thay bằng mật khẩu hợp lệ trong cơ sở dữ liệu kiểm thử
            };

            // Thực hiện
            DataRow ketQua = _dangNhapDAO.KiemTraDangNhap(thongTinDangNhap);

            // Kiểm tra
            Assert.NotNull(ketQua);
            Assert.Equal(thongTinDangNhap.TenDangNhap, ketQua["ten_dang_nhap"].ToString());
        }

        [Fact]
        public void KiemTraDangNhap_ThongTinKhongHopLe_TraVeNull()
        {
            // Sắp xếp
            var thongTinDangNhap = new DangNhapDTO
            {
                TenDangNhap = "tenDangNhapSai",
                Matkhau = "matKhauSai"
            };

            // Thực hiện
            DataRow ketQua = _dangNhapDAO.KiemTraDangNhap(thongTinDangNhap);

            // Kiểm tra
            Assert.Null(ketQua); // Kỳ vọng kết quả null vì thông tin đăng nhập không hợp lệ
        }

        [Fact]
        public void LayThongTinTheoID_TraVeThongTinNguoiDungTheoID()
        {
            // Sắp xếp
            int maNguoiDung = 1; // Thay bằng mã người dùng hợp lệ có trong cơ sở dữ liệu kiểm thử

            // Thực hiện
            QuanTriVienDTO ketQua = _dangNhapDAO.LayThongTinTheoID(maNguoiDung);

            // Kiểm tra
            Assert.NotNull(ketQua);
            Assert.Equal(maNguoiDung, ketQua.Id);
            Assert.False(string.IsNullOrEmpty(ketQua.HoVaTen)); // Kiểm tra xem họ và tên có giá trị
            Assert.Equal("admin1", ketQua.TenDangNhap); // Thay bằng tên đăng nhập mong đợi
        }
    }
}
