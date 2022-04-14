using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Doctor
    {
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
        private Room room { get; set; }
        private String specializationType { get; set; }

        public Doctor()
        {
        }

        public Doctor(int id, string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dateOfBirth, Room room, string specializationType)
        {
            Id = id;
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
            Address = address;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            this.room = room;
            this.specializationType = specializationType;
        }

        public Doctor(string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dateOfBirth, Room room, string specializationType)
        {
            Jmbg = jmbg;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
            Address = address;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            this.room = room;
            this.specializationType = specializationType;
        }
    }
}
