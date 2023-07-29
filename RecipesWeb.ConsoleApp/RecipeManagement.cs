using RecipesWeb.Model;
using RecipesWeb.Model.Enums;
using RecipesWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.ConsoleApp
{
    internal class RecipeManagement
    {
        private readonly IRecipeService _recipeService = new RecipeService();
        private readonly ICategoryService _categoryService = new CategoryService();
        private readonly IIngredientService _ingredientService = new IngredientService();
        public void Run()
        {

            Console.Clear();
            Console.WriteLine("Recipe Management");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            int option = 0;

            do
            {
                Console.Clear();

                Console.WriteLine("Escolha uma opção:");

                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Create");
                Console.WriteLine("2 - Search by ID");
                Console.WriteLine("3 - Show All");
                Console.WriteLine("4 - Update by ID");
                Console.WriteLine("5 - Delete by ID");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Insert the title of the new Recipe: ");
                        Recipe recipe = new Recipe();
                        recipe.Title = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("What's the preparation time ? (in minutes)");
                        recipe.PreparationTime = Convert.ToInt32(Console.ReadLine());

                        bool validDifficult = false;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("What's the difficult ?");
                            Console.WriteLine("1 - Easy");
                            Console.WriteLine("2 - Medium");
                            Console.WriteLine("3 - Hard");
                            Console.WriteLine("4 - Expert");
                            int difficultOption = Convert.ToInt32(Console.ReadLine());


                            switch (difficultOption)
                            {
                                case 1:
                                    recipe.Difficult = Difficult.Easy;
                                    validDifficult = true;
                                    break;
                                case 2:
                                    recipe.Difficult = Difficult.Medium;
                                    validDifficult = true;
                                    break;
                                case 3:
                                    recipe.Difficult = Difficult.Hard;
                                    validDifficult = true;
                                    break;
                                case 4:
                                    recipe.Difficult = Difficult.Expert;
                                    validDifficult = true;
                                    break;
                            }
                        } while (!validDifficult);

                        Console.Clear();

                        List<Category> categories = _categoryService.RetrieveAll();

                        if (categories.Count == 0)
                        {
                            Console.WriteLine("First you need to save a category !");
                            option = 0;
                            break;
                        }


                        Console.WriteLine("Available categories: ");
                        foreach (Category category in categories)
                            Console.WriteLine(category.ToString());

                        Console.WriteLine();
                        Console.Write("Put the number of the category for your recipe: ");
                        int selectedCategory = int.Parse(Console.ReadLine());

                        recipe.Category = categories.Find(x => x.Id == selectedCategory);

                        List<Ingredient> ingredients = _ingredientService.RetrieveAll();
                        bool moreIngredients = false;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Available ingredients: ");
                            foreach (Ingredient ingredient in ingredients)
                                Console.WriteLine(ingredient.ToString());

                            Console.WriteLine();
                            Console.Write("Put the number of the ingredient for your recipe: ");
                            int selectedIngredient = int.Parse(Console.ReadLine());
                         

                            recipe.Ingredients.Add(ingredients.Find(x => x.Id == selectedIngredient));

                            Console.WriteLine("Do you want to put more ingredients? (Y/N)");
                            if (Console.ReadLine().ToUpper() == "Y")
                                moreIngredients = true;
                            else
                                moreIngredients = false;

                        } while (moreIngredients);

                        Console.Clear();
                        Recipe createdRecipe = _recipeService.Create(recipe);
                        Console.WriteLine(createdRecipe.ToString());
                        Console.WriteLine("CREATED!");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Insert the recipe ID");
                        int id = int.Parse(Console.ReadLine());

                        Recipe retrievedRecipe = _recipeService.Retrieve(id);
                        
                        Console.WriteLine(retrievedRecipe.ToString());
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();

                        List<Recipe> allRecipes = _recipeService.RetrieveAll();

                        foreach (Recipe recipes in allRecipes)
                        { 
                            Console.WriteLine(recipes.ToString());
                            Console.WriteLine("");
                        }

                        Console.ReadLine();
                                             
                        break;
                    case 4:
                        //Console.Clear();

                        //Console.Write("Insert the recipe ID to update: ");
                        //int idUpdate = int.Parse(Console.ReadLine());

                        //Console.Write("Insert the title of the new Recipe: ");
                        //string recipeTitle = Console.ReadLine();

                        //Console.Clear();
                        //Console.WriteLine("What's the preparation time ? (in minutes)");
                        //int recipePreparationTime = Convert.ToInt32(Console.ReadLine());

                        //bool validDifficultUp = false;
                        //Difficult difficultUp;
                        //do
                        //{
                        //    Console.Clear();
                        //    Console.WriteLine("What's the difficult ?");
                        //    Console.WriteLine("1 - Easy");
                        //    Console.WriteLine("2 - Medium");
                        //    Console.WriteLine("3 - Hard");
                        //    Console.WriteLine("4 - Expert");
                        //    int difficultOption = Convert.ToInt32(Console.ReadLine());


                        //    switch (difficultOption)
                        //    {
                        //        case 1:
                        //            difficultUp = Difficult.Easy;
                        //            validDifficult = true;
                        //            break;
                        //        case 2:
                        //            difficultUp = Difficult.Medium;
                        //            validDifficult = true;
                        //            break;
                        //        case 3:
                        //            difficultUp = Difficult.Hard;
                        //            validDifficult = true;
                        //            break;
                        //        case 4:
                        //            difficultUp = Difficult.Expert;
                        //            validDifficult = true;
                        //            break;
                        //    }
                        //} while (!validDifficultUp);

                        //Console.Clear();

                        //List<Category> categories = _categoryService.RetrieveAll();

                        //if (categories.Count == 0)
                        //{
                        //    Console.WriteLine("First you need to save a category !");
                        //    option = 0;
                        //    break;
                        //}


                        //Console.WriteLine("Available categories: ");
                        //foreach (Category category in categories)
                        //    Console.WriteLine(category.ToString());

                        //Console.WriteLine();
                        //Console.Write("Put the number of the category for your recipe: ");
                        //int selectedCategory = int.Parse(Console.ReadLine());

                        //recipe.Category = categories.Find(x => x.Id == selectedCategory);

                        //List<Ingredient> ingredients = _ingredientService.RetrieveAll();
                        //bool moreIngredients = false;

                        //do
                        //{
                        //    Console.Clear();
                        //    Console.WriteLine("Available ingredients: ");
                        //    foreach (Ingredient ingredient in ingredients)
                        //        Console.WriteLine(ingredient.ToString());

                        //    Console.WriteLine();
                        //    Console.Write("Put the number of the ingredient for your recipe: ");
                        //    int selectedIngredient = int.Parse(Console.ReadLine());


                        //    recipe.Ingredients.Add(ingredients.Find(x => x.Id == selectedIngredient));

                        //    Console.WriteLine("Do you want to put more ingredients? (Y/N)");
                        //    if (Console.ReadLine().ToUpper() == "Y")
                        //        moreIngredients = true;
                        //    else
                        //        moreIngredients = false;

                        //} while (moreIngredients);

                        //Console.Clear();
                        //Recipe createdRecipe = _recipeService.Create(recipe);
                        //Console.WriteLine(createdRecipe.ToString());
                        //Console.WriteLine("CREATED!");
                        //Console.ReadLine();
                        
                        break;
                    case 5:

                        Console.WriteLine("Insert the recipe ID to delete: ");
                        int idToDelete = int.Parse(Console.ReadLine());
                        Recipe recipeToDelete = _recipeService.Retrieve(idToDelete);
                        _recipeService.Delete(idToDelete);
                        Console.WriteLine(recipeToDelete.ToString());

                        Console.WriteLine("DELETED!");
                        Console.ReadLine();
                        break;
                    default:
                        if (option != 0)
                        {
                            Console.WriteLine("A opção " + option + " não existe, tente novamente.");
                        }
                        break;
                }

            } while (option != 0);

        }
    }
}
