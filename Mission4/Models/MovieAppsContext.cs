using System;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
 
    public class MovieAppsContext : DbContext
    {
        public MovieAppsContext(DbContextOptions<MovieAppsContext> options) : base (options)
        {

        }

        public DbSet<AppResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<AppResponse>().HasData(

                new AppResponse
                {
                    MovieId = 1,
                    Category = "Action",
                    Title = "Spider-Man: No Way Home",
                    Year = "2021",
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "",
                    Notes = "Best Movie"
                },

                 new AppResponse
                 {
                     MovieId = 2,
                     Category = "Television",
                     Title = "Ted Lasso",
                     Year = "2020",
                     Director = "Jason Sudeikis Bill, Lawrence Brendan, Hunt Joe Kelly",
                     Rating = "PG-13",
                     Edited = false,
                     Lent = "",
                     Notes = "Best TV Show"
                 },

                  new AppResponse
                  {
                      MovieId = 3,
                      Category = "Comedy",
                      Title = "A Knights Tale",
                      Year = "2001",
                      Director = "Brian Helgeland",
                      Rating = "PG-13",
                      Edited = false,
                      Lent = "",
                      Notes = "Classic"
                  }

                );
        }
    }
}

