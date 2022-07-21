using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<Recipe> GetRecipeById(int recipeId);
        Task AddRecipe(Recipe recipe);
        Task UpdateRecipe(Recipe recipe);
        Task<int> RemoveRecipe(int recipeId);

    }
}
