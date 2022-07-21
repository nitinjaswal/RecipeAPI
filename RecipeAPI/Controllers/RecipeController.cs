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

        // GET api/<RecipeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecipeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
