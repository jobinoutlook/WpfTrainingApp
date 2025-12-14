using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTrainingApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnToggle_Checked(object sender, RoutedEventArgs e)
        {
            lblContent.Content="Toggle Button is ON";
            this.Background = Brushes.MistyRose;
        }

        private void btnToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            lblContent.Content = "Toggle Button is OFF";
            this.Background = Brushes.LightGray;
        }
    }
}
