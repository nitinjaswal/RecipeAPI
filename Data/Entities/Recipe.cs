﻿using System.ComponentModel.DataAnnotations;

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
        public bool IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public ICollection<Ingredient> Ingredients   { get; set; }
    }
}
