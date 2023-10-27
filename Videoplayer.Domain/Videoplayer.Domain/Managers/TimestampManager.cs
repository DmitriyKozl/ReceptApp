using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Managers
{
    internal class TimestampManager : ITimestampService
    {
        private ITimestampService _timestampService;
        public TimestampManager(ITimestampService timestampService)
        {
            _timestampService = timestampService;
        }

        public void CreateTimestamp(string name)
        {
            _timestampService.CreateTimestamp(name);
        }

        public List<Utensil> GetAllTimestamp(string filter)
        {
            return _timestampService.GetAllTimestamp(filter);
        }

        public List<Utensil> GetTimestampFromRecipe(int recipeId)
        {
            return _timestampService.GetTimestampFromRecipe(recipeId);
        }

        public void RemoveTimestamp(int id)
        {
            _timestampService.RemoveTimestamp(id);
        }

        public void UpdateTimestamp(int id, string newName)
        {
            _timestampService.UpdateTimestamp(id, newName);
        }
    }
}
