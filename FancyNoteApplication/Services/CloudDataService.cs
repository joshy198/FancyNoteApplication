using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViewModel.NotesApp.Model;
using ViewModel.NotesApp.Services;

namespace FancyNoteApplication.Services
{
    public class CloudDataService : IDataService
    {

        private string Uri => $"http://notesservice.azurewebsites.net/api/1510237039/Notes";

        private readonly HttpClient client = new HttpClient();

        public async Task<IEnumerable<MyNote>> GetAllNotes()
        {
            var json = await client.GetStringAsync(Uri);
            var notes = new List<MyNote>();
            foreach (var n in JsonConvert.DeserializeObject<IEnumerable<Note>>(json))
            {
                notes.Add(new MyNote() { Id=n.Id, Content=n.Description, Header=n.Title, Date=n.CreatedAt, LatLong=new double[] {n.Latitude, n.Longitude } });
            }
            return notes;
        }

        public async Task AddNote(MyNote mnote)
        {
            var note = MyNoteToNote(mnote);
            var json = JsonConvert.SerializeObject(note);
            var response = await client.PostAsync(Uri, new JsonContent(json));
        }

        public async Task SaveNote(MyNote mnote)
        {
            await DeleteNote(mnote);
            await AddNote(mnote);
            /*Cloud Service sagt immer no content*/
            /*var note = MyNoteToNote(mnote);
            var json = JsonConvert.SerializeObject(note);
            await client.PutAsync($"{Uri}/{note.Id}", new JsonContent(json));*/
        }

        public async Task DeleteNote(MyNote mnote)
        {
            var note = MyNoteToNote(mnote);
            await client.DeleteAsync($"{Uri}/{note.Id}");
        }

        private Note MyNoteToNote(MyNote m)
        {
            return new Note() { Id=m.Id, CreatedAt=m.Date, Description=m.Content, Title=m.Header, Latitude=m.LatLong[0], Longitude=m.LatLong[1]};
        }

    }

    public class JsonContent : StringContent
    {
        public JsonContent(string content) : this(content, Encoding.UTF8) { }

        private JsonContent(string content, Encoding encoding, string mediaType = "application/json") : base(content, encoding, mediaType) { }
    }
}
