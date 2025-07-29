using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCoreApp.Base
{
    internal class CustomWindow : Window
    {
        protected void MinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        protected void MaximizeRestoreClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }

        protected void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected void DragWindow(object sender, RoutedEventArgs e)
        {
            DragMove();
        }


    }
}
