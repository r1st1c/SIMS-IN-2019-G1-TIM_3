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
    public class OperationNotificationRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\operationNotification.json";

        public List<OperationNotification> notifications { get; set; } = new List<OperationNotification>();


        public OperationNotificationRepository() { }

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
                    notifications = JsonConvert.DeserializeObject<List<OperationNotification>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(notifications);
            File.WriteAllText(fileLocation, json);
        }

        public void Create(OperationNotification notification)
        {
            notifications.Add(notification);
            WriteToJson();
        }

        public List<OperationNotification> GetAll()
        {
            ReadJson();
            return notifications;
        }
    }
}
