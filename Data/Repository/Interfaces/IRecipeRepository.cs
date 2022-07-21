using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<Recipe> GetRecipeById(int recipeId);
        Task<OutputModel<bool>> AddRecipe(RecipeModel recipe);
        Task<int> RemoveRecipe(Recipe recipe);

    }
}
