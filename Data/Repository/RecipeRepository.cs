using Data.Entities;
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
        public void AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
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
