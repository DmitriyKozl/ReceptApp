using VideoplayerProject.API.Exceptions;
using VideoplayerProject.API.Models.Output;
using VideoplayerProject.Datalayer.Models;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Managers;
using VideoplayerProject.Domain.Models;
using Ingredient = VideoplayerProject.Domain.Models.Ingredient;
using Recipe = VideoplayerProject.Domain.Models.Recipe;

namespace VideoplayerProject.API.Mappers;

public class MapFromDomain {
    public static RecipeOutputDTO MapFromRecipeDomain(string url, Recipe recipe) {
        if (recipe == null) throw new ArgumentNullException(nameof(recipe));
        string recipeURL = $"{url}/recipes/{recipe.Id}";
        var ingredients = recipe.IngredientToTimestamp
            .SelectMany(pair => pair.Value.Select(timestamp => new IngredientInRecipeOutputDTO
            { Id = pair.Key.Id,
              Name = pair.Key.Name,
              Img = pair.Key.Img,
              Brand = pair.Key.Brand,
              From = timestamp.StartTime,
              Till = timestamp.EndTime })).ToList();
        var utensils = recipe.UtensilToTimestamp
            .SelectMany(pair => pair.Value.Select(timestamp => new UtensilInRecipeOutputDTO
            { Id = pair.Key.Id,
              Name = pair.Key.Name,
              Img = pair.Key.ImgUrl,
              From = timestamp.StartTime,
              Till = timestamp.EndTime })).ToList();

        RecipeOutputDTO dto = new RecipeOutputDTO(
            recipe.Id,
            recipe.Name,
            recipe.Servings,
            recipe.VideoLink,
            recipe.CookingTime,
            ingredients,
            utensils
        );

        return dto;
    }

    public static IngredientOutputDTO MapFromIngredientDomain(string url, Ingredient ingredient) {
        if (ingredient == null) throw new ArgumentNullException(nameof(ingredient));

        string ingredientURL = $"{url}/ingredients/{ingredient.Id}";


        IngredientOutputDTO dto = new IngredientOutputDTO
        (
            ingredient.Id,
            ingredient.Name,
            ingredient.Img,
            ingredient.Brand,
            ingredient.Price
        );

        return dto;
    }
    
    public static UtensilsOutputDTO MapFromUtensilsDomain(string url, Utensil utensils) {
        if (utensils == null) throw new ArgumentNullException(nameof(utensils));

        string utensilsURL = $"{url}/ingredients/{utensils.Id}";


        UtensilsOutputDTO dto = new UtensilsOutputDTO
        (
            utensils.Id,
            utensils.Name,
            utensils.ImgUrl
        );

        return dto;
    }
    
}