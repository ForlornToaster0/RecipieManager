using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipieManager.Backend.Models
{
    public class RecipeIngredient
    {
        [Key, Column(Order = 0)]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        [Key, Column(Order = 1)]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }

}
