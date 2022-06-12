using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface AnamnesisIRepository
    {
        public void ReadJson();


        public void WriteToJson();



        public List<Anamnesis> GetByPatientsId(int id);


        public Anamnesis GetById(int id);


        public List<Anamnesis> GetAll();
        
    }
}
