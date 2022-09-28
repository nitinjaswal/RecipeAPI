using Data.Repository.Interfaces;

namespace Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
         private readonly AppDbContext _context;
        private readonly IRecipeRepository _recipeRepository;
         public UnitOfWork(AppDbContext context,IRecipeRepository recipeRepository)
         {
            _context=context;
            _recipeRepository=recipeRepository;
         }

        public IRecipeRepository RecipeRepository =>  new RecipeRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        } 
    }
}