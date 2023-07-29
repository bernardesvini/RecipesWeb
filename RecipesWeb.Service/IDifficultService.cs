using RecipesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Service
{
    public interface IDifficultService
    {
        List<Difficult> RetrieveAll();
        Difficult Retrieve(int id);
        Difficult Create(Difficult difficult);
        Difficult Update(Difficult difficult);
        void Delete(int id);
    }
}
