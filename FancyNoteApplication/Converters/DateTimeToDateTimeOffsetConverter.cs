using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FancyNoteApplication.Converters
{
    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = value as DateTime?;
            if (!date.HasValue) return null;

            return new DateTimeOffset(date.Value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var date = value as DateTimeOffset?;

            return date?.DateTime;
        }
    }
}
