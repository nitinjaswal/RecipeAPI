using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        [Required]
        public int RecipeID { get; set; }
        [Required]
        public string IngredientName { get; set; }
    }
}
