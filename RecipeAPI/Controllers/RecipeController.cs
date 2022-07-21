using Business.Helper;
using Business.Models;
using Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        /// <summary>
        /// Get all recipes
        /// </summary>
        /// <returns></returns>
        // GET: api/<RecipeController>
        [HttpGet("", Name = "Recipes")]
        public async Task<ActionResult> Get()
        {
            var recipes = await _recipeRepository.GetRecipes();             
            return Ok(recipes.ToRecipeModel());
        }

        /// <summary>
        /// Create new recipe with ingredients
        /// </summary>
        /// <param name="recipeModel"></param>
        /// <returns></returns>
        // POST api/<RecipeController>
        [HttpPost("",Name ="Add Recipe")]
        public async Task<ActionResult> Post([FromBody] RecipeAddModel recipeAddModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
         
            return Ok(_recipeRepository.AddRecipe(recipeAddModel.ToAddRecipe()));
        }

        /// <summary>
        /// Update existing recipe or ingredients
        /// </summary>
        /// <param name="recipeModel"></param>
        /// <returns></returns>
        // PUT api/<RecipeController>
        [HttpPut("", Name = "Update Recipe")]
        public async Task<ActionResult> PUT([FromBody] RecipeUpdateModel recipeUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_recipeRepository.UpdateRecipe(recipeUpdateModel.ToUpdateRecipe()));
        }

        /// <summary>
        /// Delete a recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        // DELETE api/<RecipeController>/5
        [HttpDelete("{recipeId}")]
        public async Task<ActionResult> Delete(int recipeId)
        {
            if (recipeId < 1)
            {
                return BadRequest("RecipeId  is invalid.");
            }

            var recipe = await _recipeRepository.GetRecipeById(recipeId);

            if (recipe == null)
            {
                return NotFound("RecipeId does not exist.");
            }

            if (await _recipeRepository.RemoveRecipe(recipe) > 0)
            {
                return Ok("Recipe deleted successfully");
            };
            return BadRequest("Failed to delete recipe.");
        }        
    }
}
