using RecipesWeb.Model;
using RecipesWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = new CategoryRepository();
        public Category Create(Category category)
        {
            return _categoryRepository.Create(category);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public Category Retrieve(int id)
        {
            return _categoryRepository.Retrieve(id);
        }

        public List<Category> RetrieveAll()
        {
            return _categoryRepository.RetrieveAll();
        }

        public Category Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
    }
}
