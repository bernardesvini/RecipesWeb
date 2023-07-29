using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Model
{
    public class Difficult
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Difficult(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Difficult()
        {
        }
    }
}
