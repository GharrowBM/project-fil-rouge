using System.Windows;

namespace FilRouge.WPFApp.View
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void PostButton_OnClick(object sender, RoutedEventArgs e)
        {
            PostsWindow postW = new PostsWindow();
            postW.Show();
        }

        private void UserButton_OnClick(object sender, RoutedEventArgs e)
        {
            UsersWindow usersW = new UsersWindow();
            usersW.Show();
        }
    }
}