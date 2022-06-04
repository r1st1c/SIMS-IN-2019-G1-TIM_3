using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class PatientService
    {
        private PatientRepository patientRepository = new PatientRepository();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        public List<Patient> GetAll()
        {
            return patientRepository.GetAll();
        }

        public Patient GetById(int id)
        {
            return patientRepository.GetById(id);
        }

        public bool Save(Patient patient)
        {
            return patientRepository.Save(patient);
        }

        public bool Delete(int patient)
        {
            return patientRepository.Delete(patient);
        }

        public List<string> nameSurname()
        {
            return patientRepository.nameSurname();
        }

        

        public int getIdByNameAndSurname(string name, string surname)
        {
            return patientRepository.getIdByNameAndSurname(name, surname);
        }

        public Boolean cancelAppointment(int patientId, int appointmentId)
        {
            if(canCancelAppointment(patientId))
            {
                freeAppointment(appointmentId);
                addCancellationDate(patientId);
                return true;
            }
            else
            {
                patientRepository.Delete(patientId);
                return false;
            }
        }

        public void addCancellationDate(int patientId)
        {
            Patient patient = patientRepository.GetById(patientId);
            patient.CancellationDates.Add(DateTime.Now);
            patientRepository.Delete(patientId);
            patientRepository.Save(patient);
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
            Patient patient = patientRepository.GetById(patientId);

            return cancellationTresholdReached(patient) ? false : true;

        }

        public Boolean cancellationTresholdReached(Patient patient)
        {
            List<DateTime> cancellationDates = patient.CancellationDates;
            int cancellationsCount = cancellationDates.Count();

            if(cancellationsCount < 5)
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

      


    }
}
