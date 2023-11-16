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

        [HttpGet("{Id}")]
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
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<IngredientOutputDTO> GetIngredients(string filter) {
            try {
                var ingredientsData = _ingredientManager.GetIngredients(filter);
                var ingredientsDomain = ingredientsData
                    .Select(ingredient => MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient))
                    .ToList();
                if (ingredientsDomain == null) {
                    return NotFound("Ingredients not found.");
                }

                return Ok(ingredientsDomain);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<IngredientOutputDTO> AddIngredient(IngredientInputDTO ingredientInputDto) {
            try {
                var ingredientDomain = MapToDomain.MapToIngredientDomain(ingredientInputDto);
                var ingredient = _ingredientManager.CreateIngredient(ingredientDomain);
                var ingredientOutputDto =
                    MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient);
                return Ok(ingredientOutputDto);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut("{ingredientId}")]
        public ActionResult<IngredientOutputDTO> UpdateIngredient(IngredientInputDTO ingredientInputDto) {
            try {
                var ingredientDomain = MapToDomain.MapToIngredientDomain(ingredientInputDto);
                var ingredient = _ingredientManager.UpdateIngredient( ingredientDomain);
                var ingredientOutputDto =
                    MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient);
                return Ok(ingredientOutputDto);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}