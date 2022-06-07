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
            List<Equipment> retVal = this.equipmentRepository.GetAll();
            List<Room> roomList = this.roomRepository.GetAll();
            foreach(Equipment equipment in retVal)
            {
                foreach(Room room in roomList)
                {
                    if (equipment.RoomId == -1)
                    {
                        equipment.RoomName = "No room (DYNAMIC)";
                    }
                    if(room.Id == equipment.RoomId)
                    {
                        equipment.RoomName = room.Name;
                    }
                }
            }
            return retVal;
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

        public List<Equipment> GetByType(EquipmentType query)
        {
            return this.GetAll().Where(x => x.Equipmenttype == query).ToList();
        }


        public RoomRepository roomRepository;
        public EquipmentRepository equipmentRepository;

        public EquipmentService(RoomRepository roomRepository, EquipmentRepository equipmentRepository)
        {
            this.roomRepository = roomRepository;
            this.equipmentRepository = equipmentRepository;
        }

    }
}
