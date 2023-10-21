﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Ingredient {

        public Ingredient(int id, string name, decimal price, string brand) {
            Id = id;
            Name = name;
            Price = price;
            Brand = brand;
        }
        public int Id { get; set; }

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

        private Decimal _price;

        public Decimal Price {
            get { return _price; }
            set { if (value > 0) {
                    _price = value;
                } else {
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
                } else {
                    throw new IngredientException("Please enter a brand name");
                }
            }
        }
    }
}
