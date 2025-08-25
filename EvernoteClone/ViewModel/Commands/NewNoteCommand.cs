using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class NewNoteCommand : ICommand
    {
        NotesVM VM;

        public NewNoteCommand(NotesVM vm)
        {
            VM = vm;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object? parameter)
        {
            Notebook selectedNotebook = (Notebook)parameter;
            if (selectedNotebook != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object? parameter)
        {
            Notebook selectedNotebook = (Notebook)parameter;
            if (selectedNotebook != null)
                VM.CreateNote(selectedNotebook.Id);
        }
    }
}
