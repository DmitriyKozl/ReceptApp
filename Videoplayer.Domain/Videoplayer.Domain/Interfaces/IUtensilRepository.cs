using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces {
    public interface IUtensilRepository {
        public List<Utensil> GetAllUtensils(string filter);
        public List<Utensil> GetUtensilsFromRecipe(int recipeId);
        public void AddUtensil(int id, string name);
        public void UpdateUtensil(int id, string newName);
        public void RemoveUtensil(int id);
    }
}
