using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionMVCApp.Models
{
    public class MovieInfoContext : DbContext
    {
        public MovieInfoContext (DbContextOptions<MovieInfoContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<AddMovieSubmission> responses { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
              mb.Entity<Category>().HasData(
                  new Category {  CategoryID=1, CategoryName = "Action/Adventure"},
                  new Category { CategoryID = 2, CategoryName = "Comedy" },
                  new Category { CategoryID = 3, CategoryName = "Drama" },
                  new Category { CategoryID = 4, CategoryName = "Family" },
                  new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                  new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                  new Category { CategoryID = 7, CategoryName = "Television" },
                  new Category { CategoryID = 8, CategoryName = "VHS" }
                  );
            _ = mb.Entity<AddMovieSubmission>().HasData(

                new AddMovieSubmission
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Brave",
                    Year = 2012,
                    Director = "Brenda Chapman and Mark Andrews",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                },
                new AddMovieSubmission
                {
                    MovieID = 2,
                    CategoryID = 1,
                    Title = "Tangled",
                    Year = 2010,
                    Director = "Nathan Greno and Byron Howard",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                },
                new AddMovieSubmission
                {
                    MovieID = 3,
                    CategoryID = 2,
                    Title = "Stick It",
                    Year = 2006,
                    Director = "Jessica Bendinger",
                    Rating = "PG13",
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                }
                );
        }
    }
}
