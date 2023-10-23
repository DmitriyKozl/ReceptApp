using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Datalayer.Interfaces;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Managers;
    public class RecipeManager : IRecipeService {
        private IRecipeRepository _recipeRepository;

        public RecipeManager(IRecipeRepository recipeRepository) {
            _recipeRepository = recipeRepository;
        }

        public List<Recipe> GetAllRecipes(string filter) {
            return _recipeRepository.GetAllRecipes(filter);
        }

        public Recipe GetRecipeById(int id) {
            return _recipeRepository.GetRecipeById(id);
        }


        public void CreateRecipe(Recipe recipe) {
            _recipeRepository.CreateRecipe(recipe);
        }

        public void UpdateRecipe(int id, Recipe recipe) {
            _recipeRepository.UpdateRecipe(id, recipe);
        }
        
        public void  RemoveRecipe(int id) {
            _recipeRepository.RemoveRecipe(id);
        }
    }
