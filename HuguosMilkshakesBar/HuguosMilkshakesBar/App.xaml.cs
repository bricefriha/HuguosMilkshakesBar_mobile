using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustardApi.Objects;
using HuguosMilkshakesBar.Models;
using HuguosMilkshakesBar.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuguosMilkshakesBar
{
    public partial class App : Application
    {
        public static Service WService { set; get; }
        public static User currentUser { set; get; }
        public App()
        {
            InitializeComponent();

            // Set the web service
            WService = new Service("192.168.1.67", 3000);

            MainPage = new Page();
        }

        protected override async void OnStart()
        {

            await FetchPreviousToken();

            MainPage = new AppShell();


        }
        /// <summary>
        /// Fetch the token of the previous session if this one exist
        /// </summary>
        /// <returns></returns>
        private static async Task FetchPreviousToken()
        {
            try
            {
                // Get the token of the previous session
                var Token = await SecureStorage.GetAsync("oauth_token");


                // If this token exist
                if (!string.IsNullOrEmpty(Token))
                {
                    // Set the header
                    IDictionary<string, string> headers = new Dictionary<string, string>();
                    // Fetch the user token
                    headers.Add("Authorization", "Bearer " + Token);

                    App.currentUser = await WService.ExecuteGet<User>("users", null, headers);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
