using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfThemeApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            
            
        }

        

        void SubWindow_Click(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();
            subWindow.Owner = this;
            subWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            subWindow.ShowDialog();
        }

        

        void LoginWindow_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Topmost = true;
            loginWindow.Owner = this;
            loginWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            loginWindow.ShowDialog();
        }

        
        void RegularSubWindow_Click(object sender, RoutedEventArgs e)
        {
            RegularSubWindow regularWindow = new RegularSubWindow();
            regularWindow.Owner = this;
            regularWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            regularWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            var result = CenteredMessageBox.Show(this, "Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown(0);

            }
            
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {

        }

        private void About_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Canvas_Click(object sender, RoutedEventArgs e)
        {
            PaintWindow paintWindow = new PaintWindow();
            paintWindow.Owner = this;
            paintWindow.WindowStartupLocation= WindowStartupLocation.CenterOwner;
            paintWindow.Show();
        }
    }
}