using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Datalayer.Models; 

public class Recipe {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RecipeID { get; set; }

    [Required]
    [MaxLength(255)]
    public string RecipeName { get; set; }

    public int? Servings { get; set; }

    public string VideoLink { get; set; }

    [Required]
    public TimeSpan CookingTime { get; set; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    public ICollection<RecipeUtensil> RecipeUtensils { get; set; }
}