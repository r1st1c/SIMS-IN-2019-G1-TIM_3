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

        public string getName(int id)
        {
            return patientRepository.getName(id);
        }

        public string getSurname(int id)
        {
            return patientRepository.getSurname(id);
        }

        public DateTime getDateOfBirth(int id)
        {
            return patientRepository.getDateOfBirth(id);    
        }

        public string getJMBG(int id)
        {
            return patientRepository.getJMBG(id);   
        }

        public string getAddress(int id)
        {
            return patientRepository.getAddress(id);
        }

        public string getEmail(int id)
        {
            return patientRepository.getEmail(id);
        }

        public string getTelNumber(int id)
        {
            return patientRepository.getTelNumber(id);
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
                return true;
            }
            else
            {
                patientRepository.Delete(patientId);
                return false;
            }
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
