using FilRouge.Classes;
using FilRouge.Classes.Enums;
using FilRouge.WPFApp.ViewModel.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Repositories;
using FilRouge.Repositories.Interfaces;
using Newtonsoft.Json;
using FilRouge.WPFApp.View;

namespace FilRouge.WPFApp.ViewModel
{
    public class PostsVM : INotifyPropertyChanged
    {
        private string _searchText;
        private List<Post> posts;
        private List<Post> filteredPosts;
        private TypeOfFilterEnum selectedFilter;
        private Post selectedPost;

        public string SearchText
        {
            get { return _searchText; }
            set 
            { 
                _searchText = value;
                OnPropertyChanged("SearchText");
                FilterListOfPosts(SearchText);
            }
        }

        public List<TypeOfFilterEnum> TypeOfFilters { get; } = Enum.GetValues(typeof(TypeOfFilterEnum)).Cast<TypeOfFilterEnum>().ToList();

        public  TypeOfFilterEnum SelectedFilter 
        { 
            get { return selectedFilter; } 
            set 
            { 
                selectedFilter = value;
                OnPropertyChanged("SelectedFilter");
                FilterListOfPosts(SearchText);
            }
        }

        public List<Post> Posts
        {
            get { return posts; }
            set
            {
                posts = value;
                OnPropertyChanged("Posts");
                OnPropertyChanged("FilteredPosts");
            }
        }
        public List<Post> FilteredPosts 
        { 
            get { return filteredPosts; } 
            set 
            { 
                filteredPosts = value;
                OnPropertyChanged("FilteredPosts");
            } 
        }

        public Post SelectedPost 
        { 
            get { return selectedPost;} 
            set 
            { 
                selectedPost = value;
                OnPropertyChanged("SelectedPost");
            } 
        }

        public DeletePostCommand DeletePostCommand { get; set; }
        public ShowEditPostWindowCommand ShowEditPostWindowCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public PostsVM()
        {

            DeletePostCommand = new DeletePostCommand(this);
            ShowEditPostWindowCommand = new ShowEditPostWindowCommand(this);
            Posts = new List<Post>();
            SearchText = "";
        }

        public async void FilterListOfPosts(string searchQuery)
        {
            List<Post> newList = new List<Post>();
            
            string url = "https://localhost:5001/api";
            
            using HttpClient client = new HttpClient();
            
            var responseOfGetAll = await client.GetAsync(url + $"/Post/search{searchQuery}");
            if (responseOfGetAll.IsSuccessStatusCode)
            {
                var json = await responseOfGetAll.Content.ReadAsStringAsync();
            
                newList = JsonConvert.DeserializeObject<List<Post>>(json);

                FilteredPosts = newList;
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public async Task<List<Post>> DeletePost(int id)
        {
            List<Post> newList = new List<Post>();
            
            string url = "https://localhost:5001/api";
            
            using HttpClient client = new HttpClient();
            
            var responseOfDeletion = await client.DeleteAsync(url + $"/Post/{id}");
            if (responseOfDeletion.IsSuccessStatusCode)
            {
                FilterListOfPosts(SearchText);
            }

            return newList;
        }

        public async void UpdateListOfPosts()
        {
            List<Post> newList = new List<Post>();
            
            string url = "https://localhost:5001/api";
            
            using HttpClient client = new HttpClient();
            
            var responseOfGetAll = await client.GetAsync(url + "/Post");
            var json = await responseOfGetAll.Content.ReadAsStringAsync();
            
            newList = JsonConvert.DeserializeObject<List<Post>>(json);

            Posts = newList;
        }

        public void ShowEditPostWindow()
        {
            EditPostWindow editPostWindow = new EditPostWindow(SelectedPost);
            editPostWindow.Show();
        }
    }
}
