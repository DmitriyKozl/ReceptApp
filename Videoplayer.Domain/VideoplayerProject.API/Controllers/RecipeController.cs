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
using VideoplayerProject.Domain.Managers;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.API.Controllers;

[Route("api/[controller]/recipe")]
[ApiController]
public class RecipeController : ControllerBase {
    private readonly IRecipeService _recipeManager;
    private readonly IIngredientService _ingredientService;

    public RecipeController(IRecipeService recipeManager, IIngredientService ingredientService) {
        _recipeManager = recipeManager ?? throw new ArgumentNullException(nameof(recipeManager));
        _ingredientService = ingredientService ?? throw new ArgumentNullException(nameof(ingredientService));
    }

    [HttpGet("{recipeId}")]
    public ActionResult<RecipeOutputDTO> GetRecipeById(int recipeId) {
        try {
            var recipe = _recipeManager.GetRecipeById(recipeId);
            if (recipe == null) {
                return NotFound($"Recipe with ID {recipeId} not found.");
            }

            var recipeOutputDto = MapFromDomain.MapFromRecipeDomain(Url.Content("~/"), recipe);
            return Ok(recipeOutputDto);
        }
        catch (Exception e) {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "An error occurred while processing your request.");
        }
    }
    // POST: api/Recipe
}