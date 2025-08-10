using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCoreApp.Mvvm.View;

namespace WpfCoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageSource imgSrcMaxMin=null;
        ImageSource imgSrcMaxmize = null;
        public MainWindow()
        {
            InitializeComponent();
            imgSrcMaxMin = new BitmapImage(new Uri("/Resource/Images/maxmin_button.png", UriKind.Relative));
            imgSrcMaxmize = new BitmapImage(new Uri("/Resource/Images/maximize_button.png", UriKind.Relative));
        }


        //-----------------------------------------------------
        /// <summary>
        /// To enable/disable window shadow, comment/uncomment lines below
        /// </summary>

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;
            var margins = new Margins { Left = -1, Right = -1, Top = -1, Bottom = -1 };
            DwmExtendFrameIntoClientArea(hwnd, ref margins);
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref Margins margins);

        private struct Margins { public int Left, Right, Top, Bottom; }

        //-------------------------------------------------------

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;

                this.imgMaxMin.Source = imgSrcMaxMin;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                this.imgMaxMin.Source = imgSrcMaxmize;
                //this.Width = 800;
                //this.Height = 600;

                
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Preferences_Click(object sender, RoutedEventArgs e)
        {
            Preferences winPreferences = new();
            winPreferences.Owner = this;
            winPreferences.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            winPreferences.Show();
        }

        private void Cube3D_Click(object sender, RoutedEventArgs e)
        {
            Cube3DRotating cube3D = new();
            cube3D.Owner = this;    
            cube3D.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            cube3D.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {


            var result = CenteredMessageBox.Show(this, "Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                e.Cancel = true; // Cancel the close
            }

        }

       

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Owner = this;
            loginWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            loginWindow.ShowDialog();
        }
    }
}
