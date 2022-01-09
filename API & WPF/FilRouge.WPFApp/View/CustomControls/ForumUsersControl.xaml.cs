using System.Windows;
using System.Windows.Controls;
using FilRouge.Classes;

namespace FilRouge.WPFApp.View.CustomControls
{
    public partial class ForumUsersControl : UserControl
    {
        public User User
        {
            get { return (User)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Post.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(User), typeof(ForumUsersControl), new PropertyMetadata(new User(), SetUser));

        private static void SetUser(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ForumUsersControl control = (ForumUsersControl) d;

            if (control != null)
            {
                control.usernameTextBlock.Text = (e.NewValue as User).Username;
                control.registeredAtDateTextBlock.Text = (e.NewValue as User).RegisterAt.ToString("d");
                control.statusTextBlock.Text = (e.NewValue as User).IsAdmin ? "Admin" : "Normal User";
                control.isBlacklistedTextBlock.Text = (e.NewValue as User).IsBlacklisted ? "Banned" : "Allowed";
            }
        }
        
        public ForumUsersControl()
        {
            InitializeComponent();
        }
    }
}