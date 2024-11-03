using Dental_Clinic.BUS.ThongKe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class FormThongKe : Form
    {
        private MainForm mainForm;
        private ThongKeBus thongKeBus;
        public FormThongKe(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            thongKeBus = new ThongKeBus();
            MessageBox.Show(thongKeBus.TienThuoc(new DateTime(2024, 10, 1)).ToString());
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.CustomFormat = "MM/yyyy";
            LoadDoanhThuChart();
        }

        private void LoadDoanhThuChart()
        {
            Chart chartThuChi = new Chart();

            // Đặt kích thước cho biểu đồ
            chartThuChi.Size = new System.Drawing.Size(panelThongKe.Width, panelThongKe.Height);
            chartThuChi.Dock = DockStyle.Fill; // Để biểu đồ tự động điều chỉnh kích thước theo panel

            // Tạo một ChartArea
            ChartArea chartArea = new ChartArea("MainArea");
            chartThuChi.ChartAreas.Add(chartArea);

            // Tạo Series cho thu
            Series seriesThu = new Series("Thu");
            seriesThu.ChartType = SeriesChartType.Column; // Loại biểu đồ cột
            seriesThu.IsValueShownAsLabel = true; // Hiển thị giá trị trên các cột

            // Tạo Series cho chi
            Series seriesChi = new Series("Chi");
            seriesChi.ChartType = SeriesChartType.Column; // Loại biểu đồ cột
            seriesChi.IsValueShownAsLabel = true; // Hiển thị giá trị trên các cột

            // Dữ liệu thu chi theo tháng (ví dụ)
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            decimal[] thu = { 3000, 3500, 4000, 4500, 4800, 5000, 6000, 5500, 7000, 7500, 8000, 9000 }; // Dữ liệu thu
            decimal[] chi = { 2500, 2000, 1500, 1800, 2200, 2300, 2700, 3000, 3200, 3500, 3700, 4000 }; // Dữ liệu chi

            // Thêm dữ liệu vào series thu và chi
            for (int i = 0; i < months.Length; i++)
            {
                seriesThu.Points.AddXY(months[i], thu[i]); // Thêm điểm dữ liệu cho thu
                seriesChi.Points.AddXY(months[i], chi[i]); // Thêm điểm dữ liệu cho chi
            }

            // Thêm series vào biểu đồ
            chartThuChi.Series.Add(seriesThu);
            chartThuChi.Series.Add(seriesChi);

            // Thêm biểu đồ vào panelThongKe
            panelThongKe.Controls.Add(chartThuChi);

            // Thêm tiêu đề cho biểu đồ
            chartThuChi.Titles.Add("Biểu đồ thu chi theo tháng");
        }
    }
}
