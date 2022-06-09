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
    public class HospitalGradeController
    {
        public HospitalGradeController(HospitalGradeService hospitalGradeService)
        {
            this.HospitalGradeService = hospitalGradeService;   
        }

        public HospitalGradeService HospitalGradeService;

        public void Create(HospitalGrade hospitalGrade)
        {
            this.HospitalGradeService.Create(hospitalGrade);
        }
        public List<HospitalGrade> GetAll()
        {
            return HospitalGradeService.GetAll();
        }
    }
}
