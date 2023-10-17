using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces {
    public interface IUtensilRepository {
        public List<Utensil> GetUtelsils(string filter);
    }
}
