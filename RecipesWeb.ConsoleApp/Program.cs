using System;
using System.Collections.Generic;
using System.Text.Json;
using RecipesWeb.Service;
using RecipesWeb.Repository;

namespace RecipesWeb.ConsoleApp
{
    public class Program
    {
        private readonly IIngredientService _ingredientService = new IngredientService();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Recipes System");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");


                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Ingredient Management");
                Console.WriteLine("2 - Category Management");
                Console.WriteLine("3 - Recipe Management");



                option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        IngredientManagement ingredientManagement = new IngredientManagement();
                        ingredientManagement.Run();
                        break;
                    case 2:
                        CategoryManagement categoryManagement = new CategoryManagement();
                        categoryManagement.Run();
                        break;
                    case 3:
                        RecipeManagement recipeManagement = new RecipeManagement();
                        recipeManagement.Run();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
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
