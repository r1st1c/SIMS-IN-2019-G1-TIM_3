using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public EquipmentService equipmentService = new EquipmentService();

    }
}
