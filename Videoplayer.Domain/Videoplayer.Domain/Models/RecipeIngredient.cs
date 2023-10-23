namespace VideoplayerProject.Domain.Models; 

public class RecipeIngredient {
    
    public int RecipeID { get; set; }
    public Recipe Recipe { get; set; }

    public int IngredientID { get; set; }
    public Ingredient Ingredient { get; set; }

    public TimeSpan BeginTime { get; set; }
    public TimeSpan EndTime { get; set; }
}