using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.IRepository;

namespace Projekat_SIMS_IN_TIM3.Service
    {
        public class NoteService
        {
        public NoteIRepository noteRepository;

        public NoteService(NoteIRepository noteRepository)
            {
            this.noteRepository = noteRepository;
            }

           
            public int getNextId()
            {
                return noteRepository.getNextId();
            }

            public void Create(Model.Note note)
            {
                this.noteRepository.Create(note);
            }


            public void Delete(int noteId)
            {
                this.noteRepository.Delete(noteId);
            }

            public List<Note> GetByPatientsId(int patientId)
            {
                return this.noteRepository.GetByPatientsId((int)patientId);
            }

            public Note GetById(int noteId)
            {
                return this.noteRepository.GetById((int)noteId);
            }

           

        }
}


