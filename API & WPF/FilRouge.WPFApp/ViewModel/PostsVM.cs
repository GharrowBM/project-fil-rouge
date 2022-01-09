using FilRouge.Classes;
using FilRouge.Classes.Enums;
using FilRouge.WPFApp.ViewModel.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Repositories;
using FilRouge.Repositories.Interfaces;
using Newtonsoft.Json;

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
                FilterListOfPosts();
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
                FilterListOfPosts();
            }
        }

        public List<Post> Posts { get { return posts; } set { posts = value; } }
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public PostsVM()
        {

            DeletePostCommand = new DeletePostCommand(this);
            Posts = new List<Post>();
            SearchText = "";
        }

        private void FilterListOfPosts()
        {

        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public async void DeletePost()
        {
            string url = "https://localhost:5001/api";
            
            using HttpClient client = new HttpClient();
            
            var responseOfDeletion = await client.DeleteAsync(url + $"/Post/{SelectedPost.Id}");
            if (responseOfDeletion.IsSuccessStatusCode)
            {
                var responseOfGetAll = await client.GetAsync(url + "/Post");
                var json = await responseOfGetAll.Content.ReadAsStringAsync();
                
                Posts = JsonConvert.DeserializeObject<List<Post>>(json);
            }
        }

        public async Task<List<Post>> UpdateListOfPosts()
        {
            List<Post> newList = new List<Post>();
            
            string url = "https://localhost:5001/api";
            
            using HttpClient client = new HttpClient();
            
            var responseOfGetAll = await client.GetAsync(url + "/Post");
            var json = await responseOfGetAll.Content.ReadAsStringAsync();
            
            newList = JsonConvert.DeserializeObject<List<Post>>(json);

            return newList;
        }
    }
}
