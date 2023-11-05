namespace VideoplayerProject.API.Models.Output; 

public class IngredientInRecipeOutputDTO {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }
    public string Brand { get; set; }
    public TimeSpan From { get; set; }
    public TimeSpan Till { get; set; }
}