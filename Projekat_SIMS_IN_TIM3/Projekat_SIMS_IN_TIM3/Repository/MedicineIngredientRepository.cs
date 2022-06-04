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
        private readonly string medicineingredientpath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\medicine_ingredients.csv";

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

        public MedicineIngredient Create(MedicineIngredient toCreate)
        {
            if (File.Exists(medicineingredientpath))
            {
                toCreate.Id = next_id();
                string data = next_id() + "," + toCreate.Name + "\n";
                File.AppendAllText(medicineingredientpath, data);
                return toCreate;
            }
            Debug.Write("Csv file doesn't exist");
            return null;
        }
    }
}
