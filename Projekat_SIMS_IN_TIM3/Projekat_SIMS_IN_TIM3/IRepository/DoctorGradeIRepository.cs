using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface DoctorGradeIRepository
    {
        public void readJson();

        public void writeToJson();

        public List<DoctorGrade> GetAll();

        public DoctorGrade GetByDoctorId(int doctorId);
        public void Create(DoctorGrade doctorGrade);

    }
}
