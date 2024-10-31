using Dental_Clinic.BUS.LichLamViec;
using Dental_Clinic.DTO.ChamCong;
using Dental_Clinic.DTO.LichLamViec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.Administrator.WorkSchedule
{
    public partial class FormChinhSuaLichLamViec : Form
    {
        private TableLayoutPanel calendarTable;
        private LichLamViecBUS lichLamViecBUS;
        private int id;
        private DateTime day;
        private MainForm mainForm;
        public FormChinhSuaLichLamViec(MainForm _mainForm, int id, DateTime day)
        {
            InitializeComponent();
            this.id = id;
            this.day = day;
            mainForm = _mainForm;
            lichLamViecBUS = new LichLamViecBUS();

            HienThiLichLamViec(id, day);

            dtpLichLamViec.ValueChanged += DtpLichLamViec_ValueChanged;
        }

        public void HienThiLichLamViec(int id, DateTime day)
        {
            TaoCalendar();
            panelChiTiet.Visible = false;
            panelLichLamViec.Visible = true;
            Dictionary<DateTime, (string Ca, string TrangThai)> workShifts = new Dictionary<DateTime, (string Ca, string TrangThai)>();

            List<ChamCongDTO> lichLamViecBacSi = lichLamViecBUS.LichLamViecBacSi(id, day);

            foreach (var lichLamViec in lichLamViecBacSi)
            {
                DateTime ngayLamViec;
                if (DateTime.TryParse(lichLamViec.Ngay.ToString(), out ngayLamViec))
                {
                    if (!workShifts.ContainsKey(ngayLamViec))
                    {
                        workShifts.Add(ngayLamViec, (lichLamViec.Ca.ToString(), lichLamViec.TrangThai.ToString()));
                    }
                }
            }

            TaoLichLamViec(day, workShifts);
        }

        private void DtpLichLamViec_ValueChanged(object sender, EventArgs e)
        {
            // Khi giá trị của dtpLichLamViec thay đổi, cập nhật lịch
            DateTime selectedDate = dtpLichLamViec.Value;
            HienThiLichLamViec(id, selectedDate);
        }

        private void TaoCalendar()
        {
            // Tạo TableLayoutPanel cho lịch
            calendarTable = new TableLayoutPanel
            {
                ColumnCount = 8, // 7 cột cho ngày + 1 cột cho số tuần
                RowCount = 6,    // 6 hàng cho các tuần
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            // Thiết lập kích thước cột và hàng
            calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F)); // Cột số tuần
            for (int i = 1; i < 8; i++) calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            for (int i = 0; i < 6; i++) calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));

            // Thêm số tuần vào cột đầu tiên
            string[] weekNumbers = { "1", "2", "3", "4", "5" };
            for (int i = 1; i < 6; i++)
            {
                Label weekLabel = new Label
                {
                    Text = weekNumbers[i - 1],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BorderStyle = BorderStyle.FixedSingle
                };
                calendarTable.Controls.Add(weekLabel, 0, i);
            }

            // Tạo tiêu đề cho các ngày trong tuần
            string[] daysOfWeek = { "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy", "Chủ nhật" };
            for (int i = 0; i < 7; i++)
            {
                Label dayLabel = new Label
                {
                    Text = daysOfWeek[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BorderStyle = BorderStyle.FixedSingle
                };
                calendarTable.Controls.Add(dayLabel, i + 1, 0);  // Thêm từ cột 1 vì cột 0 là số tuần
            }

            for (int row = 1; row < 6; row++)  // 5 hàng (tuần)
            {
                for (int col = 1; col < 8; col++)  // 7 cột (ngày)
                {
                    Panel dayPanel = new Panel { BorderStyle = BorderStyle.FixedSingle };
                    calendarTable.Controls.Add(dayPanel, col, row);
                }
            }
            panelLichLamViec.Controls.Clear();
            panelLichLamViec.Controls.Add(calendarTable); // Thêm bảng lịch vào Form
        }


        private void TaoLichLamViec(DateTime selectedDate, Dictionary<DateTime, (string Ca, string TrangThai)> workShifts)
        {
            // Lấy thông tin về tháng và năm hiện tại
            int selectedYear = selectedDate.Year;
            int selectedMonth = selectedDate.Month;

            // Lấy ngày đầu tiên của tháng và số ngày trong tháng
            DateTime firstDayOfMonth = new DateTime(selectedYear, selectedMonth, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
            DayOfWeek firstDayOfWeek = firstDayOfMonth.DayOfWeek;

            // Xác định ngày đầu tiên của tháng rơi vào thứ mấy (Monday = 0, Sunday = 6)
            int firstDayIndex = ((int)firstDayOfWeek + 6) % 7;

            // Thêm các ngày vào bảng lịch
            int day = 1;
            bool daysStarted = false;

            for (int row = 1; row < 6; row++)  // 5 tuần
            {
                for (int col = 1; col < 8; col++)  // 7 ngày trong tuần
                {
                    Panel dayPanel = calendarTable.GetControlFromPosition(col, row) as Panel;

                    // Bắt đầu thêm ngày vào đúng ô khi đã tới ngày đầu tiên của tháng
                    if (dayPanel != null)
                    {
                        dayPanel.Controls.Clear();

                        if (col > firstDayIndex || daysStarted)
                        {
                            daysStarted = true;
                            if (day <= daysInMonth)
                            {

                                DateTime currentDate = new DateTime(selectedYear, selectedMonth, day);
                                string shiftText = "";

                                // Kiểm tra ca làm việc từ workShifts
                                if (workShifts.ContainsKey(currentDate))
                                {
                                    var shiftInfo = workShifts[currentDate];
                                    shiftText = shiftInfo.Ca; // Lấy ca làm
                                    string trangThai = shiftInfo.TrangThai; // Lấy trạng thái
                                    // Thay đổi màu nền dựa trên trạng thái
                                    if (trangThai == "0") // Kiểm tra nếu trạng thái là 0
                                    {
                                        dayPanel.BackColor = Color.Red; // Màu đỏ cho trạng thái không đúng giờ
                                    }
                                    else
                                    {
                                        dayPanel.BackColor = Color.FromArgb(255, 223, 186); // Màu nền cho các ngày có ca làm
                                    }

                                }

                                if (!string.IsNullOrEmpty(shiftText))
                                {
                                    Label shiftLabel = new Label
                                    {
                                        Text = "Ca làm: " + shiftText,
                                        Dock = DockStyle.Fill,
                                        TextAlign = ContentAlignment.MiddleCenter,
                                        Padding = new Padding(5),
                                        Font = new Font("Segoe UI", 8),
                                        ForeColor = Color.Black,
                                    };

                                    shiftLabel.Tag = currentDate;
                                    dayPanel.Controls.Add(shiftLabel);
                                    shiftLabel.Click += ShiftLabel_Click;
                                }

                                // Thêm số ngày
                                Label dayLabel = new Label
                                {
                                    Text = day.ToString(),
                                    Dock = DockStyle.Fill,
                                    TextAlign = ContentAlignment.TopCenter,
                                    Padding = new Padding(5),
                                    Font = new Font("Segoe UI", 7, FontStyle.Bold)
                                };
                                dayPanel.Controls.Add(dayLabel);

                                day++;
                                dayPanel.BringToFront();
                            }
                        }
                    }
                }
            }
        }

        private void ShiftLabel_Click(object sender, EventArgs e)
        {
            Label shiftLabel = sender as Label;
            if (shiftLabel != null && shiftLabel.Tag is DateTime currentDate)
            {
                HienThiChiTietNgayLamViec(id, currentDate);
            }
        }

        public void HienThiChiTietNgayLamViec(int id, DateTime day)
        {
            Label dateOfBirthLabel = new Label
            {
                Text = "Ngày sinh: " + day.ToString("dd/MM/yyyy"), // Định dạng ngày
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black
            };

            panelChiTiet.Visible = true;
            panelLichLamViec.Visible = false;

            // Thêm label vào panelLichLamViec
            //panelLichLamViec.Controls.Add(panelChiTiet);

            // Đảm bảo label nằm ở trên cùng nếu có nhiều điều khiển
            //panelChiTiet.BringToFront();
        }

        private void pbQuayVe_Click(object sender, EventArgs e)
        {
            int controlCount = panelLichLamViec.Controls.Count;
            if (controlCount == 1)
            {
                mainForm.ShowWorkScheduleInPanel();
            }
            else
            {
                dtpLichLamViec.Visible = true;
                panelChiTiet.Visible=false;
                panelLichLamViec.Visible = true;
                Control lastControl = panelLichLamViec.Controls[controlCount - 1];

                panelLichLamViec.Controls.Clear();

                panelLichLamViec.Controls.Add(lastControl);
            }
        }
    }
}
