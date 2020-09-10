using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HuguosMilkshakesBar.Models;
using HuguosMilkshakesBar.Views;
using MvvmHelpers;
using Newtonsoft.Json;
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
        private string _email;
        public string Email
        {
            set
            {
                _email = value;
                OnPropertyChanged();
            }
            get
            {
                return _email;
            }
        }
        private string _firstname;
        public string Firstname
        {
            set
            {
                _firstname = value;
                OnPropertyChanged();
            }
            get
            {
                return _firstname;
            }
        }
        private string _lastname;
        public string Lastname
        {
            set
            {
                _lastname = value;
                OnPropertyChanged();
            }
            get
            {
                return _lastname;
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
        private string _passwordV;
        public string PasswordV
        {
            set
            {
                _passwordV = value;
                OnPropertyChanged();
            }
            get
            {
                return _passwordV;
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
        private Command _signUp;
        public Command SignUp
        {
            get
            {
                return _signUp;
            }
        }
        private Command _switchFormType;
        public Command SwitchFormType
        {
            get
            {
                return _switchFormType;
            }
        }
        private bool _isSignUp;
        public bool IsSignUp
        {
            set
            {
                _isSignUp = value;

                OnPropertyChanged();
            }
            get
            {
                return _isSignUp;
            }
        }
        private bool _isSignIn;
        public bool IsSignIn
        {
            set
            {
                _isSignIn = value;

                OnPropertyChanged();
            }
            get
            {
                return _isSignIn;
            }
        }
        public SignInViewModel ()
        {
            IsSignUp = false;
            IsSignIn = true;

            _usertag = "brice.friha@email.com";
            _email = "Kevin.magnussen@email.com";
            _password = "pwd";
            _signIn = new Command(async () =>
            {
                try
                {
                    await LogIn();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
            _signUp = new Command(async () =>
            {
                try
                {
                    // Verify is passwords match
                    if (_password == _passwordV)
                    {
                        string requestBody = "{ \"email\" : \"" + _email + "\",\"firstname\" : \"" + _firstname + "\",\"lastname\" : \"" + _lastname + "\", \"password\":\"" + _password + "\"} ";

                        try
                        {

                             await App.WService.ExecutePost("users", "create", null, requestBody);

                            _switchFormType.Execute(null);
                            // Todo: modify custard api to handle the error code
                            //// Log in
                            //await LogIn();

                        }
                        catch (Exception ex)
                        {
                            ErrorMsg = ex.Message;
                        }
                        
                    }
                    else
                    {
                        ErrorMsg = "Passwords doesn't match";
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
            _switchFormType = new Command(() =>
           {
               try
               {
                   IsSignUp = !_isSignUp;
                   IsSignIn = !_isSignIn;
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.Message);
               }
           });
        }

        private async Task LogIn()
        {
            string requestBody = "{ \"email\" : \"" + Email + "\", \"password\":\"" + Password + "\"} ";

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
    }
}
