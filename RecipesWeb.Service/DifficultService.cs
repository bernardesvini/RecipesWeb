using RecipesWeb.Model;
using RecipesWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Service
{
    public class DifficultService : IDifficultService
    {
        private readonly IDifficultRepository _difficultRepository = new DifficultRepository();
        public Difficult Create(Difficult difficult)
        {
            return _difficultRepository.Create(difficult);
        }

        public void Delete(int id)
        {
            _difficultRepository.Delete(id);
        }

        public Difficult Retrieve(int id)
        {
            return _difficultRepository.Retrieve(id);
        }

        public List<Difficult> RetrieveAll()
        {
            return _difficultRepository.RetrieveAll();
        }

        public Difficult Update(Difficult difficult)
        {
            return _difficultRepository.Update(difficult);
        }
    }
}
