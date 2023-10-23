using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Datalayer.Repositories;

public class UtensilsRepository: IUtensilRepository {
    private readonly RecipeDbContext _context;

    public UtensilsRepository(RecipeDbContext context) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Utensils> GetAllUtensils(string filter) {
        return string.IsNullOrEmpty(filter)
            ? _context.Utensils.ToList()
            : _context.Utensils.Where(u => u.UtensilName.Contains(filter)).ToList();
    }

    public List<Utensils> GetUtensilsFromRecipe(int recipeId) {
        var recipe = _context.Recipes.Find(recipeId);
        if (recipe == null) throw new ArgumentNullException("Recipe not found.");

        return recipe.RecipeUtensils.Select(ru => ru.Utensils).ToList();
    }

    public void CreateUtensil( string name) {
        var utensil = new Utensils { UtensilName = name };
        _context.Utensils.Add(utensil);
        _context.SaveChanges();
    }

    public void UpdateUtensil(int id, string newName) {
        var utensil = _context.Utensils.Find(id);
        if (utensil == null) throw new ArgumentNullException("Utensils not found.");

        utensil.UtensilName = newName;
        _context.SaveChanges();
    }

    public void RemoveUtensil(int id) {
        var utensil = _context.Utensils.Find(id);
        if (utensil == null) throw new ArgumentNullException("Utensils not found.");

        _context.Utensils.Remove(utensil);
        _context.SaveChanges();
    }
}