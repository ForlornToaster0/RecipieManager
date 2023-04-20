using RecipieManager.Backend.Models;

namespace RecipieManager.Backend.Repositories
{
    public interface IInnerJoinRepository
    {
        Task<List<UserIngredient>> GetByIdInnerJoin(int Id);
        Task<Recipe> GetByIdAsync(int id);
        Task<List<Recipe>> SearchAsync(string searchQuery);
    }
}