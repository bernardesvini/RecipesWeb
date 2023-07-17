using System;

namespace RecipesWeb.Model
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Ingredient(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public Ingredient()
        {
        }
    }
}
