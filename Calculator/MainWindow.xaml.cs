using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int GWL_STYLE = -16;
        const int WS_MAXIMIZEBOX = 0x10000;

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public MainWindow()
        {
            InitializeComponent();
            lblResult.Content = 0;
            SourceInitialized += (s, e) => HideMaximizeButton();
            
            AssignButtonEvents();
        }

        private void HideMaximizeButton()
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            int style = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, style & ~WS_MAXIMIZEBOX);
        }

        //====================================================

        double lastNumber = 0, result = 0;
        char? Operator = '+';
        private void AssignButtonEvents()
        {
            btnAC.Click += FunctionButton_Click;
            btnNegativePositive.Click += FunctionButton_Click;
            
            //--------------------------------------------

            btnPlus.Click += OperationButton_Click;
            btnMinus.Click += OperationButton_Click;
            btnStar.Click += OperationButton_Click;
            btnDivision.Click += OperationButton_Click;
            btnPercentage.Click += OperationButton_Click;
            //--------------------------------------------

            btnZero.Click += NumberButton_Click;
            btnOne.Click += NumberButton_Click;
            btnTwo.Click += NumberButton_Click;
            btnThree.Click += NumberButton_Click;
            btnFour.Click += NumberButton_Click;
            btnFive.Click += NumberButton_Click;
            btnSix.Click += NumberButton_Click;
            btnSeven.Click += NumberButton_Click;
            btnEight.Click += NumberButton_Click;
            btnNine.Click += NumberButton_Click;
            

            //--------------------------------------------
            btnEquals.Click += BtnEquals_Click;
            btnPoint.Click += BtnPoint_Click;
            
        }

        

        private void FunctionButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnAC)
            {
                lblResult.Content = "0";
            }
            else if (sender == btnNegativePositive)
            {
                if (Operator == 'O')
                {
                    if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
                    {
                        if (lastNumber != 0)
                            lblResult.Content = (lastNumber * -1).ToString();
                    }
                }
                else
                {
                    double currentNumber = 0;
                    if (double.TryParse(lblResult.Content.ToString(), out currentNumber))
                    {
                        lblResult.Content = (currentNumber * -1).ToString();
                    }
                }
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                Operator = (sender as Button).Content.ToString()[0];

                
                lblResult.Content = "0";
            }
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            string strContent = Convert.ToString(lblResult.Content);
            string strDot = string.Empty;

            if (!strContent.Contains("."))
                strDot = ".";

            lblResult.Content = $"{strContent}{strDot}";

        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            
            string strContent = Convert.ToString(lblResult.Content);

            string strNumber = (sender as Button).Content.ToString();

            if (strContent == "0")
            {
                lblResult.Content = $"{strNumber}";
            }
            else
            {
                lblResult.Content = $"{strContent}{strNumber}";
            }

        }


        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            double currentNumber = 0;

            if (double.TryParse(lblResult.Content.ToString(), out currentNumber))
            {
                switch (Operator)
                {
                    case '+':
                        result = lastNumber + currentNumber;
                        break;
                    case '-':
                        result = lastNumber - currentNumber;
                        break;
                    case '*':
                        result = lastNumber * currentNumber;
                        break;
                    case '/':
                        if (currentNumber == 0)
                        {
                            //MessageBox.Show(this,"Division by zero not supported", "Error", MessageBoxButton.OK, MessageBoxImage.Error,MessageBoxResult.None,MessageBoxOptions.None);
                            CenteredMessageBox.Show(this, "Division by 0 not supported.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                        else
                        {
                            result = lastNumber / currentNumber;
                        }
                        break;
                    case '%':
                            result = (( currentNumber / 100) * lastNumber);
                        break;

                }
                Operator = 'O';
                result = Math.Round(result, 3);
                lblResult.Content = Convert.ToString(result);
            }
        }

        


    }
}