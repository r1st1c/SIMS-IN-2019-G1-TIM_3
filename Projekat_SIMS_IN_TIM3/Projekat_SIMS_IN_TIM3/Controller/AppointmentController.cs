using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class AppointmentController
    {
        public int getNextId()
        {
            return appointmentService.getNextId();
        }

        public void CreateAppointment(Model.Appointment appointment)
        {
            this.appointmentService.CreateAppointment(appointment);
        }

        public void UpdateAppointment(int id, DateTime newStartTime, DateTime newFinishTime, DateTime newDuration)
        {
            this.appointmentService.UpdateAppointment(id, newStartTime, newFinishTime, newDuration);
        }

        public void DeleteAppointment(int appointmentId)
        {
            this.appointmentService.DeleteAppointment(appointmentId);
        }

        public List<Appointment> GetAll()
        {
            return this.appointmentService.GetAll();
        }

        public List<Appointment> GetByDoctorsId(int doctorId)
        {
            return this.appointmentService.GetByDoctorsId(doctorId);
        }

        public List<Appointment> GetByPatientsId(int patientId)
        {
            return this.appointmentService.GetByPatientsId((int)patientId);
        }

        public Appointment GetById(int appointmentId)
        {
            return this.appointmentService.GetById((int)appointmentId);
        }

        public int numOfScheduledAppointmentsDuringPeriod(int doctorId, DateTime start, DateTime end)
        {
            return appointmentService.numOfScheduledAppointmentsDuringPeriod(doctorId, start, end);
        }

        public bool isDoctorFree(int doctorId, DateTime start, DateTime end)
        {
            return appointmentService.isDoctorFree(doctorId, start, end);
        }
        public AppointmentService appointmentService = new AppointmentService();
    }
}

