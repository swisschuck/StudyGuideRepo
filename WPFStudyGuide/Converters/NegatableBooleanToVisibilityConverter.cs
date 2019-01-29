using System;
using System.Windows;
using System.Windows.Data;

namespace WPFStudyGuide.Converters
{
    public class NegatableBooleanToVisibilityConverter : IValueConverter
    {
        // Negatable - to deny the existence or truth of
        //           - to nullify or make ineffective

        #region fields
        #endregion fields


        #region properties

        public bool Negate { get; set; }
        public Visibility FalseVisibility { get; set; }

        #endregion properties


        #region constructors

        public NegatableBooleanToVisibilityConverter()
        {
            FalseVisibility = Visibility.Collapsed;
        }

        #endregion constructors


        #region public methods

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool booleanValue;
            bool booleanConvertResult = bool.TryParse(value.ToString(), out booleanValue);


            if (!booleanConvertResult)
            {
                return value;
            }

            if (booleanValue && !Negate)
            {
                return Visibility.Visible;
            }

            if (booleanValue && Negate)
            {
                return FalseVisibility;
            }

            if (!booleanValue && Negate)
            {
                return Visibility.Visible;
            }

            if (!booleanValue && !Negate)
            {
                return FalseVisibility;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
