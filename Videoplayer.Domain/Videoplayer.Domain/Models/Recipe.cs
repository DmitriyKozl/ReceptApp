using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Recipe {
        [Key] public int? RecipeID { get; set; }

        [Required] public string RecipeName { get; set; }

        public int Servings { get; set; }

        public string VideoLink { get; set; }

        public TimeSpan CookingTime { get; set; }


        // Navigation properties
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        public ICollection<RecipeUtensil> RecipeUtensils { get; set; } = new List<RecipeUtensil>();

        // Add ingredient with a timestamp to recipe
        public void AddIngredientWithTimeStamp(Ingredient ingredient, TimeSpan startTime, TimeSpan endTime) {
            var recipeIngredient = new RecipeIngredient
            { Recipe = this,
              Ingredient = ingredient,
              BeginTime = startTime,
              EndTime = endTime };
            RecipeIngredients.Add(recipeIngredient);
        }

        // Remove ingredient from recipe
        public void RemoveIngredient(Ingredient ingredient) {
            var recipeIngredient = RecipeIngredients.FirstOrDefault(ri => ri.Ingredient == ingredient);
            if (recipeIngredient != null) {
                RecipeIngredients.Remove(recipeIngredient);
            }
            else {
                throw new InvalidOperationException("Recipe doesn't contain the given ingredient.");
            }
        }

        // Add utensils with a timestamp to recipe
        public void AddUtensilWithTimeStamp(Utensils utensils, TimeSpan startTime, TimeSpan endTime) {
            var recipeUtensil = new RecipeUtensil
            { Recipe = this,
              Utensils = utensils,
              BeginTime = startTime,
              EndTime = endTime };
            RecipeUtensils.Add(recipeUtensil);
        }

        // Remove utensils from recipe
        public void RemoveUtensil(Utensils utensils) {
            var recipeUtensil = RecipeUtensils.FirstOrDefault(ru => ru.Utensils == utensils);
            if (recipeUtensil != null) {
                RecipeUtensils.Remove(recipeUtensil);
            }
            else {
                throw new InvalidOperationException("Recipe doesn't contain the given utensils.");
            }
        }
    }
}