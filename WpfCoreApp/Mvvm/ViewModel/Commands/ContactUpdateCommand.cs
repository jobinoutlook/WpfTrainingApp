using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCoreApp.Mvvm.Model;

namespace WpfCoreApp.Mvvm.ViewModel.Commands
{
    public class ContactUpdateCommand : ICommand
    {
        ContactsVM contactsVM;
        public ContactUpdateCommand(ContactsVM contactsVM)
        {
            this.contactsVM = contactsVM;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter != null)
            {
                if (parameter is Contact)
                {
                    var contact = (Contact) parameter;
                    if (contact.Id > 0)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public void Execute(object? parameter)
        {
            contactsVM.UpdateContact();
        }
    }
}
