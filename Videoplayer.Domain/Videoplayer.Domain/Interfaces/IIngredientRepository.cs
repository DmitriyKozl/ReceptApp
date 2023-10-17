using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces {
    public interface IIngredientRepository {
        public List<Ingredient> GetIngredients(string filter);
    }
}
