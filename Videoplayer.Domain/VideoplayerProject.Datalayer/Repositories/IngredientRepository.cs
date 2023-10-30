using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Mappers;
using VideoplayerProject.Domain.Interfaces;
using DomainIngredient = VideoplayerProject.Domain.Models.Ingredient;
using DataIngredient = VideoplayerProject.Datalayer.Models.Ingredient;

namespace VideoplayerProject.Datalayer.Repositories;

public class IngredientRepository : IIngredientRepository {
    private readonly RecipeDbContext _context;

    public IngredientRepository(RecipeDbContext context) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<DomainIngredient> GetFilteredIngredients(string filter) {
        var dataIngredients = string.IsNullOrEmpty(filter)
            ? _context.Ingredients.ToList()
            : _context.Ingredients.Where(i => i.IngredientName.Contains(filter)).ToList();

        return dataIngredients.Select(IngredientMapper.MapToDomainModel).ToList();
    }
    
    public List<DomainIngredient> GetAllIngredients() {
        var dataIngredients = _context.Ingredients.ToList();

        return dataIngredients.Select(IngredientMapper.MapToDomainModel).ToList();
    }

    public List<DomainIngredient> GetIngredientsFromRecipe(int recipeId) {
        var dataIngredients = _context.RecipeIngredient
            .Where(ri => ri.RecipeID == recipeId)
            .Select(ri => ri.Ingredient)
            .ToList();

        return dataIngredients.Select(IngredientMapper.MapToDomainModel).ToList();
    }
    
    public DomainIngredient GetIngredientById(int id) {
        var dataIngredient = _context.Ingredients.Find(id);
        return dataIngredient == null ? null : IngredientMapper.MapToDomainModel(dataIngredient);
    }
    
    public void CreateIngredient(DomainIngredient ingredient) {
        var dataIngredient = IngredientMapper.MapToDataModel(ingredient);
        _context.Ingredients.Add(dataIngredient);
        _context.SaveChanges();
    }
    
    public void RemoveIngredient(int id) {
        var dataIngredient = _context.Ingredients.Find(id);
        if (dataIngredient == null) return;

        _context.Ingredients.Remove(dataIngredient);
        _context.SaveChanges();
    }
    
    
}