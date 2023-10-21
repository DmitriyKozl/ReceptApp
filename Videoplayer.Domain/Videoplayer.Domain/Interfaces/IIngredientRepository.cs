using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces {
    public interface IIngredientRepository {
        public List<Ingredient> GetIngredients(string filter);
        public List<Ingredient> GetIngredientsFromRecipe(int recipeId);
        public void AddIngredient(string name, string brand);
        public void UpdateIngredient(int id, string newName);
        public void RemoveIngredient(int id);
    }
}
