using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyRecipes.Models;


namespace MyRecipes.Data
{
    public class MyRecipesContext : DbContext
    {
      
        public MyRecipesContext(DbContextOptions Options)
            : base(Options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Recipe>().ToTable("Recipes");
		}
	}
}

