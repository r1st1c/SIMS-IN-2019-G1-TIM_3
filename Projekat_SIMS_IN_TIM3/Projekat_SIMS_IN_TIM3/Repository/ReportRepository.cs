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
            readJson();
        }

        public int getNextId()
        {
            int lastId = int.MinValue;
            readJson();
            foreach(Report report in reports)
            {
                if(reports == null)
                {
                    lastId = 0;
                } else
                {
                    lastId = reports.Last().Id;
                }
                
            }
            return lastId;
        }

        public void readJson()
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

        public void create(Report mp)
        {
            reports.Add(mp);
            WriteToJson();
        }

        public void update(Report mp)
        {
            readJson();
            int idx = reports.FindIndex(obj => obj.Id == mp.Id);
            reports[idx] = mp;
            WriteToJson();
        }

        public List<Report> getAll()
        {
            readJson();
            return reports;
        }

        public void delete(int rId)
        {
            readJson();
            int index = reports.FindIndex(obj => obj.Id == rId);
            reports.RemoveAt(index);
            WriteToJson();
        }

        public List<Report> getAllById(int id)
        {
            readJson();
            return reports.FindAll(obj => obj.PatientId == id);
        }

        public Report getById(int id)
        {
            readJson();
            return reports.Find(obj => obj.Id == id);
        }
    }
}
