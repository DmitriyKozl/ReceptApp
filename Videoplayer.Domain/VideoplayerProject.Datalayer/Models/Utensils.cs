using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoplayerProject.Datalayer.Models; 

public class Utensils {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UtensilID { get; set; }

    [Required]
    [MaxLength(255)]
    public string UtensilName { get; set; }

    public string ImgUrl { get; set; }

    public ICollection<RecipeUtensil> RecipeUtensils { get; set; }

}