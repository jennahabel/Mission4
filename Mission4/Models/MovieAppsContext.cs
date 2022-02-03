using System;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
 
    public class MovieAppsContext : DbContext
    {
        public MovieAppsContext(DbContextOptions<MovieAppsContext> options) : base (options)
        {

        }

        public DbSet<AppResponse> movies { get; set; }
        public DbSet<Categories> categories { get; set; }

        // Seed the database with 3 movies

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Categories>().HasData(
                new Categories {CategoryId = 1, CategoryName = "Action/Adventure"},
                new Categories { CategoryId = 2, CategoryName = "Comedy" },
                new Categories { CategoryId = 3, CategoryName = "Drama" },
                new Categories { CategoryId = 4, CategoryName = "Family" },
                new Categories { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Categories { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Categories { CategoryId = 7, CategoryName = "Television" },
                new Categories { CategoryId = 8, CategoryName = "VHS" }

                );

            mb.Entity<AppResponse>().HasData(

                new AppResponse
                {
                    MovieId = 1,
                    CategoryId = 1, 
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
                     CategoryId = 7, 
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
                      CategoryId = 2, 
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

