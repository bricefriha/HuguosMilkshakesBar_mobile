using System;
using CustardApi.Objects;
using HuguosMilkshakesBar.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuguosMilkshakesBar
{
    public partial class App : Application
    {
        public static Service WService { set; get; }
        public App()
        {
            InitializeComponent();

            // Set the web service
            WService = new Service("localhost");

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
