using System.ComponentModel;
using System.Runtime.CompilerServices;
using FilRouge.Classes;
using FilRouge.WPFApp.Annotations;

namespace FilRouge.WPFApp.ViewModel
{
    public class EditUserVM : INotifyPropertyChanged
    {
        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser;}
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        
        public EditUserVM(User user)
        {
            _selectedUser = user;
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}