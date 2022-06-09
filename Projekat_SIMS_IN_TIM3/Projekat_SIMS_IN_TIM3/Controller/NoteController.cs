using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class NoteController
    {
        public int getNextId()
        {
            return noteService.getNextId();
        }

        public void CreateNote(Model.Note note)
        {
            this.noteService.CreateNote(note);
        }


        public void DeleteNode(int noteId)
        {
            this.noteService.DeleteNote(noteId);
        }

        public List<Note> GetByPatientsId(int patientId)
        {
            return this.noteService.GetByPatientsId((int)patientId);
        }

        public Note GetById(int noteId)
        {
            return this.noteService.GetById((int)noteId);
        }

        public NoteService noteService = new NoteService();
    }
}

