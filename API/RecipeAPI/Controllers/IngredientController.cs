using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public IngredientController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        /// <summary>
        /// Get all recipes with are either veg or non-veg including servings and ingredients to include or exclude
        /// </summary>
        /// <param name="IsVeg"></param>
        /// <param name="servings"></param>
        /// <param name="include"></param>
        /// <param name="exclude"></param>
        /// <returns></returns>
        [HttpGet("{IsVeg:bool}/Servings/{servings:int}/Include/{include}/Exclude/{exclude}")]
        public async Task<ActionResult> Get(bool IsVeg, int servings, string include, string exclude)
        {
            return Ok(await _recipeService.GetRecipes(IsVeg, servings, include, exclude));
        }

        /// <summary>
        /// Recipes with specific servings and ingredient
        /// </summary>
        /// <param name="servings"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        [HttpGet("Servings/{servings:int}/Include/{include}")]
        public async Task<ActionResult> Get(int servings, string include)
        {
            return Ok(await _recipeService.GetRecipes(servings, include));
        }

        /// <summary>
        /// Recipes with specific ingredient excluded and contains specific instruction
        /// </summary>
        /// <param name="exclude"></param>
        /// <param name="instructions"></param>
        /// <returns></returns>
        [HttpGet("exclude/{exclude}/Instructions/{instructions}")]
        public async Task<ActionResult> Get(string exclude, string instructions)
        {
            return Ok(await _recipeService.GetRecipes(exclude, instructions));
        }

    }
}
