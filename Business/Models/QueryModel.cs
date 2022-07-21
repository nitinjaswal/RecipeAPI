
namespace Business.Models
{
    public class QueryModel
    {
        public string? RecipeName { get; set; }
        public Boolean? IsVeg { get; set; }
        public string? Servings { get; set; }
        public string? Instructions { get; set; }
        public string? IngredientName { get; set; }
        public string? IngInclude { get; set; }
        public string? IngExclude { get; set; }
        public string? AllVeg { get; set; }
    }
}
