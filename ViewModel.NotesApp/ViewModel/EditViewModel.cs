using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.NotesApp.Model;
using ViewModel.NotesApp.Services;
using Windows.Devices.Geolocation;

namespace ViewModel.NotesApp.ViewModel
{
    public class EditViewModel:ViewModelBase
    {
        private readonly INavigationService navigationService;

        private readonly IDataService dataService;

        private readonly IDialogService dialogService;
        public EditViewModel(INavigationService navigationService, IDataService dataService, IDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dataService = dataService;
            this.dialogService = dialogService;
            note = new MyNote { LatLong = new double[] { 0, 0 } };
        }
        public bool isSavable { get { return note.Content.Length > 3 && note.Header.Length > 3; } }
        private bool isOld = false;
        private MyNote note;
        private MyNote orig;
        public double[] LatLong { get; set; }
        public MyNote Note
        {
            get { return note; }
            set
            {
                if (value != null)
                {
                    orig = value;
                    if (orig.Header != String.Empty && orig.Header != null)
                        isOld = true;
                    note.Content = orig.Content;
                    note.Header = orig.Header;
                    note.Date = orig.Date;
                    if (orig.LatLong == null)
                        orig.LatLong = new double[] { 0, 0 };
                    note.LatLong = orig.LatLong;
                }
                
            }
        }

        private Random random = new Random();
        public async void GetCurrentLocation()
        {

            var access = await Geolocator.RequestAccessAsync();

            switch (access)
            {
                case GeolocationAccessStatus.Allowed:

                    var geolocator = new Geolocator();
                    var geopositon = await geolocator.GetGeopositionAsync();
                    var geopoint = geopositon.Coordinate.Point;

                    var latitude = geopoint.Position.Latitude + random.NextDouble() - 0.5;
                    var longitude = geopoint.Position.Longitude + random.NextDouble() - 0.5;
                    note.LatLong= new double[] {latitude,longitude };
                    break;
                case GeolocationAccessStatus.Unspecified:
                case GeolocationAccessStatus.Denied:
                    note.LatLong = new double[] { 0, 0 };
                    break;
            }

        }

        public async void SaveData()
        {
            if (isOld)
            {
                orig.Content = note.Content;
                orig.Header = note.Header;
                orig.LatLong = note.LatLong;
                orig.Date = DateTime.Now;
                await dataService.SaveNote(orig);
            }
            else
                await dataService.AddNote(note);
            navigationService.GoBack();
        }
}
}
