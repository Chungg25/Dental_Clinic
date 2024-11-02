using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomButton;
using Dental_Clinic.BUS.Patient;
using Dental_Clinic.BUS.VatTu;
using Dental_Clinic.DTO.VatTu;
using Dental_Clinic.GUI.Administrator.Supplies;
using Dental_Clinic.GUI.Administrator.WorkSchedule;
using Dental_Clinic.GUI.QuanTriVien.VatTu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class FormVatTu : Form
    {
        private MainForm mainForm;
        private VatTuBUS vatTuBUS;
        public FormVatTu(MainForm mainForm)
        {
            InitializeComponent();
            vatTuBUS = new VatTuBUS();
            HienThiThuoc();

            this.mainForm = mainForm;

            vbThuoc.FlatStyle = FlatStyle.Flat;
            vbThuoc.FlatAppearance.BorderSize = 0;
            vbThuoc.FlatAppearance.MouseOverBackColor = vbThuoc.BackColor;
            vbThuoc.FlatAppearance.MouseDownBackColor = vbThuoc.BackColor;

            vbVatTu.FlatStyle = FlatStyle.Flat;
            vbVatTu.FlatAppearance.BorderSize = 0;
            vbVatTu.FlatAppearance.MouseOverBackColor = vbVatTu.BackColor;
            vbVatTu.FlatAppearance.MouseDownBackColor = vbVatTu.BackColor;

            vbDichVu.FlatStyle = FlatStyle.Flat;
            vbDichVu.FlatAppearance.BorderSize = 0;
            vbDichVu.FlatAppearance.MouseOverBackColor = vbDichVu.BackColor;
            vbDichVu.FlatAppearance.MouseDownBackColor = vbDichVu.BackColor;

            vbThem.FlatStyle = FlatStyle.Flat;
            vbThem.FlatAppearance.BorderSize = 0;
            vbThem.FlatAppearance.MouseOverBackColor = vbThem.BackColor;
            vbThem.FlatAppearance.MouseDownBackColor = vbThem.BackColor;

            vbTimKiem.BorderSize = 1;
            vbTimKiem.BorderColor = Color.Black;
            vbTimKiem.FlatAppearance.MouseOverBackColor = vbTimKiem.BackColor;
            vbTimKiem.FlatAppearance.MouseDownBackColor = vbTimKiem.BackColor;

            tbTimKiem.Font = new Font("Segoe UI", 12F);
            tbTimKiem.Text = "Tìm kiếm";
            tbTimKiem.ForeColor = Color.Gray;
            tbTimKiem.Enter += tbTimKiem_Enter;
            tbTimKiem.Leave += tbTimKiem_Leave;
            tbTimKiem.TextChanged += tbTimKiem_TextChanged;
        }


        //Phần này để chỉnh sửa các control
        private void tbTimKiem_Enter(object? sender, EventArgs e)
        {
            if (tbTimKiem.Text == "Tìm kiếm")
            {
                tbTimKiem.Text = "";
                tbTimKiem.ForeColor = Color.Black;
            }
        }

        private void tbTimKiem_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTimKiem.Text))
            {
                tbTimKiem.Text = "Tìm kiếm";
                tbTimKiem.ForeColor = Color.Gray;
            }
        }

        //Kết thúc

        //Phần này để tạo hiển thị danh sách bác sĩ
        //Hàm CreateTableLayoutPanel() được gọi trên đầu để tạo panel hiển thị
        //Hàm AddRowToTableLayoutPanel để thêm dữ liệu vào
        //Xem hàm CreateTableLayoutPanel() để biết thêm chi tiết


        // Hàm để tạo Label
        private Label TaoLabel(string text, Font font)
        {
            return new Label
            {
                Text = text,
                Font = font,
                AutoSize = true,
                Padding = new Padding(1, 5, 50, 5),
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
        }

        // Hàm tạo nút hành động (chỉnh sửa và xóa)
        private Button TaoActionButton(Color backgroundColor, Image icon)
        {
            VBButton button = new VBButton
            {
                Width = 40,  // Kích thước nút
                Height = 40,
                BorderRadius = 10, // Chỉnh độ bo góc, nếu không là hình tròn
                FlatStyle = FlatStyle.Flat,  // Loại bỏ viền nút
                BackColor = backgroundColor, // Màu nền của nút
                Image = icon, // Đặt icon cho nút
                ImageAlign = ContentAlignment.MiddleCenter, // Căn giữa icon
                FlatAppearance = { BorderSize = 0 }, // Loại bỏ viền bao quanh
                Cursor = Cursors.Hand // Đặt kiểu chuột khi di qua nút
            };
            return button;
        }


        // Hàm thêm các nút hành động (chỉnh sửa và xóa)
        private void ThemActionButtonsVaoTableLayoutPanel(TableLayoutPanel tlpMedicine, int index, int rowIndex, int id, Action<int> onEditAction)
        {
            Image ResizeImage(Image img, int width, int height)
            {
                return new Bitmap(img, new Size(width, height));
            }

            // Đặt icon cho nút chỉnh sửa và xóa từ Resources
            Image editIcon = ResizeImage(Properties.Resources.icons8_edit_64__2_, 30, 30);
            Image deleteIcon = ResizeImage(Properties.Resources.trash_bin, 25, 25);

            // Tạo các nút
            Color editEditColor = ColorTranslator.FromHtml("#0d6efd");
            Button btnEdit = TaoActionButton(editEditColor, editIcon);
            Color editDeleteColor = ColorTranslator.FromHtml("#dc3545");
            Button btnDelete = TaoActionButton(editDeleteColor, deleteIcon);

            // Thêm sự kiện Click
            btnEdit.Click += (s, e) => onEditAction(id);
            //btnDelete.Click += (s, e) => { MessageBox.Show("Xóa"); };

            // Tạo một Panel để chứa 2 nút
            FlowLayoutPanel panelActions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = new Padding(15, 0, 0, 0),
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight, // Sắp xếp các điều khiển theo chiều ngang
                WrapContents = false
            };

            // Thêm các nút vào panel
            panelActions.Controls.Add(btnEdit);
            panelActions.Controls.Add(btnDelete);

            // Thêm Panel vào cột thao tác của hàng hiện tại
            tlpMedicine.Controls.Add(panelActions, index, rowIndex);
        }

        // Hàm để thêm hàng mới vào TableLayoutPanel
        private void ThemHangVaoMedicineTableLayoutPanel(TableLayoutPanel tlpMedicine, string tenThuoc, string DVT, string soLuong, float giaBan, string hamLuong, string hanSuDung, string Loai, int id)
        {
            int currentRow = tlpMedicine.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpMedicine.Controls.Add(TaoLabel(tenThuoc, headerFont), 0, currentRow);
            tlpMedicine.Controls.Add(TaoLabel(DVT, headerFont), 1, currentRow);
            tlpMedicine.Controls.Add(TaoLabel(soLuong, headerFont), 2, currentRow);
            tlpMedicine.Controls.Add(TaoLabel(giaBan.ToString(), headerFont), 3, currentRow);
            tlpMedicine.Controls.Add(TaoLabel(hamLuong, headerFont), 4, currentRow);
            tlpMedicine.Controls.Add(TaoLabel(hanSuDung, headerFont), 5, currentRow); // Thêm CheckBox
            tlpMedicine.Controls.Add(TaoLabel(Loai, headerFont), 6, currentRow); // Thêm CheckBox
            ThemActionButtonsVaoTableLayoutPanel(tlpMedicine, 7, currentRow, id, HienThiChinhSuaThuocLenPanel);
        }

        // Hàm tạo TableLayoutPanel và gọi hàm AddRowToTableLayoutPanel để thêm dữ liệu
        private void TaoMedicineTableLayoutPanel(List<VatTuDTO> danhSachThuoc)
        {
            if (panelDuLieu.Controls.Count > 0)
            {
                // Xóa các control trong panelBacSi, bao gồm TableLayoutPanel cũ
                panelDuLieu.Controls.Clear();
            }

            // Tạo TableLayoutPanel
            TableLayoutPanel tlpMedicine = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };

            // Thiết lập số cột
            tlpMedicine.ColumnCount = 8;
            for (int i = 0; i < tlpMedicine.ColumnCount; i++)
            {
                tlpMedicine.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            // Thiết lập số hàng và thêm các Label tiêu đề vào hàng đầu tiên
            tlpMedicine.RowCount = 1;
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            tlpMedicine.Controls.Add(TaoLabel("Tên thuốc", headerFont), 0, 0);
            tlpMedicine.Controls.Add(TaoLabel("ĐVT", headerFont), 1, 0);
            tlpMedicine.Controls.Add(TaoLabel("Số lượng", headerFont), 2, 0);
            tlpMedicine.Controls.Add(TaoLabel("Giá bán", headerFont), 3, 0);
            tlpMedicine.Controls.Add(TaoLabel("Hàm lượng", headerFont), 4, 0);
            tlpMedicine.Controls.Add(TaoLabel("Hạn sử dụng", headerFont), 5, 0);
            tlpMedicine.Controls.Add(TaoLabel("Loại", headerFont), 6, 0);
            tlpMedicine.Controls.Add(TaoLabel("Thao tác", headerFont), 7, 0);

            ClearControlsExcept(tlpMedicine);
            Panel scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };
            scrollablePanel.Controls.Add(tlpMedicine);

            panelDuLieu.Controls.Add(scrollablePanel);
            scrollablePanel.Name = "Medicine";
            foreach (var thuoc in danhSachThuoc)
            {
                ThemHangVaoMedicineTableLayoutPanel(tlpMedicine, thuoc.Ten, thuoc.DonVi, thuoc.SoLuong, thuoc.Gia, thuoc.LieuLuong, thuoc.NgayHetHan, thuoc.TenLoai, thuoc.Id); ;
            }
        }


        // Hàm để thêm hàng mới vào TableLayoutPanel
        private void ThemHangVaoSuppliesTableLayoutPanel(TableLayoutPanel tlpSupplies, string vatLieu, string DVT, string soLuong, float gia, string hanSuDung, string Loai, int id)
        {
            int currentRow = tlpSupplies.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpSupplies.Controls.Add(TaoLabel(vatLieu, headerFont), 0, currentRow);
            tlpSupplies.Controls.Add(TaoLabel(DVT, headerFont), 1, currentRow);
            tlpSupplies.Controls.Add(TaoLabel(soLuong, headerFont), 2, currentRow);
            tlpSupplies.Controls.Add(TaoLabel(gia.ToString(), headerFont), 3, currentRow);
            tlpSupplies.Controls.Add(TaoLabel(hanSuDung, headerFont), 4, currentRow);
            tlpSupplies.Controls.Add(TaoLabel(Loai, headerFont), 5, currentRow);
            ThemActionButtonsVaoTableLayoutPanel(tlpSupplies, 6, currentRow, id, HienThiChinhSuaVatTuLenPanel);
        }

        private void ThemHangVaoServiceTableLayoutPanel(TableLayoutPanel tlpSupplies, string vatLieu, string DVT, float gia, string tenLoai, int id)
        {
            if (vatLieu.Contains("-"))
            {
                vatLieu = vatLieu.Substring(vatLieu.IndexOf('-') + 1).Trim();
            }
            int currentRow = tlpSupplies.RowCount++; // Tăng số lượng hàng
            Font headerFont = new Font("Segoe UI", 10);
            tlpSupplies.Controls.Add(TaoLabel(vatLieu, headerFont), 0, currentRow);
            tlpSupplies.Controls.Add(TaoLabel(DVT, headerFont), 1, currentRow);
            tlpSupplies.Controls.Add(TaoLabel(gia.ToString(), headerFont), 2, currentRow);
            tlpSupplies.Controls.Add(TaoLabel(tenLoai, headerFont), 3, currentRow);
            ThemActionButtonsVaoTableLayoutPanel(tlpSupplies, 4, currentRow, id, HienThiChinhSuaDichVuLenPanel);
        }

        // Hàm tạo TableLayoutPanel và gọi hàm AddRowToTableLayoutPanel để thêm dữ liệu
        private void TaoSuppliesTableLayoutPanel(List<VatTuDTO> danhSachVatTu)
        {
            if (panelDuLieu.Controls.Count > 0)
            {
                // Xóa các control trong panelBacSi, bao gồm TableLayoutPanel cũ
                panelDuLieu.Controls.Clear();
            }
            // Tạo TableLayoutPanel
            TableLayoutPanel tlpSupplies = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };

            // Thiết lập số cột
            tlpSupplies.ColumnCount = 8;
            tlpSupplies.SuspendLayout();

            for (int i = 0; i < tlpSupplies.ColumnCount; i++)
            {
                tlpSupplies.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            // Thiết lập số hàng và thêm các Label tiêu đề vào hàng đầu tiên
            tlpSupplies.RowCount = 1;
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            tlpSupplies.Controls.Add(TaoLabel("Vật liệu", headerFont), 0, 0);
            tlpSupplies.Controls.Add(TaoLabel("ĐVT", headerFont), 1, 0);
            tlpSupplies.Controls.Add(TaoLabel("Số lượng", headerFont), 2, 0);
            tlpSupplies.Controls.Add(TaoLabel("Giá bán", headerFont), 3, 0);
            tlpSupplies.Controls.Add(TaoLabel("Hạn sử dụng", headerFont), 4, 0);
            tlpSupplies.Controls.Add(TaoLabel("Loại", headerFont), 5, 0);
            tlpSupplies.Controls.Add(TaoLabel("Thao tác", headerFont), 6, 0);

            ClearControlsExcept(tlpSupplies);
            Panel scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };
            scrollablePanel.Controls.Add(tlpSupplies);

            scrollablePanel.Name = "Supplies";
            panelDuLieu.Controls.Add(scrollablePanel);

            int sequenceNumber = 1;
            foreach (var vatTu in danhSachVatTu)
            {
                ThemHangVaoSuppliesTableLayoutPanel(tlpSupplies, vatTu.Ten, vatTu.DonVi, vatTu.SoLuong, vatTu.Gia, vatTu.NgayHetHan, vatTu.TenLoai, vatTu.Id);
                sequenceNumber++;
            }
            tlpSupplies.ResumeLayout();
        }

        private void TaoServiceTableLayoutPanel(List<VatTuDTO> danhSachDichVu)
        {
            if (panelDuLieu.Controls.Count > 0)
            {
                // Xóa các control trong panelBacSi, bao gồm TableLayoutPanel cũ
                panelDuLieu.Controls.Clear();
            }
            // Tạo TableLayoutPanel
            TableLayoutPanel tlpService = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };

            // Thiết lập số cột
            tlpService.ColumnCount = 5;
            tlpService.SuspendLayout();
            for (int i = 0; i < tlpService.ColumnCount; i++)
            {
                tlpService.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            // Thiết lập số hàng và thêm các Label tiêu đề vào hàng đầu tiên
            tlpService.RowCount = 1;
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            tlpService.Controls.Add(TaoLabel("Dịch vụ", headerFont), 0, 0);
            tlpService.Controls.Add(TaoLabel("ĐVT", headerFont), 1, 0);
            tlpService.Controls.Add(TaoLabel("Giá", headerFont), 2, 0);
            tlpService.Controls.Add(TaoLabel("Tên loại", headerFont), 3, 0);
            tlpService.Controls.Add(TaoLabel("Thao tác", headerFont), 4, 0);

            ClearControlsExcept(tlpService);
            Panel scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };
            scrollablePanel.Controls.Add(tlpService);

            scrollablePanel.Name = "Service";
            panelDuLieu.Controls.Add(scrollablePanel);

            int sequenceNumber = 1;
            foreach (var dichVu in danhSachDichVu)
            {
                ThemHangVaoServiceTableLayoutPanel(tlpService, dichVu.Ten, dichVu.DonVi, dichVu.Gia, dichVu.TenLoai, dichVu.Id);
                sequenceNumber++;
            }
            tlpService.ResumeLayout();
        }



        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        private void ClearControlsExcept(TableLayoutPanel controlToKeep)
        {
            // Duyệt qua danh sách điều khiển theo chiều ngược lại để tránh vấn đề khi xóa
            for (int i = panelDuLieu.Controls.Count - 1; i >= 0; i--)
            {
                Control control = panelDuLieu.Controls[i];
                // Kiểm tra nếu điều khiển không phải là tlpReception
                if (control != controlToKeep)
                {
                    panelDuLieu.Controls.Remove(control);
                }
            }
        }

        //Kết thúc
        private void vbVatTu_Click(object sender, EventArgs e)
        {
            HienVatTu();
        }
        public void HienVatTu()
        {
            List<VatTuDTO> danhSachVatTu = vatTuBUS.DanhSachVatTu(1);
            TaoSuppliesTableLayoutPanel(danhSachVatTu);
        }

        private void vbThuoc_Click(object sender, EventArgs e)
        {
            HienThiThuoc();
        }

        public void HienThiThuoc()
        {
            List<VatTuDTO> danhSachThuoc = vatTuBUS.DanhSachThuoc(1);
            TaoMedicineTableLayoutPanel(danhSachThuoc);
        }

        private void vbDichVu_Click(object sender, EventArgs e)
        {
            HienThiDichVu();
        }

        public void HienThiDichVu()
        {
            List<VatTuDTO> danhSachDichVu = vatTuBUS.DanhSachDichVu();
            TaoServiceTableLayoutPanel(danhSachDichVu);
        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            
            // Lấy nội dung tìm kiếm từ tbTimKiem
            string searchText = tbTimKiem.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                return;
            }

            var danhSachVatTu = vatTuBUS.DanhSachThuoc(1);
            if (panelDuLieu.Controls[0].Name == "Supplies")
            {
                danhSachVatTu = vatTuBUS.DanhSachVatTu(1);
            }
            else if (panelDuLieu.Controls[0].Name == "Service")
            {
                danhSachVatTu = vatTuBUS.DanhSachDichVu();
            }

            // Lọc danh sách theo họ tên
            var filteredList = danhSachVatTu
                .Where(d => d.Ten.ToLower().Contains(searchText))
                .ToList();
            if (filteredList.Any())
            {
                if (panelDuLieu.Controls[0].Name == "Medicine")
                {
                    TaoMedicineTableLayoutPanel(filteredList);
                }
                else if (panelDuLieu.Controls[0].Name == "Supplies")
                {
                    TaoSuppliesTableLayoutPanel(filteredList);
                }
                else
                {
                    TaoServiceTableLayoutPanel(filteredList);
                }
            }
        }

        //Phần điều hướng

        private void HienThiChinhSuaVatTuLenPanel(int id)
        {
            FormChinhSuaVatTu formChinhSuaVatTu = new FormChinhSuaVatTu(mainForm, id);
            formChinhSuaVatTu.TopLevel = false; // Đặt editUserForm không phải là form cấp cao nhất (TopLevel)
            formChinhSuaVatTu.FormBorderStyle = FormBorderStyle.None; // Xóa viền của editUserForm
            formChinhSuaVatTu.Dock = DockStyle.Fill; // Đặt editUserForm khớp với kích thước panel
            mainForm.panelTrangChu.Controls.Add(formChinhSuaVatTu); // Thêm editUserForm vào panel
            formChinhSuaVatTu.BringToFront();
            formChinhSuaVatTu.Show(); // Hiển thị editUserForm
        }

        private void HienThiChinhSuaThuocLenPanel(int id)
        {
            FormChinhSuaThuoc formChinhSuaThuoc = new FormChinhSuaThuoc(mainForm, id);
            formChinhSuaThuoc.TopLevel = false;
            formChinhSuaThuoc.FormBorderStyle = FormBorderStyle.None;
            formChinhSuaThuoc.Dock = DockStyle.Fill;
            mainForm.panelTrangChu.Controls.Add(formChinhSuaThuoc);
            formChinhSuaThuoc.BringToFront();
            formChinhSuaThuoc.Show();
        }
        private void HienThiChinhSuaDichVuLenPanel(int id)
        {
            FormChinhSuaDichVu formChinhSuaDichVu = new FormChinhSuaDichVu(mainForm, id);
            formChinhSuaDichVu.TopLevel = false;
            formChinhSuaDichVu.FormBorderStyle = FormBorderStyle.None;
            formChinhSuaDichVu.Dock = DockStyle.Fill;
            mainForm.panelTrangChu.Controls.Add(formChinhSuaDichVu);
            formChinhSuaDichVu.BringToFront();
            formChinhSuaDichVu.Show();
        }


        private void vbThem_Click(object sender, EventArgs e)
        {
            if (panelDuLieu.Controls[0].Name == "Medicine")
            {
                HienThiThemThuocLenPanel();
            }
            else if (panelDuLieu.Controls[0].Name == "Supplies")
            {
                HienThiThemVatTuLenPanel();
            }
            else
            {
                HienThiThemDichVuLenPanel();
            }
        }

        private void HienThiThemThuocLenPanel()
        {
            FormThemThuoc formThemThuoc = new FormThemThuoc(mainForm);
            formThemThuoc.TopLevel = false; // Đặt addMedicineForm không phải là form cấp cao nhất (TopLevel)
            formThemThuoc.FormBorderStyle = FormBorderStyle.None; // Xóa viền của addMedicineForm
            formThemThuoc.Dock = DockStyle.Fill; // Đặt addMedicineForm khớp với kích thước panel
            mainForm.panelTrangChu.Controls.Add(formThemThuoc); // Thêm addMedicineForm vào panel
            formThemThuoc.BringToFront();
            formThemThuoc.Show(); // Hiển thị addMedicineForm
        }

        private void HienThiThemVatTuLenPanel()
        {
            FormThemVatTu formThemVatTu = new FormThemVatTu(mainForm);
            formThemVatTu.TopLevel = false; // Đặt addSuppliesForm không phải là form cấp cao nhất (TopLevel)
            formThemVatTu.FormBorderStyle = FormBorderStyle.None; // Xóa viền của addSuppliesForm
            formThemVatTu.Dock = DockStyle.Fill; // Đặt addSuppliesForm khớp với kích thước panel
            mainForm.panelTrangChu.Controls.Add(formThemVatTu); // Thêm addSuppliesForm vào panel
            formThemVatTu.BringToFront();
            formThemVatTu.Show(); // Hiển thị addSuppliesForm
        }

        private void HienThiThemDichVuLenPanel()
        {
            FormThemDichVu formThemDichVu = new FormThemDichVu(mainForm);
            formThemDichVu.TopLevel = false; // Đặt addSuppliesForm không phải là form cấp cao nhất (TopLevel)
            formThemDichVu.FormBorderStyle = FormBorderStyle.None; // Xóa viền của addSuppliesForm
            formThemDichVu.Dock = DockStyle.Fill; // Đặt addSuppliesForm khớp với kích thước panel
            mainForm.panelTrangChu.Controls.Add(formThemDichVu); // Thêm addSuppliesForm vào panel
            formThemDichVu.BringToFront();
            formThemDichVu.Show(); // Hiển thị addSuppliesForm
        }

        //Kết thúc
    }
}
