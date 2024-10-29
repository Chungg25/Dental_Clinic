using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.Patient
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
    }
}
