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
            if (DateTime.Compare(date.Date, DateTime.Now.Date) > 0){
                this.equipmentRepository.scheduleFutureMove(equipmentId, targetRoomId, date);
                return false;
            }
            else{
                this.equipmentRepository.Move(equipmentId, targetRoomId);
                return true;
            }
        }

        public void MoveFromMoveOrderList()
        {
            List<EquipmentMoveOrder> equipmentMoveOrders = this.equipmentRepository.GetAvailableForMoving();
            foreach(EquipmentMoveOrder equipmentMoveOrder in equipmentMoveOrders)
            {
                this.equipmentRepository.Move(equipmentMoveOrder.EquipmentId, equipmentMoveOrder.RoomId);
            }
        }


        public RoomRepository roomRepository = new RoomRepository();
        public EquipmentRepository equipmentRepository = new EquipmentRepository();

    }
}
