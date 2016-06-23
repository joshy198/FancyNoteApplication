using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Data;

namespace FancyNoteApplication.Converters
{
    public class LatLongToGeopositionConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var LatLong = value as double[];
            return new Geopoint(new BasicGeoposition
            {
                Latitude = LatLong[0],
                Longitude = LatLong[1],
            });
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
