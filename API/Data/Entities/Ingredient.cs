using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities
{
    public class Ingredient
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int RecipeID { get; set; }

        [Required]
        [MaxLength(500)]
        public string IngredientName { get; set; }

        [ForeignKey("RecipeID")]
        public Recipe Recipe { get; set; }
    }
}
