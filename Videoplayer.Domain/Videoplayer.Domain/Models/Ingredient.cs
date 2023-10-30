using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Ingredient {
        public Ingredient(string name, decimal? price, string brand, string img) {
            Name = name;
            Price = price;
            Brand = brand;
            Img = img;
        }


        private int _id;

        public int Id {
            get { return _id; }
            set {
                if (value > 0) {
                    _id = value;
                }
                else {
                    throw new IngredientException("Invalid ID!");
                }
            }
        }

        private string _name;

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

        private Decimal? _price;

        public Decimal? Price {
            get { return _price; }
            set {
                if (value >= 0) {
                    _price = value;
                }
                else {
                    throw new IngredientException("Price must be bigger than 0.");
                }
            }
        }

        private string _brand;


        public string? Brand {
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

        private string _img;

        public string Img {
            get { return _img; }
            set { _img = value; }
        }

        public override bool Equals(object obj) {
            return obj is Ingredient ingredient &&
                   Id == ingredient.Id;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id);
        }

        public override string ToString() {
            return $"Name: {Name}, Price: {Price}, Brand: {Brand}, Image: {Img}";
        }
    }
}