using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.NotesApp.Model
{
    public class Note:ObservableObject
    {
        public DateTime Date{get;set;}
        private string header;
        public bool IsSelected { get; set; }
        public string Header { get { return header; }set { header = value;Date = DateTime.Now; } }
        private string content;
        public string Content { get { return content; } set { content = value;Date = DateTime.Now; } }
        public string Disp_Notes
        {
            get
            {
                if (Content == null)
                    Content = "";
                if (Content.Length > 50)
                    return Content.Replace(System.Environment.NewLine, " ").Remove(60) + "...";
                else
                    return Content.Replace(System.Environment.NewLine, " ");
            }
        }
        public void Delete()
        {
            Messenger.Default.Send(new DeleteMessage(this));
            //System.Diagnostics.Debug.WriteLine("Delete Message: "+Header);
        }
        public void Edit()
        {
            Messenger.Default.Send(new EditMessage(this));
            //System.Diagnostics.Debug.WriteLine("Edit Message: " + Header);
        }
    }
}
