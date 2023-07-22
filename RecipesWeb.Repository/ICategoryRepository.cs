using RecipesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Repository
{
    public interface ICategoryRepository
    {
        List<Category> RetrieveAll();
        Category Retrieve(int id);
        Category Create(Category category);
        Category Update(Category category);
        void Delete(int id);
    }
}
