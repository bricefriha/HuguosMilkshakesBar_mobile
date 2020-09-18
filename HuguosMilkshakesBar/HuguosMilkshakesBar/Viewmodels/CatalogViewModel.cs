using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using HuguosMilkshakesBar.Models;
using MvvmHelpers;

namespace HuguosMilkshakesBar.Viewmodels
{
    public class CatalogViewModel : BaseViewModel 
    {
        private ObservableCollection<Milkshake> _milkshakes; 
        public ObservableCollection<Milkshake> Milkshakes
        {
            set
            {
                _milkshakes = value;
                OnPropertyChanged();
            }
            get
            {
                return _milkshakes;
            }
        }
        public CatalogViewModel ()
        {
            // Get all the milkshakes
            _milkshakes = new ObservableCollection<Milkshake>(Task< Collection < Milkshake >>.Run( async () => await App.WService.ExecuteGet<Collection<Milkshake>>("milkshakes/")).Result);
        }
    }
}
