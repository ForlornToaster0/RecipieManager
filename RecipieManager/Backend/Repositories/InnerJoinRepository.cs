using Microsoft.EntityFrameworkCore;
using RecipieManager.Backend.Context;
using RecipieManager.Backend.Models;

namespace RecipieManager.Backend.Repositories
{
    public class InnerJoinRepository : IInnerJoinRepository
    {
        private readonly RecipeManagementContext _context;

        public InnerJoinRepository(RecipeManagementContext context)
        {
            _context = context;
        }
        public async Task<List<UserIngredient>> GetByIdInnerJoin(int Id)
        {
            var user =  _context.UserIngredients.Include(u => u.Ingredient).Where(u => u.UserId == Id).ToList();
            return user;
        }
        public async Task<Recipe> GetByIdAsync(int id)
        {
            return await _context.Recipes
                .Where(r => r.RecipeId == id)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync();
        }
        public async Task<List<Recipe>> SearchAsync(string searchQuery)
        {
            // Get all recipes from the database
            var recipes = await _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .ToListAsync();

            // Filter recipes based on search query
            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLowerInvariant();

                recipes = recipes.Where(r =>
                    r.RecipeName.ToLowerInvariant().Contains(searchQuery) ||
                    r.RecipeDescription.ToLowerInvariant().Contains(searchQuery) ||
                    r.RecipeInstructions.ToLowerInvariant().Contains(searchQuery) ||
                    r.RecipeIngredients.Any(ri => ri.Ingredient.IngredientName.ToLowerInvariant().Contains(searchQuery))
                ).ToList();
            }

            return recipes;
        }

    }
}
