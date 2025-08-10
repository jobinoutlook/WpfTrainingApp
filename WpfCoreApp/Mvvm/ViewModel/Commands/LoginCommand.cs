using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfCoreApp.Mvvm.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        LoginVM LoginVM;
        public LoginCommand(LoginVM loginVM)
        {
                this.LoginVM = loginVM;
        }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            string password = (string)parameter;
            if ( string.IsNullOrEmpty(password)||string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            this.LoginVM.ExecuteLogin(parameter);
        }
    }
}
