using CookingRecipeLog.Models;
using Microsoft.EntityFrameworkCore;

namespace CookingRecipeLog.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                Database=CookingRecipeLogDb;
                Trusted_Connection=True;
                TrustServerCertificate=True;");
        }
    }
}