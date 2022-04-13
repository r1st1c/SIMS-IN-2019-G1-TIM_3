using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class User
    {
        private DateTime dataOfBirth;

        public string Id { get; set; }
        public String Jmbg { get; set; }
        public String Username { get; set; }   
        public String Password { get; set; }   
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public User() { }
        public User(string id, string jmbg, string username, string password, string name, string surname, string email, string address,string phone, DateTime dataOfBirth)
        {
            this.Id = id;
            this.Jmbg = jmbg;  
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Address = address;
            this.Phone = phone;
            this.DateOfBirth = dataOfBirth;
        }

        public User(string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dataOfBirth)
        {
            this.Jmbg = jmbg;
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Address = address;
            this.Phone = phone;
            this.dataOfBirth = dataOfBirth;
        }
    }
}
