using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class IngredientUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string IngredientName { get; set; }
    }
}
