using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Doctor
    {
        public User User { get; set; }
        private Room room;
        private String specializationType;
        public Doctor(string jmbg, string username, string password, string name, string surname, string email, string address, string phoneNumber, DateTime dateOfBirth,
            int id, string roomName, RoomType roomType, int floor, string description)
        {
            User newUser = new User(jmbg, username, password, name, surname, email, address, phoneNumber, dateOfBirth);
            this.User = newUser;

            Room newRoom = new Room(id, roomName, roomType, floor, description);
            this.room = newRoom;
        }

        public Doctor(User user)
        {
            this.User = user;
        }

        
    }
}
