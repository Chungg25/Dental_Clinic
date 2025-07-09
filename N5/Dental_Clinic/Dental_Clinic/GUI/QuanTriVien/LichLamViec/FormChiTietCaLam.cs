using Dental_Clinic.BUS.LichLamViec;
using Dental_Clinic.DTO.ChamCong;
using System.Net.Mail;
using System.Net;

namespace Dental_Clinic.GUI.QuanTriVien.LichLamViec
{
    public partial class FormChiTietCaLam : Form
    {
        private LichLamViecBUS lichLamViecBUS;
        private int _id;
        private DateTime _day;
        public FormChiTietCaLam(int id, DateTime day)
        {
            InitializeComponent();
            lichLamViecBUS = new LichLamViecBUS();
            _id = id;
            _day = day;
            ChinhSua();
            HienThi(id, day);
        }

        public void HienThi(int id, DateTime day)
        {
            ChamCongDTO chamCongDTO = lichLamViecBUS.ChiTietLamViec(id, day);
            vbHoTen.Text = chamCongDTO.HoTen;
            vbEmail.Text = chamCongDTO.Email;
            vbSĐT.Text = chamCongDTO.SĐT;
            vbGioiTinh.Text = chamCongDTO.GioiTinh ? "Nam" : "Nữ";
            vbGioVao.Text = chamCongDTO.GioVao;
            vbGioRa.Text = chamCongDTO.GioRa;
            vbTrangThai.Text = chamCongDTO.GhiChu;
            vbQueQuan.Text = chamCongDTO.DiaChi;

            cbThayDoi.SelectedItem = chamCongDTO.Ca.ToString();

            if (string.IsNullOrEmpty(chamCongDTO.GhiChu))
            {

            }
            else if (chamCongDTO.GhiChu.Equals("làm việc đúng giờ", StringComparison.OrdinalIgnoreCase))
            {
                vbTrangThai.BackColor = ColorTranslator.FromHtml("#28a745");
                vbTrangThai.ForeColor = Color.White;
                vbTrangThai.Font = new Font(vbTrangThai.Font, FontStyle.Bold);
                vbTrangThai.BorderSize = 1;
                vbTrangThai.FlatAppearance.MouseOverBackColor = vbTrangThai.BackColor;
                vbTrangThai.FlatAppearance.MouseDownBackColor = vbTrangThai.BackColor;
            }
            else if (chamCongDTO.GhiChu.Equals("đi làm trễ", StringComparison.OrdinalIgnoreCase))
            {
                vbTrangThai.BackColor = ColorTranslator.FromHtml("#17a2b8");
                vbTrangThai.ForeColor = Color.White;
                vbTrangThai.Font = new Font(vbTrangThai.Font, FontStyle.Bold);
                vbTrangThai.BorderSize = 1;
                vbTrangThai.FlatAppearance.MouseOverBackColor = vbTrangThai.BackColor;
                vbTrangThai.FlatAppearance.MouseDownBackColor = vbTrangThai.BackColor;
            }
            else
            {
                vbTrangThai.BackColor = ColorTranslator.FromHtml("#dc3545");
                vbTrangThai.ForeColor = Color.White;
                vbTrangThai.Font = new Font(vbTrangThai.Font, FontStyle.Bold);
                vbTrangThai.BorderSize = 1;
                vbTrangThai.FlatAppearance.MouseOverBackColor = vbTrangThai.BackColor;
                vbTrangThai.FlatAppearance.MouseDownBackColor = vbTrangThai.BackColor;
            }

            DateTime today = DateTime.Now;

            if (day.AddDays(-2) < today.Date)
            {
                cbThayDoi.Enabled = false;
                cbThayDoi.SelectedItem = "Có";
                vbLuuThayDoi.Visible = false;
            }
        }

        private void ChinhSua()
        {
            vbHoTen.FlatStyle = FlatStyle.Flat;
            vbHoTen.FlatAppearance.BorderSize = 0;
            vbHoTen.FlatAppearance.MouseOverBackColor = vbHoTen.BackColor;
            vbHoTen.FlatAppearance.MouseDownBackColor = vbHoTen.BackColor;

            vbEmail.FlatStyle = FlatStyle.Flat;
            vbEmail.FlatAppearance.BorderSize = 0;
            vbEmail.FlatAppearance.MouseOverBackColor = vbEmail.BackColor;
            vbEmail.FlatAppearance.MouseDownBackColor = vbEmail.BackColor;

            vbSĐT.FlatStyle = FlatStyle.Flat;
            vbSĐT.FlatAppearance.BorderSize = 0;
            vbSĐT.FlatAppearance.MouseOverBackColor = vbSĐT.BackColor;
            vbSĐT.FlatAppearance.MouseDownBackColor = vbSĐT.BackColor;

            vbGioiTinh.BorderSize = 1;
            vbGioiTinh.BorderColor = Color.Black;
            vbGioiTinh.FlatAppearance.MouseOverBackColor = vbGioiTinh.BackColor;
            vbGioiTinh.FlatAppearance.MouseDownBackColor = vbGioiTinh.BackColor;

            vbGioVao.BorderSize = 1;
            vbGioVao.BorderColor = Color.Black;
            vbGioVao.FlatAppearance.MouseOverBackColor = vbGioVao.BackColor;
            vbGioVao.FlatAppearance.MouseDownBackColor = vbGioVao.BackColor;

            vbGioRa.BorderSize = 1;
            vbGioRa.BorderColor = Color.Black;
            vbGioRa.FlatAppearance.MouseOverBackColor = vbGioRa.BackColor;
            vbGioRa.FlatAppearance.MouseDownBackColor = vbGioRa.BackColor;

            vbTrangThai.BorderSize = 1;
            vbTrangThai.BorderColor = Color.Black;
            vbTrangThai.FlatAppearance.MouseOverBackColor = vbTrangThai.BackColor;
            vbTrangThai.FlatAppearance.MouseDownBackColor = vbTrangThai.BackColor;

            vbQueQuan.BorderSize = 1;
            vbQueQuan.BorderColor = Color.Black;
            vbQueQuan.FlatAppearance.MouseOverBackColor = vbQueQuan.BackColor;
            vbQueQuan.FlatAppearance.MouseDownBackColor = vbQueQuan.BackColor;

            cbThayDoi.Items.Add("1");
            cbThayDoi.Items.Add("2");
            cbThayDoi.Items.Add("Hủy");
            cbThayDoi.Items.Add("Có");
            
            cbThayDoi.FlatStyle = FlatStyle.Flat;

            vbThayDoi.BorderSize = 1;
            vbThayDoi.BorderColor = Color.Black;
            vbThayDoi.FlatAppearance.MouseOverBackColor = vbThayDoi.BackColor;
            vbThayDoi.FlatAppearance.MouseDownBackColor = vbThayDoi.BackColor;

            //foreach (Control control in panelChiTiet.Controls)
            //{
            //    if (control is Label label)
            //    {
            //        label.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            //    }
            //}
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            string trangThai = cbThayDoi.SelectedItem.ToString();
            if(trangThai.Equals("1") || trangThai.Equals("2"))
            {
                lichLamViecBUS.ThemLichLamViec(_id, int.Parse(trangThai), _day);
                string ca = cbThayDoi.SelectedItem.ToString();
                string thu = _day.ToString("dddd", new System.Globalization.CultureInfo("vi-VN"));
                GuiMail(vbEmail.Text, $"Thêm lịch làm việc vào ngày {_day.ToString("yyyy-MM-dd")} (Ca: {ca}, Thứ: {thu})");
            }
            else
            {
                lichLamViecBUS.XoaLichLamViec(_id, _day);
                string ca = cbThayDoi.SelectedItem.ToString();
                string thu = _day.ToString("dddd", new System.Globalization.CultureInfo("vi-VN"));
                GuiMail(vbEmail.Text, $"Hủy ca làm việc vào ngày {_day.ToString("yyyy-MM-dd")} (Ca: {ca}, Thứ: {thu})");
            }
        }

        private bool GuiMail(string MailPhanHoi, string tinNhan)
        {
            var fromAddress = new MailAddress("techcraft.n05@gmail.com", "TechCraft N05");
            var toAddress = new MailAddress(MailPhanHoi); 
            const string fromPassword = "qbno mjeq fpyp zhng";
            const string subject = "Thông báo lịch làm việc";
            // Định dạng lại nội dung email với HTML
            string body = $@"
            <html>
                <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333; padding: 20px;'>
                    <h2 style='color: #333;'>Thông báo thay đổi lịch làm việc</h2>
                    <p style='font-size: 14px;'>Xin chào,</p>
                    <p style='font-size: 14px;'>Lịch làm việc của bạn đã được thay đổi.</p>
                    <p style='font-size: 14px'>
                        Vui lòng kiểm tra lại lịch làm việc mới của bạn:
                    </p>
                    <p style='font-size: 20px; font-weight: bold; color: #ff0000'>
                        {tinNhan}
                    </p>
                    <p style='font-size: 14px'>
                        Nếu bạn có bất kỳ câu hỏi nào, hãy liên hệ với chúng tôi.
                    </p
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
                //MessageBox.Show(tinNhan);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
    }
}
