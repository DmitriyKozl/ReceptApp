using Microsoft.AspNetCore.Mvc;
using VideoplayerProject.API.Mappers;
using VideoplayerProject.API.Models.Output;
using VideoplayerProject.Domain.Interfaces;
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

    [HttpGet("all")]
    public ActionResult<RecipeOutputDTO> GetAllRecipes() {
        
        var recipesData = _recipeManager.GetAllRecipes();
        var recipesDomain = recipesData.Select(recipe => MapFromDomain.MapFromRecipeDomain(Url.Content("~/"), recipe)).ToList();
        
        if (recipesDomain == null)
        {
            return NotFound("Recipes not found.");
        }

        return Ok(recipesDomain);
    }
    // POST: api/Recipe
}