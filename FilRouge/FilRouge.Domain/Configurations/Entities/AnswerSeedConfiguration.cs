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
    internal class AnswerSeedConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder
                .HasMany(a => a.Comments)
                .WithOne(c => c.Answer)
                .HasForeignKey(c => c.AnswerId);


            builder.HasData
                (
                    new Answer
                    {
                        Id = 1,
                        Content = "Answer A",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 1,
                        PostId = 1,
                    },
                    new Answer
                    {
                        Id = 2,
                        Content = "Answer B",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 2,
                        PostId = 1,
                    },
                    new Answer
                    {
                        Id = 3,
                        Content = "Answer C",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 1,
                        PostId = 2,
                    },
                    new Answer
                    {
                        Id = 4,
                        Content = "Answer D",
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now,
                        Score = 0,
                        AuthorId = 2,
                        PostId = 2,
                    }
            );

        }
    }
}
