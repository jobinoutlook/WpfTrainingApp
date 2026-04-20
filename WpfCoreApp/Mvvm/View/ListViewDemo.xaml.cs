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
using WpfCoreApp.Mvvm.ViewModel;

namespace WpfCoreApp.Mvvm.View
{
    /// <summary>
    /// Interaction logic for ListViewDemo.xaml
    /// </summary>
    public partial class ListViewDemo : Window
    {
        private CitizenVM _viewModel;
        public ListViewDemo()
        {
            InitializeComponent();
            _viewModel = new CitizenVM();
            //this.DataContext = _viewModel;
        }

       
    }
}
