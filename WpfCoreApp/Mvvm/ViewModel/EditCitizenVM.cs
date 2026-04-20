using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfCoreApp.EF;
using WpfCoreApp.Mvvm.Model;

namespace WpfCoreApp.Mvvm.ViewModel
{
    public class EditCitizenVM
    {
        public Citizen Citizen { get; }
        public ICommand SaveCommand { get; }

        public EditCitizenVM(Citizen citizen)
        {
            Citizen = citizen;
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            using (var context = new AppDbContext())
            {
                context.Citizens.Update(Citizen);
                context.SaveChanges();
            }
            // Close window after save
            Application.Current.Windows
                .OfType<Window>()
                .SingleOrDefault(w => w.DataContext == this)?.Close();
        }
    }
}
