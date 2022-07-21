
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class RecipeUpdateModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string RecipeName { get; set; }
        [Required]
        public Boolean IsVeg { get; set; }
        [Required]
        public int Servings { get; set; }
        [Required]
        [MaxLength(500)]
        public string Instructions { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public ICollection<IngredientUpdateModel> Ingredients { get; set; }
    }
}
