using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Complete();
        IRecipeRepository RecipeRepository{get;}
    }
}