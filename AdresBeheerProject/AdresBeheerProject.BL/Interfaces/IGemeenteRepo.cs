using AdresBeheerProject.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresBeheerProject.BL.Interfaces {
    public interface IGemeenteRepo {
        Gemeente GeefGemeente(int gemeenteId);
    }
}
