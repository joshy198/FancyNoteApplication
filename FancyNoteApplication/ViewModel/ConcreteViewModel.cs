using FancyNoteApplication.Services;
using FancyNoteApplication.View;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ViewModel.NotesApp.Common;
using ViewModel.NotesApp.Services;
using ViewModel.NotesApp.ViewModel;

namespace FancyNoteApplication.ViewModel
{
    public class ConcreteViewModel:ViewModelLocator
    {
        static ConcreteViewModel()
        {
            SimpleIoc.Default.Register(RegisterNavigationService);
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IStorageService, LocalStorageService>();
            //SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<IDataService, CloudDataService>();
        }
        private static INavigationService RegisterNavigationService()
        {
            var service = new NavigationService();
            service.Configure(Navigation.MainView, typeof(MainPage));
            service.Configure(Navigation.Edit, typeof(Edit));
            service.Configure(Navigation.Settings, typeof(Settings));
            return service;
        }
    }
}
