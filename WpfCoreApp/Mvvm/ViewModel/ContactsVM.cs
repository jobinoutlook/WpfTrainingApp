using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfCoreApp.EF;
using WpfCoreApp.Mvvm.Model;
using WpfCoreApp.Mvvm.ViewModel.Commands;

namespace WpfCoreApp.Mvvm.ViewModel
{
    public class ContactsVM : INotifyPropertyChanged
    {
        private bool _isContactsFullyAdded = false;
        private AppDbContext? _appDbContext = null;

        

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public Contact SelectedContact { get; set; }



        private ObservableCollection<Contact> contacts;

        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; }

        }

        public event EventHandler? RequestClose;

        public ContactsVM()
        {

            contacts = new ObservableCollection<Contact>();
            contacts.CollectionChanged += Contacts_CollectionChanged;
            _appDbContext = new AppDbContext();
            CloseCommand = new CloseWindowCommand();

            SubmitCommand = new ContactCreateCommand(this);

            LoadContacts();

            

        }

        private void Contacts_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(_isContactsFullyAdded)
            {
                OnPropertyChanged(nameof(Contacts));
                    
            }
        }

        private void LoadContacts()
        {


            contacts.Clear();

            List<Contact> list = _appDbContext.Contacts.ToList();

            if (list.Count == 1)
            {
                _isContactsFullyAdded = true;
                contacts.Add(list[0]);
                _isContactsFullyAdded = false;

            }
            else if (list.Count > 1)
            {
                for(int i=0; i<list.Count-1; i++)
                {
                    contacts.Add(list[i]);
                }

                _isContactsFullyAdded = true;
                contacts.Add(list[list.Count - 1]);
                _isContactsFullyAdded = false;

            }

            
            

        }

        public void UpdateContact()
        {
            _appDbContext?.Contacts.Update(SelectedContact);
            _appDbContext?.SaveChanges();
            LoadContacts();
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        public void DeleteContact()
        {
            _appDbContext?.Remove(SelectedContact);
            _appDbContext?.SaveChanges();
            LoadContacts();
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        public ICommand CloseCommand { get; }

        public ICommand SubmitCommand { get; }

        public void SubmitContact()
        {
            
            _appDbContext?.Contacts.Add(NewContact);
            
            _appDbContext?.SaveChanges();
            LoadContacts();
            RequestClose?.Invoke(this, EventArgs.Empty);
        }


        private string _name;
        private string _email;
        private string _phoneNumber;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber= value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        public Contact NewContact
        {
            get { return new Contact() { Name = _name, Email = _email, PhoneNumber = _phoneNumber }; }

           // set { _name = value.Name; _email = value.Email; _phoneNumber = value.PhoneNumber; }
        }
    }


    
}
