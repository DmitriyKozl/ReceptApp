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

        
        public List<Ingredient> GetIngredients(string filter) {
            return _ingredientRepo.GetIngredients(filter);
        }

        public List<Ingredient> GetIngredientsFromRecipe(int recipeId)
        {
            return _ingredientRepo.GetIngredientsFromRecipe(recipeId);
        }
        
        public Ingredient GetIngredientById(int id)
        {
            return _ingredientRepo.GetIngredientById(id);
        }
        
        public Ingredient CreateIngredient(Ingredient ingredient)
        {
            _ingredientRepo.CreateIngredient(ingredient);
            return ingredient;
        }
        
        public void RemoveIngredient(int id)
        {
            _ingredientRepo.RemoveIngredient(id);
        }

        public Ingredient UpdateIngredient(Ingredient ingredient)
        {
           _ingredientRepo.UpdateIngredient(ingredient);
           return ingredient;
        }
    }

}