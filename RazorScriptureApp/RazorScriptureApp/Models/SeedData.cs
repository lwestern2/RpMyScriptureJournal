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
                        Book = "Nefi",
                        Chapter = 2,
                        Verse = 3,
                        Note= "Good",
                        Date = DateTime.Parse("1989-2-12"),
                       
                    },

                     new Scripture
                     {
                         Book = "Lehi",
                         Chapter = 2,
                         Verse = 3,
                         Note = "Good",
                         Date = DateTime.Parse("1989-2-12"),

                     },

                     new Scripture
                     {
                         Book = "Jacob",
                         Chapter = 2,
                         Verse = 3,
                         Note = "Good",
                         Date = DateTime.Parse("1989-2-12"),

                     }

                   
                );
                context.SaveChanges();
            }
        }
    }
}