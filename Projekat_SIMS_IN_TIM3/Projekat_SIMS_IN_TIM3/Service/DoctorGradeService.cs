using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class DoctorGradeService
    {
        public DoctorGradeRepository DoctorGradeRepository = new DoctorGradeRepository();

        public List<DoctorGrade> GetAll()
        {
            return DoctorGradeRepository.GetAll();
        }
    }
}
