using Dental_Clinic.BUS.Patient;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.BacSi.BenhNhan
{
    public partial class FormThemBenhNhan_BacSi : Form
    {
        private FormBacSi _formBacSi;
        private BenhNhanBUS _benhNhanBUS;
        private BenhNhanDTO _benhNhanDTO;
        public FormThemBenhNhan_BacSi(FormBacSi formBacSi)
        {
            InitializeComponent();
            this._formBacSi = formBacSi;
            this._benhNhanBUS = new BenhNhanBUS();
            this._benhNhanDTO = new BenhNhanDTO();
        }
    }
}
