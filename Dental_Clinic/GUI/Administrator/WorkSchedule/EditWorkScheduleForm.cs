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
    public partial class EditWorkScheduleForm : Form
    {
        private TableLayoutPanel calendarTable;
        private DateTimePicker monthYearPicker;
        public EditWorkScheduleForm(object _mainForm)
        {
            InitializeComponent();
            CreateCalendar();

            dtpLichLamViec.ValueChanged += DtpLichLamViec_ValueChanged;
            UpdateCalendar(dtpLichLamViec.Value);
        }

        private void DtpLichLamViec_ValueChanged(object sender, EventArgs e)
        {
            // Khi giá trị của dtpLichLamViec thay đổi, cập nhật lịch
            DateTime selectedDate = dtpLichLamViec.Value;
            UpdateCalendar(dtpLichLamViec.Value);
        }

        private void CreateCalendar()
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
            for (int i = 1; i < 8; i++) calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 200F));
            for (int i = 0; i < 6; i++) calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));

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
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
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

            panelLichLamViec.Controls.Add(calendarTable); // Thêm bảng lịch vào Form
        }

        private Dictionary<DateTime, string> workShifts = new Dictionary<DateTime, string>
        {
            // Ví dụ: Thêm ca làm cho một vài ngày
            { new DateTime(2024, 10, 23), "Ca sáng: 8AM - 12PM" },
            { new DateTime(2024, 10, 24), "Ca chiều: 1PM - 5PM" },
            { new DateTime(2024, 10, 25), "Ca tối: 6PM - 10PM" },
        };

        private void UpdateCalendar(DateTime selectedDate)
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
                        dayPanel.Controls.Clear();  // Xóa nội dung cũ

                        if (col > firstDayIndex || daysStarted)
                        {
                            daysStarted = true;
                            if (day <= daysInMonth)
                            {

                                DateTime currentDate = new DateTime(selectedYear, selectedMonth, day);
                                if (workShifts.ContainsKey(currentDate))
                                {
                                    Label shiftLabel = new Label
                                    {
                                        Text = workShifts[currentDate],
                                        Dock = DockStyle.Top,
                                        TextAlign = ContentAlignment.TopLeft,
                                        Padding = new Padding(5),
                                        Font = new Font("Segoe UI", 7),
                                        ForeColor = Color.FromArgb(32, 155, 220),                                      
                                    };
                                    dayPanel.Controls.Add(shiftLabel);
                                }

                                // Thêm số ngày
                                Label dayLabel = new Label
                                {
                                    Text = day.ToString(),
                                    Dock = DockStyle.Top,
                                    TextAlign = ContentAlignment.TopLeft,
                                    Padding = new Padding(5),
                                    Font = new Font("Segoe UI", 7)
                                };
                                dayPanel.Controls.Add(dayLabel);

                                day++;
                            }
                        }
                    }
                }
            }
        }
    }
}
