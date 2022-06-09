using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using System.IO;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class NoteRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\notes.json";
        public List<Note> notes { get; set; } = new List<Note>();

        public static int maxId=0;
        public NoteRepository()
        {
            ReadJson();
        }

        public int getNextId()
        {
            
            ReadJson();
           

            maxId++;

            return maxId;
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
                    notes = JsonConvert.DeserializeObject<List<Note>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText(fileLocation, json);
        }

        public void CreateNote(Model.Note note)
        {
            notes.Add(note);
            WriteToJson();
        }


        public void DeleteNote(int noteId)
        {
            ReadJson();
            int index = notes.FindIndex(obj => obj.Id == noteId);
            notes.RemoveAt(index);
            WriteToJson();
        }

       

        public List<Note> GetByPatientsId(int patientId)
        {
            ReadJson();
            return notes.FindAll(obj => obj.PatientId == patientId);

        }

        public Note GetById(int noteId)
        {
            
            ReadJson();
            Note ret = new Note(1, "Naslov", DateTime.Now);

            foreach (Note note in notes)
            {
                if (note.Id == noteId)
                {
                    ret = note;
                }
            }

            return ret;
        }

    }
}
