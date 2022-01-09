using FilRouge.WPFApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FilRouge.Classes;
using FilRouge.WPFApp.View;
using Newtonsoft.Json;

namespace FilRouge.WPFApp.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        private Visibility loginVisibility;
        private Visibility registerVisibility;
        private string username;
        private string password;
        private bool isShowningRegister = false;

        public Visibility LoginVisibility
        {
            get { return loginVisibility; }
            set 
            { 
                loginVisibility = value;
                OnPropertyChanged("LoginVisibility");
            }
        }

        public Visibility RegisterVisibility
        {
            get { return registerVisibility; }
            set 
            { 
                registerVisibility = value;
                OnPropertyChanged("RegisterVisibility");
            }
        }
        
        public string Username
        {
            get { return username; }
            set 
            { 
                username = value;
                OnPropertyChanged("Username");
            }
        }
        
        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public SwitchLoginRegisterCommand SwitchLoginRegisterCommand { get; set; }
        public LoginVerificationCommand LoginVerificationCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public LoginVM()
        {
            LoginVisibility = Visibility.Visible;
            RegisterVisibility = Visibility.Collapsed;

            LoginVerificationCommand = new LoginVerificationCommand(this);
            SwitchLoginRegisterCommand = new SwitchLoginRegisterCommand(this);
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void SwitchLoginRegister()
        {
            isShowningRegister = !isShowningRegister;
            if (isShowningRegister)
            {
                RegisterVisibility = Visibility.Visible;
                LoginVisibility = Visibility.Collapsed;
            }
            else
            {
                RegisterVisibility = Visibility.Collapsed;
                LoginVisibility = Visibility.Visible;
            }
        }

        public async void LogUserTest()
        {
            string url = "https://localhost:5001/api/User";

            using HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(json);
            
            if (listOfUsers.Find(u=>u.IsAdmin == true && u.Username == username && u.Password == password) != null)
            {
                PostsWindow postWindow = new PostsWindow();
                postWindow.Show();
            }
        }
    }
}
