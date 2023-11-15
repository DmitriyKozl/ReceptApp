using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 
public interface IIngredientService {
    public List<Ingredient> GetIngredients(string filter);
    public Ingredient GetIngredientById(int id);
    public List<Ingredient> GetIngredientsFromRecipe(int recipeId);
    
    public Ingredient CreateIngredient(Ingredient ingredient);
    
    public void RemoveIngredient(int id);

    public void UpdateIngredient(Ingredient ingredient);

}