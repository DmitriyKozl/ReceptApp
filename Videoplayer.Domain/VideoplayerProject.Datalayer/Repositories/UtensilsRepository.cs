using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Mappers;
using VideoplayerProject.Domain.Interfaces;
using DomainUtensil = VideoplayerProject.Domain.Models.Utensil;
using DataUtensil = VideoplayerProject.Datalayer.Models.Utensils;

namespace VideoplayerProject.Datalayer.Repositories;

public class UtensilsRepository : IUtensilsRepository {
    private readonly RecipeDbContext _context;

    public UtensilsRepository(RecipeDbContext context) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<DomainUtensil> GetAllUtensils() {
        var dataUtensils = _context.Utensils.ToList();
        return dataUtensils.Select(UtensilMapper.MapToDomainModel).ToList();
    }

    public List<DomainUtensil> GetFilteredUtensils(string filter) {
        var dataUtensils = string.IsNullOrEmpty(filter)
            ? _context.Utensils.ToList()
            : _context.Utensils.Where(u => u.UtensilName.Contains(filter)).ToList();

        return dataUtensils.Select(UtensilMapper.MapToDomainModel).ToList();
    }

    public List<DomainUtensil> GetUtensilsFromRecipe(int recipeId) {
        var recipeUtensils = _context.RecipeUtensils.Where(ru => ru.RecipeID == recipeId).ToList();
        if (!recipeUtensils.Any())
            return new List<DomainUtensil>();

        // Fetch the utensils directly from the Utensils table
        var utensilIds = recipeUtensils.Select(ru => ru.UtensilID).Distinct().ToList();
        var dataUtensils = _context.Utensils.Where(u => utensilIds.Contains(u.UtensilID)).ToList();

        // Map the data utensils to domain utensils
        return dataUtensils.Select(UtensilMapper.MapToDomainModel).ToList();
    }

    public DomainUtensil GetUtensilById(int id) {
        var dataUtensil = _context.Utensils.Find(id);
        if (dataUtensil == null) throw new ArgumentNullException("Utensil not found.");

        return UtensilMapper.MapToDomainModel(dataUtensil);
    }

    public void CreateUtensil(DomainUtensil utensil) {
        var dataUtensil = UtensilMapper.MapToDataModel(utensil);
        _context.Utensils.Add(dataUtensil);
        _context.SaveChanges();
    }

    public void RemoveUtensil(int id) {
        var dataUtensil = _context.Utensils.Find(id);
        if (dataUtensil == null) throw new ArgumentNullException("Utensil not found.");

        _context.Utensils.Remove(dataUtensil);
        _context.SaveChanges();
    }

    public void UpdateUtensil(DomainUtensil utensil) {
        var dataUtensil = UtensilMapper.MapToDataModel(utensil);
        if (dataUtensil == null) throw new ArgumentNullException("Utensil not found.");

        _context.Utensils.Update(dataUtensil);
        _context.SaveChanges();
    }
}