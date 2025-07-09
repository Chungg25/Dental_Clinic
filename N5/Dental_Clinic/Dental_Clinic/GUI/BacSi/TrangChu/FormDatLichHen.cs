using Dental_Clinic.BUS.BacSi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.BacSi.TrangChu
{
    public partial class FormDatLichHen : Form
    {
        private int maBacSi;
        private int maBenhNhan;
        private BacSiBUS bacSiBUS;

        public FormDatLichHen(int maBacSi, int maBenhNhan)
        {
            InitializeComponent();
            this.maBacSi = maBacSi;
            this.maBenhNhan = maBenhNhan;
            this.bacSiBUS = new BacSiBUS();
        }

        private void FormDatLichHen_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button vbButton)
                {
                    vbButton.FlatStyle = FlatStyle.Flat;
                    vbButton.FlatAppearance.BorderSize = 0;
                    vbButton.FlatAppearance.MouseOverBackColor = vbButton.BackColor;
                    vbButton.FlatAppearance.MouseDownBackColor = vbButton.BackColor;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
            }

            dateTimePicker.MinDate = DateTime.Now;
        }
        // Ca làm chi được nhập 1 và 2
        private void tbCaLam_TextChanged(object sender, EventArgs e)
        {
            if (tbCaLam.Text != "1" && tbCaLam.Text != "2")
            {
                tbCaLam.Text = "";
            }
        }
        // Chỉ được chọn ngày hiện tại trở đi
        private void dtpNgayHen_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker.ValueChanged -= dtpNgayHen_ValueChanged;
            if (dateTimePicker.Value < DateTime.Now)
            {
                dateTimePicker.Value = DateTime.Now;
            }
            dateTimePicker.ValueChanged += dtpNgayHen_ValueChanged;
        }


        private void vbHuy_Click(object sender, EventArgs e)
        {
            // Tắt form
            this.Close();
        }

        private void vbXacNhan_Click(object sender, EventArgs e)
        {
            if (bacSiBUS.ThemLichHen(maBenhNhan, maBacSi, tbGhiChu.Text, dateTimePicker.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(tbCaLam.Text)))
            {
                MessageBox.Show("Thêm lịch hẹn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm lịch hẹn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
