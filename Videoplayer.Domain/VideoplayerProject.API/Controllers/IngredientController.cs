using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using VideoplayerProject.API.Mappers;
using VideoplayerProject.API.Models.Output;
using VideoplayerProject.API.Models;
using VideoplayerProject.Domain.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientManager;

    public IngredientController(IIngredientService ingredientManager)
    {
        _ingredientManager = ingredientManager ?? throw new ArgumentNullException(nameof(ingredientManager));
    }
    [HttpGet("{ingredientId}", Name = "GetIngredientById")]
    public ActionResult<IngredientOutputDTO> GetIngredientById(int ingredientId)
    {
        try
        {
            var ingredient = _ingredientManager.GetIngredientById(ingredientId);
            if (ingredient == null)
            {
                return NotFound($"Ingredient with ID {ingredientId} not found.");
            }

            var ingredientOutputDto = MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient);
            return Ok(ingredientOutputDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet(Name = "GetAllIngredients")]
    public ActionResult<IEnumerable<IngredientOutputDTO>> GetAllIngredients()
    {
        try
        {
            var ingredientsData = _ingredientManager.GetIngredients("");
            var ingredientsDomain = ingredientsData
                .Select(ingredient => MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient))
                .ToList();

            if (ingredientsDomain == null)
            {
                return NotFound("Ingredients not found.");
            }

            return Ok(ingredientsDomain);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("filter/{filter?}", Name = "GetIngredients")]
    public ActionResult<IEnumerable<IngredientOutputDTO>> GetIngredients(string? filter = null)
    {
        try
        {
            var ingredientsData = _ingredientManager.GetIngredients(filter);
            var ingredientsDomain = ingredientsData
                .Select(ingredient => MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient))
                .ToList();
            if (ingredientsDomain == null)
            {
                return NotFound("Ingredients not found.");
            }

            return Ok(ingredientsDomain);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public ActionResult<IngredientOutputDTO> AddIngredient(IngredientInputDTO ingredientInputDto)
    {
        try
        {
            var ingredientDomain = MapToDomain.MapToIngredientDomain(ingredientInputDto);
            var ingredient = _ingredientManager.CreateIngredient(ingredientDomain);
            var ingredientOutputDto = MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient);
            return Ok(ingredientOutputDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{ingredientId}")]
    public ActionResult<IngredientOutputDTO> UpdateIngredient(IngredientInputDTO ingredientInputDto)
    {
        try
        {
            var ingredientDomain = MapToDomain.MapToIngredientDomain(ingredientInputDto);
            var ingredient = _ingredientManager.UpdateIngredient(ingredientDomain);
            var ingredientOutputDto = MapFromDomain.MapFromIngredientDomain(Url.Content("~/"), ingredient);
            return Ok(ingredientOutputDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
