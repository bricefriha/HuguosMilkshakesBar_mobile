using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HuguosMilkshakesBar.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace HuguosMilkshakesBar.Viewmodels
{
    public class CatalogDetailViewModel : BaseViewModel
    {
        private Milkshake _milkshake;
        public Milkshake Milkshake
        {
            get
            {
                return _milkshake;
            }
            set
            {
                _milkshake = value;
                OnPropertyChanged();
            }
        }
        public CatalogDetailViewModel (string milkshakeId)
        {
            Task.Run(async () => await this.GetMilkshake(milkshakeId));
        }
        private async Task GetMilkshake(string milkshakeId)
        {
            // Define the body
            string requestBody = "{ \"milkshakeId\" : \"" + milkshakeId + "\"} ";

            // Fetch all the detail about the milkshake
            Milkshake = await App.WService.ExecuteGet<Milkshake>("milkshakes", "single", null, requestBody);
        }
    }
}
