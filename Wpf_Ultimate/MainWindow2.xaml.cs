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

namespace Wpf_Ultimate
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
        }

        private void btnOne_MouseEnter(object sender, MouseEventArgs e)
        {
            gridlayer1.Visibility = Visibility.Visible;

            // Adjust ZIndex order to ensure the pane is on top:
            parentGrid.Children.Remove(gridlayer1);
            parentGrid.Children.Add(gridlayer1);

            // Ensure the other pane is hidden if it is undocked
            if (btnTwo.Visibility == Visibility.Visible)
                gridlayer2.Visibility = Visibility.Collapsed;
        }

        private void btnTwo_MouseEnter(object sender, MouseEventArgs e)
        {
            gridlayer2.Visibility = Visibility.Visible;

            // Adjust ZIndex order to ensure the pane is on top:
            parentGrid.Children.Remove(gridlayer2);
            parentGrid.Children.Add(gridlayer2);

            // Ensure the other pane is hidden if it is undocked
            if (btnOne.Visibility == Visibility.Visible)
                gridlayer1.Visibility = Visibility.Collapsed;
        }

        private void panel1_MouseEnter(object sender, MouseEventArgs e)
        {
            // Ensure the other pane is hidden if it is undocked
            if (btnTwo.Visibility == Visibility.Visible)
                gridlayer2.Visibility = Visibility.Collapsed;
        }

        private void panel2_MouseEnter(object sender, MouseEventArgs e)
        {
            // Ensure the other pane is hidden if it is undocked
            if (btnOne.Visibility == Visibility.Visible)
                gridlayer1.Visibility = Visibility.Collapsed;
        }

        private void panel1Pin_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void panel2Pin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void layer0_MouseEnter(object sender, MouseEventArgs e)
        {
            if (btnOne.Visibility == Visibility.Visible)
                gridlayer1.Visibility = Visibility.Collapsed;
            if (btnTwo.Visibility == Visibility.Visible)
                gridlayer2.Visibility = Visibility.Collapsed;
        }

        private void parentGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (btnOne.Visibility == Visibility.Visible)
                    gridlayer1.Visibility = Visibility.Collapsed;
                if (btnTwo.Visibility == Visibility.Visible)
                    gridlayer2.Visibility = Visibility.Collapsed;
            }
            
        }
    }
}
