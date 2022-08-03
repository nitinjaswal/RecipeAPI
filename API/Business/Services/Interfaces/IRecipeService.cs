using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeModel>> GetRecipes();
        Task<IEnumerable<RecipeModel>> GetRecipes(bool isVeg);
        Task<IEnumerable<RecipeModel>> GetRecipes(int servings);
        Task<IEnumerable<RecipeModel>> GetRecipes(bool isVeg, int servings);
        Task<IEnumerable<RecipeModel>> GetRecipes(bool isVeg, int servings, string inlcude, string exclude);
        Task<IEnumerable<RecipeModel>> GetRecipes(int servings, string include);
        Task<IEnumerable<RecipeModel>> GetRecipes(string exclude, string instructions);

        Task<RecipeModel> GetRecipeById(int recipeId);

        Task<RecipeModel> GetRecipeById(int recipeId,bool isVeg);
        Task AddRecipe(RecipeAddModel recipe);
        Task<int> UpdateRecipe(RecipeUpdateModel recipe);
        Task<int> RemoveRecipe(int recipeId);
    }
}
