using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    internal class LoginCommand : ICommand
    {
        LoginVM VM;
        public event EventHandler? CanExecuteChanged;

        public LoginCommand(LoginVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            //TODO

        }
    }
}
