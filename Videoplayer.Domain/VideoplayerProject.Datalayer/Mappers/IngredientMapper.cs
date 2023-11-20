using VideoplayerProject.Domain.Models;
using DatalayerIngredient = VideoplayerProject.Datalayer.Models.Ingredient;

namespace VideoplayerProject.Datalayer.Mappers;

public class IngredientMapper {
    public static Ingredient MapToDomainModel(Datalayer.Models.Ingredient dataIngredient) {
        return new Ingredient(
            dataIngredient.IngredientID,
            dataIngredient.IngredientName,
            dataIngredient.Price,
            dataIngredient.Brand,
            dataIngredient.ImageThumbnail
            ); 
    }

    public static Datalayer.Models.Ingredient MapToDataModel(Ingredient domainIngredient) {
        return new Datalayer.Models.Ingredient
        { IngredientID = domainIngredient.Id,
          IngredientName = domainIngredient.Name,
          Price = domainIngredient.Price,
          Brand = domainIngredient.Brand,
          ImageThumbnail = domainIngredient.Img };
    }
}