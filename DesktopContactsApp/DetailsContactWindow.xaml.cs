using DesktopContactsApp.Classes.DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for DetailsContactWindow.xaml
    /// </summary>
    public partial class DetailsContactWindow : Window
    {
        Contact contact;
        public DetailsContactWindow(Contact contact)
        {
            InitializeComponent();
            this.Owner = Application.Current.MainWindow;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contact = contact;
            FillContactText();
        }

        void FillContactText()
        {
            txtName.Text = contact.Name;
            txtEmail.Text = contact.Email;
            txtPhone.Text = contact.Phone;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                contact.Name = txtName.Text;
                contact.Email = txtEmail.Text;
                contact.Phone = txtPhone.Text;

                connection.CreateTable<Contact>();
                connection.Update(contact);
                
                
            }

            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
                
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
