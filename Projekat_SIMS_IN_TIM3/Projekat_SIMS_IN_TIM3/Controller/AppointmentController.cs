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
        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
        public AppointmentService appointmentService;
        public int GetNextId()
        {
            return appointmentService.GetNextId();
        }

        public void Create(Appointment appointment)
        {
            this.appointmentService.Create(appointment);
        }

        public void Update(Appointment appointment)
        {
            this.appointmentService.Update(appointment);
        }

        public void Delete(int appointmentId)
        {
            this.appointmentService.Delete(appointmentId);
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


        public bool IsDoctorFree(int doctorId, DateTime start, DateTime end)
        {
            return appointmentService.IsDoctorFree(doctorId, start, end);
        }

        public Boolean Cancel(int patientId, int appointmentId)
        {
            return appointmentService.Cancel(patientId, appointmentId);
        }
       
    }
}

