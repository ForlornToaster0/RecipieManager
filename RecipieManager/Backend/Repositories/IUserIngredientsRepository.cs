using RecipieManager.Backend.Models;

namespace RecipieManager.Backend.Repositories
{
    public interface IUserIngredientsRepository
    {
        Task<List<UserIngredient>> GetByIdInnerJoin(int Id);
    }
}