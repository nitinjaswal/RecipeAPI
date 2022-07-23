using Business.Models;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        /// <summary>
        /// Get all recipes
        /// </summary>
        /// <returns></returns>
        // GET: api/<RecipeController>
        [HttpGet("", Name = "Recipes")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _recipeService.GetRecipes());
        }

        /// <summary>
        /// Create new recipe with ingredients
        /// </summary>
        /// <param name="recipeModel"></param>
        /// <returns></returns>
        // POST api/<RecipeController>
        [HttpPost("", Name = "Add Recipe")]
        public async Task<ActionResult> Post([FromBody] RecipeAddModel recipeAddModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_recipeService.AddRecipe(recipeAddModel));
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
            if (await _recipeService.UpdateRecipe(recipeUpdateModel) > 0)
            {
                return Ok("Recipe updated successfully");
            }
            return BadRequest("Soemthing went wrong");

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
            if (await _recipeService.RemoveRecipe(recipeId) > 0)
            {
                return Ok("Recipe deleted successfully");
            }
            return BadRequest("Failed to delete Recipe");
        }
    }
}
