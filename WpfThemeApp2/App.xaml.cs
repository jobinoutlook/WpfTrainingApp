using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfThemeApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        public void TitleBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window window = Window.GetWindow(sender as DependencyObject);
            if (window != null)
            {
                if (window.WindowState == WindowState.Normal)
                    window.WindowState = WindowState.Maximized;
                else if (window.WindowState == WindowState.Maximized)
                    window.WindowState = WindowState.Normal;
            }
        }

        public void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(sender as DependencyObject);
            if (window != null)
                window.WindowState = WindowState.Minimized;
        }

        public void MaximizeRestore_Click(object sender, RoutedEventArgs e)
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

        public void Close_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;

            // Get the parent window
            var window = Window.GetWindow(button);


            if (Convert.ToString(window.Tag) == "MainWindow")
            {
                var result = CenteredMessageBox.Show(window, "Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                   Application.Current.Shutdown(0); // Cancel the close
                    
                }
                
            }
            else if(Convert.ToString(window.Tag) == "SubWindow")
            {
                return;
            }
            else
            {
                window = Window.GetWindow(sender as DependencyObject);
                window?.Close();
            }
        }

    }

}
