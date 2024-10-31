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
    public partial class FormChinhSuaBenhNhan_BacSi : Form
    {
        private FormBacSi _formBacSi;
        private BenhNhanDTO _benhNhanDTO;
        private BenhNhanBUS _benhNhanBUS;
        public FormChinhSuaBenhNhan_BacSi(FormBacSi formBacSi, BenhNhanDTO benhNhanDTO)
        {
            InitializeComponent();
            this._formBacSi = formBacSi;
            this._benhNhanDTO = benhNhanDTO;
            this._benhNhanBUS = new BenhNhanBUS();
        }
    }
}
