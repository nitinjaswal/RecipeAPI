using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class IngredientAddModel
    {
        [Required]
        [MaxLength(500)]
        public string IngredientName { get; set; }
    }
}
