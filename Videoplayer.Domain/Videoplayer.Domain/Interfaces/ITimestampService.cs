using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces
{
    internal interface ITimestampService
    {
        public List<Utensil> GetAllTimestamp(string filter);
        public List<Utensil> GetTimestampFromRecipe(int recipeId);
        void CreateTimestamp(string name);
        public void UpdateTimestamp(int id, string newName);
        public void RemoveTimestamp(int id);
    }
}
