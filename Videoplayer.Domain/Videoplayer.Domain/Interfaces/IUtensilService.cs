using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces;

public interface IUtensilService {
    Utensil GetUtensilById(int id);
    List<Utensil> GetUtensilsFromRecipe(int recipeId);
    List<Utensil> GetUtensils(string? filter = null);

    Utensil CreateUtensil(Utensil utensil);
    
    Utensil UpdateUtensil(Utensil utensil);
}