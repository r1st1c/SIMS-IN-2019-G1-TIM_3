using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.IRepository;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class AnamnesisService
    {
        public AnamnesisService(AnamnesisIRepository anamnesisRepository)
        {
            this.anamnesisRepository = anamnesisRepository;
        }

        public AnamnesisIRepository anamnesisRepository;

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