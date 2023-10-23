using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 
public interface IIngredientService {
    public List<Ingredient> GetIngredients(string filter);
    public List<Ingredient> GetIngredientsFromRecipe(int recipeId);
    public void CreateIngredient(string name, string brand);
    public void UpdateIngredient(int id, string newName, string newBrand);
    public void RemoveIngredient(int id);
}