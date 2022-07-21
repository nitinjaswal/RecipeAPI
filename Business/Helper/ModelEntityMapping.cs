using Business.Models;
using Data.Entities;

namespace Business.Helper
{
    public static class ModelEntityMaping
    {
        public static IEnumerable<RecipeModel> ToRecipeModel(this IEnumerable<Recipe> recipes)
        {
            var listRecipeModel = new List<RecipeModel>();
            foreach (var recipe in recipes)
            {
                var recipeModel = new RecipeModel();
                recipeModel.Id = recipe.Id;
                recipeModel.RecipeName = recipe.RecipeName;
                recipeModel.IsVeg = recipe.IsVeg;
                recipeModel.Servings = recipe.Servings;
                recipeModel.Instructions = recipe.Instructions;
                recipeModel.CreatedDateTime = recipe.CreatedDateTime;

                recipeModel.Ingredients = new List<IngredientModel>();
                foreach (var item in recipe.Ingredients)
                {
                    recipeModel.Ingredients.Add(new IngredientModel
                    {
                        IngredientName = item.IngredientName,
                    });
                }
                listRecipeModel.Add(recipeModel);
            }


            return listRecipeModel;
        }

        public static Recipe ToAddRecipe(this RecipeAddModel recipeModel)
        {
            Recipe recipe = new Recipe();
            recipe.RecipeName = recipeModel.RecipeName;
            recipe.IsVeg = recipeModel.IsVeg;
            recipe.Servings = recipeModel.Servings;
            recipe.Instructions = recipeModel.Instructions;
            recipe.IsActive = true;
            recipe.CreatedDateTime = DateTime.Now;
            recipe.Ingredients = new List<Ingredient>();
            foreach (var item in recipeModel.Ingredients)
            {
                recipe.Ingredients.Add(new Ingredient
                {
                    IngredientName = item.IngredientName,
                });
            }
            return recipe;
        }

        public static Recipe ToUpdateRecipe(this RecipeUpdateModel recipeModel)
        {
            Recipe recipe = new Recipe();
            recipe.Id = recipeModel.Id;
            recipe.RecipeName = recipeModel.RecipeName;
            recipe.IsVeg = recipeModel.IsVeg;
            recipe.Servings = recipeModel.Servings;
            recipe.Instructions = recipeModel.Instructions;
            recipe.IsActive = true;
            recipe.UpdatedDateTime = DateTime.Now;
            recipe.Ingredients = new List<Ingredient>();
            foreach (var item in recipeModel.Ingredients)
            {
                recipe.Ingredients.Add(new Ingredient
                {
                    Id = item.Id,
                    IngredientName = item.IngredientName,
                });
            }
            return recipe;
        }
    }
}
