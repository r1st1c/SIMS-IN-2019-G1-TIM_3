using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class MedicineIngredientRepository
    {
        private readonly string medicineingredientpath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\room_split.csv";

        public int next_id()
        {
            string[] csvLines = File.ReadAllLines(medicineingredientpath);
            return csvLines.Length;
        }

        public MedicineIngredient GetById(int id)
        {
            List<MedicineIngredient> all = this.GetAll();
            foreach (MedicineIngredient ingredient in all)
            {
                if (ingredient.Id == id)
                {
                    return ingredient;
                }
            }
            return null;
        }

        public List<MedicineIngredient> GetAll()
        {
            string[] csvLines = File.ReadAllLines(medicineingredientpath);
            List<MedicineIngredient> found = new List<MedicineIngredient>();
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }
                string[] data = csvLines[i].Split(',');

                found.Add(new MedicineIngredient(Int32.Parse(data[0]), data[1]));

            }
            return found;
        }

        public bool Create(MedicineIngredient toCreate)
        {
            if (File.Exists(medicineingredientpath))
            {
                string data = next_id() + "," + toCreate.Name + "\n";
                File.AppendAllText(medicineingredientpath, data);
                return true;
            }
            Debug.Write("Csv file doesnt exist");
            return false;
        }

        public bool Update(MedicineIngredient toUpdate)
        {
            string[] csvLines = File.ReadAllLines(medicineingredientpath);
            csvLines[toUpdate.Id] = toUpdate.Id + "," + toUpdate.Name;
            File.WriteAllLines(medicineingredientpath, csvLines);
            return true;
        }

        public bool DeleteById(int id)
        {
            string[] csvLines = File.ReadAllLines(medicineingredientpath);
            csvLines[id] = "";
            File.WriteAllLines(medicineingredientpath, csvLines);
            return true;
        }
    }
}
