namespace VideoplayerProject.API.Models;

public class IngredientInputDTO {
    public string Name { get; set; }
    public string Brand { get; set; }
    public TimeSpan From { get; set; }
    public TimeSpan Till { get; set; }
}