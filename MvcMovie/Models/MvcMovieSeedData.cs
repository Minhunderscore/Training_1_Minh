using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                // if (context.Movie.Any())
                // {
                //     return;   // DB has been seeded
                // }
                
                string[] titles= new string[]{};
                for (int i=0; i<=500; i++){
                    titles.Append(new string("Film #"+(char)i));
                };
                
                string[] genres= new string[]{
                    "Romantic Comedy", "Comedy", "Western", "Horror", "Eastern", "Adult"
                };

                Random gen = new Random();
                DateTime RandomDay(){
                    DateTime start = new DateTime(1995, 1, 1);
                    int range = (DateTime.Today - start).Days;           
                    return start.AddDays(gen.Next(range));
                };

                for (int i=0; i<=500; i++){
                    context.Movie.AddRange(
                        new Movie
                        {
                        Title = titles[i],
                        // ReleaseDate = RandomDay(),
                        // Genre = genres[i%6],
                        // Price = i,
                        // Rating = (char)i
                        }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}