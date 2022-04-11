using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class RoomController
    {
        public Room GetById(int id)
        {
            return this.roomService.GetById(id);
        }

        public List<Room> GetAll()
        {
            return this.roomService.GetAll();
        }

        public bool Create(Room room)
        {
            return this.roomService.Create(room);
        }

        public bool Update(Room room)
        {
            return this.roomService.Update(room);
        }

        public bool DeleteById(int id)
        {
            return this.roomService.DeleteById(id);
        }

        public bool Split(int id)
        {
            return this.roomService.Split(id);
        }

        public bool Merge(int firstId, int secondId)
        {
            return this.roomService.Merge(firstId, secondId);
        }

        public RoomService roomService = new RoomService();

    }
}
