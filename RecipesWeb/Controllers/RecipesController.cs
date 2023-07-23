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
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        // GET: api/<RecipesController>
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return _recipeService.RetrieveAll();
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return _recipeService.Retrieve(id);
        }

        // POST api/<RecipesController>
        [HttpPost]
        public Recipe Post(Recipe i)
        {
           return _recipeService.Create(i);
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _recipeService.Delete(id);
        }
    }
}
