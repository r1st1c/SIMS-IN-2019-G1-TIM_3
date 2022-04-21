using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class EquipmentService
    {
        public Equipment GetById(int id)
        {
            return this.equipmentRepository.GetById(id);
        }

        public List<Equipment> GetAll()
        {
            return this.equipmentRepository.GetAll();
        }

        public bool Move(int equipmentId, int targetRoomId, DateTime date)
        {
            if(this.equipmentRepository.Move(equipmentId, targetRoomId))
            {
                return true;
            }
            return false;
        }
        public RoomRepository roomRepository = new RoomRepository();
        public EquipmentRepository equipmentRepository = new EquipmentRepository();

    }
}
