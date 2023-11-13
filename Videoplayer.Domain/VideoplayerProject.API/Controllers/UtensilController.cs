using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoplayerProject.API.Mappers;
using VideoplayerProject.API.Models.Output;
using VideoplayerProject.Domain.Interfaces;

namespace VideoplayerProject.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UtensilController : ControllerBase {

        private readonly IUtensilService _utensilManager;

        public UtensilController(IUtensilService utensilManager) {
            _utensilManager = utensilManager ?? throw new ArgumentNullException(nameof(utensilManager));
        }

        [HttpGet("{utensilId}")]
        public ActionResult<UtensilsOutputDTO> GetUtensilById(int utensilId) {
            try {
                var utensil = _utensilManager.GetUtensilById(utensilId);
                if (utensil == null) {
                    return NotFound($"utensil with ID {utensilId} not found.");
                }

                var utensilOutputDto =
                    MapFromDomain.MapFromUtensilsDomain(Url.Content("~/"), utensil);
                return Ok(utensilOutputDto);
            }
            catch (Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request.");
            }
        }
        [HttpGet("all")]
        
        public ActionResult<UtensilsOutputDTO> GetUtensils() {
            var utensilsData = _utensilManager.GetAllUtensils();
            var utensilsDomain = utensilsData.Select(utensil => MapFromDomain.MapFromUtensilsDomain(Url.Content("~/"), utensil)).ToList();
            if (utensilsDomain == null)
            { 
                return NotFound("Utensils not found.");
            }
            return Ok(utensilsDomain);
        }
    }
}
