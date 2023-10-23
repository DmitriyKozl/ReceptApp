namespace VideoplayerProject.Domain.Models; 

public class RecipeUtensil {
    public int RecipeID { get; set; }
    public Recipe Recipe { get; set; }

    public int UtensilID { get; set; }
    public Utensils Utensils { get; set; }

    public TimeSpan BeginTime { get; set; }
    public TimeSpan EndTime { get; set; }
}