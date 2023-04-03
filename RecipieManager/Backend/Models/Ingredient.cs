using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipieManager.Backend.Models
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string IngredientDescription { get; set; }
        public bool IsAllergen { get; set; } = false;
    }

}
