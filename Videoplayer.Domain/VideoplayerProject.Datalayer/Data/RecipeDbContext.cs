using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VideoplayerProject.Datalayer.Models;
using Ingredient = VideoplayerProject.Datalayer.Models.Ingredient;
using Recipe = VideoplayerProject.Datalayer.Models.Recipe;
using Utensils = VideoplayerProject.Datalayer.Models.Utensils;

namespace VideoplayerProject.Datalayer.Data;

public class RecipeDbContext : DbContext {
    public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
        : base(options) { }

    private string connectionstring =
        "Server=tcp:receptendb.database.windows.net,1433;Initial Catalog=receptdb;Persist Security Info=False;User ID=receptdblogin;Password=qLW7yJZHyNU4zJP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

    public DbSet<Ingredient>? Ingredients { get; set; }
    public DbSet<Recipe>? Recipes { get; set; }
    public DbSet<Utensils>? Utensils { get; set; }
    public DbSet<RecipeIngredient>? RecipeIngredient { get; set; }
    public DbSet<RecipeUtensil>? RecipeUtensils { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<RecipeIngredient>()
            .HasKey(ri => new
            { ri.RecipeID, ri.IngredientID, ri.BeginTime });

        // Define relationships
        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients) // Assuming the Recipe entity has a collection of RecipeIngredients
            .HasForeignKey(ri => ri.RecipeID);

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients) // Assuming the Ingredient entity has a collection of RecipeIngredients
            .HasForeignKey(ri => ri.IngredientID);

        // Utensil configuration
        modelBuilder.Entity<Utensils>()
            .HasKey(u => u.UtensilID);
        modelBuilder.Entity<RecipeUtensil>()
            .HasKey(ru => new
            { ru.RecipeID, ru.UtensilID });
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(
            connectionstring).LogTo(Console.WriteLine, LogLevel.Information);
    }
}