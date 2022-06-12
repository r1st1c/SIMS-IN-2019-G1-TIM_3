using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using System.IO;
using Projekat_SIMS_IN_TIM3.IRepository;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class AppointmentRepository : AppointmentIRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\appointments.json";
        public List<Appointment> appointments { get; set; } = new List<Appointment>();

        public AppointmentRepository()
        {
            ReadJson();
        }

        public int GetNextId()
        {
            return appointments.Count != 0 ? appointments.Max(x => x.Id) + 1 : 0;
        }

        public void ReadJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }

            using (StreamReader r = new StreamReader(fileLocation))
            {
                string json = r.ReadToEnd();    
                if (json != "")
                {
                    appointments = JsonConvert.DeserializeObject<List<Appointment>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(appointments);
            File.WriteAllText(fileLocation, json);
        }

        public void Create(Appointment appointment)
        {
            appointments.Add(appointment);
            WriteToJson();
        }

        public void Update(Appointment appointment)
        {
            // TODO: implement
            return;
        }

        public void Delete(int appointmentId)
        {
            ReadJson();
            int index = appointments.FindIndex(obj => obj.Id == appointmentId);
            appointments.RemoveAt(index);
            WriteToJson();
        }

        public List<Appointment> GetAll()
        {
            ReadJson();
            return appointments;
        }

        public List<Appointment> GetByDoctorsId(int doctorId)
        {
            ReadJson();
            
            return appointments.FindAll(obj => obj.DoctorId == doctorId);
        }

        public List<Appointment> GetByPatientsId(int patientId)
        {
            ReadJson();
            return appointments.FindAll(obj => obj.PatientId == patientId);
            
        }

        public Appointment GetById(int appointmentId)
        {
            ReadJson();
            return appointments.Find(obj => obj.Id == appointmentId);
        }

        
    }
}
