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
    public class ReportRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\reports.json";
        public List<Report> reports = new List<Report>();
        public ReportRepository()
        {
            ReadJson();
        }

        public int GetNextId()
        {
            return reports.Count != 0 ? reports.Max(x => x.Id) + 1 : 0;
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
                    reports = JsonConvert.DeserializeObject<List<Report>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(reports);
            File.WriteAllText(fileLocation, json);
        }

        public void Create(Report rp)
        {
            reports.Add(rp);
            WriteToJson();
        }

        public void Update(Report rp)
        {
            ReadJson();
            int idx = reports.FindIndex(obj => obj.Id == rp.Id);
            reports[idx] = rp;
            WriteToJson();
        }

        public List<Report> GetAll()
        {
            ReadJson();
            return reports;
        }

        public void Delete(int id)
        {
            ReadJson();
            int index = reports.FindIndex(obj => obj.Id == id);
            reports.RemoveAt(index);
            WriteToJson();
        }

        public List<Report> GetAllById(int id)
        {
            ReadJson();
            return reports.FindAll(obj => obj.PatientId == id);
        }

        public Report GetById(int id)
        {
            ReadJson();
            return reports.Find(obj => obj.Id == id);
        }
    }
}
