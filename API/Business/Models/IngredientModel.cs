using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        [Required]
        public int RecipeID { get; set; }
        [Required]
        [MaxLength(500)]
        public string IngredientName { get; set; }
    }
}
