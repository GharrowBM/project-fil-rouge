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
using System.Windows.Shapes;

namespace FilRouge.WPFApp.View
{
    /// <summary>
    /// Interaction logic for PostsWindow.xaml
    /// </summary>
    public partial class PostsWindow : Window
    {
        private FilRougeDbContext context = new FilRougeDbContext();
        private List<Post> posts;

        public PostsWindow()
        {
            InitializeComponent();

            posts = context.Posts.ToList();
        }

        private void postListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void searchPostTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
