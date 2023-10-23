using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces {
    public interface IUtensilRepository {
        public List<Utensils> GetAllUtensils(string filter);
        public List<Utensils> GetUtensilsFromRecipe(int recipeId);
        public void  CreateUtensil(string name);
        public void UpdateUtensil(int id, string newName);
        public void RemoveUtensil(int id);
    }
}
