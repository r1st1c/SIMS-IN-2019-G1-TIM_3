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
        public DoctorGradeService DoctorGradeService = new DoctorGradeService();

        public List<DoctorGrade> GetAll()
        {
            return DoctorGradeService.GetAll();
        }
    }
}
