using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 

public interface IIngredientRepository {
    public List<Ingredient> GetFilteredIngredients(string filter);
    public Ingredient GetIngredientById(int id);
    public List<Ingredient> GetAllIngredients();
    public List<Ingredient> GetIngredientsFromRecipe(int recipeId);
    
    void CreateIngredient(Ingredient ingredient);
    
    public void RemoveIngredient(int id);
    public void UpdateIngredient(Ingredient ingredient);
    
}