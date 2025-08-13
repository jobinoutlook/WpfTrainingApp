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
    /// Interaction logic for ContactsWindow.xaml
    /// </summary>
    public partial class ContactsWindow : Window
    {
        public ContactsWindow()
        {
            InitializeComponent();
            this.DataContext = new ContactsVM();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowDetails();
        }

        private void ShowDetails()
        {
            Contact contact = (Contact)listView.SelectedItem;

            if (contact != null)
            {
                
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow();
                contactDetailsWindow.Owner = this;
                contactDetailsWindow.DataContext = this.DataContext;
                contactDetailsWindow.ShowDialog();


            }
        }

        

       
    }
    
}
