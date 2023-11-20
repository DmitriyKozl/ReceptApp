using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 

public interface IUtensilsRepository {
    public List<Utensil> GetUtensils(string? filter = null);
    public Utensil GetUtensilById(int id);
    public List<Utensil> GetUtensilsFromRecipe(int recipeId);
    void CreateUtensil(Utensil utensil);
     void UpdateUtensil(Utensil utensil);
    
}