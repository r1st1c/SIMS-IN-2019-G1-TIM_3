using Newtonsoft.Json;
using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class AbsenceNotificationsRepository : AbsenceNotificationsIRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\absenceNotifications.json";
        public List<AbsenceNotification> notifications { get; set; } = new List<AbsenceNotification>();
        
        public AbsenceNotificationsRepository() { ReadJson(); }
        public void Create(AbsenceNotification notification)
        {
            notifications.Add(notification);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            notifications.RemoveAt(notifications.FindIndex(obj => obj.Id == id));
            WriteToJson();
        }

        public List<AbsenceNotification> GetAll()
        {
            ReadJson();
            return notifications;
        }

        public List<AbsenceNotification> GetByDoctorsId(int id)
        {
            ReadJson();
            return notifications.FindAll(obj => obj.AbsenceRequest.DoctorId == id);
        }

        public AbsenceNotification GetById(int id)
        {
            ReadJson();
            return notifications.Find(obj => obj.Id == id);
        }

        public int GetNextId()
        {
            return notifications.Count != 0 ? notifications.Max(x => x.Id) + 1 : 0;
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
                    notifications = JsonConvert.DeserializeObject<List<AbsenceNotification>>(json);
                }
            }
        }

        public void Update(AbsenceNotification notification)
        {
            throw new NotImplementedException();
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(notifications);
            File.WriteAllText(fileLocation, json);
        }
    }
}
