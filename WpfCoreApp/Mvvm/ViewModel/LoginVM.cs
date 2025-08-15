using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCoreApp.AppHelper;
using WpfCoreApp.Mvvm.ViewModel.Commands;

namespace WpfCoreApp.Mvvm.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }

        public LoginVM()
        {
            this.LoginCommand = new LoginCommand(this);
        }
        //==================================================

        private string username;

        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

                

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;

                OnPropertyChanged(nameof(Message));
            }
        }

        public LoginCommand LoginCommand { get; set; }

        public event EventHandler? RequestClose;

        public void ExecuteLogin(object? parameter)
        {
            if (username == "jobin" && password == "admin123")
            {
                AppSettings.IsUserAuthenticated = true;
                AppSettings.UserName = username;

                RequestClose?.Invoke(this, EventArgs.Empty);

                

            }
            else
            {
                Message = "Invalid Username or Password";
            }
            
                
        }

        

    }
}
