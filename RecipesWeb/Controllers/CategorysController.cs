using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipesWeb.Model;
using RecipesWeb.Service;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipesWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategorysController> _logger;

        public CategorysController(ICategoryService categoryService, ILogger<CategorysController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }



        // GET: api/<CategorysController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryService.RetrieveAll();
        }

        // GET api/<CategorysController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryService.Retrieve(id);
        }

        // POST api/<CategorysController>
        [HttpPost]
        public void Post(Category c)
        {
            _categoryService.Create(c);
        }

        // PUT api/<CategorysController>/5
        [HttpPut]
        public void Put(Category c)
        {
            _categoryService.Update(c);
        }

        // DELETE api/<CategorysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.Delete(id);
        }
    }
}
