using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Ingredient {
        public Ingredient() { }

        public Ingredient(int id, string name, decimal price, string brand) {
            Id = id;
            Name = name;
            Price = price;
            Brand = brand;
        }

        [Key] 
        [Column("IngredientID")] // Data annotation for EF to enforce this field as NOT NULL 

        public int Id { get; private set; } // Make setter private to prevent changing the ID arbitrarily

        private string _name;

        [Required] // Data annotation for EF to enforce this field as NOT NULL
        [Column("IngredientName")] // Data annotation for EF to enforce this field as NOT NULL 
        public string Name {
            get { return _name; }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    _name = value;
                }
                else {
                    throw new IngredientException("Please enter an ingredient name");
                }
            }
        }

        private decimal _price;

        public decimal Price {
            get { return _price; }
            set {
                if (value > 0) {
                    _price = value;
                }
                else {
                    throw new IngredientException("Price must be bigger than 0.");
                }
            }
        }

        private string _brand;

        public string Brand // Removed the nullable operator as string is already nullable
        {
            get { return _brand; }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    _brand = value;
                }
                else {
                    throw new IngredientException("Please enter a brand name");
                }
            }
        }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    }
}