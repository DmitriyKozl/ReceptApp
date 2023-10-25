using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoplayerProject.Datalayer.Models; 

public class Ingredient {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IngredientID { get; set; }

    [Required]
    [MaxLength(255)]
    public string IngredientName { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [MaxLength(255)]
    public string Brand { get; set; }

    public string ImageThumbnail { get; set; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
}