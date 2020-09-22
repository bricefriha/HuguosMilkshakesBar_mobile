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
    public partial class CatalogPage : ContentPage
    {
        public CatalogPage()
        {
            InitializeComponent();

            BindingContext = new CatalogViewModel();
        }
    }
}