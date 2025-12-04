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

namespace WpfThemeApp2
{
    /// <summary>
    /// Interaction logic for PaintWindow.xaml
    /// </summary>
    public partial class PaintWindow : Window
    {
        
        public PaintWindow()
        {
            InitializeComponent();
            DrawLineOnCanvas();
        }

        void DrawLineOnCanvas()
        {
            Line myLine = new Line
            {
                X1 = 5,
                Y1 = 5,
                X2 = 200,
                Y2 = 200,
                Stroke = Brushes.IndianRed,
                StrokeThickness = 2
            };
            paintCanvas.Children.Add(myLine);

            Polygon polygon = new Polygon
            {
                Stroke = Brushes.IndianRed,
                Fill = Brushes.IndianRed,
                StrokeThickness = 2,
                Points = new PointCollection()
                {
                    new Point(192,196),
                    new Point(200,200),
                    new Point(196,192)
                }
            };
            paintCanvas.Children.Add(polygon);

            Line yaxis = new Line
            {
                X1 = 5,
                Y1 = 5,
                X2 = 5,
                Y2 = 200,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            paintCanvas.Children.Add(yaxis);

            Polygon polygonY = new Polygon
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Black,
                StrokeThickness = 2,
                Points = new PointCollection()
                {
                    new Point(2,192),
                    new Point(5,200),
                    new Point(8,192)
                }
            };
            paintCanvas.Children.Add(polygonY);

            Line xaxis = new Line
            {
                X1 = 5,
                Y1 = 5,
                X2 = 200,
                Y2 = 5,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            }; 
            paintCanvas.Children.Add(xaxis);

            Polygon polygonX = new Polygon
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Black,
                StrokeThickness = 2,
                Points = new PointCollection()
                {
                    new Point(192,2),
                    new Point(200,5),
                    new Point(192,8)
                }
            };
            paintCanvas.Children.Add(polygonX);

            Line gridLine= new Line
            {
                X1 = 5,
                Y1 = 202,
                X2 = 202,
                Y2 = 202,
                Stroke = Brushes.LightGray,
                StrokeThickness = 1
            };
            paintCanvas.Children.Add(gridLine);

           Line line2= new Line
            {
                X1 = 202,
                Y1 = 5,
                X2 = 202,
                Y2 = 202,
                Stroke = Brushes.LightGray,
                StrokeThickness = 1
            };
            paintCanvas.Children.Add(line2);
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                try
                {
                    // Print the Canvas directly
                    printDialog.PrintVisual(paintCanvas, "Canvas Print");
                }
                catch(System.Runtime.CompilerServices.RuntimeWrappedException)
                {
                    CenteredMessageBox.Show(this, "An error occurred while trying to print the canvas.", "Print Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
