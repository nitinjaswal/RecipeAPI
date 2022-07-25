using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<IEnumerable<Recipe>> GetRecipes(bool isVeg);
        Task<IEnumerable<Recipe>> GetRecipes(int servings);
        Task<IEnumerable<Recipe>> GetRecipes(bool isVeg, int servings);
        Task<IEnumerable<Recipe>> GetRecipes(bool isVeg, int servings, string include, string exclude);
        Task<IEnumerable<Recipe>> GetRecipes(int servings, string include);
        Task<IEnumerable<Recipe>> GetRecipes(string exclude, string instructions);
        Task<Recipe> GetRecipeById(int recipeId);
        Task AddRecipe(Recipe recipe);
        Task<int> UpdateRecipe(Recipe recipe);
        Task<int> RemoveRecipe(int recipeId);
    }
}
