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
    public class OperationRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\operations.json";
        public List<Operation> operations { get; set; } = new List<Operation>();

        public OperationRepository() { }

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
                    operations = JsonConvert.DeserializeObject<List<Operation>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(operations);
            File.WriteAllText(fileLocation, json);
        }

        public List<Operation> getAll()
        {
            ReadJson();
            return operations;
        }

        public void create(Operation operation)
        {
            operations.Add(operation);
            WriteToJson();
        }
    }
}
