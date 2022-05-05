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
    }
}
