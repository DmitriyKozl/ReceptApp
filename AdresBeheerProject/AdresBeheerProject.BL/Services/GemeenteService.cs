using AdresBeheerProject.BL.Exceptions;
using AdresBeheerProject.BL.Interfaces;
using AdresBeheerProject.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresBeheerProject.BL.Services {
    public class GemeenteService {

        private IGemeenteRepo _repo;

        public Gemeente GeefGemeente(int gemeenteId) {
			try {
                return _repo.GeefGemeente(gemeenteId);
			} catch (Exception ex) {
                throw new GemeenteServiceException("GeefGemeente", ex);
			}
        }
    }
}
