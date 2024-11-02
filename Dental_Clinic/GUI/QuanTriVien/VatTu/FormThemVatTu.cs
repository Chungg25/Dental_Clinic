﻿using Dental_Clinic.BUS.VatTu;
using Dental_Clinic.DTO.VatTu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.Administrator.Supplies
{
    public partial class FormThemVatTu : Form
    {
        private MainForm mainForm;
        private VatTuBUS dichVuBUS;
        private VatTuDTO dichVuDTO;
        public FormThemVatTu(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            dichVuBUS = new VatTuBUS();
            dichVuDTO = new VatTuDTO();

            ChinhSua();
        }

        public void ChinhSua()
        {
            foreach (Control control in panelDuLieu.Controls)
            {
                if (control is Button vbButton)
                {
                    vbButton.FlatStyle = FlatStyle.Flat;
                    vbButton.FlatAppearance.BorderSize = 0;
                    vbButton.FlatAppearance.MouseOverBackColor = vbButton.BackColor;
                    vbButton.FlatAppearance.MouseDownBackColor = vbButton.BackColor;
                }
            }

            foreach (Control control in panelDuLieu.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                }
            }

            foreach (Control control in panelDuLieu.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
            }

            cbLoaiVatTu.Items.Add("Vật tư");
            cbLoaiVatTu.Items.Add("Dụng cụ");
            cbLoaiVatTu.Items.Add("Thiết bị");

            dtpNgaySanXuat.Format = DateTimePickerFormat.Custom;
            dtpNgaySanXuat.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayHetHan.Format = DateTimePickerFormat.Custom;
            dtpNgayHetHan.CustomFormat = "dd/MM/yyyy";
        }

        private void pbQuayVe_Click(object sender, EventArgs e)
        {
            if (mainForm.panelTrangChu.Controls.Count > 0)
            {
                mainForm.panelTrangChu.Controls.RemoveAt(0);
                if (mainForm.panelTrangChu.Controls.Count > 0)
                {
                    Control control = mainForm.panelTrangChu.Controls[0];
                    control.Visible = true;
                    if (control is Form form)
                    {
                        if (form is FormVatTu formVatTu)
                        {
                            formVatTu.HienVatTu();
                        }
                    }
                }
            }
        }

        private void vbThemVatTu_Click(object sender, EventArgs e)
        {

        }

        public bool KiemTraThem()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(tbThuoc.Text))
            {
                vbThuoc.BorderColor = Color.Red; // Đặt màu viền cho tbHoTen
                isValid = false;
            }
            else
            {
                vbThuoc.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(cbLoaiVatTu.Text))
            {
                vbLoaiThuoc.BorderColor = Color.Red; // Đặt màu viền cho tbEmail
                isValid = false;
            }
            else
            {
                vbLoaiThuoc.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbSoLuong.Text))
            {
                vbSoLuong.BorderColor = Color.Red; // Đặt màu viền cho tbSĐT
                isValid = false;
            }
            else
            {
                vbSoLuong.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbDonViTinh.Text))
            {
                vbDonViTinh.BorderColor = Color.Red; // Đặt màu viền cho tbCCCD
                isValid = false;
            }
            else
            {
                vbDonViTinh.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbLieuLuong.Text))
            {
                vbLieuLuong.BorderColor = Color.Red; // Đặt màu viền cho tbHeSoLuong
                isValid = false;
            }
            else
            {
                vbLieuLuong.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbGia.Text))
            {
                vbGia.BorderColor = Color.Red; // Đặt màu viền cho tbQueQuan
                isValid = false;
            }
            else
            {
                vbGia.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            //if (string.IsNullOrEmpty(tbGia.Text))
            //{
            //    vbGioiTinh.BorderColor = Color.Red; // Đặt màu nền cho ComboBox khi không chọn
            //    isValid = false;
            //}
            //else
            //{
            //    vbGioiTinh.BorderColor = Color.White; // Đặt màu nền mặc định
            //}

            //if (cbChuyenNganh.SelectedItem == null)
            //{
            //    vbChuyenNganh.BorderColor = Color.Red; // Đặt màu nền cho ComboBox khi không chọn
            //    isValid = false;
            //}
            //else
            //{
            //    vbChuyenNganh.BorderColor = Color.Black; // Đặt màu nền mặc định
            //}
            return isValid;
        }
    }
}
