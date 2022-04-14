using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class AppointmentService
    {
        public void CreateAppointment(Model.Appointment appointment)
        {
            this.appointmentRepository.CreateAppointment(appointment);
        }

        public void UpdateAppointment(int id, DateTime newStartTime, DateTime newFinishTime, DateTime newDuration)
        {
            this.appointmentRepository.UpdateAppointment(id, newStartTime, newFinishTime, newDuration);
        }

        public void DeleteAppointment(int appointmentId)
        {
            this.appointmentRepository.DeleteAppointment(appointmentId);
        }

        public List<Appointment> GetAll()
        {
            return this.appointmentRepository.GetAll();
        }

        public List<Appointment> GetByDoctorsId(int doctorId)
        {
            return this.appointmentRepository.GetByDoctorsId((int)doctorId);
        }

        public List<Appointment> GetByPatientsId(int patientId)
        {
            return this.appointmentRepository.GetByPatientsId((int)patientId);
        }

        public Appointment GetById(int appointmentId)
        {
            return this.appointmentRepository.GetById((int)appointmentId);
        }

        public AppointmentRepository appointmentRepository = new AppointmentRepository();

    }
}
