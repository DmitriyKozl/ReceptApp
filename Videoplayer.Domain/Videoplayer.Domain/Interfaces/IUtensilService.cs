using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces;

public interface IUtensilService {
    List<Utensil> GetAllUtensils();
    Utensil GetUtensilById(int id);
    List<Utensil> GetUtensilsFromRecipe(int recipeId);
    List<Utensil> GetFilteredUtensils(string filter);

    Utensil CreateUtensil(Utensil utensil);
    
    Utensil UpdateUtensil(Utensil utensil);
}