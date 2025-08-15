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
using WpfCoreApp.Mvvm.ViewModel.Commands;

namespace WpfCoreApp.Mvvm.View
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;
        ContactsVM _contactsVM;
        public ContactDetailsWindow(ContactsVM contactsVM)
        {
            InitializeComponent();
            _contactsVM = contactsVM;
            this.Owner = Application.Current.MainWindow;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
           // var contactsVM =  (ContactsVM)this.DataContext;
          //  contactsVM.SelectedContact = contact;
            this.DataContext = contactsVM;
            contactsVM.RequestClose += (s, e) => this.Close();
            this.contact = contactsVM.SelectedContact;

            btnUpdate.Command = new ContactUpdateCommand(contactsVM);
            btnUpdate.CommandParameter = contactsVM.SelectedContact;
            
            btnDelete.Command = new ContactDeleteCommand(contactsVM);
            btnDelete.CommandParameter = contactsVM.SelectedContact;

        }

        //void FillContactText()
        //{
        //    txtName.Text = contact.Name;
        //    txtEmail.Text = contact.Email;
        //    txtPhone.Text = contact.PhoneNumber;
        //}

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
