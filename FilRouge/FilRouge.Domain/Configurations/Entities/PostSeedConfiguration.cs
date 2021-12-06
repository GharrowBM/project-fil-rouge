using FilRouge.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Data.Configurations.Entities
{
    internal class PostSeedConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasMany(p => p.Answers)
                .WithOne(a => a.Post)
                .HasForeignKey(a => a.PostId);


            builder
                .HasData
                (
                    new Post
                    {
                        Id = 1,
                        Title = "Post A",
                        Content = "Post A content",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 1,

                    },
                    new Post
                    {
                        Id = 2,
                        Title = "Post B",
                        Content = "Post B content",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 666,
                        AuthorId = 2,
                    }
                );

        }
    }
}
