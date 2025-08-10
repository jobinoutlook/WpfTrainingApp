using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfCoreApp.Mvvm.ViewModel.ValueConverters
{
    internal class UsernameToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string username = (string)value;
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                return false;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isUsername= (bool)value;
            if(!isUsername) return false;
            return true;
        }
    }
}
