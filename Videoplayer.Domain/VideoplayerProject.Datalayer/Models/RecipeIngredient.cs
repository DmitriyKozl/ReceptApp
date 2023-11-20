using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Datalayer.Models; 

public class RecipeIngredient {
    
    [Key, Column(Order = 0)]
    public int RecipeID { get; set; }

    [Key, Column(Order = 1)]
    public int IngredientID { get; set; }

    [Key, Column(Order = 2)]
    public TimeSpan BeginTime { get; set; }

    public TimeSpan EndTime { get; set; }

    [ForeignKey("RecipeID")]
    public Recipe Recipe { get; set; }

    [ForeignKey("IngredientID")]
    public Ingredient Ingredient { get; set; }
}