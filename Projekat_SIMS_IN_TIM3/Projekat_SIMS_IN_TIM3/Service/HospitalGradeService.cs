using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using Projekat_SIMS_IN_TIM3.IRepository;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class HospitalGradeService
    {
        public HospitalGradeService(HospitalGradeIRepository hospitalGradeRepository)
        {
            this.HospitalGradeRepository = hospitalGradeRepository;
        }

        public HospitalGradeIRepository HospitalGradeRepository;

        public void Create(HospitalGrade hospitalGrade)
        {
            this.HospitalGradeRepository.Create(hospitalGrade);
        }
        public List<HospitalGrade> GetAll()
        {
            return HospitalGradeRepository.GetAll();
        }
    }
}
