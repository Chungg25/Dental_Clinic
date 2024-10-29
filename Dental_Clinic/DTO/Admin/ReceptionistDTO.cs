using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.Admin
{
    public class ReceptionistDTO
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Citizen_id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public float Salary_coefficient { get; set; }
        public int Status { get; set; }
    }
}
