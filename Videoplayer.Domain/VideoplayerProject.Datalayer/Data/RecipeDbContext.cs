using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VideoplayerProject.Datalayer.Models;
using Ingredient = VideoplayerProject.Datalayer.Models.Ingredient;
using Recipe = VideoplayerProject.Datalayer.Models.Recipe;

namespace VideoplayerProject.Datalayer.Data;

public class RecipeDbContext : DbContext {
    public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
        : base(options) { }

    
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Utensils> Utensils { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
    public DbSet<RecipeUtensil> RecipeUtensils { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Recipe>()
            .Property(r => r.RecipeID)
            .ValueGeneratedOnAdd(); 
        modelBuilder.Entity<RecipeIngredient>()
            .HasKey(ri => new { ri.RecipeID, ri.IngredientID, ri.BeginTime });

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients)
            .HasForeignKey(ri => ri.RecipeID);

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients)
            .HasForeignKey(ri => ri.IngredientID);

        // RecipeUtensil configuration
        modelBuilder.Entity<RecipeUtensil>()
            .HasKey(ru => new { ru.RecipeID, ru.UtensilID, ru.BeginTime });

        modelBuilder.Entity<RecipeUtensil>()
            .HasOne(ru => ru.Recipe)
            .WithMany(r => r.RecipeUtensils)
            .HasForeignKey(ru => ru.RecipeID);

        modelBuilder.Entity<RecipeUtensil>()
            .HasOne(ru => ru.Utensil)
            .WithMany(u => u.RecipeUtensils)
            .HasForeignKey(ru => ru.UtensilID);
    }
}