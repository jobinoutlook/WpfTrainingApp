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
        bool panel1_mouseleave = false;
        bool panel1_mouseenter=false;

        bool panel2_mouseleave = false;
        bool panel2_mouseenter = false;

        bool parentGrid_mouseenter=false;
        bool parentGrid_mouseleave=false;

        ColumnDefinition colOneCopyForLayer0;
        ColumnDefinition colTwoCopyForLayer0;
        ColumnDefinition colTwoCopyForLayer1;

        public MainWindow2()
        {
            InitializeComponent();
            // Initialize the dummy (grouped) columns that are created during docking:
            colOneCopyForLayer0 = new ColumnDefinition();
            colOneCopyForLayer0.SharedSizeGroup = "column1";
            colTwoCopyForLayer0 = new ColumnDefinition();
            colTwoCopyForLayer0.SharedSizeGroup = "column2";
            colTwoCopyForLayer1 = new ColumnDefinition();
            colTwoCopyForLayer1.SharedSizeGroup = "column2";
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
            panel1_mouseenter = true;
            panel1_mouseleave = false;
            // Ensure the other pane is hidden if it is undocked
            if (btnTwo.Visibility == Visibility.Visible)
                gridlayer2.Visibility = Visibility.Collapsed;
        }

        private void panel1_MouseLeave(object sender, MouseEventArgs e)
        {
            panel1_mouseleave=true;
            panel1_mouseenter=false;

            if(parentGrid_mouseenter==true)
            {
                if (btnOne.Visibility == Visibility.Visible)
                    gridlayer1.Visibility = Visibility.Collapsed;
            }
        }

        private void panel2_MouseEnter(object sender, MouseEventArgs e)
        {
            // Ensure the other pane is hidden if it is undocked
            if (btnOne.Visibility == Visibility.Visible)
                gridlayer1.Visibility = Visibility.Collapsed;


            panel2_mouseenter = true;
            panel2_mouseleave = false;
        }

        public void panel1Pin_Click(object sender, RoutedEventArgs e)
        {
            if (btnOne.Visibility == Visibility.Collapsed)
                UndockPane(1);
            else
                DockPane(1);
        }

        // Toggle panel 2 between docked and undocked states 
        public void panel2Pin_Click(object sender, RoutedEventArgs e)
        {
            if (btnTwo.Visibility == Visibility.Collapsed)
                UndockPane(2);
            else
                DockPane(2);
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
            
            //if (e.LeftButton == MouseButtonState.Pressed)
            //{
            //    if (panel1_mouseleave==true && panel1_mouseenter==false)
            //    {
            //        if (btnOne.Visibility == Visibility.Visible)
            //            gridlayer1.Visibility = Visibility.Collapsed;
            //    }

            //    if (panel2_mouseleave == true && panel2_mouseenter == false)
            //    {
            //        if (btnTwo.Visibility == Visibility.Visible)
            //            gridlayer2.Visibility = Visibility.Collapsed;
            //    }
            //}
            
        }

        private void panel2_MouseLeave(object sender, MouseEventArgs e)
        {


            panel2_mouseleave = true;
            panel2_mouseenter = false;

            if (parentGrid_mouseenter == true)
            {
                if (btnTwo.Visibility == Visibility.Visible)
                    gridlayer2.Visibility = Visibility.Collapsed;
            }
        }

        private void parentGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            parentGrid_mouseenter = true;
            parentGrid_mouseleave = false;
          
        }

        private void parentGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            //if (parentGrid_mouseenter)
            //{
            //    if (panel1_mouseleave == true)// && panel1_mouseenter == false)
            //    {
            //        if (btnOne.Visibility == Visibility.Visible)
            //            gridlayer1.Visibility = Visibility.Collapsed;
            //    }

            //    if (panel2_mouseleave == true)// && panel2_mouseenter == false)
            //    {
            //        if (btnTwo.Visibility == Visibility.Visible)
            //            gridlayer2.Visibility = Visibility.Collapsed;
            //    }
            //}

            parentGrid_mouseenter = false;
            parentGrid_mouseleave = true;
        }

        public void DockPane(int paneNumber)
        {
            if (paneNumber == 1)
            {
                btnOne.Visibility = Visibility.Collapsed;
                panel1PinImg.Source = new BitmapImage(new Uri("VerticalPin.jpg", UriKind.Relative));

                // Add the cloned column to layer 0:
                layer0.ColumnDefinitions.Add(colOneCopyForLayer0);
                // Add the cloned column to layer 1, but only if pane 2 is docked:
                if (btnTwo.Visibility == Visibility.Collapsed) gridlayer1.ColumnDefinitions.Add(colTwoCopyForLayer1);
            }
            else if (paneNumber == 2)
            {
                btnTwo.Visibility = Visibility.Collapsed;
                panel2PinImg.Source = new BitmapImage(new Uri("VerticalPin.jpg", UriKind.Relative));

                // Add the cloned column to layer 0:
                layer0.ColumnDefinitions.Add(colTwoCopyForLayer0);
                // Add the cloned column to layer 1, but only if pane 1 is docked:
                if (btnOne.Visibility == Visibility.Collapsed) gridlayer1.ColumnDefinitions.Add(colTwoCopyForLayer1);
            }
        }

        // Undocks a pane, which reveals the corresponding pane button
        public void UndockPane(int panelNbr)
        {
            if (panelNbr == 1)
            {
                gridlayer1.Visibility = Visibility.Collapsed;
                btnOne.Visibility = Visibility.Visible;
                panel1PinImg.Source = new BitmapImage(new Uri("HorizontalPin.jpg", UriKind.Relative));

                // Remove the cloned columns from layers 0 and 1:
                layer0.ColumnDefinitions.Remove(colOneCopyForLayer0);
                // This won't always be present, but Remove silently ignores bad columns:
                gridlayer1.ColumnDefinitions.Remove(colTwoCopyForLayer1);
            }
            else if (panelNbr == 2)
            {
                gridlayer2.Visibility = Visibility.Collapsed;
                btnTwo.Visibility = Visibility.Visible;
                panel2PinImg.Source = new BitmapImage(new Uri("HorizontalPin.jpg", UriKind.Relative));

                // Remove the cloned columns from layers 0 and 1:
                layer0.ColumnDefinitions.Remove(colTwoCopyForLayer0);
                gridlayer1.ColumnDefinitions.Remove(colTwoCopyForLayer1);
            }
        }
    }
}
