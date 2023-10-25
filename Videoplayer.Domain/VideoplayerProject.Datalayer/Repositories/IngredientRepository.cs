using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Interfaces;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;
using Ingredient = VideoplayerProject.Datalayer.Models.Ingredient;

namespace VideoplayerProject.Datalayer.Repositories;

public class IngredientRepository : IIngredientRepository {
    private readonly RecipeDbContext _context;

    public IngredientRepository(RecipeDbContext context) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Ingredient> GetIngredients(string filter) {
        return string.IsNullOrEmpty(filter)
            ? _context.Ingredients.ToList()
            : _context.Ingredients.Where(i => i.IngredientName.Contains(filter)).ToList();
    }

    public List<Ingredient> GetIngredientsFromRecipe(int recipeId) {
        return _context.RecipeIngredient.Where(ri => ri.RecipeID == recipeId).Select(ri => ri.Ingredient).ToList();
    }
    
    

    public void CreateIngredient(string name, string brand) {
        var ingredient = new Ingredient
        { IngredientName = name, Brand = brand };
        _context.Ingredients.Add(ingredient);
        _context.SaveChanges();
    }

    public void UpdateIngredient(int id, string newName, string newBrand) {
        var ingredient = _context.Ingredients.Find(id);
        if (ingredient == null) return;

        ingredient.IngredientName = newName;
        ingredient.Brand = newBrand;
        _context.SaveChanges();
    }

    public void RemoveIngredient(int id) {
        var ingredient = _context.Ingredients.Find(id);
        if (ingredient == null) return;

        _context.Ingredients.Remove(ingredient);
        _context.SaveChanges();
    }
}