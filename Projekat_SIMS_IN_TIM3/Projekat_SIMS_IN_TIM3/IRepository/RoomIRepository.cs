using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface RoomIRepository
    {
        public int NextId();
        public Room GetById(int id);
        public List<Room> GetAll();
        public bool Create(Room room);
        public bool Update(Room room);
        public bool DeleteById(int id);

    }
}
