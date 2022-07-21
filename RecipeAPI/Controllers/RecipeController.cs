using Data.Models;
using Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<RecipeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var recipes = await _recipeRepository.GetRecipes();
            return Ok(recipes);
        }


        // POST api/<RecipeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RecipeModel recipeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _recipeRepository.AddRecipe(recipeModel));
        }

        // PUT api/<RecipeController>
        [HttpPut]
        public async Task<ActionResult> PUT([FromBody] RecipeModel recipeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _recipeRepository.AddRecipe(recipeModel));
        }

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
