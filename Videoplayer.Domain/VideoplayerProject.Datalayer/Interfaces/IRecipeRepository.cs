using VideoplayerProject.Domain.Models;
using Recipe = VideoplayerProject.Datalayer.Models.Recipe;

namespace VideoplayerProject.Datalayer.Interfaces {
    public interface IRecipeRepository {
        List<Recipe> GetAllRecipes(string filter);
        Recipe GetRecipeById(int id); 
        void CreateRecipe(Recipe recipe);
        void UpdateRecipe(int id, Recipe recipe); 
        void  RemoveRecipe(int id);
    }
}
