using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Managers {
    public class RecipeManager : IRecipeRepository {
        private IRecipeRepository _recipeRepo;

        public RecipeManager(IRecipeRepository recipeRepo) {
            _recipeRepo = recipeRepo;
        }

        public void AddRecipe(Recipe recipe) {
            _recipeRepo.AddRecipe(recipe);
        }

        public void DeleteRecipe(Recipe recipe) {
            _recipeRepo.DeleteRecipe(recipe);
        }

        public List<Recipe> GetAllRecipes(string filter) {
            return _recipeRepo.GetAllRecipes(filter);
        }
    }
}
