using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Managers
{
    public class IngredientManager : IIngredientRepository
    {
        private IIngredientRepository _ingredientRepo;

        public IngredientManager(IIngredientRepository ingredientRepo) {
            _ingredientRepo = ingredientRepo;
        }

        public void AddIngredient(string name, string brand)
        {
            _ingredientRepo.AddIngredient(name, brand);
        }

        public List<Ingredient> GetIngredients(string filter) {
            return _ingredientRepo.GetIngredients(filter);
        }

        public List<Ingredient> GetIngredientsFromRecipe(int recipeId)
        {
            return _ingredientRepo.GetIngredientsFromRecipe(recipeId);
        }

        public void RemoveIngredient(int id)
        {
            _ingredientRepo.RemoveIngredient(id);
        }

        public void UpdateIngredient(int id, string newName)
        {
            _ingredientRepo.UpdateIngredient(id, newName);
        }
    }
}