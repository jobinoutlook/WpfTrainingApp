using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel
{
    public class LoginVM
    {
		private User user;

		public User User
		{
			get { return user; }
			set { user = value; }
		}

		public LoginCommand LoginCommand { get; set; }
		public RegisterCommand RegisterCommand { get; set; }

		public LoginVM()
		{
			LoginCommand = new LoginCommand(this);
			RegisterCommand = new RegisterCommand(this);
		}

	}
}
