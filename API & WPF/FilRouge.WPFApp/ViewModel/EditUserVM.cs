using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using FilRouge.Classes;
using FilRouge.WPFApp.Annotations;
using FilRouge.WPFApp.View;
using FilRouge.WPFApp.ViewModel.Commands;
using Newtonsoft.Json;

namespace FilRouge.WPFApp.ViewModel
{
    public class EditUserVM : INotifyPropertyChanged
    {
        private User _selectedUser;
        private EditUserWindow _window;

        public User SelectedUser
        {
            get { return _selectedUser;}
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        
        public EditUserCommand EditUserCommand { get; set; }

        public EditUserVM(User user, EditUserWindow window)
        {
            _window = window;
            _selectedUser = user;

            EditUserCommand = new EditUserCommand(this);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public async void EditUser()
        {
            string url = "https://localhost:5001/api";

            var json = JsonConvert.SerializeObject(SelectedUser);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpClient client = new HttpClient();

            var httpResponse = await client.PutAsync(url + $"/User/wpf/{SelectedUser.Id}", httpContent);

            if (httpResponse.IsSuccessStatusCode)
            {
                _window.Close();
            }
        }
    }
}