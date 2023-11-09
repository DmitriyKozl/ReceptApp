using VideoplayerProject.API.Exceptions;
using VideoplayerProject.API.Models;
using VideoplayerProject.API.Models.Output;
using VideoplayerProject.Domain.Models;

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
  
}