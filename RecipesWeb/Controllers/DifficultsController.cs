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
    public class DifficultsController : ControllerBase
    {
        private readonly IDifficultService _difficultService;
        private readonly ILogger<DifficultsController> _logger;

        public DifficultsController(IDifficultService difficultService, ILogger<DifficultsController> logger)
        {
            _difficultService = difficultService;
            _logger = logger;
        }



        // GET: api/<CategorysController>
        [HttpGet]
        public IEnumerable<Difficult> Get()
        {
            return _difficultService.RetrieveAll();
        }

        // GET api/<CategorysController>/5
        [HttpGet("{id}")]
        public Difficult Get(int id)
        {
            return _difficultService.Retrieve(id);
        }

        // POST api/<CategorysController>
        [HttpPost]
        public Difficult Post(Difficult d)
        {
            return _difficultService.Create(d);
        }

        // PUT api/<CategorysController>/5
        [HttpPut]
        public Difficult Put(Difficult c)
        {
            return _difficultService.Update(c);
        }

        // DELETE api/<CategorysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _difficultService.Delete(id);
        }
    }
}
