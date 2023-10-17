using AdresBeheerProject.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresBeheerProject.BL.Models {
    public class Gemeente {

        public Gemeente(int nIScode, string gemeenteNaam) {
            SetNIScode(nIScode);
            SetGemeenteNaam(gemeenteNaam);
        }

        public int NIScode { get; private set; }

        public string GemeenteNaam { get; private set; }

        public void SetGemeenteNaam(string naam) {
            if((string.IsNullOrWhiteSpace(naam)) || !char.IsUpper(naam[0])) {
                GemeenteException ex = new("Naam niet correct");
                ex.Data.Add("Gemeentenaam", naam);
                throw ex;
            }
        }

        public void SetNIScode(int code) {
            if(code < 10000 || code > 99999) {
                GemeenteException ex = new("Code niet correct");
                ex.Data.Add("NIScode", code);
                throw ex;
            }
        }        
    }
}
