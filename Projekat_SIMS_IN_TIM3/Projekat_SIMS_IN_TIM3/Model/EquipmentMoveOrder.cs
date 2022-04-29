using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    internal class EquipmentMoveOrder
    {
        //DTO FOR SENDING BACK INFORMATION WHEN READING FROM FILE
        public int EquipmentId { get; set; }
        public DateTime dateOfMoving { get; set; } 
    }
}
