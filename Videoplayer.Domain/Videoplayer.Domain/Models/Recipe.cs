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
            set {
                if (value >= 0) {
                    _id = value;
                } else { throw new RecipeException("Invalid ID!"); }
            }
        }

        private string _name;

        public string Name {
            get { return _name; }
            set {
                if (!string.IsNullOrWhiteSpace(value)) {
                    _name = value;
                } else {
                    throw new RecipeException("Please enter a recipe name");
                }
            }
        }

        private int? _servings;

        public int? Servings {
            get { return _servings; }
            set {
                if (value > 0) {
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
                if (!string.IsNullOrWhiteSpace(value)) {
                    _videoLink = value;
                } else {
                    throw new RecipeException("Please enter a valid link");
                }
            }
        }

        private TimeSpan _cookingTime;

        public TimeSpan CookingTime {
            get { return _cookingTime; }
            set {
                if (value >= TimeSpan.Zero) {
                    _cookingTime = value;
                } else {
                    throw new RecipeException("Cooking time can't be negative.");
                }
            }
        }

        public Dictionary<Ingredient, List<Timestamp>> IngredientToTimestamp = new();
        public Dictionary<Utensil, List<Timestamp>> UtensilToTimestamp = new();

        // Add ingredient with a timestamp to recipe
        public void AddIngredientWithTimeStampToRecipe(Ingredient ingredient, Timestamp timestamp) {
            // First get all the startimes of the recipe that are equal to the startime of the timestamp
            var startimes = IngredientToTimestamp.Values.SelectMany(timestampList => timestampList)
                .Where(timestamp => timestamp.StartTime == timestamp.StartTime).ToList();

            // If there are no timestamps where the starttime is already used, add the ingredient with timestamp
            if (startimes.Count == 0) {
                // If the ingredient has already been used in the recipe, simply add the timestamp to the existing list
                if (IngredientToTimestamp.ContainsKey(ingredient)) {

                    //Simply add the timestamp to the existing list
                    IngredientToTimestamp[ingredient].Add(timestamp);
                }

                // If the ingredient wasn't already used, add it to the recipe along with the timestamp
                else {
                    List<Timestamp> timestamps = new List<Timestamp>();
                    timestamps.Add(timestamp);
                    IngredientToTimestamp.Add(ingredient, timestamps);
                }
            } else {
                throw new RecipeException("The given starttime is already in use. Please provide a different starttime");
            }
        }

        // Remove ingredient from recipe (and all its timestamps)
        public void RemoveIngredient(Ingredient ingredient) {
            if (IngredientToTimestamp.ContainsKey(ingredient)) {
                IngredientToTimestamp.Remove(ingredient);
            } else {
                throw new RecipeException("Recipe doesn't use the given ingredient");
            }
        }

        // Remove specific timestamp for an ingredient in a recipe
        public void RemoveTimestampForIngredient(Ingredient ingredient, Timestamp timestamp) {
            if (IngredientToTimestamp.ContainsKey(ingredient)) {
                if (IngredientToTimestamp[ingredient].Contains(timestamp)) {
                    IngredientToTimestamp[ingredient].Remove(timestamp);
                } else {
                    throw new RecipeException("No timestamp was found that corresponds with the given ingredient and time.");
                }
            } else {
                throw new RecipeException("The recipe doesn't use the given ingredient");
            }
        }

        // Change the timestamp of an ingredient in a recipe
        public void UpdateIngredientTimestamp(Ingredient ingredient, Timestamp oldTimestamp, Timestamp newTimestamp) {
            if (IngredientToTimestamp.ContainsKey(ingredient)) {
                if (IngredientToTimestamp[ingredient].Contains(oldTimestamp)) {
                    IngredientToTimestamp[ingredient].Remove(oldTimestamp);
                    IngredientToTimestamp[ingredient].Add(newTimestamp);
                } else {
                    throw new RecipeException("No timestamp was found that corresponds with the given ingredient and time.");
                }
            } else {
                throw new RecipeException("The recipe doesn't use the given ingredient");
            }
        }

        // Add ingredient with a timestamp to recipe
        public void AddUtensilWithTimeStampToRecipe(Utensil utensil, Timestamp timestamp) {
            List<Timestamp> timestamps = new List<Timestamp>();
            timestamps.Add(timestamp);

            // Additional check to ensure that only one ingredient popup can be shown in a second
            UtensilToTimestamp.Add(utensil, timestamps);
        }

        // Remove ingredient from recipe (and all its timestamps)
        public void RemoveUtensil(Utensil utensil) {
            if (UtensilToTimestamp.ContainsKey(utensil)) {
                UtensilToTimestamp.Remove(utensil);
            } else {
                throw new RecipeException("Recipe doesn't use the given utensil");
            }
        }

        // Remove specific timestamp for an ingredient in a recipe
        public void RemoveTimestampForUtensil(Utensil utensil, Timestamp timestamp) {
            if (UtensilToTimestamp.ContainsKey(utensil)) {
                if (UtensilToTimestamp[utensil].Contains(timestamp)) {
                    UtensilToTimestamp[utensil].Remove(timestamp);
                } else {
                    throw new RecipeException("No timestamp was found that corresponds with the given utensil and time.");
                }
            } else {
                throw new RecipeException("The recipe doesn't use the given utensil");
            }
        }

        // Change the timestamp of an ingredient in a recipe
        public void UpdateUtensilTimestamp(Utensil utensil, Timestamp oldTimestamp, Timestamp newTimestamp) {
            if (UtensilToTimestamp.ContainsKey(utensil)) {
                if (UtensilToTimestamp[utensil].Contains(oldTimestamp)) {
                    UtensilToTimestamp[utensil].Remove(oldTimestamp);
                    UtensilToTimestamp[utensil].Add(newTimestamp);
                } else {
                    throw new RecipeException("No timestamp was found that corresponds with the given utensil and time.");
                }
            } else {
                throw new RecipeException("The recipe doesn't use the given utensil");
            }
        }

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