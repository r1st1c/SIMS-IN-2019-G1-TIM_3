using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    internal class Equipment
    {
        public enum EquipmentType
        {
            static_equipment,
            dynamic_equipment
        }

        public string Equipmentname { get; set; }
        public string Manufacturer { get; set; }
        public EquipmentType Equipmenttype { get; set; }
        public int Id { get; set; }




    }
}
