using VideoplayerProject.Datalayer.Models;

namespace VideoplayerProject.Datalayer.Mappers; 

public class RecipeIngredientMapper {
    public static RecipeIngredient MapToDomainModel(Datalayer.Models.RecipeIngredient dataRecipeIngredient)
    {
        return new RecipeIngredient
        {
        RecipeID = dataRecipeIngredient.RecipeID,
        IngredientID = dataRecipeIngredient.IngredientID,
        BeginTime = dataRecipeIngredient.BeginTime,
        EndTime = dataRecipeIngredient.EndTime
        };
    }

    public static Datalayer.Models.RecipeIngredient MapToDataEntity(RecipeIngredient domainRecipeIngredient)
    {
        return new Datalayer.Models.RecipeIngredient
        {
        RecipeID = domainRecipeIngredient.RecipeID,
        IngredientID = domainRecipeIngredient.IngredientID,
        BeginTime = domainRecipeIngredient.BeginTime,
        EndTime = domainRecipeIngredient.EndTime
        };
    }
}