using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Patient
    {
        public Patient() { }

        public Patient(string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dataOfBirth)
        {
            User newUser = new User(jmbg,username,password,name,surname,email,address,phone,dataOfBirth);
            this.User = newUser;
        }

        public Patient(User user)
        {
            this.User = user;
        }

        public User User { get; set; }
    }
}
