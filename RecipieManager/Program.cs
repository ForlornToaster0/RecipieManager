using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RecipieManager.Backend.Context;
using RecipieManager.Backend.Models;
using RecipieManager.Backend.Repositories;
using RecipieManager.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Ingredient>, Repository<Ingredient>>();
builder.Services.AddScoped<IRepository<Recipe>, Repository<Recipe>>();
builder.Services.AddScoped<IInnerJoinRepository, InnerJoinRepository>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<RecipeManagementContext>(options =>
       options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RecipeDatabase;Trusted_Connection=True;"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
