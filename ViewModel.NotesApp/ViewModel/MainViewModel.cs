using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.NotesApp.Model;
using ViewModel.NotesApp.Services;
using Windows.UI.Popups;

namespace ViewModel.NotesApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly SettingsViewModel settings;
        IDataService dataService;

        private Note note;
        public Note SelectedNote
        {
            get { return note; }
            set
            {
                if (note != null)
                    note.IsSelected = false;
                if (value != null)
                {
                    value.IsSelected = true;
                    note = value;
                }
            }
        }
        private ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes
        {
            get
            {
                if (SearchString == null)
                    SearchString = String.Empty;
                if (notes == null)
                    notes = new ObservableCollection<Note>();
                var temp = dataService.GetAllNotes().Where(x =>
                                x.Header.ToUpper().StartsWith(SearchString.ToUpper())
                                && (!FromDate.HasValue|| x.Date >= FromDate.Value)
                                && (!ToDate.HasValue || x.Date <= ToDate.Value)).ToList();
                if (settings.SortAscending)
                    temp = temp.OrderBy(x => x.Date).Take(settings.Limitation).ToList();
                else
                    temp = temp.OrderByDescending(x => x.Date).ToList();
                notes.Clear();
                foreach (var note in temp)
                {
                    notes.Add(note);
                }
                return notes;
            }
        }
        public string SearchString { set; get; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        private readonly INavigationService navigationService;

        public MainViewModel(IDataService dataService, INavigationService navigationService, SettingsViewModel settings)
        {
            this.dataService = dataService;
            this.settings = settings;
            SearchString = String.Empty;
            Messenger.Default.Register<DeleteMessage>(this, DeleteNote);
            Messenger.Default.Register<EditMessage>(this, NavigateToEditNote);
            this.navigationService = navigationService;
        }

        public void NavigateToNewNote()
        {
            navigationService.NavigateTo(Common.Navigation.Edit);
        }

        public void NavigateToEditNote(EditMessage message)
        {
            navigationService.NavigateTo(Common.Navigation.Edit,message.Content);
        }

        public async void DeleteNote(DeleteMessage message)
        {
            var dialog = new MessageDialog("Do you want to remove this note?");
            dialog.Title = "Confirmation";
            dialog.Commands.Add(new UICommand { Label = "Delete", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                dataService.DeleteNote(message.Content);
                RaisePropertyChanged(nameof(Notes));
            }
        }

        public void NavigateToSettings()
        {
            navigationService.NavigateTo(Common.Navigation.Settings);
        }
    }
}
