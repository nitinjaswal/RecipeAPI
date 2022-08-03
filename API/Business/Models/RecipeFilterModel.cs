
namespace Business.Models
{
    public class RecipeFilterModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsVeg { get; set; }
        public int Servings { get; set; } = 0;
        public string? IngInclude { get; set; }
        public string? IngExclude { get; set; }
        public string? Instructions { get; set; }
    }
}
