using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Ingredient {

        public Ingredient(string name, string brand) {
            Name = name;
            Brand = brand;
        }

        private string _name;

        public string Name {
            get { return _name; }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    _name = value;
                } else {
                    throw new IngredientException("Please enter an ingredient name");
                }
            }
        }

        private string _brand;        

        public string? Brand {
            get { return _brand; }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    _brand = value;
                } else {
                    throw new IngredientException("Please enter a brand name");
                }
            }
        }
    }
}
