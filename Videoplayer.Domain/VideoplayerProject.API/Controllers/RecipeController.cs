using Microsoft.AspNetCore.Mvc;
using VideoplayerProject.API.Mappers;
using VideoplayerProject.API.Models;
using VideoplayerProject.API.Models.Output;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;


namespace VideoplayerProject.API.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class RecipeController : ControllerBase {
    private readonly IRecipeService _recipeManager;
    private readonly IIngredientService _ingredientService;

    public RecipeController(IRecipeService recipeManager, IIngredientService ingredientService) {
        _recipeManager = recipeManager ?? throw new ArgumentNullException(nameof(recipeManager));
        _ingredientService = ingredientService ?? throw new ArgumentNullException(nameof(ingredientService));
    }

    [HttpGet("{{recipeId}}")]
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
        var recipesDomain = recipesData.Select(recipe => MapFromDomain.MapFromRecipeDomain(Url.Content("~/"), recipe))
            .ToList();

        if (recipesDomain == null) {
            return NotFound("Recipes not found.");
        }

        return Ok(recipesDomain);
    }

    [HttpPost("recipe")]
    public ActionResult<RecipeOutputDTO> AddRecipe([FromBody] RecipeInputDTO recipeInputDto) {
        try {

            Recipe recipe = _recipeManager.CreateRecipe(MapToDomain.MapToRecipeDomain(recipeInputDto));
            return CreatedAtAction(nameof(GetRecipeById), new
                { recipeId = recipe.Id },
                MapFromDomain.MapFromRecipeDomain(Url.Content("~/"), recipe));

        }
        catch (Exception e) {
            return BadRequest(e.Message);
            
        }
    }
    [HttpPost("{recipeId}/ingredient/{ingredientId}")]
    public ActionResult<RecipeOutputDTO> AddIngredientToRecipe([FromBody] IngredientInRecipeDTO ingredientInRecipeDTO, [FromRoute] int ingredientId, [FromRoute] int recipeId) {
        try {
            Recipe recipe = _recipeManager.GetRecipeById(recipeId);
            Ingredient ingredient = _ingredientService.GetIngredientById(ingredientId);
            Timestamp timestamp = new Timestamp(ingredientInRecipeDTO.From, ingredientInRecipeDTO.Till,ingredientId);

            _recipeManager.AddIngredientWithTimeStamp(recipe, ingredient, timestamp);
            return CreatedAtAction(nameof(GetRecipeById), new { recipeId = recipe.Id }, MapFromDomain.MapFromRecipeDomain(Url.Content("~/"), recipe));
        }
        catch (Exception e) {
            return BadRequest(e.Message);
        }
    }
    //
    // [HttpDelete("{recipeId}")]
    // public ActionResult<RecipeOutputDTO> DeleteRecipe(int recipeId) {
    //     try {
    //         Recipe recipe = _recipeManager.GetRecipeById(recipeId);
    //         if (recipe == null) {
    //             return NotFound($"Recipe with ID {recipeId} not found.");
    //         }
    //
    //         _recipeManager.RemoveRecipe(recipeId);
    //         return NoContent();
    //     }
    //     catch (Exception e) {
    //         return StatusCode(StatusCodes.Status500InternalServerError,
    //             "An error occurred while processing your request.");
    //     }
    // }
    //
    // [HttpPut("{recipeId}")]
    // public ActionResult<RecipeOutputDTO> UpdateRecipe(int recipeId, [FromBody] RecipeInputDTO recipeInputDto) {
    //     try {
    //         Recipe recipe = _recipeManager.GetRecipeById(recipeId);
    //         if (recipe == null) {
    //             return NotFound($"Recipe with ID {recipeId} not found.");
    //         }
    //
    //         Recipe updatedRecipe = MapToDomain.MapToRecipeDomain(recipeInputDto);
    //         _recipeManager.UpdateRecipe(recipeId, updatedRecipe);
    //         return NoContent();
    //     }
    //     catch (Exception e) {
    //         return StatusCode(StatusCodes.Status500InternalServerError,
    //             "An error occurred while processing your request.");
    //     }
    // }
    
}

    