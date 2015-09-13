using System;
using System.Windows.Data;
using System.Windows.Media;

namespace QuotesInMSWord
{
    public class ValueToColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Brushes.Black;

            double cval = (double)value;
            
            if (cval > 0) return Brushes.Green;
            else if (cval < 0) return Brushes.Red;
            else return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
