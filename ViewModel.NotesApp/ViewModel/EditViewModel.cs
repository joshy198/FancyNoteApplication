using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.NotesApp.Model;
using ViewModel.NotesApp.Services;

namespace ViewModel.NotesApp.ViewModel
{
    public class EditViewModel:ViewModelBase
    {
        private readonly INavigationService navigationService;

        private readonly IDataService dataService;

        private readonly IDialogService dialogService;
        public EditViewModel(INavigationService navigationService,
                                      IDataService dataService, 
									  IDialogService dialogService)
		{
			this.navigationService = navigationService;
			this.dataService = dataService;
			this.dialogService = dialogService;
            note = new Note();
        }
        public bool isSavable { get { return note.Content.Length > 3 && note.Header.Length > 3; } }
        private bool isOld = false;
        private Note note;
        private Note orig;
        public Note Note
        {
            get { return note; }
            set
            {
                if (value != null)
                { 
                    isOld = true;
                    orig = value;
                    note.Content = orig.Content;
                    note.Header = orig.Header;
                    note.Date = orig.Date;
                }
                
            }
        }
        public void SaveData()
        {
            if (isOld)
            {
                orig.Content = note.Content;
                orig.Header = note.Header;
                dataService.SaveNote(orig);
            }
            else
                dataService.AddNote(note);
            navigationService.GoBack();
        }
}
}
