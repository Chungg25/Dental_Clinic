using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomButton;

namespace Dental_Clinic.GUI.Login
{
    public partial class ForgotPassword : Form
    {
        private Dental_Clinic mainForm;
        public ForgotPassword(Dental_Clinic mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            CustomizeButton(btnGuiMa); // Bo góc cho btnGuiMa
            CustomizeButton(btnXacNhan); // Bo góc cho btnXacNhan
        }

        private void CustomizeButton(Button button)
        {
            // Sự kiện Paint cho nút để bo góc
            button.Paint += (s, e) =>
            {
                // Đặt bán kính bo góc
                int borderRadius = 30;

                // Tạo đường viền bo góc
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.StartFigure();
                    path.AddArc(0, 0, borderRadius, borderRadius, 180, 90); // Góc trên bên trái
                    path.AddArc(button.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90); // Góc trên bên phải
                    path.AddArc(button.Width - borderRadius, button.Height - borderRadius, borderRadius, borderRadius, 0, 90); // Góc dưới bên phải
                    path.AddArc(0, button.Height - borderRadius, borderRadius, borderRadius, 90, 90); // Góc dưới bên trái
                    path.CloseFigure();
                    button.Region = new Region(path);
                }

                // Thiết lập màu nền và màu chữ
                button.BackColor = Color.FromArgb(0, 89, 253); // Màu nền theo RGB (0, 89, 253)
                button.ForeColor = Color.White; // Màu chữ
            };
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }

        private void picBack_Click(object sender, EventArgs e)
        {
            mainForm.ShowLoginFormInPanel();
        }
    }
}
