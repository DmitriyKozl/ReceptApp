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

        public List<Ingredient> GetIngredients(string filter) {
            return _ingredientRepo.GetIngredients(filter);
        }
    }
}