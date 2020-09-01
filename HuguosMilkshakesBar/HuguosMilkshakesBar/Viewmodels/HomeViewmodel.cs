using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            RefreshPostList();
        }

        /// <summary>
        ///  Function to refresh the post list
        /// </summary>
        private async Task RefreshPostList()
        {
            try
            {
                // Get the posts and order them by date
                Posts = new ObservableCollection<Post>((await App.WService.ExecuteGet<Collection<Post>>("posts/")).OrderBy(post => post.CreatedDate).Reverse());
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Network 🌐", "Sorry, but we can get any data from the server 😥.", "I'll retry later.");
            }
        }
    }
}
