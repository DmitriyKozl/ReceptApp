using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Models;
using VideoplayerProject.Domain.Models;
using Ingredient = VideoplayerProject.Domain.Models.Ingredient;
using Recipe = VideoplayerProject.Domain.Models.Recipe;
using Utensil = VideoplayerProject.Domain.Models.Utensil;

namespace VideoplayerProject.Datalayer.Mappers;

public class RecipeMapper {
    private readonly RecipeDbContext _context;

    public RecipeMapper(RecipeDbContext context) {
        _context = context;
    }

    public static Recipe MapToDomainModel(Datalayer.Models.Recipe dataRecipe) {
        dataRecipe.RecipeIngredients ??= new List<RecipeIngredient>();
        dataRecipe.RecipeUtensils ??= new List<RecipeUtensil>();

        var ingredientGroups = new Dictionary<Ingredient, List<Timestamp>>();
        foreach (var group in dataRecipe.RecipeIngredients.GroupBy(ri => ri.IngredientID)) {
            var ingredient = IngredientMapper.MapToDomainModel(group.First().Ingredient);
            var timestamps = group.Select(ri => new Timestamp(ri.BeginTime, ri.EndTime, ri.Ingredient.IngredientID))
                .Distinct()
                .ToList();

            if (!ingredientGroups.ContainsKey(ingredient)) {
                ingredientGroups.Add(ingredient, timestamps);
            } else {
                // Merge or update the list if the key already exists
                ingredientGroups[ingredient] = ingredientGroups[ingredient].Union(timestamps).ToList();
            }
        }

        var utensilGroups = new Dictionary<Utensil, List<Timestamp>>();
        foreach (var group in dataRecipe.RecipeUtensils.GroupBy(ru => ru.UtensilID)) {
            var utensil = UtensilMapper.MapToDomainModel(group.First().Utensil);
            var timestamps = group.Select(ru => new Timestamp(ru.BeginTime, ru.EndTime, ru.UtensilID))
                .Distinct()
                .ToList();

            if (!utensilGroups.ContainsKey(utensil)) {
                utensilGroups.Add(utensil, timestamps);
            } else {
                // Merge or update the list if the key already exists
                utensilGroups[utensil] = utensilGroups[utensil].Union(timestamps).ToList();
            }
        }

        // Create the domain model
        var domainRecipe = new Recipe(
            dataRecipe.RecipeName,
            dataRecipe.Servings ?? 0,
            dataRecipe.VideoLink,
            dataRecipe.CookingTime
        ) {
        Id = dataRecipe.RecipeID,
        IngredientToTimestamp = ingredientGroups,
        UtensilToTimestamp = utensilGroups
        };

        return domainRecipe;
    }
    public static Datalayer.Models.Recipe MapToDataEntity(Recipe domainRecipe, RecipeDbContext context) {
        var dataRecipe = GetDataRecipe(domainRecipe, context);
        SetRecipeProperties(dataRecipe, domainRecipe);
        
        HandleRecipeIngredients(domainRecipe, dataRecipe, context);
        HandleRecipeUtensils(domainRecipe, dataRecipe, context);

        return dataRecipe;
    }
 private static void HandleRecipeIngredients(Recipe domainRecipe, Datalayer.Models.Recipe dataRecipe, RecipeDbContext context) {
    foreach (var ingredientPair in domainRecipe.IngredientToTimestamp) {
        var ingredient = context.Ingredients.Find(ingredientPair.Key.Id) ?? new Datalayer.Models.Ingredient {
            IngredientName = ingredientPair.Key.Name,
            Price = ingredientPair.Key.Price,
            Brand = ingredientPair.Key.Brand
        };

        if (ingredient.IngredientID == 0) {
            context.Ingredients.Add(ingredient);
            context.SaveChanges();
            ingredientPair.Key.Id = ingredient.IngredientID;
        }

        foreach (var timestamp in ingredientPair.Value) {
            var existingRecipeIngredient = context.RecipeIngredient
                .FirstOrDefault(ri => ri.RecipeID == dataRecipe.RecipeID &&
                                      ri.IngredientID == ingredient.IngredientID &&
                                      ri.BeginTime == timestamp.StartTime);

            if (existingRecipeIngredient == null) {
                dataRecipe.RecipeIngredients.Add(new RecipeIngredient {
                    RecipeID = dataRecipe.RecipeID,
                    IngredientID = ingredient.IngredientID,
                    BeginTime = timestamp.StartTime,
                    EndTime = timestamp.EndTime
                });
            } else {
                existingRecipeIngredient.EndTime = timestamp.EndTime;
            }
        }
    }
}

private static void HandleRecipeUtensils(Recipe domainRecipe, Datalayer.Models.Recipe dataRecipe, RecipeDbContext context) {
    foreach (var utensilPair in domainRecipe.UtensilToTimestamp) {
        var utensil = context.Utensils
            .FirstOrDefault(u => u.UtensilName == utensilPair.Key.Name);

        if (utensil == null) {
            utensil = new Utensils {
                UtensilName = utensilPair.Key.Name,
                ImgUrl = utensilPair.Key.ImgUrl
            };
            context.Utensils.Add(utensil);
            context.SaveChanges();
        }

        foreach (var timestamp in utensilPair.Value) {
            var existingRecipeUtensil = context.RecipeUtensils
                .FirstOrDefault(ru => ru.RecipeID == dataRecipe.RecipeID &&
                                      ru.UtensilID == utensil.UtensilID &&
                                      ru.BeginTime == timestamp.StartTime);

            if (existingRecipeUtensil == null) {
                dataRecipe.RecipeUtensils.Add(new RecipeUtensil {
                    RecipeID = dataRecipe.RecipeID,
                    UtensilID = utensil.UtensilID,
                    BeginTime = timestamp.StartTime,
                    EndTime = timestamp.EndTime
                });
            } else {
                existingRecipeUtensil.EndTime = timestamp.EndTime;
            }
        }
    }
}
private static Datalayer.Models.Recipe GetDataRecipe(Recipe domainRecipe, RecipeDbContext context) {
    if (domainRecipe.Id == 0) {
        return new Datalayer.Models.Recipe();
    } else {
        var existingRecipe = context.Recipes
            .Include(r => r.RecipeIngredients)
            .Include(r => r.RecipeUtensils)
            .FirstOrDefault(r => r.RecipeID == domainRecipe.Id);

        if (existingRecipe == null) 
            throw new InvalidOperationException("Recipe not found for updating.");

        return existingRecipe;
    }
}
    private static void SetRecipeProperties(Datalayer.Models.Recipe dataRecipe, Recipe domainRecipe) {
        dataRecipe.RecipeName = domainRecipe.Name;
        dataRecipe.Servings = domainRecipe.Servings;
        dataRecipe.VideoLink = domainRecipe.VideoLink;
        dataRecipe.CookingTime = domainRecipe.CookingTime;
    }

    
    
}