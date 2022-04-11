using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class User
    {
        private int id;
        private String jmbg;
        private String username;
        private String password;
        private String name;
        private String surname;
        private String email;
        private String address;
        private String phone;
        private DateTime dateOfBirth;

        public int Id { get; set; }
        public String Jmbg { get; set; }
        public String Username { get; set; }   
        public String Password { get; set; }   
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
