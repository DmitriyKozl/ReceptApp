using VideoplayerProject.Datalayer.Models;

namespace VideoplayerProject.Datalayer.Mappers; 

public class RecipeUtensilMapper {
    public static RecipeUtensil MapToDomainModel(Datalayer.Models.RecipeUtensil dataRecipeUtensil)
    {
        return new RecipeUtensil
        {
        RecipeID = dataRecipeUtensil.RecipeID,
        UtensilID = dataRecipeUtensil.UtensilID,
        BeginTime = dataRecipeUtensil.BeginTime,
        EndTime = dataRecipeUtensil.EndTime
        };
    }

    public static Datalayer.Models.RecipeUtensil MapToDataEntity(RecipeUtensil domainRecipeUtensil)
    {
        return new Datalayer.Models.RecipeUtensil
        {
        RecipeID = domainRecipeUtensil.RecipeID,
        UtensilID = domainRecipeUtensil.UtensilID,
        BeginTime = domainRecipeUtensil.BeginTime,
        EndTime = domainRecipeUtensil.EndTime
        };
    }
}