using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.UCL.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public List<Note> Notes
        {
            get
            {
                return Services.FullCollection.Where(x =>
                                x.Header.ToUpper().StartsWith(SearchString.ToUpper())
                                && (FromDate == null || x.Date >= FromDate)
                                && (ToDate == null || x.Date <= ToDate));
            }
        }
        public string SearchString { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public void NavigateToEditNote()
        { }
        public void NavigateToNewNote()
        { }
        public void DeleteNote()
        { }
        public void NavigateToSettings()
        { }
    }
}
