using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 

public interface IUtensilService {
    public List<Utensil> GetAllUtensils(string filter);
    public List<Utensil> GetUtensilsFromRecipe(int recipeId);
    void CreateUtensil(string name);
    public void UpdateUtensil(int id, string newName);
    public void RemoveUtensil(int id);
}