using VideoplayerProject.Datalayer.Models;
using Ingredient = VideoplayerProject.Domain.Models.Ingredient;

namespace VideoplayerProject.API.Models.Output;

public class RecipeOutputDTO {
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Servings { get; set; }
    public string VideoLink { get; set; }
    public TimeSpan CookingTime { get; set; }
    public List<IngredientInRecipeOutputDTO> Ingredients { get; set; }
    public List<UtensilInRecipeOutputDTO> Utensils { get; set; }
    
    public RecipeOutputDTO(int id, string name, int? servings, string videoLink, TimeSpan cookingTime, List<IngredientInRecipeOutputDTO> ingredients, List<UtensilInRecipeOutputDTO> utensils) {
        Id = id;
        Name = name;
        Servings = servings;
        VideoLink = videoLink;
        CookingTime = cookingTime;
        Ingredients = ingredients;
        Utensils = utensils;
    }
}