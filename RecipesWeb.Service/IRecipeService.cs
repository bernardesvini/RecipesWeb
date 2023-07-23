using RecipesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Service
{
    public interface IRecipeService
    {
        public Recipe Create(Recipe recipe);
        public Recipe Update(Recipe recipe);
        public Recipe UpdatePartial(Recipe recipe);
        public List<Recipe> RetrieveAll();
        public Recipe Retrieve(int id);
        public void Delete(int id);
    }
}
