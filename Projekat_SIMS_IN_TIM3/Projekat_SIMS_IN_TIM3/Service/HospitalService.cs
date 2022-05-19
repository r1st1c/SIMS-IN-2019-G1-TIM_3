using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class HospitalService
    {
        public HospitalRepository hospitalRepository = new HospitalRepository();  

        public void addGrade(HospitalGradeDTO gradeDTO)
        {
            Hospital hospital = hospitalRepository.Get();

            hospital = applyGrades(hospital, gradeDTO);

            hospitalRepository.DeleteHospital();
            hospitalRepository.CreateHospital(hospital);
        }

        public Hospital applyGrades(Hospital hospital, HospitalGradeDTO gradeDTO)
        {
     
            hospital.RoomsGrades.Add(gradeDTO.RoomGrade);
            hospital.StaffGrades.Add(gradeDTO.StaffGrade);
            hospital.HospitalityGrades.Add(gradeDTO.HospitalityGrade);
            hospital.LocationGrades.Add(gradeDTO.LocationGrade);   
            hospital.CleanlinessGrades.Add(gradeDTO.CleanlinessGrade);

            return hospital;
        }

    }
}
