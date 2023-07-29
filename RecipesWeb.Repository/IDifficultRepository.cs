using RecipesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Repository
{
    public interface IDifficultRepository
    {
        List<Difficult> RetrieveAll();
        Difficult Retrieve(int id);
        Difficult Create(Difficult category);
        Difficult Update(Difficult category);
        void Delete(int id);
    }
}
