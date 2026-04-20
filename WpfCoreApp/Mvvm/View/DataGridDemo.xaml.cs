using Microsoft.EntityFrameworkCore;
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
using WpfCoreApp.Mvvm.Model;
using WpfCoreApp.Mvvm.ViewModel;

namespace WpfCoreApp.Mvvm.View
{
    /// <summary>
    /// Interaction logic for DataGridDemo.xaml
    /// </summary>
    public partial class DataGridDemo : Window
    {
        private EmployeeVM _viewModel;

        public DataGridDemo()
        {
            InitializeComponent();
            _viewModel = new EmployeeVM();
            this.DataContext = _viewModel;
        }

        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveChanges();
            CenteredMessageBox.Show(this,"Changes saved to database!","");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = dgEmployees.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                _viewModel.RemoveFromGrid(selectedEmployee);
                CenteredMessageBox.Show(this,"Row removed from grid. Click Save to persist changes.","");
            }
            else
            {
                CenteredMessageBox.Show(this,"Please select a row to delete.","");
            }
        }

        private void dgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = dgEmployees.SelectedItem != null;
        }

        private void dgEmployees_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var vm = DataContext as EmployeeVM;
            if (vm != null)
            {
                vm.HasChanges = true;
            }
        }
    }
}
