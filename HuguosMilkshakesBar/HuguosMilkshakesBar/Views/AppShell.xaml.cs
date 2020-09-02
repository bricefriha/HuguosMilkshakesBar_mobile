using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuguosMilkshakesBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void btnSignIn_Clicked(object sender, EventArgs e)
        {
            CloseFlyout();

            // Navigate to sign in page
            await this.Navigation.PushAsync(new SignInPage());

        }
        /// <summary>
        /// Method to close the flyout
        /// </summary>
        private void CloseFlyout()
        {
            FlyoutBehavior = FlyoutBehavior.Disabled;
            FlyoutBehavior = FlyoutBehavior.Flyout;
        }
    }
}