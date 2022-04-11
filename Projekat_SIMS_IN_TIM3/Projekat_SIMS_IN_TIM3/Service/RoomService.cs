using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class RoomService
    {
        public Room GetById(int id)
        {
            return this.roomRepository.GetById(id);
        }

        public List<Room> GetAll()
        {
            return this.roomRepository.GetAll();
        }

        public bool Create(Room room)
        {
            return this.roomRepository.Create(room);
        }

        public bool Update(Room room)
        {
            return this.roomRepository.Update(room);    
        }

        public bool DeleteById(int id)
        {
            return this.roomRepository.DeleteById(id);
        }

        public bool Split(int id)
        {
            return this.roomRepository.Split(id);
        }

        public bool Merge(int firstId, int secondId)
        {
            return this.roomRepository.Merge(firstId, secondId);
        }

        public RoomRepository roomRepository = new RoomRepository();

    }
}
