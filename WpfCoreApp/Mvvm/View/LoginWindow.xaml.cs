using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfCoreApp.Mvvm.ViewModel;

namespace WpfCoreApp.Mvvm.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();

            var viewModel = new LoginVM();

            this.DataContext = viewModel;
            viewModel.RequestClose += (s, e) => this.Close();


            Loaded += Window_Loaded;


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0); // 0 = success
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;

            // Get current style
            int style = GetWindowLong(hwnd, GWL_STYLE);

            // Remove the close button (WS_SYSMENU disables system menu including close)
            SetWindowLong(hwnd, GWL_STYLE, style & ~WS_SYSMENU);


           

        }

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //var viewModel = new LoginVM();

            //this.DataContext = viewModel;
            //viewModel.RequestClose += (s, e) => this.Close();
        }
        //--------------------------------
        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    var hwnd = new WindowInteropHelper(this).Handle;

        //    uint color = 0xFF483D8B; // ARGB: opaque dark gray
        //    DwmSetWindowAttribute(hwnd, DWMWA_CAPTION_COLOR, ref color, sizeof(uint));
        //}

        //private const int DWMWA_CAPTION_COLOR = 35;

        //[DllImport("dwmapi.dll")]
        //private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref uint attrValue, int attrSize);



        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    var hwnd = new WindowInteropHelper(this).Handle;

        //    int attrValue = 2; // DWMWA_NCRENDERING_POLICY
        //    DwmSetWindowAttribute(hwnd, 2, ref attrValue, sizeof(int));

        //    var margins = new MARGINS { cxLeftWidth = -1 };
        //    DwmExtendFrameIntoClientArea(hwnd, ref margins);
        //}
        //[DllImport("dwmapi.dll")]
        //private static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        //[DllImport("dwmapi.dll")]
        //private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        //private struct MARGINS
        //{
        //    public int cxLeftWidth;
        //    public int cxRightWidth;
        //    public int cyTopHeight;
        //    public int cyBottomHeight;
        //}




        //-------------------------------------------------------
    }
}
