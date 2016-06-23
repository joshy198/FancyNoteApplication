using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.NotesApp.Model
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonProperty("Content")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
