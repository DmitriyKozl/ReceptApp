using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces {
    public interface IRecipeRepository {
        public List<Recipe> GetAllRecipes(string filter);
        public void DeleteRecipe(Recipe recipe);
        public void AddRecipe(Recipe recipe);
    }
}
