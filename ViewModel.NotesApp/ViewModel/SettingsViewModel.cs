using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.NotesApp.Services;

namespace ViewModel.NotesApp.ViewModel
{
    public class SettingsViewModel:ViewModelBase
    {
        private readonly IStorageService storageService;
        public SettingsViewModel(IStorageService storageService)
        {
            this.storageService = storageService;
            Load();
        }
        public int Limitation { get; set; }
        public bool SortAscending { get; set; }

        public void Save()
        {
            storageService.Write(nameof(Limitation), Limitation);
            storageService.Write(nameof(SortAscending), SortAscending);
        }

        public void Load()
        {
            Limitation = storageService.Read<int>(nameof(Limitation), 5);
            SortAscending = storageService.Read<bool>(nameof(SortAscending), true);
        }
    }
}
