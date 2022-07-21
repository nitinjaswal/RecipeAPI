using Data.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext _context;

        public RecipeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public async Task AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _context.Recipes.Where(x => x.IsActive != false).Include(ing => ing.Ingredients).ToListAsync();
        }

        public async Task<int> RemoveRecipe(int recipeId)
        {
            var recipe = _context.Recipes.FirstOrDefault(x => x.Id == recipeId);
            _context.Recipes.Remove(recipe);
            return await _context.SaveChangesAsync();
        }

        public async Task<Recipe> GetRecipeById(int recipeId)
        {
            return await _context.Recipes.Include(i => i.Ingredients).FirstOrDefaultAsync(x => x.Id == recipeId);
        }
    }
}
