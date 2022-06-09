using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.IRepository;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class AppointmentService
    {
        public AppointmentService(AppointmentIRepository appointmentRepository, PatientService patientService)
        {
            this.patientService = patientService;
            this.appointmentRepository = appointmentRepository;
        }

        public AppointmentIRepository appointmentRepository;
        public PatientService patientService;


        public int GetNextId()
        {
            return appointmentRepository.GetNextId();
        }

        public void Create(Appointment appointment)
        {
            this.appointmentRepository.Create(appointment);
        }

        public void Update(Appointment appointment)
        {
            this.appointmentRepository.Update(appointment);
        }

        public void Delete(int appointmentId)
        {
            this.appointmentRepository.Delete(appointmentId);
        }

        public List<Appointment> GetAll()
        {
            return this.appointmentRepository.GetAll();
        }

        public List<Appointment> GetByDoctorsId(int id)
        {
            return this.appointmentRepository.GetByDoctorsId((int)id);
        }

        public List<Appointment> GetByPatientsId(int id)
        {
            return this.appointmentRepository.GetByPatientsId((int)id);
        }

        public Appointment GetById(int id)
        {
            return this.appointmentRepository.GetById((int)id);
        }


        public int NumOfScheduledAppointmentsDuringPeriod(int doctorId, DateTime start, DateTime end)
        {
            
            List<Appointment> appointmentsByDoctor = GetByDoctorsId(doctorId);
            int scheduledAppointments = 0;

            foreach (Appointment appointment in appointmentsByDoctor)
            {
                scheduledAppointments = (appointment.StartTime.Date >= start.Date && appointment.StartTime.Date <= end) ? scheduledAppointments++ : 0;  
            }
            return scheduledAppointments;
        }

        public bool IsDoctorFree(int doctorId, DateTime start, DateTime end)
        {
            int numOfScheduledAppointments = NumOfScheduledAppointmentsDuringPeriod(doctorId, start, end);
           
            return (numOfScheduledAppointments > 0) ? false : true;
        }

       

        public Boolean Cancel(int patientId, int appointmentId)
        {
            if (CanCancelAppointment(patientId))
            {
                FreeAppointment(appointmentId);
                AddCancellationDate(patientId);
                return true;
            }
            else
            {
                patientService.Delete(patientId);
                return false;
            }
        }

        public void AddCancellationDate(int patientId)
        {
            Patient patient = patientService.GetById(patientId);
            patient.CancellationDates.Add(DateTime.Now);
            patientService.Delete(patientId);
            patientService.Save(patient);
        }

        public void FreeAppointment(int appointmentId)
        {
            Appointment appointment = appointmentRepository.GetById(appointmentId);

            appointmentRepository.Delete(appointmentId);

            appointment.PatientId = -1;

            appointmentRepository.Create(appointment);
        }

        public Boolean CanCancelAppointment(int patientId)
        {
            Patient patient = patientService.GetById(patientId);

            return CancellationTresholdReached(patient) ? false : true;

        }

        public Boolean CancellationTresholdReached(Patient patient)
        {
            List<DateTime> cancellationDates = patient.CancellationDates;
            int cancellationsCount = cancellationDates.Count();

            if (cancellationsCount < 5)
            {
                return false;
            }

            TimeSpan timeDifference = GetTimeDifference(cancellationDates);

            return timeDifference.TotalDays <= 30;

        }

        public TimeSpan GetTimeDifference(List<DateTime> cancellationDates)
        {
            int cancellationsCount = cancellationDates.Count();
            DateTime fifthLastCancellation = cancellationDates[cancellationsCount - 5];

            return DateTime.Now - fifthLastCancellation;
        }


    }
}
