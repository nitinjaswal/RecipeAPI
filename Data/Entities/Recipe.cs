using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Recipe
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public Boolean IsVeg { get; set; }
        [Required]
        public string Servings { get; set; }
        [Required]
        public string Instructions { get; set; }

        public ICollection<Ingredient> Ingredients   { get; set; }
    }
}
