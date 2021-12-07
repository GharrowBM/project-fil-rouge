using FilRouge.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Data
{
    public class FilRougeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(SecretConnection.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Base Datas 

            // Users

            User userA = new User
            {
                Id = 1,
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
                Id = 2,
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

            Tag tagA = new Tag { Id = 1, Name = "Tag A", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };
            Tag tagB = new Tag { Id = 2, Name = "Tag B", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };
            Tag tagC = new Tag { Id = 3, Name = "Tag C", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };
            Tag tagD = new Tag { Id = 4, Name = "Tag D", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };
            Tag tagE = new Tag { Id = 5, Name = "Tag E", Subscribers = new List<User>(), RelatedPosts = new List<Post>() };

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
                Id = 1,
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
                Id = 2,
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
                Id = 1,
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
                Id = 2,
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
                Id = 3,
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
                Id = 4,
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
                Id = 1,
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
                Id = 2,
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
                Id = 3,
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
                Id = 4,
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
                Id = 5,
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
                Id = 6,
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
                Id = 7,
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
                Id = 8,
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

            #endregion

            #region DB Links - Constraints

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Answers)
                .WithOne(p => p.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(p => p.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Answers)
                .WithOne(a => a.Post)
                .HasForeignKey(a => a.PostId);

            modelBuilder.Entity<Answer>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.Answer)
                .HasForeignKey(c => c.AnswerId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(p => p.User)
                .WithMany(a => a.Answers)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Post)
                .WithMany(p => p.Answers)
                .HasForeignKey(a => a.PostId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Comment>()
                .HasOne(p => p.User)
                .WithMany(a => a.Comments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Answer)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<User>()
            //    .OwnsMany(u => u.FavoriteTags)
            //    .OwnsMany(t => t.Subscribers);

            //modelBuilder.Entity<Post>()
            //    .OwnsMany(p => p.Tags)
            //    .OwnsMany(t => t.RelatedPosts);

            //modelBuilder.Entity<Post>()
            //    .OwnsOne(p => p.User)
            //    .OwnsMany(a => a.Posts);

            //modelBuilder.Entity<Answer>()
            //    .OwnsOne(p => p.Post)
            //    .OwnsMany(p => p.Answers);

            //modelBuilder.Entity<Answer>()
            //    .OwnsOne(c => c.User)
            //    .OwnsMany(a => a.Answers);

            //modelBuilder.Entity<Comment>()
            //    .OwnsOne(c => c.Answer)
            //    .OwnsMany(a => a.Comments);

            //modelBuilder.Entity<Comment>()
            //    .OwnsOne(c => c.User)
            //    .OwnsMany(a => a.Comments);
                



            #endregion

            //modelBuilder.Entity<User>().HasData(userA, userB);
            //modelBuilder.Entity<Tag>().HasData(tagA, tagB, tagC, tagD, tagE);
            //modelBuilder.Entity<Post>().HasData(postA, postB);
            //modelBuilder.Entity<Answer>().HasData(answerA, answerB, answerC, answerD);
            //modelBuilder.Entity<Comment>().HasData(commentA, commentB, commentC, commentD, commentE, commentF, commentG, commentH);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
