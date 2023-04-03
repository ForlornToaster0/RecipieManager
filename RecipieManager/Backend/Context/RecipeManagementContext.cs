using Microsoft.EntityFrameworkCore;
using RecipieManager.Backend.Models;

namespace RecipieManager.Backend.Context
{
    public class RecipeManagementContext : DbContext
    {
        public RecipeManagementContext(DbContextOptions<RecipeManagementContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserIngredient> UserIngredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RecipeDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<UserIngredient>()
        .HasKey(ui => new { ui.UserId, ui.IngredientId });
        }
    }
}
