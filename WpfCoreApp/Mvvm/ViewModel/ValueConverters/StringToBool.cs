using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfCoreApp.Mvvm.ViewModel.ValueConverters
{
    internal class StringToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringvalue = (string)value;
            if (string.IsNullOrEmpty(stringvalue) || string.IsNullOrWhiteSpace(stringvalue))
                return false;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isString = (bool)value;
            if (!isString) return false;
            return true;
        }
    }
}
