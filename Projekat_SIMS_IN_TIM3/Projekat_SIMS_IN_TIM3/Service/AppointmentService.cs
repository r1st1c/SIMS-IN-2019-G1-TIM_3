using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
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

        public int getNextId()
        {
            return appointmentRepository.getNextId();
        }

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

        public int numOfScheduledAppointmentsDuringPeriod(int doctorId, DateTime start, DateTime end)
        {
            return appointmentRepository.numOfScheduledAppointmentsDuringPeriod(doctorId, start, end);
        }


        public bool isDoctorFree(int doctorId, DateTime start, DateTime end)
        {
            return appointmentRepository.isDoctorFree(doctorId, start, end);
        }


        public Boolean cancelAppointment(int patientId, int appointmentId)
        {
            if (canCancelAppointment(patientId))
            {
                freeAppointment(appointmentId);
                addCancellationDate(patientId);
                return true;
            }
            else
            {
                patientService.Delete(patientId);
                return false;
            }
        }

        public void addCancellationDate(int patientId)
        {
            Patient patient = patientService.GetById(patientId);
            patient.CancellationDates.Add(DateTime.Now);
            patientService.Delete(patientId);
            patientService.Save(patient);
        }

        public void freeAppointment(int appointmentId)
        {
            Appointment appointment = appointmentRepository.GetById(appointmentId);

            appointmentRepository.DeleteAppointment(appointmentId);

            appointment.PatientId = -1;

            appointmentRepository.CreateAppointment(appointment);
        }

        public Boolean canCancelAppointment(int patientId)
        {
            Patient patient = patientService.GetById(patientId);

            return cancellationTresholdReached(patient) ? false : true;

        }

        public Boolean cancellationTresholdReached(Patient patient)
        {
            List<DateTime> cancellationDates = patient.CancellationDates;
            int cancellationsCount = cancellationDates.Count();

            if (cancellationsCount < 5)
            {
                return false;
            }

            TimeSpan timeDifference = getTimeDifference(cancellationDates);

            return timeDifference.TotalDays <= 30;

        }

        public TimeSpan getTimeDifference(List<DateTime> cancellationDates)
        {
            int cancellationsCount = cancellationDates.Count();
            DateTime fifthLastCancellation = cancellationDates[cancellationsCount - 5];

            return DateTime.Now - fifthLastCancellation;
        }


        public AppointmentRepository appointmentRepository = new AppointmentRepository();

        public PatientService patientService = new PatientService();

    }
}
