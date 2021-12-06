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
    internal class CommentSeedConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasData
                (
                    new Comment
                    {
                        Id = 1,
                        Content = "Comment A",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 1,
                        AnswerId = 1,
                    },
                    new Comment
                    {
                        Id = 2,
                        Content = "Comment B",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 2,
                        AnswerId = 1,
                    },
                    new Comment
                    {
                        Id = 3,
                        Content = "Comment C",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 1,
                        AnswerId = 2,
                    },
                    new Comment
                    {
                        Id = 4,
                        Content = "Comment D",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 2,
                        AnswerId = 2,
                    },
                    new Comment
                    {
                        Id = 5,
                        Content = "Comment A",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 1,
                        AnswerId = 3,
                    },
                    new Comment
                    {
                        Id = 6,
                        Content = "Comment B",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 2,
                        AnswerId = 3,
                    },
                    new Comment
                    {
                        Id = 7,
                        Content = "Comment C",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 1,
                        AnswerId = 4,
                    },
                    new Comment
                    {
                        Id = 8,
                        Content = "Comment D",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 2,
                        AnswerId = 4,
                    }
                );
        }
    }
}
