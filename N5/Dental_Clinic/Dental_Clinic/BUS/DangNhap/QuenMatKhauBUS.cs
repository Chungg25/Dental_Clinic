using Dental_Clinic.DAO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.Login
{
    public class QuenMatKhauBUS
    {
        private QuenMatKhauDAO forgotPasswordDAO;

        public QuenMatKhauBUS()
        {
            this.forgotPasswordDAO = new QuenMatKhauDAO();
        }
        // Kiểm tra username có tồn tại trong database không
        public bool KiemTraTenDangNhap(string tenDangNhap)
        {
            return forgotPasswordDAO.KiemTraTenDangNhap(tenDangNhap);
        }
        // Kiểm tra email có tồn tại trong database không
        public bool KiemTraMail(string email)
        {
            return forgotPasswordDAO.KiemTraMail(email);
        }
        // Hàm tạo mã code
        public string TaoCode()
        {
            Random random = new Random();
            string code = "";
            for (int i = 0; i < 6; i++)
            {
                code += random.Next(0, 9).ToString();
            }
            return code;
        }
        // Hàm gửi mã code đến email
        public bool GuiXacThucDenMail(string MailPhanHoi, string CodeXacThuc)
        {
            var fromAddress = new MailAddress("techcraft.n05@gmail.com", "TechCraft N05");
            var toAddress = new MailAddress(MailPhanHoi);
            const string fromPassword = "qbno mjeq fpyp zhng";
            const string subject = "Mã xác nhận của bạn";

            // Định dạng lại nội dung email với HTML
            string body = $@"
            <html>
              <body>
                <h2 style='color: #333;'>Xin chào,</h2>
                <p style='font-size: 14px;'>Mã xác nhận của bạn là:</p>
                <p style='font-size: 20px; font-weight: bold; color: #4CAF50;'>{CodeXacThuc}</p>
                <p>Nếu bạn không yêu cầu mã này, hãy bỏ qua email này.</p>
                <br />  
                <p>Trân trọng,</p>
                <p>Đội ngũ hỗ trợ</p>
              </body>
            </html>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        // Lấy mật khẩu từ mail và username
        public string LayMatKhau(string email, string tenDangNhap)
        {
            return forgotPasswordDAO.MatKhau(email, tenDangNhap);
        }
    }
}
