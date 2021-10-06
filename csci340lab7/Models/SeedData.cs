using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using csci340lab7.Data;
using System;
using System.Linq;

namespace csci340lab7.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new csci340lab7Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<csci340lab7Context>>()))
            {
                // Look for any movies.
                if (context.Cat.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cat.AddRange(
                    new Cat
                    {
                        Name = "Teddie",
                        BirthDate = DateTime.Parse("2006-7-2"),
                        Breed = "Domestic Short Hair",
                        FurPattern = "Tabby"
                    },

                    new Cat
                    {
                        Name = "Peaches",
                        BirthDate = DateTime.Parse("2007-4-23"),
                        Breed = "Ragdoll",
                        FurPattern = "Calico"
                    },

                    new Cat
                    {
                        Name = "Creme Puff",
                        BirthDate = DateTime.Parse("1967-8-3"),
                        Breed = "Domestic Short Hair",
                        FurPattern = "Tabby"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
