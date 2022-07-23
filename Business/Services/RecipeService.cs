using Business.Helper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<int> UpdateRecipe(RecipeUpdateModel recipeUpdateModel)
        {
            return await _recipeRepository.UpdateRecipe(recipeUpdateModel.ToUpdateRecipe());
        }

        public async Task AddRecipe(RecipeAddModel recipeAddModel)
        {
            await _recipeRepository.AddRecipe(recipeAddModel.ToAddRecipe());
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes()
        {
            var recipes = await _recipeRepository.GetRecipes();
            return recipes.ToRecipeModel();
        }

        public async Task<int> RemoveRecipe(int recipeId)
        {
            var recipe = await _recipeRepository.GetRecipeById(recipeId);
            if (recipe != null)
            {
                return await _recipeRepository.RemoveRecipe(recipeId);
            }
            return 0;
        }

        public async Task<RecipeModel> GetRecipeById(int recipeId)
        {
            var recipe = await _recipeRepository.GetRecipeById(recipeId);
            if (recipe == null)
            {
                return null;
            }
            return recipe.ToGetRecipeModel();
        }

    }
}
