using FilRouge.WPFApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FilRouge.WPFApp.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        private Visibility loginVisibility;
        private Visibility registerVisibility;
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

        public SwitchLoginRegisterCommand SwitchLoginRegisterCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public LoginVM()
        {
            LoginVisibility = Visibility.Visible;
            RegisterVisibility = Visibility.Collapsed;

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
    }
}
