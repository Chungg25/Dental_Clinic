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
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.CustomFormat = "MM/yyyy";
            LoadDoanhThuChartThang11();

            dtpNgay.ValueChanged += DtpNgay_ValueChanged;

            vbThongKeDoanhThu.FlatStyle = FlatStyle.Flat;
            vbThongKeDoanhThu.FlatAppearance.BorderSize = 0;
            vbThongKeDoanhThu.FlatAppearance.MouseOverBackColor = vbThongKeDoanhThu.BackColor;
            vbThongKeDoanhThu.FlatAppearance.MouseDownBackColor = vbThongKeDoanhThu.BackColor;

            vbThongKeBenh.FlatStyle = FlatStyle.Flat;
            vbThongKeBenh.FlatAppearance.BorderSize = 0;
            vbThongKeBenh.FlatAppearance.MouseOverBackColor = vbThongKeBenh.BackColor;
            vbThongKeBenh.FlatAppearance.MouseDownBackColor = vbThongKeBenh.BackColor;
        }

        private void DtpNgay_ValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị mới của dtpNgay
            DateTime selectedDate = dtpNgay.Value;
            bool hasThuChi = panelThongKe.Controls.OfType<Chart>().Any(c => c.Name == "ThuChi");

            if (selectedDate.Month == 11) // Kiểm tra nếu tháng là 11
            {
                if (hasThuChi)
                {
                    LoadDoanhThuChartThang11();
                }
                else
                {
                    VeBieuDoMatBenh();
                }
            }
            else
            {
                if (hasThuChi)
                {
                    LoadDoanhThuChartThang10();
                }
                else
                {
                    VeBieuDoMatBenhThang10();
                }
            }
        }

        private void LoadDoanhThuChartThang11()
        {
            panelThongKe.Controls.Clear();

            // Biểu đồ chênh lệch thu chi
            Chart chartChenhLech = new Chart();
            chartChenhLech.Size = new System.Drawing.Size(panelThongKe.Width, panelThongKe.Height / 2);
            chartChenhLech.Dock = DockStyle.Top; // Để biểu đồ tự động điều chỉnh kích thước theo panel

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
            string month = "Tháng 11";
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
            chartChenhLech.Titles.Add("Chênh lệch thu chi tháng 11");

            // Thêm chú thích cho biểu đồ chênh lệch
            Legend legendChenhLech = new Legend("LegendChenhLech");
            chartChenhLech.Legends.Add(legendChenhLech);

            // Biểu đồ chi tiết chi tiền thuốc, vật tư
            Chart chartChiTiet = new Chart();
            chartChiTiet.Size = new System.Drawing.Size(panelThongKe.Width, panelThongKe.Height / 2);
            chartChiTiet.Dock = DockStyle.Bottom; // Để biểu đồ tự động điều chỉnh kích thước theo panel

            // Tạo một ChartArea cho chi tiết
            ChartArea chartAreaChiTiet = new ChartArea("ChiTietArea");
            chartChiTiet.ChartAreas.Add(chartAreaChiTiet);

            // Tạo Series cho chi tiết
            Series seriesThuoc = new Series("Tiền thuốc");
            Series seriesVatTu = new Series("Tiền vật tư");
            Series seriesDoanhThu = new Series("Doanh thu");

            seriesThuoc.ChartType = SeriesChartType.Column; // Biểu đồ cột cho tiền thuốc
            seriesVatTu.ChartType = SeriesChartType.Column; // Biểu đồ cột cho tiền vật tư
            seriesDoanhThu.ChartType = SeriesChartType.Column; // Biểu đồ cột cho doanh thu
            seriesThuoc.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột tiền thuốc
            seriesVatTu.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột tiền vật tư
            seriesDoanhThu.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột doanh thu

            // Dữ liệu cho chi tiết
            decimal tienThuoc = 2000; // Giá trị tiền thuốc
            decimal tienVatTu = 1500; // Giá trị tiền vật tư
            decimal doanhThu = tienThu - tienChi; // Doanh thu tính từ chênh lệch

            // Thêm dữ liệu vào series
            seriesThuoc.Points.AddXY(month, tienThuoc);
            seriesVatTu.Points.AddXY(month, tienVatTu);
            seriesDoanhThu.Points.AddXY(month, doanhThu);

            // Thay đổi màu sắc cho các cột chi tiết
            seriesThuoc.Color = Color.FromArgb(198, 225, 165); // Xanh lá nhạt
            seriesVatTu.Color = Color.FromArgb(255, 239, 153); // Vàng nhạt
            seriesDoanhThu.Color = Color.FromArgb(204, 153, 255); // Tím nhạt

            // Thêm series vào biểu đồ chi tiết
            chartChiTiet.Series.Add(seriesThuoc);
            chartChiTiet.Series.Add(seriesVatTu);
            chartChiTiet.Series.Add(seriesDoanhThu);

            // Thêm tiêu đề cho biểu đồ chi tiết
            chartChiTiet.Titles.Add("Chi tiết chi tiêu tháng 11");

            // Thêm chú thích cho biểu đồ chi tiết
            Legend legendChiTiet = new Legend("LegendChiTiet");
            chartChiTiet.Legends.Add(legendChiTiet);


            chartChiTiet.Name = "ThuChi";
            // Thêm biểu đồ vào panelThongKe
            panelThongKe.Controls.Add(chartChenhLech);
            panelThongKe.Controls.Add(chartChiTiet);
        }

        private void LoadDoanhThuChartThang10()
        {
            panelThongKe.Controls.Clear();

            // Biểu đồ chênh lệch thu chi
            Chart chartChenhLech = new Chart();
            chartChenhLech.Size = new System.Drawing.Size(panelThongKe.Width, panelThongKe.Height / 2);
            chartChenhLech.Dock = DockStyle.Top; // Để biểu đồ tự động điều chỉnh kích thước theo panel

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

            // Dữ liệu cho tháng 10
            string month = "Tháng 10";
            decimal tienThu = 7000; // Giá trị tiền thu cho tháng 10
            decimal tienChi = 4000; // Giá trị tiền chi cho tháng 10

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

            // Biểu đồ chi tiết chi tiền thuốc, vật tư
            Chart chartChiTiet = new Chart();
            chartChiTiet.Size = new System.Drawing.Size(panelThongKe.Width, panelThongKe.Height / 2);
            chartChiTiet.Dock = DockStyle.Bottom; // Để biểu đồ tự động điều chỉnh kích thước theo panel

            // Tạo một ChartArea cho chi tiết
            ChartArea chartAreaChiTiet = new ChartArea("ChiTietArea");
            chartChiTiet.ChartAreas.Add(chartAreaChiTiet);

            // Tạo Series cho chi tiết
            Series seriesThuoc = new Series("Tiền thuốc");
            Series seriesVatTu = new Series("Tiền vật tư");
            Series seriesDoanhThu = new Series("Doanh thu");

            seriesThuoc.ChartType = SeriesChartType.Column; // Biểu đồ cột cho tiền thuốc
            seriesVatTu.ChartType = SeriesChartType.Column; // Biểu đồ cột cho tiền vật tư
            seriesDoanhThu.ChartType = SeriesChartType.Column; // Biểu đồ cột cho doanh thu
            seriesThuoc.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột tiền thuốc
            seriesVatTu.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột tiền vật tư
            seriesDoanhThu.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột doanh thu

            // Dữ liệu cho chi tiết tháng 10
            decimal tienThuoc = 2500; // Giá trị tiền thuốc cho tháng 10
            decimal tienVatTu = 2000; // Giá trị tiền vật tư cho tháng 10
            decimal doanhThu = tienThu - tienChi; // Doanh thu tính từ chênh lệch

            // Thêm dữ liệu vào series
            seriesThuoc.Points.AddXY(month, tienThuoc);
            seriesVatTu.Points.AddXY(month, tienVatTu);
            seriesDoanhThu.Points.AddXY(month, doanhThu);

            // Thay đổi màu sắc cho các cột chi tiết
            seriesThuoc.Color = Color.FromArgb(198, 225, 165); // Xanh lá nhạt
            seriesVatTu.Color = Color.FromArgb(255, 239, 153); // Vàng nhạt
            seriesDoanhThu.Color = Color.FromArgb(204, 153, 255); // Tím nhạt

            // Thêm series vào biểu đồ chi tiết
            chartChiTiet.Series.Add(seriesThuoc);
            chartChiTiet.Series.Add(seriesVatTu);
            chartChiTiet.Series.Add(seriesDoanhThu);

            // Thêm tiêu đề cho biểu đồ chi tiết
            chartChiTiet.Titles.Add("Chi tiết chi tiêu tháng 10");

            // Thêm chú thích cho biểu đồ chi tiết
            Legend legendChiTiet = new Legend("LegendChiTiet");
            chartChiTiet.Legends.Add(legendChiTiet);

            chartChiTiet.Name = "ThuChi";

            // Thêm biểu đồ vào panelThongKe
            panelThongKe.Controls.Add(chartChenhLech);
            panelThongKe.Controls.Add(chartChiTiet);
        }

        private void vbThongKeBenh_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpNgay.Value;

            if (selectedDate.Month == 11) // Kiểm tra nếu tháng là 11
            {
                VeBieuDoMatBenh();
            }
            else
            {
                VeBieuDoMatBenhThang10();
            }
        }

        private void VeBieuDoMatBenh()
        {
            // Danh sách các loại mặt bệnh
            var matBenh = new List<string>
    {
        "Khám - Hồ sơ",
        "Nhổ răng",
        "Nha chu",
        "Chữa răng - Nội nha",
        "Phục hình tháo lắp",
        "Phục hình cố định",
        "Điều trị răng sữa",
        "Chỉnh hình răng mặt",
        "Nha công cộng",
        "Điều trị loạn năng hệ thống nhai",
        "X-Quang răng",
        "Cấy ghép Implant",
        "Phục hình đơn lẻ",
        "Phục hình bắt vít"
    };

            // Giá trị giả định cho số lượng bệnh nhân
            var soLuong = new List<int>
    {
        20, // Khám - Hồ sơ
        15, // Nhổ răng
        10, // Nha chu
        5,  // Chữa răng - Nội nha
        8,  // Phục hình tháo lắp
        12, // Phục hình cố định
        7,  // Điều trị răng sữa
        4,  // Chỉnh hình răng mặt
        9,  // Nha công cộng
        3,  // Điều trị loạn năng hệ thống nhai
        11, // X-Quang răng
        6,  // Cấy ghép Implant
        14, // Phục hình đơn lẻ
        5   // Phục hình bắt vít
    };

            int total = soLuong.Sum(); // Tính tổng số lượng
            var threshold = total * 0.05; // Ngưỡng 10%

            List<string> finalLabels = new List<string>();
            List<int> finalValues = new List<int>();

            int otherCount = 0;

            // Tính toán giá trị và phân loại
            for (int i = 0; i < matBenh.Count; i++)
            {
                if (soLuong[i] < threshold)
                {
                    otherCount += soLuong[i]; // Cộng dồn số lượng cho phần "Khác"
                }
                else
                {
                    finalLabels.Add(matBenh[i]);
                    finalValues.Add(soLuong[i]);
                }
            }

            // Thêm phần "Khác" nếu có
            if (otherCount > 0)
            {
                finalLabels.Add("Khác");
                finalValues.Add(otherCount);
            }

            // Vẽ biểu đồ
            Chart chartMatBenh = new Chart
            {
                Dock = DockStyle.Fill
            };

            // Tạo ChartArea
            ChartArea chartArea = new ChartArea("MainArea");
            chartMatBenh.ChartAreas.Add(chartArea);

            // Tạo Series cho biểu đồ tròn
            Series series = new Series("MatBenh")
            {
                ChartType = SeriesChartType.Pie, // Biểu đồ tròn
                IsValueShownAsLabel = true, // Hiển thị giá trị
                Label = "#VALY{0.##}", // Hiển thị giá trị và tên phần
                LegendText = "#VALX" // Hiển thị tên bệnh
            };

            // Màu sắc cho từng phần
            Color[] colors = new Color[]
            {
        Color.Red,
        Color.Blue,
        Color.Green,
        Color.Orange,
        Color.Purple,
        Color.Brown,
        Color.Yellow,
        Color.Cyan,
        Color.Magenta,
        Color.Lime,
        Color.Teal,
        Color.Pink,
        Color.Gray,
        Color.LightGreen
            };

            // Thêm dữ liệu vào series và chỉ định màu sắc
            for (int i = 0; i < finalLabels.Count; i++)
            {
                series.Points.AddXY(finalLabels[i], finalValues[i]);
                series.Points[i].Color = colors[i % colors.Length]; // Gán màu sắc cho từng phần
            }

            // Thêm series vào biểu đồ
            chartMatBenh.Series.Add(series);
            chartMatBenh.Name = "MatBenh";

            // Thêm biểu đồ vào panelThongKe
            panelThongKe.Controls.Clear();
            panelThongKe.Controls.Add(chartMatBenh);

            // Thêm tiêu đề cho biểu đồ
            chartMatBenh.Titles.Add("Thống Kê Mặt Bệnh Tháng 11");


            // Thêm chú thích cho phần "Khác"
            if (otherCount > 0)
            {
                chartMatBenh.Legends.Add(new Legend("Legend")
                {
                    Docking = Docking.Right, // Đặt vị trí chú thích bên phải
                    IsTextAutoFit = true // Tự động điều chỉnh kích thước văn bản
                });
            }
        }

        private void VeBieuDoMatBenhThang10()
        {
            // Danh sách các loại mặt bệnh
            var matBenh = new List<string>
    {
        "Khám - Hồ sơ",
        "Nhổ răng",
        "Nha chu",
        "Chữa răng - Nội nha",
        "Phục hình tháo lắp",
        "Phục hình cố định",
        "Điều trị răng sữa",
        "Chỉnh hình răng mặt",
        "Nha công cộng",
        "Điều trị loạn năng hệ thống nhai",
        "X-Quang răng",
        "Cấy ghép Implant",
        "Phục hình đơn lẻ",
        "Phục hình bắt vít"
    };

            // Giá trị giả định cho số lượng bệnh nhân tháng 10
            var soLuong = new List<int>
    {
        25, // Khám - Hồ sơ
        20, // Nhổ răng
        15, // Nha chu
        8,  // Chữa răng - Nội nha
        12, // Phục hình tháo lắp
        10, // Phục hình cố định
        6,  // Điều trị răng sữa
        4,  // Chỉnh hình răng mặt
        11, // Nha công cộng
        3,  // Điều trị loạn năng hệ thống nhai
        9,  // X-Quang răng
        7,  // Cấy ghép Implant
        10, // Phục hình đơn lẻ
        2   // Phục hình bắt vít
    };

            int total = soLuong.Sum(); // Tính tổng số lượng
            var threshold = total * 0.05; // Ngưỡng 5%

            List<string> finalLabels = new List<string>();
            List<int> finalValues = new List<int>();

            int otherCount = 0;

            // Tính toán giá trị và phân loại
            for (int i = 0; i < matBenh.Count; i++)
            {
                if (soLuong[i] < threshold)
                {
                    otherCount += soLuong[i]; // Cộng dồn số lượng cho phần "Khác"
                }
                else
                {
                    finalLabels.Add(matBenh[i]);
                    finalValues.Add(soLuong[i]);
                }
            }

            // Thêm phần "Khác" nếu có
            if (otherCount > 0)
            {
                finalLabels.Add("Khác");
                finalValues.Add(otherCount);
            }

            // Vẽ biểu đồ
            Chart chartMatBenh = new Chart
            {
                Dock = DockStyle.Fill
            };

            // Tạo ChartArea
            ChartArea chartArea = new ChartArea("MainArea");
            chartMatBenh.ChartAreas.Add(chartArea);

            // Tạo Series cho biểu đồ tròn
            Series series = new Series("MatBenh")
            {
                ChartType = SeriesChartType.Pie, // Biểu đồ tròn
                IsValueShownAsLabel = true, // Hiển thị giá trị
                Label = "#VALY{0.##}", // Hiển thị giá trị và tên phần
                LegendText = "#VALX" // Hiển thị tên bệnh
            };

            // Màu sắc cho từng phần
            Color[] colors = new Color[]
            {
        Color.FromArgb(255, 99, 71), // Tomato
        Color.FromArgb(135, 206, 235), // Sky Blue
        Color.FromArgb(60, 179, 113), // Medium Sea Green
        Color.FromArgb(255, 215, 0), // Gold
        Color.FromArgb(153, 50, 204), // Dark Orchid
        Color.FromArgb(139, 69, 19), // Saddle Brown
        Color.FromArgb(255, 140, 0), // Dark Orange
        Color.FromArgb(30, 144, 255), // Dodger Blue
        Color.FromArgb(255, 192, 203), // Pink
        Color.FromArgb(50, 205, 50), // Lime Green
        Color.FromArgb(72, 61, 139), // Dark Slate Blue
        Color.FromArgb(211, 211, 211), // Light Gray
        Color.FromArgb(144, 238, 144), // Light Green
        Color.FromArgb(238, 130, 238) // Violet
            };

            // Thêm dữ liệu vào series và chỉ định màu sắc
            for (int i = 0; i < finalLabels.Count; i++)
            {
                series.Points.AddXY(finalLabels[i], finalValues[i]);
                series.Points[i].Color = colors[i % colors.Length]; // Gán màu sắc cho từng phần
            }

            // Thêm series vào biểu đồ
            chartMatBenh.Series.Add(series);
            chartMatBenh.Name = "MatBenh";

            // Thêm biểu đồ vào panelThongKe
            panelThongKe.Controls.Clear();
            panelThongKe.Controls.Add(chartMatBenh);

            // Thêm tiêu đề cho biểu đồ
            chartMatBenh.Titles.Add("Thống Kê Mặt Bệnh Tháng 10");

            // Thêm chú thích cho phần "Khác"
            if (otherCount > 0)
            {
                chartMatBenh.Legends.Add(new Legend("Legend")
                {
                    Docking = Docking.Right, // Đặt vị trí chú thích bên phải
                    IsTextAutoFit = true // Tự động điều chỉnh kích thước văn bản
                });
            }
        }


        private void vbThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpNgay.Value;
            if (selectedDate.Month == 11) // Kiểm tra nếu tháng là 11
            {
                LoadDoanhThuChartThang11();
            }
            else
            {
                LoadDoanhThuChartThang10();
            }
        }
    }
}
