using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoreApp.Mvvm.Model
{
    internal class Preference
    {
        
        public bool ShowInSystemTray {  get; set; }
        public bool ShowInTaskBar {  get; set; } = true;
    }
}
