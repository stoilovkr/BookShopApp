﻿// <auto-generated />
using BookService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookService.Migrations
{
    [DbContext(typeof(BooksDbContext))]
    [Migration("20190908115929_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookService.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName");

                    b.HasKey("Id");

                    b.ToTable("Author","dbo");

                    b.HasData(
                        new { Id = 1, FullName = "Leo Tolstoy" },
                        new { Id = 2, FullName = "William Shakespeare" },
                        new { Id = 3, FullName = "Mark Twain" }
                    );
                });

            modelBuilder.Entity("BookService.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<int>("Genre");

                    b.Property<double>("Price");

                    b.Property<string>("Synopsis");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book","dbo");

                    b.HasData(
                        new { Id = 1, AuthorId = 1, Genre = 0, Price = 200.0, Synopsis = "The novel chronicles the French invasion of Russia and the impact of the Napoleonic era...", Title = "War and peace" },
                        new { Id = 2, AuthorId = 2, Genre = 4, Price = 300.0, Synopsis = "In Romeo and Juliet, Shakespeare creates a violent world, in which two young people fall in love...", Title = "Romeo and Juliet" },
                        new { Id = 3, AuthorId = 3, Genre = 6, Price = 400.0, Synopsis = "A nineteenth-century boy from a Mississippi River town recounts his adventures...", Title = "The Adventures of Huckleberry Finn" },
                        new { Id = 4, AuthorId = 1, Genre = 0, Price = 200.0, Synopsis = "It deals with themes of betrayal, faith, family, marriage, Imperial Russian society, desire, and rural vs. city life....", Title = "Ana Karenina" },
                        new { Id = 5, AuthorId = 2, Genre = 1, Price = 300.0, Synopsis = "Set in Denmark, the play depicts Prince Hamlet and his revenge against his uncle, Claudius, who has murdered Hamlet's father in order to seize his throne and marry Hamlet's mother....", Title = "Hamlet" },
                        new { Id = 6, AuthorId = 3, Genre = 0, Price = 400.0, Synopsis = " It is set in the 1840s in the fictional town of St. Petersburg, inspired by Hannibal, Missouri, where Twain lived as a boy....", Title = "The Adventures of Tom Sawyer" }
                    );
                });

            modelBuilder.Entity("BookService.Models.Book", b =>
                {
                    b.HasOne("BookService.Models.Author", "AuthorEntity")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
