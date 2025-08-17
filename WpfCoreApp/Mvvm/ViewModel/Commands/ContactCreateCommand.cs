using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCoreApp.Mvvm.Model;

namespace WpfCoreApp.Mvvm.ViewModel.Commands
{
    internal class ContactCreateCommand : ICommand
    {
        ContactsVM _contactsVM;
        public ContactCreateCommand(ContactsVM contactsVM)
        {
            _contactsVM = contactsVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter != null)
            {
                string param = parameter.ToString();
                if(!string.IsNullOrEmpty(param))
                {
                    return true; 
                }
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            _contactsVM.SubmitContact();
        }
    }
}
