using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dental_Clinic.DTO.Admin;
using Dental_Clinic.BUS.Admin;
using System.Windows.Forms.DataVisualization.Charting;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class DashboardForm : Form
    {
        private QuanTriVienBUS quanTriVienBUS;
        public DashboardForm(MainForm mainForm)
        {
            InitializeComponent();
            quanTriVienBUS = new QuanTriVienBUS();

            lbBacSi.Text = quanTriVienBUS.SoLuongBacSi().ToString();
            lbBenhNhan.Text = quanTriVienBUS.SoLuongBenhNhan().ToString();
            lbDoanhThu.Text = quanTriVienBUS.TongLuong().ToString();
            LoadDoanhThuChartThang11();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadDoanhThuChartThang11()
        {
            panela.Controls.Clear();

            // Biểu đồ chênh lệch thu chi
            Chart chartChenhLech = new Chart();
            chartChenhLech.Size = new System.Drawing.Size(panela.Width, panela.Height);
            chartChenhLech.Dock = DockStyle.Fill; // Để biểu đồ tự động điều chỉnh kích thước theo panel

            // Tạo một ChartArea cho chênh lệch
            ChartArea chartAreaChenhLech = new ChartArea("ChenhLechArea");
            chartChenhLech.ChartAreas.Add(chartAreaChenhLech);

            // Tạo Series cho thu và chi
            Series seriesThu = new Series("Tiền thu");
            Series seriesChi = new Series("Tiền chi");

            seriesThu.ChartType = SeriesChartType.Column; // Biểu đồ cột cho thu
            seriesChi.ChartType = SeriesChartType.Column; // Biểu đồ cột cho chi
            seriesThu.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột thu
            seriesChi.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột chi

            // Dữ liệu cho tháng 11
            string month = "Tháng 10";
            decimal tienThu = 8000; // Giá trị tiền thu cho tháng 11
            decimal tienChi = 5000; // Giá trị tiền chi cho tháng 11

            // Thêm dữ liệu vào series
            seriesThu.Points.AddXY(month, tienThu);
            seriesChi.Points.AddXY(month, tienChi);

            // Thay đổi màu sắc cho các cột
            seriesThu.Color = Color.FromArgb(100, 181, 246); // Xanh nhạt
            seriesChi.Color = Color.FromArgb(255, 182, 193); // Hồng nhạt

            // Thêm series vào biểu đồ chênh lệch
            chartChenhLech.Series.Add(seriesThu);
            chartChenhLech.Series.Add(seriesChi);

            // Thêm tiêu đề cho biểu đồ chênh lệch
            chartChenhLech.Titles.Add("Chênh lệch thu chi tháng 10");

            // Thêm chú thích cho biểu đồ chênh lệch
            Legend legendChenhLech = new Legend("LegendChenhLech");
            chartChenhLech.Legends.Add(legendChenhLech);

            // Thêm biểu đồ vào panelTrangChu
            panela.Controls.Add(chartChenhLech);
        }

    }
}
