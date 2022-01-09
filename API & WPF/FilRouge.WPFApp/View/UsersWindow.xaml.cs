using System.Windows;
using FilRouge.WPFApp.ViewModel;

namespace FilRouge.WPFApp.View
{
    public partial class UsersWindow : Window
    {
        public UserVM UVM { get; set; }
        public UsersWindow()
        {
            UVM = new UserVM();
            
            InitializeComponent();
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            UVM.GetAllUsers();
        }
    }
}