using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace VideoRentalApp.DataAccess
{
    public class VideoRentalAppDbContext : DbContext 
    {
        public DbSet<User> User { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Rental> Rental { get; set; }

        public VideoRentalAppDbContext(DbContextOptions<VideoRentalAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x=> x.UserId);

            modelBuilder.Entity<Rental>()
                .HasOne(x => x.Movie)
                .WithMany()
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Cast>()
                .HasOne(x => x.Movie)
                .WithMany()
                .HasForeignKey(x => x.MovieId);


             modelBuilder.Entity<User>().HasData(
                    new User 
                    { Id = 1,
                      FirstName = "Stefan",
                      LastName = "Stefanovski",
                      Age = 28,
                      CardNumber=1111222233334444,
                      Email = "stefan123@example.com",
                      CreatedOn=new DateTime(2025,04,14),
                      IsSubscriptionExpired = false,
                      SubscriptionType = SubscriptionTypeEnum.Yearly
                    },
                    
                    new User
                    { Id = 2,   
                      FirstName = "Bob",
                      LastName = "Bobski",
                      Age = 36,
                      CardNumber = 2222333355556666,
                      Email = "bobbobski@example.com",
                      CreatedOn = new DateTime(2025, 01, 01),
                      IsSubscriptionExpired = false,
                      SubscriptionType = SubscriptionTypeEnum.Monthly
                    },

                    new User
                    {
                        Id = 3,
                        FirstName = "Petko",
                        LastName = "Petkovski",
                        Age = 19,
                        CardNumber = 5555666688881111,
                        Email = "petko5@example.com",                        
                        CreatedOn = new DateTime(2023, 12, 14),
                        IsSubscriptionExpired = true,
                        SubscriptionType = SubscriptionTypeEnum.Weekly
                    },
                    new User
                    {
                        Id = 4,
                        FirstName = "Ivana",
                        LastName = "Ivanovska",
                        Age = 39,
                        CardNumber = 555511114545000,
                        Email = "ivanaIv@example.com",
                        CreatedOn = new DateTime(2024, 09, 07),
                        IsSubscriptionExpired = false,
                        SubscriptionType = SubscriptionTypeEnum.Yearly

                    },
                    new User
                    {
                        Id = 5,
                        FirstName = "Jovana",
                        LastName = "Jovanovska",
                        Age = 23,
                        CardNumber = 1122334455667788,
                        Email = "jovana19@example.com",
                        CreatedOn = new DateTime(2023, 05, 03),
                        IsSubscriptionExpired = false,
                        SubscriptionType = SubscriptionTypeEnum.Weekly
                    }

              );

            modelBuilder.Entity<Movie>().HasData(
                    new Movie
                    {   Id = 1,
                        Title = "The Matrix",
                        Genre = GenreEnum.SciFi,
                        Language = LanguageEnum.English,
                        IsAvailable = true,
                        AgeRestriction = 16,
                        Duration = 2.16,
                        Quantity = 1,
                        ReleaseDate = new DateTime(1999, 3, 31) },
                        
                    new Movie
                    { Id = 2,
                        Title = "Inception",
                        Genre = GenreEnum.SciFi,
                        Language = LanguageEnum.English,
                        IsAvailable = true,
                        AgeRestriction = 18,
                        Duration = 2.28,
                        Quantity = 1,
                        ReleaseDate = new DateTime(2010, 7, 16) },
                    new Movie
                    {   Id = 3,
                        Title = "The Accountant",
                        Genre = GenreEnum.Action,
                        Language = LanguageEnum.English,
                        IsAvailable = true,
                        AgeRestriction = 16,
                        Duration = 2.8,
                        Quantity = 1,
                        ReleaseDate = new DateTime(2014, 11, 7) }
                );

            modelBuilder.Entity<Cast>().HasData(
                    new Cast
                    {
                        Id = 1,
                        Name = "Keanu Reeves",
                        MovieId = 1,                        
                        Part = PartEnum.Actor
                    },

                    new Cast
                    {
                        Id = 2,
                        Name = "Anne Moss",
                        MovieId = 1,
                        Part = PartEnum.Camera
                    },
                    new Cast
                    {
                        Id = 3,
                        Name = "Leonardo DiCaprio",
                        MovieId = 2,
                        Part = PartEnum.Actor
                    },
                    new Cast
                    {
                        Id = 4,
                        Name = "Matthew Brown",
                        MovieId = 3,
                        Part = PartEnum.Director
                    }
                    );

            modelBuilder.Entity<Rental>().HasData(
                    new Rental
                    {
                        Id = 1,
                        UserId = 1,   
                        MovieId = 1,   
                        RentedOn = new DateTime(2025, 7, 10),
                        ReturnedOn = null           
                    },
                    new Rental
                    {
                        Id = 2,
                        UserId = 1,   
                        MovieId = 2,   
                        RentedOn = new DateTime(2025, 7, 13),
                        ReturnedOn = null
                    },
                    new Rental
                    {
                        Id = 3,
                        UserId = 2,  
                        MovieId = 1,   
                        RentedOn = new DateTime(2025, 6, 25),
                        ReturnedOn = new DateTime(2025, 6, 30)
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
