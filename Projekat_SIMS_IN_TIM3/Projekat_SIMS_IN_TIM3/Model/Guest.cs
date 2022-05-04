using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Guest
    {
      
        public Guest()
        {
            
        }

        public int Id { get; set; }
        public String Jmbg { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public Guest(string jmbg,string name,string surname,string username,string password)
        {
            this.Jmbg = jmbg;
            this.Name = name;
            this.Surname = surname;
            this.Username = username;
            this.Password = password;
        }
    }
}
