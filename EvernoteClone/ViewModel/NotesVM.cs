using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EvernoteClone.ViewModel
{
    public class NotesVM: INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

		private Notebook selectedNotebook;

        public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

        public Notebook SelectedNotebook
		{
			get { return selectedNotebook; }
			set
			{
				selectedNotebook = value;
                OnPropertyChanged(nameof(SelectedNotebook));
                GetNotes();
            }
		}

        private Visibility isVisible;

        public  Visibility IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        private Note selectedNote;

        public Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
                SelectedNoteChanged?.Invoke(this,new EventArgs());
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

		public NewNotebookCommand NewNotebookCommand { get; set; }
		public NewNoteCommand NewNoteCommand { get; set; }
        public EditCommand EditCommand { get; set; }

        public EndEditingCommand EndEditingCommand { get; set; }

        public event EventHandler SelectedNoteChanged;
        public NotesVM()
        {
			Notebooks = new ObservableCollection<Notebook>();
			Notes = new ObservableCollection<Note>();

			NewNotebookCommand = new NewNotebookCommand(this);
			NewNoteCommand = new NewNoteCommand(this);
            EditCommand = new EditCommand(this);
            EndEditingCommand = new EndEditingCommand(this);

            IsVisible = Visibility.Collapsed;

            GetNotebooks();
        }

		public void CreateNotebook()
		{
            Notebook newNotebook = new Notebook()
            {
                Name = "New notebook",
                UserId = 1
            };

			if(DatabaseHelper.Insert(newNotebook))
            {
                GetNotebooks();
            }
		}


		public void CreateNote(int notebookId)
		{
			var newNote = new Note()
			{
				NotebookId = notebookId,
				Title = $"Note for {DateTime.Now.ToString()}",
				CreatedTime = DateTime.Now,
				UpdatedTime = DateTime.Now
			};

			if(DatabaseHelper.Insert(newNote))
            {
                GetNotes();
            }
		}

        private async void GetNotebooks()
        {
            //List<Notebook> notebooks = await ReadAll<Notebook>();

            List<Notebook> notebooks = await DatabaseHelper.ReadAllAsync<Notebook>();

            Notebooks.Clear();
            foreach (var notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }

            
        }

        private async void GetNotes()
        {
            if (SelectedNotebook != null)
            {
                List<Note> notes = await DatabaseHelper.ReadAllAsync<Note>();
                notes = notes.Where(n => n.NotebookId == SelectedNotebook.Id).ToList();
                Notes.Clear();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
        }


        public void StartEditing()
        {
            IsVisible = Visibility.Visible;
        }

        public void StopEditing(Notebook notebook)
        {
            IsVisible = Visibility.Collapsed;
            DatabaseHelper.Update(notebook);
            GetNotebooks();
        }



    }
}
