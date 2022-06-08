using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface EquipmentIRepository
    {
        public Equipment GetById(int id);
        public List<Equipment> GetAll();
        public bool Move(int equipmentId, int targetRoomId);
        public bool scheduleFutureMove(int equipmentId, int targetRoomId, DateTime date);
        public List<EquipmentMoveOrder> GetAvailableForMoving();
        public void MoveEquipmentToDefaultRoomAfterDeletingRoom(int roomId);

    }
}
