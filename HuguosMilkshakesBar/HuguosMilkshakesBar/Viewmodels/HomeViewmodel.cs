using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using HuguosMilkshakesBar.Models;
using MvvmHelpers;

namespace HuguosMilkshakesBar.Viewmodels
{
    class HomeViewmodel : BaseViewModel
    {
        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> Posts
        {
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
            get { return _posts; }
        }
        public HomeViewmodel ()
        {
            // Set the title
            this.Title = "Home";

            _posts = new ObservableCollection<Post>();

            // Get the posts
            RefreshPostList().Wait();
        }

        /// <summary>
        ///  Function to refresh the post list
        /// </summary>
        private async Task RefreshPostList()
        {
            try
            {
                Posts = await App.WService.ExecuteGet<ObservableCollection<Post>>("posts");
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Network 🌐", "Sorry, but we can get any data from the server 😥.", "I'll retry later.");
            }
        }
    }
}
