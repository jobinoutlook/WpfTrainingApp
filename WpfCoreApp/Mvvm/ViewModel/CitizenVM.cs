using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfCoreApp.EF;
using WpfCoreApp.Mvvm.Model;
using WpfCoreApp.Mvvm.View;

namespace WpfCoreApp.Mvvm.ViewModel
{
    public class CitizenVM : INotifyPropertyChanged
    {
        public ICommand InsertPhotoCommand { get; }

        private AppDbContext? _context;

        private bool _hasChanges;

        public bool HasChanges
        {
            get => _hasChanges;
            set
            {
                _hasChanges = value;
                OnPropertyChanged(nameof(HasChanges));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand EditCitizenCommand { get; }

        public ICommand AddCitizenCommand { get; }

        public ICommand DeleteCitizenCommand { get; }

        public ObservableCollection<Citizen>? Citizens { get; set; }


        public CitizenVM()
        {
            _context = new AppDbContext();

            Citizens = new ObservableCollection<Citizen>(_context.Citizens.ToList());

            //Employees.CollectionChanged += EmployeeCollectionChanged;

            InsertPhotoCommand = new RelayCommand<Citizen>(InsertPhoto);

            EditCitizenCommand = new RelayCommand<Citizen>(EditCitizen);

            AddCitizenCommand = new RelayCommand(AddCitizen);

            DeleteCitizenCommand = new RelayCommand<object>(DeleteCitizen);

        }

        private void InsertPhoto(Citizen citizen)
        {
            // Example: open file dialog to select an image
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.png)|*.jpg;*.png"
            };

            if (dialog.ShowDialog() == true)
            {
                citizen.Photo = File.ReadAllBytes(dialog.FileName);
                // Notify UI of property change if needed
                if (_context != null)
                {
                    _context.Citizens.Update(citizen);
                    _context.SaveChanges();
                }
            }
        }

        private void EditCitizen(Citizen citizen)
        {
            var editWindow = new EditCitizenWindow
            {
                DataContext = new EditCitizenVM(citizen) // pass citizen to VM
            };
            editWindow.ShowDialog();
        }

        private void AddCitizen()
        {
            var addWindow = new AddCitizenWindow
            {
                DataContext = new AddCitizenVM()
            };
            addWindow.ShowDialog();

            // After closing, refresh list if new citizen was added
            using (var context = new AppDbContext())
            {
                Citizens?.Clear();
                foreach (var c in context.Citizens.ToList())
                    Citizens?.Add(c);
            }
        }

        private void DeleteCitizen(object parameter)
        {
            var tuple = parameter as Tuple<Citizen, Window>;
            if (tuple == null) return;

            var citizen = tuple.Item1;
            var window = tuple.Item2;

            //var result = MessageBox.Show($"Are you sure you want to delete {citizen.FirstName} {citizen.LastName}?",
            //                             "Confirm Delete",
            //                             MessageBoxButton.YesNo,
            //                             MessageBoxImage.Warning);

            var result = CenteredMessageBox.Show(window, $"Are you sure you want to delete {citizen.FirstName} {citizen.LastName}?",
                                         "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using (var context = new AppDbContext())
                {
                    context.Citizens.Remove(citizen);
                    context.SaveChanges();
                }

                Citizens?.Remove(citizen); // remove from ObservableCollection
            }
        }
    }
    
}