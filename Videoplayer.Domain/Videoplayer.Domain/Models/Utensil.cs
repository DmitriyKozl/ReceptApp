using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Utensil {

        public Utensil( string name, string imgUrl, int id) {
            Name = name;
            ImgUrl = imgUrl;
            Id = id;
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

        private string? _imgUrl;
        
        public string? ImgUrl {
            get { return _imgUrl; }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    _imgUrl = value;
                } else {
                    throw new UtensilException("Please enter an Utensil image URL");
                }
            }
        }
        public override string ToString()
        {
            return $" Name: {Name}, Image URL: {ImgUrl}";
        }
    }
}