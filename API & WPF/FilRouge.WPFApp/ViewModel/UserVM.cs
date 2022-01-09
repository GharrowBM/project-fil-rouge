using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FilRouge.WPFApp.Annotations;
using FilRouge.Classes;
using FilRouge.Classes.Enums;
using FilRouge.WPFApp.View;
using FilRouge.WPFApp.ViewModel.Commands;
using Newtonsoft.Json;

namespace FilRouge.WPFApp.ViewModel
{
    public class UserVM : INotifyPropertyChanged
    {
        private string _searchText;
        private List<User> users;
        private User selectedUser;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
                GetAllUsers();
            }
        }
        public List<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public DeleteUserCommand DeleteUserCommand { get; set; }
        public ShowEditUserCommand ShowEditUserCommand { get; set; }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        
        public UserVM()
        {
            DeleteUserCommand = new DeleteUserCommand(this);
            ShowEditUserCommand = new ShowEditUserCommand(this);
            Users = new List<User>();
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public async void GetAllUsers()
        {
            List<User> newList = new List<User>();
            
            string url = "https://localhost:5001/api/User";
            
            using HttpClient client = new HttpClient();
            
            var responseOfGetAll = await client.GetAsync(url);
            if (responseOfGetAll.IsSuccessStatusCode)
            {
                var json = await responseOfGetAll.Content.ReadAsStringAsync();
            
                newList = JsonConvert.DeserializeObject<List<User>>(json);

                Users = newList;
            }
        }

        public async Task<List<User>> DeleteUser(int id)
        {
            List<User> newList = new List<User>();
            
            string url = "https://localhost:5001/api";
            
            using HttpClient client = new HttpClient();
            
            var responseOfDeletion = await client.DeleteAsync(url + $"/User/{id}");
            if (responseOfDeletion.IsSuccessStatusCode)
            {
                GetAllUsers();
            }

            return newList;
        }

        public void ShowEditUserWindow()
        {
            EditUserWindow editUserWin = new EditUserWindow();
            editUserWin.Show();
        }
    }
}