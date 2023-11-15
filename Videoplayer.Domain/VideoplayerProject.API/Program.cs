using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Repositories;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Managers;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRecipeService, RecipeManager>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IIngredientService, IngredientManager>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IUtensilService, UtensilManager>(); 
builder.Services.AddScoped<IUtensilsRepository, UtensilsRepository>();
builder.Services.AddDbContext<RecipeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseCors(policy=>policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(policy=>policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
}
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

