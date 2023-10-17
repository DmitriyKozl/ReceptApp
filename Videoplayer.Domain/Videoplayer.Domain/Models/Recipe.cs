using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Recipe {
        public Recipe(string name, string videoLink) {
            _name = name;
            _videoLink = videoLink;
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

        public Dictionary<Ingredient, List<Timestamp>> IngredientToTimestamp = new();
        public Dictionary<Utensil, List<Timestamp>> UtensilToTimestamp = new();

        // Add ingredient with a timestamp to recipe
        public void AddIngredientWithTimeStampToRecipe(Ingredient ingredient, string beginTime, string endTime) {
            List<Timestamp> timestamps = new List<Timestamp>();
            Timestamp timestamp = new(beginTime, endTime);
            timestamps.Add(timestamp);

            // Additional check to ensure that only one ingredient popup can be shown in a second
            IngredientToTimestamp.Add(ingredient, timestamps);
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
        public void RemoveTimestamp(Ingredient ingredient, Timestamp timestamp) {
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
        public void UpdateTimestamp(Ingredient ingredient, Timestamp oldTimestamp, Timestamp newTimestamp) {
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
        public void AddUtensilWithTimeStampToRecipe(Utensil utensil, string beginTime, string endTime) {
            List<Timestamp> timestamps = new List<Timestamp>();
            Timestamp timestamp = new(beginTime, endTime);
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
        public void RemoveUtensil(Utensil utensil, Timestamp timestamp) {
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
        public void UpdateUtensil(Utensil utensil, Timestamp oldTimestamp, Timestamp newTimestamp) {
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
    }
}
