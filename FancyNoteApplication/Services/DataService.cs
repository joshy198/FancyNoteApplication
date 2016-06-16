using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.NotesApp.Model;
using ViewModel.NotesApp.Services;

namespace FancyNoteApplication.Services
{
    public class DataService:IDataService
    {
        private readonly List<Note> allNotes;
        private IStorageService storageService;

        public DataService(IStorageService storageService)
        {
            this.storageService = storageService;
            if (allNotes == null)
                allNotes=NotesFromJson();
        }
        public IEnumerable<Note> GetAllNotes()
        {
            return allNotes;
        }

        public void AddNote(Note note)
        {
            allNotes.Add(note);
            NotesToJson();
        }

        public void SaveNote(Note note)
        {
            note.Date = DateTime.Now;
            NotesToJson();
        }

        public void DeleteNote(Note note)
        {
            allNotes.Remove(note);
        }
        private void NotesToJson()
        {
            storageService.Write(nameof(allNotes), allNotes);
        }
        private List<Note> NotesFromJson()
        {
            return storageService.Read<List<Note>>(nameof(allNotes), new List<Note>());
        }
    }
}
