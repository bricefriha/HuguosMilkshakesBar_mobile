using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using HuguosMilkshakesBar.Models;
using HuguosMilkshakesBar.Views;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HuguosMilkshakesBar.Viewmodels
{
    public class SignInViewModel : BaseViewModel
    {
        private string _errorMsg;
        public string ErrorMsg
        {
            set
            {
                _errorMsg = value;
                OnPropertyChanged();
            }
            get
            {
                return _errorMsg;
            }
        }
        private string _usertag;
        public string Usertag
        {
            set
            {
                _usertag = value;
                OnPropertyChanged();
            }
            get
            {
                return _usertag;
            }
        }
        private string _password;
        public string Password
        {
            set
            {
                _password = value;
                OnPropertyChanged();
            }
            get
            {
                return _password;
            }
        }
        private Command _signIn;
        public Command SignIn
        {
            get
            {
                return _signIn;
            }
        }
        public SignInViewModel ()
        {
            _usertag = "brice.friha@email.com";
            _password = "pwd";
            _signIn = new Command(async () =>
            {
                try
                {
                    string requestBody = "{ \"email\" : \"" + Usertag + "\", \"password\":\"" + Password + "\"} ";

                    // Log in
                    App.currentUser = await App.WService.ExecutePost<User>("users", "authenticate", null, requestBody);

                    if (App.currentUser != null)
                    {
                        // Store the token
                        await SecureStorage.SetAsync("oauth_token", App.currentUser.Token);

                        // Load the username
                        (App.Current.MainPage.BindingContext as ShellViewmodel).LoadUsername();

                        // Back to the previous page
                        await App.Current.MainPage.Navigation.PopAsync(true);
                    }
                    else
                    {
                        ErrorMsg = "Nope";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }
    }
}
