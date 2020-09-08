using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;

namespace HuguosMilkshakesBar.Viewmodels
{
    class ShellViewmodel : BaseViewModel
    {
        private string _username;
        public string Username
        {
            set
            {
                _username = value;
                OnPropertyChanged();
            }
            get
            {
                return _username;
            }
        }
        public ShellViewmodel ()
        {
            LoadUsername();
        }

        public void LoadUsername()
        {
            if (App.currentUser != null)
            {
                Username = App.currentUser.FirstName;

            }
        }
    }
}
