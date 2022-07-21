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

        public async Task UpdateRecipe(RecipeUpdateModel recipeUpdateModel)
        {
            _recipeRepository.UpdateRecipe(recipeUpdateModel.ToUpdateRecipe());
        }

        public async Task AddRecipe(RecipeAddModel recipeAddModel)
        {
            _recipeRepository.AddRecipe(recipeAddModel.ToAddRecipe());
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes()
        {
            var recipes = await _recipeRepository.GetRecipes();
            return recipes.ToRecipeModel();
        }

        public async Task<int> RemoveRecipe(int recipeId)
        {
            return await _recipeRepository.RemoveRecipe(recipeId);
        }

        public async Task<RecipeModel> GetRecipeById(int recipeId)
        {
            var recipe = await _recipeRepository.GetRecipeById(recipeId);
            return recipe.ToGetRecipeModel();
        }

    }
}
