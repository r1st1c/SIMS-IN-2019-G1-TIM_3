using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface NoteIRepository
    {
        public int getNextId();


        public void ReadJson();


        public void WriteToJson();


        public void Create(Model.Note note);




        public void Delete(int noteId);





        public List<Note> GetByPatientsId(int patientId);



        public Note GetById(int noteId);
        

    }
}

