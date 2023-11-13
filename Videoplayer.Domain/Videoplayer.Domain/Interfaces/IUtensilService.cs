using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 

public interface IUtensilService {
    public List<Utensil> GetAllUtensils();
    public Utensil GetUtensilById(int id);
    public List<Utensil> GetUtensilsFromRecipe(int recipeId);
    public List<Utensil> GetFilteredUtensils(string filter);
    
    public Utensil CreateUtensil(Utensil utensil);
    
    public void RemoveUtensil(int id);

}