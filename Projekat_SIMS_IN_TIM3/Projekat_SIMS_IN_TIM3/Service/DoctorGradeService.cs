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
    public class DoctorGradeService
    {
        public DoctorGradeService(DoctorGradeIRepository doctorGradeRepository)
        {
            this.DoctorGradeRepository = doctorGradeRepository; 
        }

        public DoctorGradeIRepository DoctorGradeRepository;

        public void Create(DoctorGrade grade)
        {
            this.DoctorGradeRepository.Create(grade);
        }

        //pisao kolega branislav!!!!!!!
        public List<DoctorGrade> GetAllByDoctorId(int id)
        {
            List<DoctorGrade> retVal = new List<DoctorGrade>();
            foreach (var grade in this.GetAll())
            {
                if (grade.doctorId == id)
                {
                    retVal.Add(grade);
                }
            }
            return retVal;
        }
        public List<DoctorGrade> GetAll()
        {
            return DoctorGradeRepository.GetAll();
        }

        
    }
}
