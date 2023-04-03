using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipieManager.Backend.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string UserPassword { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(50)]
        public string UserEmail { get; set; }
        public byte UserPermisionlevel { get; set; }
    }

}
