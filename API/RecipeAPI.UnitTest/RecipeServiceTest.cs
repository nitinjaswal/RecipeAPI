using Business.Helper;
using Business.Models;
using Business.Services;
using Business.Services.Interfaces;
using Data.Entities;
using Data.Repository.Interfaces;
using Moq;
using Xunit;

namespace RecipeAPI.UnitTest
{

    public class RecipeServiceTest
    {
        public readonly Mock<IRecipeRepository> _recipeRepository = new Mock<IRecipeRepository>();

        [Fact]
        public void Get_AllRecipes_Should_Fetch_AllRecipes()
        {
            var recipe = new Recipe();
            recipe.Id = 1;
            recipe.RecipeName = "Noodles";
            recipe.IsVeg = true;
            recipe.Servings = 2;
            recipe.Instructions = "Must be Boiled for 1 hour with some olive oil";
            recipe.IsActive = true;
            recipe.CreatedDateTime = DateTime.Now;
            recipe.UpdatedDateTime = DateTime.Now;
            recipe.Ingredients = new List<Ingredient>();
            recipe.Ingredients.Add(new Ingredient
            {
                RecipeID = 1,
                IngredientName = "Capsicum, garlic"
            });

            List<Recipe> recipeList = new List<Recipe>();
            recipeList.Add(recipe);

            //Arrange
            _recipeRepository.Setup(x => x.GetRecipes()).Returns(Task.FromResult(recipeList.AsEnumerable()));

            IRecipeService recipeService = new RecipeService(_recipeRepository.Object);

            //Act
            var result = recipeService.GetRecipes().Result;

            //Assert
            Assert.True(result.Count() > 0);
        }

        [Fact]
        public void Add_Recipe_Should_Create_Recipe()
        {
            var recipe = new RecipeAddModel();
            recipe.RecipeName = "Noodles";
            recipe.IsVeg = true;
            recipe.Servings = 2;
            recipe.Instructions = "Must be Boiled for 1 hour with some olive oil";
            recipe.Ingredients = new List<IngredientAddModel>();
            recipe.Ingredients.Add(new IngredientAddModel
            {
                IngredientName = "Capsicum, garlic"
            });

            List<RecipeAddModel> recipeList = new List<RecipeAddModel>();
            recipeList.Add(recipe);

            //Arrange
            _recipeRepository.Setup(x => x.AddRecipe(recipe.ToAddRecipe())).Returns(Task.CompletedTask);
            IRecipeService recipeService = new RecipeService(_recipeRepository.Object);

            //Act
            var result = recipeService.AddRecipe(recipe);

            //Assert
            Assert.True(result.IsCompleted);
            //_recipeRepository.Verify(x => x.AddRecipe(recipe.ToAddRecipe()), Times.AtLeastOnce());
        }

        [Fact]
        public void Remove_Recipe_Should_Delete_Recipe()
        {
            var recipe = new Recipe();
            recipe.Id = 1;
            recipe.RecipeName = "Noodles";
            recipe.IsVeg = true;
            recipe.Servings = 2;
            recipe.Instructions = "Must be Boiled for 1 hour with some olive oil";
            recipe.Ingredients = new List<Ingredient>();
            recipe.Ingredients.Add(new Ingredient
            {
                IngredientName = "Capsicum, garlic"
            });

            //Arrange
            _recipeRepository.Setup(x => x.GetRecipeById(recipe.Id)).Returns(Task.FromResult(recipe));
            _recipeRepository.Setup(x => x.RemoveRecipe(recipe.Id)).Returns(Task.FromResult(1));
            IRecipeService recipeService = new RecipeService(_recipeRepository.Object);

            //Act
            var result = recipeService.RemoveRecipe(recipe.Id);

            // Assert
            Assert.True(result.IsCompleted);

        }

        [Fact]
        public void Get_RecipeById_Should_Return_Recipe()
        {
            var recipe = new Recipe();
            recipe.Id = 1;
            recipe.RecipeName = "Noodles";
            recipe.IsVeg = true;
            recipe.Servings = 2;
            recipe.Instructions = "Must be Boiled for 1 hour with some olive oil";
            recipe.IsActive = true;
            recipe.CreatedDateTime = DateTime.Now;
            recipe.UpdatedDateTime = DateTime.Now;
            recipe.Ingredients = new List<Ingredient>();
            recipe.Ingredients.Add(new Ingredient
            {
                RecipeID = 1,
                IngredientName = "Capsicum, garlic"
            });


            //Arrange
            _recipeRepository.Setup(x => x.GetRecipeById(recipe.Id)).Returns(Task.FromResult(recipe));

            IRecipeService recipeService = new RecipeService(_recipeRepository.Object);

            //Act
            var result = recipeService.GetRecipeById(1).Result;

            //Assert
            Assert.True(result.RecipeName == "Noodles");
            Assert.True(recipe.Ingredients.Count > 0);
        }

    }
}