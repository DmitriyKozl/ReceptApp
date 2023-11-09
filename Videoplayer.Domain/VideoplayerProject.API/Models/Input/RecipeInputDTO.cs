namespace VideoplayerProject.API.Models; 

public class RecipeInputDTO {
    public string Name { get; set; }
    public string Img { get; set; }
    public string VideoLink { get; set; }
    public int? Servings { get; set; }
    public TimeSpan CookingTime { get; set; }
}