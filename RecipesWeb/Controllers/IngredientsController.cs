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
    public class IngredientsController : ControllerBase
    {

        private readonly IIngredientService _ingredientService;
        private readonly ILogger<IngredientsController> _logger;

        public IngredientsController(IIngredientService ingredientService, ILogger<IngredientsController> logger)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }


        // GET: api/<IngredientsController>
        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {
            return _ingredientService.RetrieveAll();
        }

        // GET api/<IngredientsController>/5
        [HttpGet("{id}")]
        public Ingredient Get(int id)
        {
            return _ingredientService.Retrieve(id);
        }

        // POST api/<IngredientsController>
        [HttpPost]
        public Ingredient Post(Ingredient i)
        {
            return _ingredientService.Create(i);
        }

        // PUT api/<IngredientsController>/5
        [HttpPut]    
        public Ingredient Put(Ingredient i)
        {
            return _ingredientService.Update(i);
        }

        // DELETE api/<IngredientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ingredientService.Delete(id);
        }
    }
}
