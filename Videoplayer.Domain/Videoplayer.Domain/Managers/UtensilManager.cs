using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Managers {
    public class UtensilManager : IUtensilService {
        private IUtensilsRepository  _utensilRepository;
        public UtensilManager(IUtensilsRepository repo) 
        {
            _utensilRepository = repo;
        }



        public List<Utensil> GetAllUtensils()
        {
            return _utensilRepository.GetAllUtensils();
        }
        public List<Utensil> GetUtensilsFromRecipe(int recipeId)
        {
            return _utensilRepository.GetUtensilsFromRecipe(recipeId);
        }
        
        public Utensil GetUtensilById(int id)
        {
            return _utensilRepository.GetUtensilById(id);
        }
        
        public List<Utensil> GetFilteredUtensils(string filter)
        {
            return _utensilRepository.GetFilteredUtensils(filter);
        }
        
        public Utensil CreateUtensil(Utensil utensil)
        {
            _utensilRepository.CreateUtensil(utensil);
            return utensil;
        }
        
        public void RemoveUtensil(int id)
        {
            _utensilRepository.RemoveUtensil(id);
        }
        
        public Utensil UpdateUtensil(Utensil utensil)
        {
            _utensilRepository.UpdateUtensil(utensil);
            return utensil;
        }



    }
}