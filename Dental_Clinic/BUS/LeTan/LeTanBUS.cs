using Dental_Clinic.DAO.LeTan;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.HoaDon;
using Dental_Clinic.DTO.LichHen;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.IO.Font;
using iText.Kernel.Font;
using Dental_Clinic.DTO.Luong;

namespace Dental_Clinic.BUS.LeTan
{
    public class LeTanBUS
    {
        private LeTanDAO _leTanDAO;

        public LeTanBUS()
        {
            this._leTanDAO = new LeTanDAO();
        }
        // Lấy danh sách lịch hẹn theo ngày
        public List<BacSiDTO> LayThongTinBacSiTrongNgay(string ngayHienTai)
        {
            return _leTanDAO.LayThongTinBacSiTrongNgay(ngayHienTai);
        }
        // Lấy danh sách lịch hẹn theo ngày
        public List<LichHenDTO> LayDanhSachLichHenTheoNgay(string ngayHienTai)
        {
            return _leTanDAO.LayDanhSachLichHenTheoNgay(ngayHienTai);
        }
        // Thêm lịch hẹn
        public bool ThemLichHen(LichHenDTO lichHenDTO)
        {
            return _leTanDAO.ThemLichHen(lichHenDTO);
        }
        // Lấy thông tin bệnh nhân và bệnh án theo mã bệnh nhân
        public BenhNhanDTO LayThongTinBenhNhanVaBenhAnTheoMa(int maBenhNhan)
        {
            return _leTanDAO.LayThongTinBenhNhanVaBenhAnTheoMa(maBenhNhan);
        }
        // Cập nhật thông tin bệnh nhân và bệnh án theo mã bệnh nhân
        public bool CapNhatThongTinBenhNhanVaBenhAn(BenhNhanDTO benhNhan)
        {
            return _leTanDAO.CapNhatThongTinBenhNhanVaBenhAn(benhNhan);
        }
        // Hiển thị danh sách bệnh nhân chưa thanh toán
        public List<BenhNhanDTO> LayDanhSachBenhNhanChuaThanhToan(string ngayHienTai)
        {
            return _leTanDAO.LayDanhSachBenhNhanChuaThanhToan(ngayHienTai);
        }
        // Lấy thông tin bệnh nhân theo mã bệnh nhân
        public BenhNhanDTO LayThongTinBenhNhan(int maBenhNhan)
        {
            return _leTanDAO.LayThongTinBenhNhan(maBenhNhan);
        }
        // Lấy chi tiết hóa đơn theo mã bệnh nhân
        public List<HoaDonDTO> LayChiTietHoaDonBenhNhan(int maBenhNhan)
        {
            return _leTanDAO.LayChiTietHoaDonBenhNhan(maBenhNhan);
        }
        // Cập nhật trạng thái thanh toán của bệnh nhân
        public bool CapNhatTrangThaiHoaDon(int maHoaDon, int phuongThucThanhToan, float tongTien)
        {
            return _leTanDAO.CapNhatTrangThaiHoaDon(maHoaDon, phuongThucThanhToan, tongTien);
        }
        // Xuất hoá đơn pdf
        public void XuatHoaDonPDF(BenhNhanDTO benhNhan, List<HoaDonDTO> hoaDons)
        {
            // Sử dụng SaveFileDialog để cho phép người dùng chọn vị trí lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Lưu hóa đơn PDF";
                saveFileDialog.FileName = $"HoaDon_{benhNhan.HoVaTen}_{DateTime.Now:yyyyMMdd}.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                // Đường dẫn file được chọn bởi người dùng
                string filePath = saveFileDialog.FileName;

                // Khởi tạo file PDF
                using (var pdfWriter = new PdfWriter(filePath))
                using (var pdfDoc = new PdfDocument(pdfWriter))
                using (var doc = new Document(pdfDoc))
                {
                    // Sử dụng font hỗ trợ tiếng Việt
                    PdfFont font = PdfFontFactory.CreateFont("c:/windows/fonts/arial.ttf", PdfEncodings.IDENTITY_H);
                    doc.SetFont(font);

                    // Tiêu đề hóa đơn
                    doc.Add(new Paragraph("HÓA ĐƠN THANH TOÁN")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(18)
                        .SetBold());

                    doc.Add(new Paragraph("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy"))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetFontSize(10)
                        .SetMarginBottom(20));

                    // Thông tin bệnh nhân
                    doc.Add(new Paragraph("Thông tin bệnh nhân")
                        .SetBold()
                        .SetFontSize(14));

                    doc.Add(new Paragraph($"Mã bệnh nhân: {benhNhan.Id}"));
                    doc.Add(new Paragraph($"Tên bệnh nhân: {benhNhan.HoVaTen}"));
                    doc.Add(new Paragraph($"Tuổi: {benhNhan.Tuoi}"));
                    doc.Add(new Paragraph($"Giới tính: {(benhNhan.GioiTinh ? "Nam" : "Nữ")}"));
                    doc.Add(new Paragraph($"Số điện thoại: {benhNhan.SDT}"));
                    doc.Add(new Paragraph($"Bác sĩ phụ trách: {benhNhan.TenBacSi}"));
                    doc.Add(new Paragraph($"Ca làm việc: {benhNhan.Ca}"));
                    doc.Add(new Paragraph($"Trạng thái khám: {benhNhan.TrangThaiKham}"));

                    doc.Add(new Paragraph("\n"));

                    // Bảng chi tiết hóa đơn
                    doc.Add(new Paragraph("Chi tiết thanh toán").SetBold().SetFontSize(14));

                    Table table = new Table(5, true);
                    table.AddHeaderCell(new Paragraph("Loại mục").SetFont(font));
                    table.AddHeaderCell(new Paragraph("Tên mục").SetFont(font));
                    table.AddHeaderCell(new Paragraph("Số lượng").SetFont(font));
                    table.AddHeaderCell(new Paragraph("Đơn giá").SetFont(font));
                    table.AddHeaderCell(new Paragraph("Thành tiền").SetFont(font));

                    decimal tongTien = 0;
                    foreach (var hoaDon in hoaDons)
                    {
                        table.AddCell(new Paragraph(hoaDon.LoaiMuc).SetFont(font));
                        table.AddCell(new Paragraph(hoaDon.TenMuc).SetFont(font));
                        table.AddCell(new Paragraph(hoaDon.SoLuong.ToString()).SetFont(font));
                        table.AddCell(new Paragraph(hoaDon.DonGia.ToString("C")).SetFont(font));
                        table.AddCell(new Paragraph(hoaDon.ThanhTien.ToString("C")).SetFont(font));
                        tongTien += (decimal)hoaDon.ThanhTien;
                    }

                    doc.Add(table);

                    // Tổng tiền thanh toán
                    doc.Add(new Paragraph($"\nTổng tiền thanh toán: {tongTien:C}")
                        .SetBold()
                        .SetFontSize(14)
                        .SetFontColor(ColorConstants.RED));

                    // Lời cảm ơn
                    doc.Add(new Paragraph("\nXin cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi!")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetItalic()
                        .SetFontSize(10)
                        .SetFont(font));
                }

                // Thông báo hoàn tất xuất file PDF
                MessageBox.Show($"Hóa đơn đã được xuất thành công tại {filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Lấy thông tin lương
        public LuongDTO LayThongTinLuong(int maLeTan, int thang, int nam)
        {
            return _leTanDAO.LayThongTinLuong(maLeTan, thang, nam);
        }
    }
}
