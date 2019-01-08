using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFStudyGuide.Classes
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.ToString("d");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string stringValue = value as string;
            DateTime resultDateTime;

            if (DateTime.TryParse(stringValue, out resultDateTime))
            {
                return resultDateTime;
            }

            throw new Exception("failed to convert date time");
        }
    }
}
