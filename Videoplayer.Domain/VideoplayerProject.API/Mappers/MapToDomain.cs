using System.Security.Cryptography;
using VideoplayerProject.API.Exceptions;
using VideoplayerProject.API.Models;
using VideoplayerProject.API.Models.Output;
using VideoplayerProject.Datalayer.Models;
using VideoplayerProject.Domain.Models;
using Ingredient = VideoplayerProject.Domain.Models.Ingredient;
using Recipe = VideoplayerProject.Domain.Models.Recipe;

namespace VideoplayerProject.API.Mappers;

public class MapToDomain {
    public static Recipe MapToRecipeDomain(RecipeInputDTO recipe) {
        try {
            return new Recipe(
                recipe.Name,
                recipe.Servings,
                recipe.VideoLink,
                recipe.CookingTime
            );
        }
        catch (Exception e) {
            throw new MapException("Error while mapping RecipeInputDTO to Recipe.", e);
        }
    }
    public static Ingredient MapToIngredientDomain(IngredientInputDTO ingredient) {
        try {
            return new Ingredient(
                ingredient.IngredientId,
                ingredient.Name,
                ingredient.Price,
                ingredient.Brand,
                ingredient.Img
                
            );
        }
        catch (Exception e) {
            throw new MapException("Error while mapping IngredientInputDTO to Ingredient.", e);
        }
    }
  
    public static Utensil MapToUtensilDomain(UtensilInputDTO utensil) {
        try {
            return new Utensil(
                utensil.Id,
                utensil.Name,
                utensil.Img
            );
        }
        catch (Exception e) {
            throw new MapException("Error while mapping UtensilInputDTO to Utensil.", e);
        }
    }

    public static Users MapToDataUsers(UserOutputDTO users)
    {
        try
        {
            return new Users
            {
                Password = users.Password,
                Username = users.Username
            };
        }
        catch (Exception e)
        {
            throw new MapException("Error while mapping UserOutputDTO to Users");
        }
    }
}