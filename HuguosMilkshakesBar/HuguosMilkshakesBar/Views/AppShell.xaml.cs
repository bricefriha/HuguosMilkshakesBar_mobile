using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuguosMilkshakesBar.Viewmodels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuguosMilkshakesBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        private ShellViewmodel _vm;
        public AppShell()
        {
            
            InitializeComponent();
            BindingContext = _vm = new ShellViewmodel();
        }

        private async void btnSignIn_Clicked(object sender, EventArgs e)
        {
            _vm.CloseFlyout();

            // Navigate to sign in page
            await this.Navigation.PushAsync(new SignInPage());

        }
        
    }
}