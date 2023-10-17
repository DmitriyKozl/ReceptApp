using AdresBeheerProject.BL.Services;
using AdresBeheerProject.REST.Model.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdresBeheerProject.REST.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AdresBeheerController : ControllerBase {

        private GemeenteService _gemeenteService;

        [HttpGet("{gemeenteId")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int GemeenteId) {
            
            try {

            } catch (Exception ex){
                return NotFound(ex.Message);
            }
        }
    }
}
