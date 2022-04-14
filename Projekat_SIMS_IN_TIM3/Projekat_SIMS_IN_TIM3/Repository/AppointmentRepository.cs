using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class AppointmentRepository
    {
        public List<Appointment> getAll()
        {
            List<Appointment> appointments = new List<Appointment>();
            string[] csv = File.ReadAllLines(@"C:\Users\Elena\Desktop\appointmentsData.csv");

            for (int i = 0; i < csv.Length; ++i)
            {
                if (csv[i] == "")
                {
                    continue;
                }

                string[] csv_data = csv[i].Split(';');
                appointments.Add(new Appointment(
                    int.Parse(csv_data[0]),
                    DateTime.Parse(csv_data[1]),
                    int.Parse(csv_data[2]),
                    Enum.Parse<AppointmentType>(csv_data[3]),
                    int.Parse(csv_data[4]),
                    int.Parse(csv_data[5])
                    ));
            }

            return appointments;
        }
    }
}
