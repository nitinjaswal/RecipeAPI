using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeModel>> GetRecipes();
        Task<RecipeModel> GetRecipeById(int recipeId);
        Task AddRecipe(RecipeAddModel recipe);
        Task<int> UpdateRecipe(RecipeUpdateModel recipe);
        Task<int> RemoveRecipe(int recipeId);
    }
}
