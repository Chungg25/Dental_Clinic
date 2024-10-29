using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.Admin
{
    public class UserDTO
    {
        private int id;
        private string full_name;
        private string citizen_id;
        private string phone;
        private string address;
        private bool gender;
        private DateTime dob;
        private string role;
        private string username;
        private string password;
        private string email;
        private float salary_coefficient;

        public int Id { get => id; set => id = value; }
        public string Full_name { get => full_name; set => full_name = value; }
        public string Citizen_id { get => citizen_id; set => citizen_id = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public bool Gender { get => gender; set => gender = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Role { get => role; set => role = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public float Salary_coefficient { get => salary_coefficient; set => salary_coefficient = value; }
    }
}
