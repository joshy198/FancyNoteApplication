using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.NotesApp.Model;
using ViewModel.NotesApp.Services;

namespace FancyNoteApplication.Services
{
  /*  public class DataService:IDataService
    {
        private readonly List<MyNote> allNotes;
        private IStorageService storageService;

        public DataService(IStorageService storageService)
        {
            this.storageService = storageService;
            if (allNotes == null)
                allNotes=NotesFromJson();
        }
        public async Task<IEnumerable<MyNote>> GetAllNotes()
        {
            return allNotes;
        }

        public async Task AddNote(MyNote note)
        {
            allNotes.Add(note);
             NotesToJson();
        }

        public async Task SaveNote(MyNote note)
        {
            note.Date = DateTime.Now;
             NotesToJson();
        }

        public async Task DeleteNote(MyNote note)
        {
             allNotes.Remove(note);
        }
        private void NotesToJson()
        {
            storageService.Write(nameof(allNotes), allNotes);
        }
        private List<MyNote> NotesFromJson()
        {
            return storageService.Read<List<MyNote>>(nameof(allNotes), new List<MyNote>());
        }
    }*/
}
