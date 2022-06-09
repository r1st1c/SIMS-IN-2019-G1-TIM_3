using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class AnamnesisController
    {
        public AnamnesisController(AnamnesisService anamnesisService)
        {
            this.anamnesisService = anamnesisService;
        }
        public AnamnesisService anamnesisService;

        public List<Anamnesis> GetAll()
        {
            return anamnesisService.GetAll();
        }

        public Anamnesis GetById(int id)
        {
            return anamnesisService.GetById(id);
        }


        public List<Anamnesis> GetByPatientsId(int patientId)
        {
            return this.anamnesisService.GetByPatientsId((int)patientId);
        }
    }
}
