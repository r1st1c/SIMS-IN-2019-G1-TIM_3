using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface AppointmentIRepository
    {

        public int GetNextId();

        public void ReadJson();

        public void WriteToJson();

        public void Create(Appointment appointment);

        public void Update(Appointment appointment);
        public void Delete(int appointmentId);
        public List<Appointment> GetAll();

        public List<Appointment> GetByDoctorsId(int doctorId);

        public List<Appointment> GetByPatientsId(int patientId);

        public Appointment GetById(int appointmentId);

        public int NumOfScheduledAppointmentsDuringPeriod(int doctorId, DateTime start, DateTime end);

        public bool IsDoctorFree(int doctorId, DateTime start, DateTime end);
       
    }
}
