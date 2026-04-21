using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WpfCoreApp.Mvvm.Model;

namespace WpfCoreApp.AppHelper
{
    public class CitizenWindowTupleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var citizen = values[0] as Citizen;
            var window = values[1] as Window;
            return Tuple.Create(citizen, window);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
