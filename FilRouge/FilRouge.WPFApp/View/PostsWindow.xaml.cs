using FilRouge.Data;
using FilRouge.Domain;
using Microsoft.EntityFrameworkCore;
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

            //PopulateDatabase();

            posts = context.Posts.Include(p => p.User).ToList();

            postListView.ItemsSource = posts;
        }

        private void postListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void searchPostTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PopulateDatabase()
        {
            // Users

            User userA = new User
            {
                FirstName = "Jotaro",
                LastName = "Cujoh",
                Username = "Jojo",
                AvatarURI = new Uri("http://avatar.com/jojo"),
                Email = "jotaro.cujoh@mail.com",
                RegisterAt = DateTime.Now,
                IsBlacklisted = false,
                FavoriteTags = new List<Tag>(),
                Posts = new List<Post>(),
                Answers = new List<Answer>(),
                Comments = new List<Comment>()
            };

            User userB = new User
            {
                FirstName = "Jolyne",
                LastName = "Cujoh",
                Username = "JojoGirl",
                AvatarURI = new Uri("http://avatar.com/jojogirl"),
                Email = "jotaro.cujoh.girl@mail.com",
                RegisterAt = DateTime.Now,
                IsBlacklisted = true,
                FavoriteTags = new List<Tag>(),
                Posts = new List<Post>(),
                Answers = new List<Answer>(),
                Comments = new List<Comment>()
            };

            // Tags

            Tag tagA = new Tag { Name = "Tag A", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };
            Tag tagB = new Tag { Name = "Tag B", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };
            Tag tagC = new Tag { Name = "Tag C", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };
            Tag tagD = new Tag { Name = "Tag D", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };
            Tag tagE = new Tag { Name = "Tag E", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };

            // Links between Users and Tags 

            userA.FavoriteTags.Add(tagA);
            tagA.Subscribers.Add(userA);
            userA.FavoriteTags.Add(tagB);
            tagB.Subscribers.Add(userA);
            userB.FavoriteTags.Add(tagB);
            tagB.Subscribers.Add(userB);
            userA.FavoriteTags.Add(tagC);
            tagC.Subscribers.Add(userA);
            userA.FavoriteTags.Add(tagD);
            tagD.Subscribers.Add(userA);
            userB.FavoriteTags.Add(tagD);
            tagD.Subscribers.Add(userB);
            userB.FavoriteTags.Add(tagE);
            tagE.Subscribers.Add(userB);

            // Posts

            Post postA = new Post
            {
                Title = "Post A",
                Content = "Post A content",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userA,
                UserId = 1,
                Tags = new List<Tag> { tagA, tagB },
                Answers = new List<Answer>()

            };

            Post postB = new Post
            {
                Title = "Post B",
                Content = "Post B content",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 666,
                User = userB,
                UserId = 2,
                Tags = new List<Tag> { tagC, tagD, tagE },
                Answers = new List<Answer>()
            };

            // Links between Users and Posts 

            userA.Posts.Add(postA);
            userB.Posts.Add(postB);

            // Links between Tags and Posts 

            tagA.RelatedPosts.Add(postA);
            tagB.RelatedPosts.Add(postA);
            tagC.RelatedPosts.Add(postB);
            tagD.RelatedPosts.Add(postB);
            tagE.RelatedPosts.Add(postB);

            // Answers

            Answer answerA = new Answer
            {
                Content = "Answer A",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userA,
                UserId = 1,
                Post = postA,
                PostId = 1,
                Comments = new List<Comment>()
            };

            Answer answerB = new Answer
            {
                Content = "Answer B",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userB,
                UserId = 2,
                Post = postA,
                PostId = 1,
                Comments = new List<Comment>()
            };

            Answer answerC = new Answer
            {
                Content = "Answer C",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userA,
                UserId = 1,
                Post = postB,
                PostId = 2,
                Comments = new List<Comment>()
            };

            Answer answerD = new Answer
            {
                Content = "Answer D",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userB,
                UserId = 2,
                Post = postB,
                PostId = 2,
                Comments = new List<Comment>()
            };

            // Links between Users and Answers

            userA.Answers.Add(answerA);
            userB.Answers.Add(answerB);
            userA.Answers.Add(answerC);
            userB.Answers.Add(answerD);

            // Links between Posts and Answers 

            postA.Answers.Add(answerA);
            postA.Answers.Add(answerA);
            postB.Answers.Add(answerC);
            postB.Answers.Add(answerD);

            //Comments

            Comment commentA = new Comment
            {
                Content = "Comment A",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userA,
                UserId = 1,
                Answer = answerA,
                AnswerId = 1
            };

            Comment commentB = new Comment
            {
                Content = "Comment B",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userB,
                UserId = 2,
                Answer = answerA,
                AnswerId = 1
            };

            Comment commentC = new Comment
            {
                Content = "Comment C",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userA,
                UserId = 1,
                Answer = answerB,
                AnswerId = 2
            };

            Comment commentD = new Comment
            {
                Content = "Comment D",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userB,
                UserId = 2,
                Answer = answerB,
                AnswerId = 2
            };

            Comment commentE = new Comment
            {
                Content = "Comment E",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userA,
                UserId = 1,
                Answer = answerC,
                AnswerId = 3
            };

            Comment commentF = new Comment
            {
                Content = "Comment F",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userB,
                UserId = 2,
                Answer = answerC,
                AnswerId = 3
            };

            Comment commentG = new Comment
            {
                Content = "Comment G",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userA,
                UserId = 1,
                Answer = answerD,
                AnswerId = 4
            };

            Comment commentH = new Comment
            {
                Content = "Comment H",
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Score = 0,
                User = userB,
                UserId = 2,
                Answer = answerD,
                AnswerId = 4
            };

            // Links between Users and Comments

            userA.Comments.Add(commentA);
            userB.Comments.Add(commentB);
            userA.Comments.Add(commentC);
            userB.Comments.Add(commentD);
            userA.Comments.Add(commentE);
            userB.Comments.Add(commentF);
            userA.Comments.Add(commentG);
            userB.Comments.Add(commentH);

            // Links between Answers and Posts

            answerA.Comments.Add(commentA);
            answerA.Comments.Add(commentB);
            answerB.Comments.Add(commentC);
            answerB.Comments.Add(commentD);
            answerC.Comments.Add(commentE);
            answerC.Comments.Add(commentF);
            answerD.Comments.Add(commentG);
            answerD.Comments.Add(commentH);

            context.Users.Add(userA);
            context.Users.Add(userB);

            context.Tags.Add(tagA);
            context.Tags.Add(tagB);
            context.Tags.Add(tagC);
            context.Tags.Add(tagD);
            context.Tags.Add(tagE);

            context.Posts.Add(postA);
            context.Posts.Add(postB);

            context.Answers.Add(answerA);
            context.Answers.Add(answerB);
            context.Answers.Add(answerC);
            context.Answers.Add(answerD);

            context.Comments.Add(commentA);
            context.Comments.Add(commentB);
            context.Comments.Add(commentC);
            context.Comments.Add(commentD);
            context.Comments.Add(commentE);
            context.Comments.Add(commentF);
            context.Comments.Add(commentG);
            context.Comments.Add(commentH);
            
            context.SaveChanges();
        }


    }
}
