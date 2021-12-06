﻿// <auto-generated />
using System;
using FilRouge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilRouge.Data.Migrations
{
    [DbContext(typeof(FilRougeDbContext))]
    [Migration("20211206142638_BaseDatas")]
    partial class BaseDatas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FilRouge.Domain.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Content = "Answer A",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(3172),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(3481),
                            PostId = 1,
                            Score = 0
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Content = "Answer B",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4392),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4403),
                            PostId = 1,
                            Score = 0
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            Content = "Answer C",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4407),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4409),
                            PostId = 2,
                            Score = 0
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            Content = "Answer D",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4412),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4414),
                            PostId = 2,
                            Score = 0
                        });
                });

            modelBuilder.Entity("FilRouge.Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerId = 1,
                            AuthorId = 1,
                            Content = "Comment A",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(9321),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(9618),
                            Score = 0
                        },
                        new
                        {
                            Id = 2,
                            AnswerId = 1,
                            AuthorId = 2,
                            Content = "Comment B",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(518),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(530),
                            Score = 0
                        },
                        new
                        {
                            Id = 3,
                            AnswerId = 2,
                            AuthorId = 1,
                            Content = "Comment C",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(534),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(536),
                            Score = 0
                        },
                        new
                        {
                            Id = 4,
                            AnswerId = 2,
                            AuthorId = 2,
                            Content = "Comment D",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(539),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(541),
                            Score = 0
                        },
                        new
                        {
                            Id = 5,
                            AnswerId = 3,
                            AuthorId = 1,
                            Content = "Comment A",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(544),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(546),
                            Score = 0
                        },
                        new
                        {
                            Id = 6,
                            AnswerId = 3,
                            AuthorId = 2,
                            Content = "Comment B",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(549),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(551),
                            Score = 0
                        },
                        new
                        {
                            Id = 7,
                            AnswerId = 4,
                            AuthorId = 1,
                            Content = "Comment C",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(553),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(555),
                            Score = 0
                        },
                        new
                        {
                            Id = 8,
                            AnswerId = 4,
                            AuthorId = 2,
                            Content = "Comment D",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(558),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(560),
                            Score = 0
                        });
                });

            modelBuilder.Entity("FilRouge.Domain.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Content = "Post A content",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(3902),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(4343),
                            Score = 0,
                            Title = "Post A"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Content = "Post B content",
                            CreatedAt = new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(5161),
                            EditedAt = new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(5173),
                            Score = 666,
                            Title = "Post B"
                        });
                });

            modelBuilder.Entity("FilRouge.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tag A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tag B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tag C"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tag D"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Tag E"
                        });
                });

            modelBuilder.Entity("FilRouge.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarURI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBlacklisted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvatarURI = "http://avatar.com/jojo",
                            Email = "jotaro.cujoh@mail.com",
                            FirstName = "Jotaro",
                            IsBlacklisted = false,
                            LastName = "Cujoh",
                            RegisterAt = new DateTime(2021, 12, 6, 15, 26, 37, 513, DateTimeKind.Local).AddTicks(9279),
                            Username = "Jojo"
                        },
                        new
                        {
                            Id = 2,
                            AvatarURI = "http://avatar.com/jojogirl",
                            Email = "jotaro.cujoh.girl@mail.com",
                            FirstName = "Jolyne",
                            IsBlacklisted = true,
                            LastName = "Cujoh",
                            RegisterAt = new DateTime(2021, 12, 6, 15, 26, 37, 516, DateTimeKind.Local).AddTicks(4195),
                            Username = "JojoGirl"
                        });
                });

            modelBuilder.Entity("FilRouge.Domain.Answer", b =>
                {
                    b.HasOne("FilRouge.Domain.User", "Author")
                        .WithMany("Answers")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FilRouge.Domain.Post", "Post")
                        .WithMany("Answers")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("FilRouge.Domain.Comment", b =>
                {
                    b.HasOne("FilRouge.Domain.Answer", "Answer")
                        .WithMany("Comments")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilRouge.Domain.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("FilRouge.Domain.Post", b =>
                {
                    b.HasOne("FilRouge.Domain.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("FilRouge.Domain.Tag", b =>
                {
                    b.HasOne("FilRouge.Domain.Post", null)
                        .WithMany("Tags")
                        .HasForeignKey("PostId");

                    b.HasOne("FilRouge.Domain.User", null)
                        .WithMany("FavoriteTags")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FilRouge.Domain.Answer", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("FilRouge.Domain.Post", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("FilRouge.Domain.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Comments");

                    b.Navigation("FavoriteTags");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
