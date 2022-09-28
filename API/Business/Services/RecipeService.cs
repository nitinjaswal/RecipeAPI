using Business.Helper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> UpdateRecipe(RecipeUpdateModel recipeUpdateModel)
        {
            return await _unitOfWork.RecipeRepository.UpdateRecipe(recipeUpdateModel.ToUpdateRecipe());
        }

        public async Task AddRecipe(RecipeAddModel recipeAddModel)
        {
            await _unitOfWork.RecipeRepository.AddRecipe(recipeAddModel.ToAddRecipe());
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes()
        {
            var recipes = await _unitOfWork.RecipeRepository.GetRecipes();
            return recipes.ToRecipeModel();
        }

        public async Task<int> RemoveRecipe(int recipeId)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetRecipeById(recipeId);
            if (recipe != null)
            {
                return await _unitOfWork.RecipeRepository.RemoveRecipe(recipeId);
            }
            return 0;
        }

        public async Task<RecipeModel> GetRecipeById(int recipeId)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetRecipeById(recipeId);
            if (recipe == null)
            {
                return null;
            }
            return recipe.ToGetRecipeModel();
        }


        public Task<RecipeModel> GetRecipeById(int recipeId, bool isVeg)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes(bool isVeg)
        {
            var recipes = await _unitOfWork.RecipeRepository.GetRecipes(isVeg);
            return recipes.ToRecipeModel();
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes(int servings)
        {
            var recipes = await _unitOfWork.RecipeRepository.GetRecipes(servings);
            return recipes.ToRecipeModel();
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes(bool isVeg, int servings)
        {
            var recipes = await _unitOfWork.RecipeRepository.GetRecipes(isVeg,servings);
            return recipes.ToRecipeModel();
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes(bool isVeg, int servings, string inlcude, string exclude)
        {
            var recipes = await _unitOfWork.RecipeRepository.GetRecipes(isVeg, servings, inlcude, exclude);
            return recipes.ToRecipeModel();
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes(int servings, string include)
        {
            var recipes = await _unitOfWork.RecipeRepository.GetRecipes(servings, include);
            return recipes.ToRecipeModel();
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes(string exclude, string instructions)
        {
            var recipes = await _unitOfWork.RecipeRepository.GetRecipes(exclude, instructions);
            return recipes.ToRecipeModel();
        }
    }
}
