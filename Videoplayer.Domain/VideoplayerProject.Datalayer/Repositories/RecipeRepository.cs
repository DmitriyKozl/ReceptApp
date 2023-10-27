using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Interfaces;
using VideoplayerProject.Domain.Models;
using Recipe = VideoplayerProject.Datalayer.Models.Recipe;

namespace VideoplayerProject.Datalayer.Repositories; 

public class RecipeRepository : IRecipeRepository {
    private readonly RecipeDbContext _context;

    public RecipeRepository(RecipeDbContext context) {
        // If context is null, it throws an ArgumentNullException
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Recipe> GetAllRecipes(string filter) {
        
       // condition to check: string.IsNullOrEmpty(filter).
        return string.IsNullOrEmpty(filter)
        //if true, return all recipes
            ? _context.Recipes.ToList()
        // if false, return recipes that contain the filter
            : _context.Recipes.Where(r => r.RecipeName.Contains(filter)).ToList();
    }

    public Recipe GetRecipeById(int id) {
        var recipe = _context.Recipes.Find(id);

        if (recipe == null)
        {
            return null;
        }

        return recipe;    }


    public void RemoveRecipe(int id) {
        // Find the recipe by ID
        var recipe = _context.Recipes.Find(id);

        if (recipe == null) {
   
            Console.WriteLine("Recipe not found");
            return;
        }

        // Remove the recipe
        _context.Recipes.Remove(recipe);
        _context.SaveChanges();
    }

    public void CreateRecipe(Recipe recipe) {
        if (recipe == null) throw new ArgumentNullException(nameof(recipe));

        _context.Recipes.Add(recipe);
        _context.SaveChanges();
    }

    public void UpdateRecipe(int id, Recipe updatedRecipe) {
        var recipe = _context.Recipes.Find(id);
        if (recipe == null) {
            Console.WriteLine("Recipe not found");
            return;
        }

        recipe.RecipeName = updatedRecipe.RecipeName;
    
        _context.SaveChanges();
    }
}