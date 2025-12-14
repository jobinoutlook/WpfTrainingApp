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
using System.Windows.Shapes;

namespace WpfTrainingApp4
{
    /// <summary>
    /// Interaction logic for LearningFrame.xaml
    /// </summary>
    public partial class LearningFrame : Window
    {
        public LearningFrame()
        {
            InitializeComponent();
        }

        private void btnIntel_Click(object sender, RoutedEventArgs e)
        {
            frame1.Visibility = Visibility.Hidden;
            frame.Visibility = Visibility.Visible;
        }

        private void btnMsft_Click(object sender, RoutedEventArgs e)
        {
            frame.Visibility = Visibility.Hidden;
            frame1.Visibility = Visibility.Visible;
        }
    }
}
