using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.Administrator.User
{
    public partial class AddUserForm : Form
    {
        public AddUserForm(MainForm _mainForm)
        {
            InitializeComponent();

            vbHoTen.BorderSize = 1;
            vbHoTen.BorderColor = Color.Black;
        }
    }
}
