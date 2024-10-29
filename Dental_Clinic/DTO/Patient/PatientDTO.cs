using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.Patient
{
    public class PatientDTO
    {
        private int id;
        private string hoVaTen;
        private string diaChi;
        private bool gioiTinh;
        private int tuoi;
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public int Tuoi { get; set; }
    }
}
