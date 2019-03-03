using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorScriptureApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorScriptureAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorScriptureAppContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Nephi",
                        Chapter = 2,
                        Verse = 15,
                        Note= "Sunday school",
                        Date = DateTime.Parse("1998-3-5"),
                       
                    },

                     new Scripture
                     {
                         Book = "Lehi",
                         Chapter = 7,
                         Verse = 10,
                         Note = "Good",
                         Date = DateTime.Parse("1989-2-12"),

                     },

                     new Scripture
                     {
                         Book = "Jacob",
                         Chapter = 1,
                         Verse = 19,
                         Note = "Something",
                         Date = DateTime.Parse("2001-5-19"),

                     }

                   
                );
                context.SaveChanges();
            }
        }
    }
}