using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Model
{
    public class Rating
    {
        public int Id { get; set; }
        public int Ratings { get; set; }
        public int RecipeID { get; set; }

        public Rating(int id, int ratings, int recipeID)
        {
            Id = id;
            Ratings = ratings;
            RecipeID = recipeID;
        }

        public Rating()
        {
        }
    }
}
