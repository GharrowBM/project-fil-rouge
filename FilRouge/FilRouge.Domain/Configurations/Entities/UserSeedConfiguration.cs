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
    public class UserSeedConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Posts)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Answers)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Comments)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.FavoriteTags)
                .WithMany(t => t.Subscribers);

            builder
                .HasData
                (
                    new User
                    {
                        Id = 1,
                        FirstName = "Jotaro",
                        LastName = "Cujoh",
                        Username = "Jojo",
                        AvatarURI = new Uri("http://avatar.com/jojo"),
                        Email = "jotaro.cujoh@mail.com",
                        RegisterAt = DateTime.Now,
                        IsBlacklisted = false,
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Jolyne",
                        LastName = "Cujoh",
                        Username = "JojoGirl",
                        AvatarURI = new Uri("http://avatar.com/jojogirl"),
                        Email = "jotaro.cujoh.girl@mail.com",
                        RegisterAt = DateTime.Now,
                        IsBlacklisted = true,
                    }
                );

        }

    }
}
