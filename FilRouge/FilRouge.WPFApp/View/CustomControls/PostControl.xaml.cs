using FilRouge.Data;
using FilRouge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilRouge.WPFApp.View.CustomControls
{
    /// <summary>
    /// Interaction logic for PostControl.xaml
    /// </summary>
    public partial class PostControl : UserControl
    {
        private static FilRougeDbContext context = new FilRougeDbContext();

        public Post Post
        {
            get { return (Post)GetValue(PostProperty); }
            set { SetValue(PostProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Post.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostProperty =
            DependencyProperty.Register("Post", typeof(Post), typeof(PostControl), new PropertyMetadata(new Post(), SetPost));

        private static void SetPost(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PostControl control = (PostControl) d;

            if (control != null)
            {
                control.postAuthorTextBlock.Text = (e.NewValue as Post).Author.Username;
                control.postTitleTextBlock.Text = (e.NewValue as Post).Title;
                control.postCreationDateTextBlock.Text = (e.NewValue as Post).CreatedAt.ToString();
                control.postContentTextBlock.Text = (e.NewValue as Post).Content;
            }
        }


        public PostControl()
        {
            InitializeComponent();
        }
    }
}
