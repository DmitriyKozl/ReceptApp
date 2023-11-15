using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoplayerProject.API.Mappers;
using VideoplayerProject.API.Models;
using VideoplayerProject.API.Models.Output;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

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
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<UtensilsOutputDTO> GetUtensils() {
            try {
                var utensilsData = _utensilManager.GetAllUtensils();
                var utensilsDomain = utensilsData
                    .Select(utensil => MapFromDomain.MapFromUtensilsDomain(Url.Content("~/"), utensil)).ToList();
                if (utensilsDomain == null) {
                    return NotFound("Utensils not found.");
                }

                return Ok(utensilsDomain);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<UtensilsOutputDTO> AddUtensil([FromBody] UtensilInputDTO utensilsInputDto) {
            try {
                Utensil utensil = _utensilManager.CreateUtensil(MapToDomain.MapToUtensilDomain(utensilsInputDto));
                return CreatedAtAction(nameof(GetUtensilById), new
                    { utensilId = utensil.Id },
                    MapFromDomain.MapFromUtensilsDomain(Url.Content("~/"), utensil));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{utensilId}")]
        public ActionResult<UtensilsOutputDTO> UpdateUtensil(UtensilInputDTO utensilInputDto) {
            try {
                var utensilDomain = MapToDomain.MapToUtensilDomain(utensilInputDto);
                var utensil = _utensilManager.UpdateUtensil(utensilDomain);
                var utensilOutputDto =
                    MapFromDomain.MapFromUtensilsDomain(Url.Content("~/"), utensil);
                return Ok(utensilOutputDto);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}