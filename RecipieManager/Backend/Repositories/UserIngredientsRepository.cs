using Microsoft.EntityFrameworkCore;
using RecipieManager.Backend.Context;
using RecipieManager.Backend.Models;

namespace RecipieManager.Backend.Repositories
{
    public class UserIngredientsRepository : IUserIngredientsRepository
    {
        private readonly RecipeManagementContext _context;

        public UserIngredientsRepository(RecipeManagementContext context)
        {
            _context = context;
        }
        public async Task<List<UserIngredient>> GetByIdInnerJoin(int Id)
        {
            var user =  _context.UserIngredients.Include(u => u.Ingredient).Where(u => u.UserId == Id).ToList();
            return user;
        }
    }
}
