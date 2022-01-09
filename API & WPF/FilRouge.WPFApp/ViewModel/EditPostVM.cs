using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Classes;
using FilRouge.Classes.Enums;
using FilRouge.WPFApp.View;
using FilRouge.WPFApp.ViewModel.Commands;
using Newtonsoft.Json;


namespace FilRouge.WPFApp.ViewModel
{
    public class EditPostVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Post selectedPost;


        public Post SelectedPost
        {
            get { return selectedPost; }
            set
            {
                selectedPost = value;
                OnPropertyChanged("SelectedPost");
            }
        }

        public EditPostCommand EditPostCommand { get; set; }

        public EditPostVM(Post post)
        {
            SelectedPost = post;
            EditPostCommand = new EditPostCommand(this);
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public async void EditPost()
        {
            string url = "https://localhost:5001/api";

            var json = JsonConvert.SerializeObject(selectedPost);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpClient client = new HttpClient();

            var httpResponse = await client.PutAsync(url + $"/Put/{SelectedPost.Id}", httpContent);

            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}
