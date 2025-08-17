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
using WpfCoreApp.EF;
using WpfCoreApp.Mvvm.Model;
using WpfCoreApp.Mvvm.ViewModel;

namespace WpfCoreApp.Mvvm.View
{
    /// <summary>
    /// Interaction logic for ContactsWindow.xaml
    /// </summary>
    public partial class ContactsWindow : Window
    {
        ContactsVM contactsVM;
        bool _collectionChanged = false;
        public ContactsWindow()
        {
            InitializeComponent();
            contactsVM = new ContactsVM();

            contactsVM.Contacts.CollectionChanged += Contacts_CollectionChanged;

            this.DataContext = contactsVM;
            //contactsVM.RequestClose += (s, e) => this.Close();

            var lstContact = contactsVM.Contacts;  //_appDbctx.Contacts.ToList();

            

            lstviewContacts.ItemsSource = lstContact;
        }

        private void Contacts_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _collectionChanged = true;
        }

        private void lstviewContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowDetails();
        }

        private void ShowDetails()
        {
            Contact contact = (Contact)lstviewContacts.SelectedItem;
            contactsVM.SelectedContact = contact;

            if (contact != null)
            {
                
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(contactsVM);
                contactDetailsWindow.Owner = this;
                contactDetailsWindow.DataContext = this.DataContext;
                //contactsVM.RequestClose += (s, e) => contactDetailsWindow.Close();
                contactDetailsWindow.ShowDialog();

                if (_collectionChanged)
                {
                    var lstContact = contactsVM.Contacts;  //_appDbctx.Contacts.ToList();
                    lstviewContacts.ItemsSource = null;
                    lstviewContacts.Items.Clear();
                    lstviewContacts.ItemsSource = lstContact;
                    _collectionChanged= false;
                }

            }
        }

        private void btnNewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow(contactsVM);
            newContactWindow.Owner = this;
            newContactWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newContactWindow.ShowDialog();

            _collectionChanged = true;
            var lstContact = contactsVM.Contacts;  //_appDbctx.Contacts.ToList();
            lstviewContacts.ItemsSource = null;
            lstviewContacts.Items.Clear();
            lstviewContacts.ItemsSource = lstContact;
            _collectionChanged = false;

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    
}
