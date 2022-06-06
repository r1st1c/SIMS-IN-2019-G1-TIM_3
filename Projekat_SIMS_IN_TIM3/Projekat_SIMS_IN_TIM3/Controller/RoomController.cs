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
        public int GetMaxId()
        {
            return this.roomService.GetMaxId();
        }

        public Room GetById(int id)
        {
            return this.roomService.GetById(id);
        }

        public Room GetByName(string name)
        {
            return this.roomService.GetByName(name);
        }

        public List<Room> GetAll()
        {
            return this.roomService.GetAll();
        }

        public (bool, bool) Create(Room room)
        {
            return this.roomService.Create(room);
        }

        public bool UpdateUsingNewName(Room room)
        {
            return this.roomService.UpdateUsingNewName(room);
        }

        public bool UpdateUsingSameName(Room room)
        {
            return this.roomService.UpdateUsingSameName(room);
        }

        public bool DeleteById(int id)
        {
            return this.roomService.DeleteById(id);
        }


        private RoomService roomService;

        public RoomController(RoomService roomService)
        {
            this.roomService=roomService;
        }
    }
}