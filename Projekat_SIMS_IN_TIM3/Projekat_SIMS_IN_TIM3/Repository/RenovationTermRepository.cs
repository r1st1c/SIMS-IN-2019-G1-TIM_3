using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class RenovationTermRepository
    {
        private readonly string roombasicrenovationpath =
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName +
            "\\Data\\room_basic_renovation.csv";
        public bool ScheduleRenovation(RenovationTerm renovationTerm)
        {
            if (File.Exists(roombasicrenovationpath))
            {
                string data = renovationTerm.RoomId + "," + renovationTerm.Range.Start.ToShortDateString() + "," + renovationTerm.Range.End.ToShortDateString() + "," + renovationTerm.Description + "\n";
                File.AppendAllText(roombasicrenovationpath, data);
                return true;
            }

            Debug.Write("Csv file doesn't exist");
            return false;
        }

        public List<RenovationTerm> GetRenovationSchedules()
        {
            string[] csvLines = File.ReadAllLines(roombasicrenovationpath);
            List<RenovationTerm> list = new List<RenovationTerm>();
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }

                string[] data = csvLines[i].Split(',');
                list.Add(new RenovationTerm(
                    Int32.Parse(data[0]),
                    DateTime.ParseExact(data[1], "dd-MMM-yy", null),
                    DateTime.ParseExact(data[2], "dd-MMM-yy", null),
                    data[3]
                ));
            }

            return list;
        }

        public void DeleteScheduling(RenovationTerm renovationTerm)
        {
            string[] csvLines = File.ReadAllLines(roombasicrenovationpath);
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }

                string[] data = csvLines[i].Split(',');
                if (Int32.Parse(data[0]) == renovationTerm.RoomId && renovationTerm.Range.Start.ToShortDateString().Equals(data[1]) &&
                    renovationTerm.Range.End.ToShortDateString().Equals(data[2]))
                {
                    csvLines[i] = "";
                }
            }

            File.WriteAllLines(roombasicrenovationpath, csvLines);
        }
    }
}
