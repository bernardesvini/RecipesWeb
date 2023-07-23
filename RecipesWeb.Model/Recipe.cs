using RecipesWeb.Model.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RecipesWeb.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Difficult Difficult { get; set; }
        public Category Category { get; set; }
        public int PreparationTime { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public Recipe(int id, string title, Difficult difficult, Category category, int preparationTime)
        {
            Id = id;
            Title = title;
            Difficult = difficult;
            Category = category;
            PreparationTime = preparationTime;
        }

        public Recipe()
        {
        }

        public override string ToString()
        {
            string printRecipe = $"ID: {Id} \nTitle: {Title} \nDifficult: {Difficult} \nCategory: {Category.Name} \n" +
                $"Preparation Time: {PreparationTime} minutes \nIngredients: ";

            foreach (var item in Ingredients)
            {
                printRecipe += $"\n{item.Description}";
            }

            return printRecipe;
        }

        public override bool Equals(object obj)
        {
            return obj is Recipe recipe &&
                   Title == recipe.Title;
        }
    }
}
