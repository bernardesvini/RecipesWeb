using RecipesWeb.Model;
using RecipesWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository = new RecipeRepository();
        public Recipe Create(Recipe recipe)
        {
            return _recipeRepository.Create(recipe);
        }

        public void Delete(int id)
        {
            _recipeRepository.Delete(id);
        }

        public Recipe Retrieve(int id)
        {
            return _recipeRepository.Retrieve(id);
        }

        public List<Recipe> RetrieveAll()
        {
            return _recipeRepository.RetrieveAll();
        }

        public Recipe Update(Recipe recipe)
        {
            return _recipeRepository.Update(recipe);
        }

        public Recipe UpdatePartial(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
