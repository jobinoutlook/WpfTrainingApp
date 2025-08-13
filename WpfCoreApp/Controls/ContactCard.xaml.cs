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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCoreApp.Mvvm.Model;

namespace WpfCoreApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactCard.xaml
    /// </summary>
    public partial class ContactCard : UserControl
    {
        private Contact contact;




        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        private static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactCard), new PropertyMetadata(new Contact(), SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactCard control = d as ContactCard;

            if (control != null)
            {
                control.txbName.Text = ((Contact)e.NewValue).Name;
                control.txbEmail.Text = ((Contact)e.NewValue).Email;
                control.txbPhone.Text = ((Contact)e.NewValue).PhoneNumber;
            }
        }
        public ContactCard()
        {
            InitializeComponent();
        }
    }
}
