using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Mappers;
using VideoplayerProject.Domain.Interfaces;
using DomainUtensil = VideoplayerProject.Domain.Models.Utensil;
using DataUtensil = VideoplayerProject.Datalayer.Models.Utensils;
using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Exceptions;
using VideoplayerProject.Datalayer.Models;

namespace VideoplayerProject.Datalayer.Repositories;

public class UtensilsRepository : IUtensilsRepository
{
    private readonly RecipeDbContext _context;

    public UtensilsRepository(RecipeDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<DomainUtensil> GetUtensils(string? filter = null)
    {
        try
        {
            var query = _context.Utensils.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(u => u.UtensilName.Contains(filter));
            }

            var dataUtensils = query.ToList();

            return dataUtensils.Select(UtensilMapper.MapToDomainModel).ToList();
        }
        catch (Exception ex)
        {
            throw new UtensilRepositoryException("Error in GetUtensils", ex);
        }

    }

    public List<DomainUtensil> GetUtensilsFromRecipe(int recipeId)
    {
        try
        {
            var recipeUtensils = _context.RecipeUtensils.Where(ru => ru.RecipeID == recipeId).ToList();
            if (!recipeUtensils.Any())
                return new List<DomainUtensil>();

            // Fetch the utensils directly from the Utensils table
            var utensilIds = recipeUtensils.Select(ru => ru.UtensilID).Distinct().ToList();
            var dataUtensils = _context.Utensils.Where(u => utensilIds.Contains(u.UtensilID)).ToList();

            // Map the data utensils to domain utensils
            return dataUtensils.Select(UtensilMapper.MapToDomainModel).ToList();
        }
        catch (Exception ex)
        {
            throw new UtensilRepositoryException("Error in GetUtensilsFromRecipe.", ex);
        }
    }

    public DomainUtensil GetUtensilById(int id)
    {
        try
        {
            var dataUtensil = _context.Utensils.Find(id);
            if (dataUtensil == null) throw new ArgumentNullException("Utensil not found.");

            return UtensilMapper.MapToDomainModel(dataUtensil);
        }
        catch (Exception ex)
        {
            throw new UtensilRepositoryException("Error in GetUtensilById.", ex);
        }

    }

    public void CreateUtensil(DomainUtensil utensil)
    {
        try
        {
            var dataUtensil = UtensilMapper.MapToDataModel(utensil);
            _context.Utensils.Add(dataUtensil);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new UtensilRepositoryException("Error creating utensil.", ex);
        }

    }


    public void UpdateUtensil(DomainUtensil utensil)
    {
        try
        {
            var dataUtensil = UtensilMapper.MapToDataModel(utensil);
            if (dataUtensil == null)
            {
                throw new UtensilRepositoryException("Utensil not found.");
            }

            var existingEntry = _context.ChangeTracker.Entries<Utensils>().FirstOrDefault(e => e.Entity.UtensilID == dataUtensil.UtensilID);
            if (existingEntry != null)
            {
                existingEntry.State = EntityState.Detached;
            }

            _context.Utensils.Update(dataUtensil);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new UtensilRepositoryException("Error updating utensil.", ex);
        }
    }
}