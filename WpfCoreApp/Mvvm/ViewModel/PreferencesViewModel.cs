using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCoreApp.EF;
using WpfCoreApp.Mvvm.Model;

namespace WpfCoreApp.Mvvm.ViewModel
{
    internal class PreferencesViewModel
    {
        private AppDbContext? _appDbContext = null;

        public PreferencesViewModel()
        {
            _appDbContext = new AppDbContext();
        }

        public Preference GetPreference()
        {
            return _appDbContext.Preferences.FirstOrDefault();
        }

    }
}
