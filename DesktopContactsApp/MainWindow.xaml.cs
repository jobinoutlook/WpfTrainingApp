using DesktopContactsApp.Classes.DesktopContactsApp.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Contact> lstContact;
        public MainWindow()
        {
            InitializeComponent();

            
            ReadDatabase();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new();
            newContactWindow.ShowDialog();
            ReadDatabase();
        }

        void ReadDatabase()
        {
            
            using (SQLite.SQLiteConnection conn=new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                lstContact = (conn.Table<Contact>().ToList()).OrderBy(n => n.Name).ToList();
            }

            if (lstContact != null)
            {

                lstviewContacts.ItemsSource = lstContact;
                //dataGrid.ItemsSource = lstContact;


            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lstFiltered = lstContact.Where(l => l.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            lstviewContacts.ItemsSource = lstFiltered;
        }

        
        private void lstviewContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact contact = (Contact)lstviewContacts.SelectedItem;

            if (contact != null)
            {
                DetailsContactWindow detailsContactWindow = new DetailsContactWindow(contact);
                detailsContactWindow.ShowDialog();

                ReadDatabase();
            }
        }
    }
}