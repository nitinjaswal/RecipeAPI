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
        public async Task<int> UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            return await _context.SaveChangesAsync();
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

        public async Task<IEnumerable<Recipe>> GetRecipes(bool isVeg)
        {
            return await _context.Recipes.Where(x => x.IsActive != false && x.IsVeg == isVeg).Include(ing => ing.Ingredients).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipes(int servings)
        {
            return await _context.Recipes.Where(x => x.IsActive != false && x.Servings == servings).Include(ing => ing.Ingredients).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipes(bool isVeg, int servings)
        {
            return await _context.Recipes.Where(x => x.IsActive != false && x.IsVeg == isVeg && x.Servings == servings).Include(ing => ing.Ingredients).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipes(bool isVeg, int servings, string inlcude, string exclude)
        {
            return await _context.Recipes.Where(x => x.IsActive != false && x.IsVeg == isVeg && x.Servings == servings).Include(ing => ing.Ingredients).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipes(int servings, string inlcude)
        {
            return await _context.Recipes.Where(x => x.IsActive != false && x.Servings == servings).Include(ing => ing.Ingredients).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipes(string exclude, string instructions)
        {
            return await _context.Recipes.Where(x => x.IsActive != false && x.Instructions.Contains(instructions)).Include(ing => ing.Ingredients).ToListAsync();
        }
    }
}
