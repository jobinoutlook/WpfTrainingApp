using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCoreApp.EF;
using WpfCoreApp.Mvvm.Model;

namespace WpfCoreApp.Mvvm.ViewModel
{
    public class EmployeeVM : INotifyPropertyChanged
    {
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

        private ObservableCollection<Employee>? employees = new ObservableCollection<Employee>();

        

        public ObservableCollection<Employee>? Employees { get; set; }
        

        public EmployeeVM()
        {
            _context = new AppDbContext();

            Employees = new ObservableCollection<Employee>(_context.Employees.ToList());

            Employees.CollectionChanged += EmployeeCollectionChanged;
            
        }

        private void EmployeeCollectionChanged(object? sender, EventArgs e)
        {
            HasChanges = true;
        }

        public void SaveChanges()
        {
            // Sync ObservableCollection changes back to DbContext
            if (Employees != null && _context != null)
            {
                foreach (var emp in Employees)
                {
                    if (_context.Entry(emp).State == EntityState.Detached)
                    {
                        _context.Attach(emp);
                    }
                }

                var dbEmployees = _context.Employees.ToList();
                foreach (var dbEmp in dbEmployees)
                {
                    if (!Employees.Any(e => e.Id == dbEmp.Id))
                    {
                        _context.Employees.Remove(dbEmp);
                    }
                }

                _context.SaveChanges();
                HasChanges = false;
            }
        }

        public void RemoveFromGrid(Employee emp)
        {
            if (emp != null && Employees != null)
            {
                Employees.Remove(emp);
            }
        }
        //public void DeleteEmployee(Employee emp)
        //{
        //    if (emp != null && Employees != null)// && _context != null )
        //    {
        //        // Remove from ObservableCollection (updates UI)
        //        Employees.Remove(emp);

        //        //// Remove from DbContext (marks for deletion)
        //        //_context.Employees.Remove(emp);

        //        //// Commit to DB
        //        //_context.SaveChanges();
        //    }
        //}
    }
}
