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
                    new Point(190,195),
                    new Point(200,200),
                    new Point(195,190)
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
        }
        
    }
}
