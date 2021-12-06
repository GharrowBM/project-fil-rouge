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
    internal class TagSeedConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder
                .HasMany(t => t.Subscribers)
                .WithMany(u => u.FavoriteTags);
                

            builder
                .HasData
                (
                    new Tag { Id = 1, Name = "Tag A"},
                    new Tag { Id = 2, Name = "Tag B"},
                    new Tag { Id = 3, Name = "Tag C"},
                    new Tag { Id = 4, Name = "Tag D"},
                    new Tag { Id = 5, Name = "Tag E"}
                );
        }
    }
}
