using VideoplayerProject.Domain.Models;
using Ingredient = VideoplayerProject.Datalayer.Models.Ingredient;

namespace VideoplayerProject.Domain.Interfaces;
    public interface IIngredientRepository {
        public List<Ingredient> GetIngredients(string filter);
        public List<Ingredient> GetIngredientsFromRecipe(int recipeId);
        public void CreateIngredient(string name, string brand);
        
        // TO DO : add variables for updating ingredient
        public void UpdateIngredient(int id, string newName, string newBrand);
        public void RemoveIngredient(int id);
    }

