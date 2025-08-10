using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    internal class SearchCommand2 : ICommand
    {
        WeatherVM2 WeatherVM2;
        public SearchCommand2(WeatherVM2 weatherVM2)
        {
            this.WeatherVM2 = weatherVM2;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        void OnCanExecuteChanged()
        {
            throw new NotImplementedException();
        }

        public bool CanExecute(object? parameter)
        {
            var query = parameter as string;
            if (string.IsNullOrWhiteSpace(query))
            {
                return false;
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            this.WeatherVM2.MakeQuery();
        }
    }
}
