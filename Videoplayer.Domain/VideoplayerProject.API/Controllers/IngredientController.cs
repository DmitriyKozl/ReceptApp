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
    public class IngredientController : ControllerBase {
        private readonly IIngredientService _ingredientManager;

        public IngredientController(IIngredientService ingredientManager) {
            _ingredientManager = ingredientManager ?? throw new ArgumentNullException(nameof(ingredientManager));
        }

        [HttpGet("{ingredientId}")]
        public ActionResult<IngredientOutputDTO> GetIngredientById(int ingredientId) {
            try {
                var ingredient = _ingredientManager.GetIngredientById(ingredientId);
                if (ingredient == null) {
                    return NotFound($"ingredient with ID {ingredientId} not found.");
                }

                var ingredientOutputDto =
                    MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient);
                return Ok(ingredientOutputDto);
            }
            catch (Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request.");
            }
        }

        [HttpGet("all")]
        public ActionResult<IngredientOutputDTO> GetIngredients() {
            var ingredientsData = _ingredientManager.GetAllIngredients();
            var ingredientsDomain = ingredientsData
                .Select(ingredient => MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient)).ToList();
            if (ingredientsDomain == null) {
                return NotFound("Ingredients not found.");
            }

            return Ok(ingredientsDomain);
        }

      
    }
}