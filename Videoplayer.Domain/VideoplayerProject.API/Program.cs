using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Managers;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IRecipeService, RecipeManager>();
    builder.Services.AddDbContext<RecipeDbContext>(options =>
        options.UseSqlServer("Server=tcp:receptendb.database.windows.net,1433;Initial Catalog=receptdb;Persist Security Info=False;User ID=receptdblogin;Password=qLW7yJZHyNU4zJP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
}
var app = builder.Build();

{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}