using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class EquipmentController
    {
        public Equipment GetById(int id)
        {
            return this.equipmentService.GetById(id);
        }

        public List<Equipment> GetAll()
        {
            return this.equipmentService.GetAll();
        }

        public (bool,bool) Move(int equipmentId, int targetRoomId, DateTime date)
        {

            if (DateTime.Compare(date.Date, DateTime.Now.Date) < 0)
            {
                MessageBox.Show("Date is before today!");
                return (false, false);
            }
            if (this.roomService.GetById(targetRoomId) == null)
            {
                MessageBox.Show("Room does not exist!");
                return (false,false);
            } 

            return (this.equipmentService.Move(equipmentId, targetRoomId, date),true);
        }

        public List<Equipment> GetByType(EquipmentType query)
        {
            return this.equipmentService.GetByType(query);
        }

        public void MoveFromMoveOrderList()
        {
            this.equipmentService.MoveFromMoveOrderList();
        }
        public EquipmentService equipmentService;
        public RoomService roomService;

        public EquipmentController(RoomService roomService, EquipmentService equipmentService)
        {
            this.roomService = roomService;
            this.equipmentService = equipmentService;
        }

    }
}
