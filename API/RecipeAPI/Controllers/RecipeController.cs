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
        [HttpGet]
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
        /// <summary>
        /// Get Recipe by Id
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet("{recipeId:int}")]
        public async Task<ActionResult> Get(int recipeId)
        {
            return Ok(await _recipeService.GetRecipeById(recipeId));
        }

        /// <summary>
        /// Get all veg or non-veg recipes
        /// </summary>
        /// <param name="IsVeg"></param>
        /// <returns></returns>
        [HttpGet("{IsVeg:bool}")]
        public async Task<ActionResult> Get(bool IsVeg)
        {
            return Ok(await _recipeService.GetRecipes(IsVeg));
        }

        /// <summary>
        /// Get recipes as per servings 
        /// </summary>
        /// <param name="servings"></param>
        /// <returns></returns>
        [HttpGet("{servings}")]
        public async Task<ActionResult> Get(string servings)
        {
            return Ok(await _recipeService.GetRecipes(Convert.ToInt32(servings)));
        }

        /// <summary>
        /// Get all recipes with are either veg or non-veg including servings
        /// </summary>
        /// <param name="IsVeg"></param>
        /// <param name="servings"></param>
        /// <returns></returns>
        [HttpGet("{IsVeg:bool}/Servings/{servings:int}")]
        public async Task<ActionResult> Get(bool IsVeg, int servings)
        {
            return Ok(await _recipeService.GetRecipes(IsVeg, servings));
        }

    }
}
