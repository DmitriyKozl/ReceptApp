using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Utensil {

        public Utensil(int id, string name) {
            Id = id;
            Name = name;
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else { throw new UtensilException("Invalid ID!"); }
            }
        }

        private string _name;

        public string Name {
            get { return _name; }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    _name = value;
                } else {
                    throw new UtensilException("Please enter an Utensil name");
                }

            }
        }
    }
}