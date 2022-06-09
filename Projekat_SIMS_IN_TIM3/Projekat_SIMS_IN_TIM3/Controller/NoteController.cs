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

        public NoteController(NoteService noteService)
        {
            this.noteService = noteService;
        }


        public NoteService noteService;


        public int getNextId()
        {
            return noteService.getNextId();
        }

        public void Create(Model.Note note)
        {
            this.noteService.Create(note);
        }


        public void Delete(int noteId)
        {
            this.noteService.Delete(noteId);
        }

        public List<Note> GetByPatientsId(int patientId)
        {
            return this.noteService.GetByPatientsId((int)patientId);
        }

        public Note GetById(int noteId)
        {
            return this.noteService.GetById((int)noteId);
        }

        
    }
}

