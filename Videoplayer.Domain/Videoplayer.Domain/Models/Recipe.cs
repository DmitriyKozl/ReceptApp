using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Recipe {
        public Recipe(string name, int? servings, string videoLink, TimeSpan cookingTime) {
            Name = name;
            Servings = servings;
            VideoLink = videoLink;
            CookingTime = cookingTime;
            Id = 0;
        }

        private int _id;

        public int Id {
            get { return _id; }
            set { if (value >= 0) {
                    _id = value;                
                } else { throw new RecipeException("Invalid ID!"); }
            }
        }

        private string _name;

        public string Name {
            get { return _name; }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    _name = value;
                } else {
                    throw new RecipeException("Please enter a recipe name");
                }
            }
        }

        private int? _servings;

        public int? Servings {
            get { return _servings; }
            set { if (value > 0) {
                    _servings = value;    
                } else {
                    throw new RecipeException("Invalid ammount of servings");
                }
            }
        }

        private string _videoLink;

        public string VideoLink {
            get { return _videoLink; }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    _videoLink = value;
                } else {
                    throw new RecipeException("Please enter a recipe name");
                }
            }
        }

        private TimeSpan _cookingTime;

        public TimeSpan CookingTime  {
            get { return _cookingTime; }
            set {  if(value >= TimeSpan.Zero) {
                    _cookingTime = value;
                } else {
                    throw new RecipeException("Cooking time can't be negative.");
                }
            }
        }        

        public Dictionary<Ingredient, List<Timestamp>> IngredientToTimestamp = new();
        public Dictionary<Utensil, List<Timestamp>> UtensilToTimestamp = new();

        // Add ingredient with a timestamp to recipe
        
        public override string ToString() {
            var builder = new StringBuilder();

            builder.AppendLine($"Name: {Name}");
            builder.AppendLine($"Servings: {Servings}");
            builder.AppendLine($"Video Link: {VideoLink}");
            builder.AppendLine($"Cooking Time: {CookingTime}");

            builder.AppendLine("Ingredients:");
            foreach (var ingredientEntry in IngredientToTimestamp) {
                builder.AppendLine($"  Ingredient: {ingredientEntry.Key.Name}");
                foreach (var timestamp in ingredientEntry.Value) {
                    builder.AppendLine($"    Timestamp: {timestamp.StartTime} - {timestamp.EndTime}");
                }
            }

            builder.AppendLine("Utensils:");
            foreach (var utensilEntry in UtensilToTimestamp) {
                builder.AppendLine($"  Utensil: {utensilEntry.Key.Name}");
                foreach (var timestamp in utensilEntry.Value) {
                    builder.AppendLine($" Timestamp: {timestamp.StartTime} - {timestamp.EndTime}");
                }
            }

            return builder.ToString();
        }

    }
}