using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
    {
        public class NoteService
        {

            public int getNextId()
            {
                return noteRepository.getNextId();
            }

            public void CreateNote(Model.Note note)
            {
                this.noteRepository.CreateNote(note);
            }


            public void DeleteNote(int noteId)
            {
                this.noteRepository.DeleteNote(noteId);
            }

            public List<Note> GetByPatientsId(int patientId)
            {
                return this.noteRepository.GetByPatientsId((int)patientId);
            }

            public Note GetById(int noteId)
            {
                return this.noteRepository.GetById((int)noteId);
            }

            public NoteRepository noteRepository = new NoteRepository();

        }
}


