using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class IngredientAddModel
    {
        [Required]
        public string IngredientName { get; set; }
    }
}
