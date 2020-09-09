using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;

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
        private Command _signOut;
        public Command SignOut
        {
            get
            {
                return _signOut;
            }
        }
        public ShellViewmodel ()
        {
            LoadUsername();

            _signOut = new Command(async () => 
            { 
                // Remove the key
                SecureStorage.Remove("oauth_token");

                // remove the session
                App.currentUser = null;

                // close the flyout
                //CloseFlyout();

                // Reload the username
                LoadUsername();
            });
        }

        public void LoadUsername()
        {
            if (App.currentUser != null)
            {
                Username = App.currentUser.FirstName;

            } 
            else
            {
                Username = null;
            }
        }
        /// <summary>
        /// Method to close the flyout
        /// </summary>
        public void CloseFlyout()
        {
            (App.Current.MainPage as Shell).FlyoutBehavior = FlyoutBehavior.Disabled;
            (App.Current.MainPage as Shell).FlyoutBehavior = FlyoutBehavior.Flyout;
        }
    }
}
