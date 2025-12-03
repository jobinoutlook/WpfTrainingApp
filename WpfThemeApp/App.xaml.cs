using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfThemeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {

                Window window = Window.GetWindow(sender as DependencyObject);


                // Allow dragging the window when single click
                if (e.ClickCount == 1)
                {
                    window?.DragMove();
                }

                // Handle double click: toggle maximize/restore
                if (e.ClickCount == 2)
                {
                    if (window?.WindowState == WindowState.Normal)
                    {
                        window.WindowState = WindowState.Maximized;
                    }
                    else if (window?.WindowState == WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Normal;
                    }
                }

            }
        }

        //private void TitleBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    Window window = Window.GetWindow(sender as DependencyObject);
        //    if (window != null)
        //    {
        //        if (window.WindowState == WindowState.Normal)
        //            window.WindowState = WindowState.Maximized;
        //        else if (window.WindowState == WindowState.Maximized)
        //            window.WindowState = WindowState.Normal;
        //    }
        //}

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(sender as DependencyObject);
            if (window != null)
                window.WindowState = WindowState.Minimized;
        }

        private void MaximizeRestore_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(sender as DependencyObject);
            if (window != null)
            {
                if (window.WindowState == WindowState.Normal)
                    window.WindowState = WindowState.Maximized;
                else
                    window.WindowState = WindowState.Normal;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(sender as DependencyObject);
            window?.Close();
        }

       

        
    }
}
