using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Managers {
    public class UtensilManager : IUtensilRepository {
        private IUtensilRepository _utensilRepository;
        public UtensilManager(IUtensilRepository repo) 
        {
            _utensilRepository = repo;
        }

        public void AddUtensil(int id, string name)
        {
            _utensilRepository.AddUtensil(id, name);
        }

        public List<Utensil> GetAllUtensils(string filter)
        {
            return _utensilRepository.GetAllUtensils(filter);
        }

        public List<Utensil> GetUtensilsFromRecipe(int recipeId)
        {
            return _utensilRepository.GetUtensilsFromRecipe(recipeId);
        }

        public void RemoveUtensil(int id)
        {
            _utensilRepository.RemoveUtensil(id);
        }

        public void UpdateUtensil(int id, string newName)
        {
            _utensilRepository.UpdateUtensil(id, newName);
        }
    }
}
