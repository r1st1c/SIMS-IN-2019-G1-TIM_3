using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class AnamnesisService
    {
        public AnamnesisRepository anamnesisRepository = new AnamnesisRepository();

        public List<Anamnesis> GetAll()
        {
            return anamnesisRepository.GetAll();
        }

        public Anamnesis GetById(int id)
        {
            return anamnesisRepository.GetById(id);
        }


        public List<Anamnesis> GetByPatientsId(int patientId)
        {
            return this.anamnesisRepository.GetByPatientsId((int)patientId);
        }
    }
}