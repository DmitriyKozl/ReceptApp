using VideoplayerProject.Datalayer.Interfaces;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

    

namespace VideoplayerProject.Domain.Managers
{
    public class IngredientManager : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepo;

        public IngredientManager(IIngredientRepository ingredientRepo)
        {
            _ingredientRepo = ingredientRepo;
        }


        public void CreateIngredient(string name, string brand)
        {
            _ingredientRepo.CreateIngredient(name, brand);
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

        public void UpdateIngredient(int id, string newName, string newBrand)
        {
            _ingredientRepo.UpdateIngredient(id, newName, newBrand);
        }
        
    }

}