using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.Login
{
    internal class LoginDTO
    {
        private string tenDangNhap;
        private string matKhau;

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string Matkhau { get => matKhau; set => matKhau = value; }

    }
}
