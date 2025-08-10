using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfCoreApp.Mvvm.ViewModel.ValueConverters
{
    internal class PasswordToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string password = (string)value;
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                return false;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isPassword = (bool)value;
            if (!isPassword) return false;
            return true;
        }
    }
}
