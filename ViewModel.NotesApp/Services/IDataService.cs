using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.NotesApp.Model;

namespace ViewModel.NotesApp.Services
{
    public interface IDataService
    {
        Task<IEnumerable<MyNote>> GetAllNotes();

        Task AddNote(MyNote note);

        Task SaveNote(MyNote note);

        Task DeleteNote(MyNote note);
    }
}
