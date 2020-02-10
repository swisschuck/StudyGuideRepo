using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFAnimations.Converters
{
    public class ProgressBarColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int progressValue = (int)value;

            if (progressValue <= 30)
            {
                return 0;
            }
            else if (progressValue <= 60)
            {
                return 1;
            }
            else if (progressValue <= 90)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
