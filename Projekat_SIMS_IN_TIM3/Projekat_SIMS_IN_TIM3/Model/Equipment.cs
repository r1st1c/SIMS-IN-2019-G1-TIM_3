using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public enum EquipmentType
    {
        static_equipment,
        dynamic_equipment
    }
    public class Equipment
    {
        
        public int Id { get; set; }
        public string Equipmentname { get; set; }
        public string Manufacturer { get; set; }
        public EquipmentType Equipmenttype { get; set; }
        public int RoomId { get; set; }

        public Equipment(int id,string equipmentname,string manufacturer, EquipmentType equipmentType, int roomId)
        {
            Id = id;
            Equipmentname = equipmentname;
            Manufacturer = manufacturer;
            Equipmenttype = equipmentType;
            RoomId = roomId;
        }


    }
}
