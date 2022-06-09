using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class DoctorGradeController
    {
        public DoctorGradeController(DoctorGradeService doctorGradeService)
        {
            this.DoctorGradeService = doctorGradeService;
        }

        public DoctorGradeService DoctorGradeService;
        public void Create(DoctorGrade grade)
        {
            this.DoctorGradeService.Create(grade);
        }

        public List<DoctorGrade> GetAllByDoctorId(int id)
        {
            return this.DoctorGradeService.GetAllByDoctorId(id);
        }
        public List<DoctorGrade> GetAll()
        {
            return DoctorGradeService.GetAll();
        }
    }
}
