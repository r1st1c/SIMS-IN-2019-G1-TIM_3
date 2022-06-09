using Newtonsoft.Json;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class RejectedMedicineNotificationRepository
    {

        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\rejectedMeds.json";
        public List<RejectedMedicineNotification> notifications { get; set; } = new List<RejectedMedicineNotification>();

        public RejectedMedicineNotificationRepository() { }

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
                    notifications = JsonConvert.DeserializeObject<List<RejectedMedicineNotification>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(notifications);
            File.WriteAllText(fileLocation, json);
        }

        public List<RejectedMedicineNotification> GetAll()
        {
            ReadJson();
            return notifications;
        }

        public void Create(RejectedMedicineNotification notification)
        {
            notifications.Add(notification);
            WriteToJson();
        }

        public void Delete(int notificationId)
        {
            ReadJson();
            int index = notifications.FindIndex(obj => obj.Id == notificationId);
            notifications.RemoveAt(index);
            WriteToJson();
        }

    }
}
