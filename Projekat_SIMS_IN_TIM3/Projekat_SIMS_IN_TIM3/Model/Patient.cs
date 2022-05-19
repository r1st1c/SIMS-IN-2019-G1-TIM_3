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

        public User User { get; set; }
        public List<DateTime> CancellationDates;
        public Patient(string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dataOfBirth)
        {
            User newUser = new User(jmbg,username,password,name,surname,email,address,phone,dataOfBirth);
            this.User = newUser;
            this.CancellationDates = new List<DateTime>();
        }

        
        public Patient(User user)
        {
            this.User = user;
            this.CancellationDates = new List<DateTime>(); 
        }

    }
}
