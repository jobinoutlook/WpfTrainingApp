using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfThemeApp2.AppHelper
{
    internal static class AppSettings
    {
        public static bool IsUserAuthenticated {  get; set; }

        public static string UserName { get; set; } = string.Empty;
    }
}
