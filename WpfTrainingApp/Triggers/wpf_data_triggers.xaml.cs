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

namespace WpfTrainingApp.Triggers
{
    /// <summary>
    /// Interaction logic for wpf_data_triggers.xaml
    /// </summary>
    public partial class wpf_data_triggers : Window
    {
        public wpf_data_triggers()
        {
            InitializeComponent();
            chk_visible.IsChecked = true;
        }
    }
}
