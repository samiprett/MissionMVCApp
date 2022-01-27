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
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<AddMovieSubmission>().HasData(

                new AddMovieSubmission
                {
                    MovieID = 1,
                    Category = "Family",
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
                    Category = "Family",
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
                    Category = "Comedy",
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
