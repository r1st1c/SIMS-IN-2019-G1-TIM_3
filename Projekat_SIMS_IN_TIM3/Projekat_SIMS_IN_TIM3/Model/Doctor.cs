using System;
using System.Collections.Generic;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Doctor
    {
        private string username;
        private string password;

        public User User { get; set; }
        private Room room { get; set; }
        public String specializationType { get; set; }
        private List<Appointment> appointments { get; set; }    
        

        public Doctor()
        {
        }

        public Doctor(User user, String spec)
        {
            this.User = user;
            this.specializationType = spec;
        }

        public Doctor(int id, string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dataOfBirth, Room room, String specializationType)
        {
            User user = new User(jmbg, username, password, name, surname, 
                email, address, phone, dataOfBirth);
            this.room = room;
            this.specializationType = specializationType;
        }
        public Doctor(User user, Room room, string specializationType)
        {
            
            this.room = room;
            this.specializationType = specializationType;
        }

        public Doctor(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
