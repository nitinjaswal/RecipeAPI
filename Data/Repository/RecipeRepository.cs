using Data.Entities;
using Data.Models;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext _context;

        public RecipeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<OutputModel<bool>> AddRecipe(RecipeModel recipeModel)
        {
            var outputModel = new OutputModel<bool>();

            Recipe recipe = new Recipe();
            recipe.Id = recipeModel.Id;
            recipe.RecipeName = recipeModel.RecipeName;
            recipe.IsVeg = recipeModel.IsVeg;
            recipe.Servings = recipeModel.Servings;
            recipe.Instructions = recipeModel.Instructions;

            recipe.Ingredients = new List<Ingredient>();
            foreach (var item in recipeModel.Ingredients)
            {
                recipe.Ingredients.Add(new Ingredient
                {
                    IngredientName = item.IngredientName,
                    RecipeID = item.RecipeID
                }); ;
            }

            if (recipe.Id > 0)
            {
                _context.Recipes.Update(recipe);
            }
            else
            {
                _context.Recipes.Add(recipe);
            }

            _context.SaveChanges();
            outputModel.Status = true;
            outputModel.Message = $"Recipe {recipe.RecipeName} added successfully.";
            return outputModel;

        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _context.Recipes.Include(x => x.Ingredients).ToListAsync();
        }

        public async Task<int> RemoveRecipe(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            return await _context.SaveChangesAsync();
        }

        public async Task<Recipe> GetRecipeById(int recipeId)
        {
            return await _context.Recipes.Where(x => x.Id == recipeId).Include(i => i.Ingredients).FirstOrDefaultAsync();
        }
    }
}
