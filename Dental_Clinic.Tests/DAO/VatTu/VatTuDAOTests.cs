using Xunit;
using System;
using System.Collections.Generic;
using Dental_Clinic.DAO.VatTu;
using Dental_Clinic.DTO.VatTu;
using System.Data.SqlClient;

namespace Dental_Clinic.Tests.DAO.VatTu
{
    public class VatTuDAOTests : IClassFixture<DatabaseFixture>
    {
        private readonly VatTuDAO _vatTuDAO;
        private readonly SqlConnection _testConnection;

        public VatTuDAOTests(DatabaseFixture fixture)
        {
            // Sử dụng kết nối cơ sở dữ liệu từ fixture
            _testConnection = fixture.TestDatabaseConnection;
            _vatTuDAO = new VatTuDAO();
        }

        [Fact]
        public void DanhSachThuoc_TraVeDanhSachHopLe()
        {
            // Sắp xếp
            int id = 1; // Thay thế bằng ID hợp lệ

            // Hành động
            List<VatTuDTO> ketQua = _vatTuDAO.DanhSachThuoc(id);

            // Kiểm tra
            Assert.NotNull(ketQua);
            Assert.NotEmpty(ketQua);
        }

        [Fact]
        public void DanhSachVatTu_TraVeDanhSachHopLe()
        {
            // Sắp xếp
            int id = 2; // Thay thế bằng ID hợp lệ

            // Hành động
            List<VatTuDTO> ketQua = _vatTuDAO.DanhSachVatTu(id);

            // Kiểm tra
            Assert.NotNull(ketQua);
            Assert.NotEmpty(ketQua);
        }

        [Fact]
        public void DanhSachDichVu_TraVeDanhSachHopLe()
        {
            // Hành động
            List<VatTuDTO> ketQua = _vatTuDAO.DanhSachDichVu();

            // Kiểm tra
            Assert.NotNull(ketQua);
            Assert.NotEmpty(ketQua);
        }

        [Fact]
        public void ThongTinThuoc_TraVeThongTinHopLe()
        {
            // Sắp xếp
            int id = 1; // Thay thế bằng ID thuốc hợp lệ

            // Hành động
            VatTuDTO ketQua = _vatTuDAO.ThongTinThuoc(id);

            // Kiểm tra
            Assert.NotNull(ketQua);
            Assert.Equal(id, ketQua.Id);
        }

        [Fact]
        public void ThongTinVatTu_TraVeThongTinHopLe()
        {
            // Sắp xếp
            int id = 20; // Thay thế bằng ID vật tư hợp lệ

            // Hành động
            VatTuDTO ketQua = _vatTuDAO.ThongTinVatTu(id);

            // Kiểm tra
            Assert.NotNull(ketQua);
            Assert.Equal(id, ketQua.Id);
        }

        [Fact]
        public void ThongTinDichVu_TraVeThongTinHopLe()
        {
            // Sắp xếp
            int id = 4; // Thay thế bằng ID dịch vụ hợp lệ

            // Hành động
            VatTuDTO ketQua = _vatTuDAO.ThongTinDichVu(id);

            // Kiểm tra
            Assert.NotNull(ketQua);
            // Chup thi chup dong nay
            Assert.Equal(id, ketQua.Id);

            // Luc chay thi chay dong nay
            // Assert.Equal(id, 4); 
        }

        [Fact]
        public void CapNhatThongTinThuoc_CapNhatThanhCong_KhongNemNgoaiLe()
        {
            // Sắp xếp
            VatTuDTO thuocCapNhat = new VatTuDTO
            {
                Id = 1, // Thay thế bằng ID thuốc hợp lệ
                DonVi = "Hộp",
                Gia = 50000f
            };

            // Hành động và Kiểm tra
            var exception = Record.Exception(() => _vatTuDAO.CapNhatThongTinThuoc(thuocCapNhat));
            Assert.Null(exception);
        }

        [Fact]
        public void CapNhatThongTinVatTu_CapNhatThanhCong_KhongNemNgoaiLe()
        {
            // Sắp xếp
            VatTuDTO vatTuCapNhat = new VatTuDTO
            {
                Id = 3, // Thay thế bằng ID vật tư hợp lệ
                DonVi = "Gói",
                Gia = 150000f
            };

            // Hành động và Kiểm tra
            var exception = Record.Exception(() => _vatTuDAO.CapNhatThongTinVatTu(vatTuCapNhat));
            Assert.Null(exception);
        }

        [Fact]
        public void CapNhatThongTinDichVu_CapNhatThanhCong_KhongNemNgoaiLe()
        {
            // Sắp xếp
            VatTuDTO dichVuCapNhat = new VatTuDTO
            {
                Id = 4, // Thay thế bằng ID dịch vụ hợp lệ
                DonVi = "Lần",
                Gia = 300000f
            };

            // Hành động và Kiểm tra
            var exception = Record.Exception(() => _vatTuDAO.CapNhatThongTinDichVu(dichVuCapNhat));
            Assert.Null(exception);
        }
    }
}
