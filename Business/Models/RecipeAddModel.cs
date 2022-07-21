using System.ComponentModel.DataAnnotations;


namespace Business.Models
{
    public class RecipeAddModel
    {
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public Boolean IsVeg { get; set; }
        [Required]
        public string Servings { get; set; }
        [Required]
        public string Instructions { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public ICollection<IngredientAddModel> Ingredients { get; set; }
    }
}
