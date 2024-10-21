using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomButton;

namespace Dental_Clinic.GUI.Login
{
    public partial class ForgotPassword : Form
    {
        private Dental_Clinic mainForm;
        public ForgotPassword(Dental_Clinic mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }

        private void picBack_Click(object sender, EventArgs e)
        {
            mainForm.ShowLoginFormInPanel();
        }
    }
}
