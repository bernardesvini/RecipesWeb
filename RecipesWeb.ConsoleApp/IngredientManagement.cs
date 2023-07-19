using RecipesWeb.Model;
using RecipesWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipesWeb.ConsoleApp
{
    internal class IngredientManagement
    {
        private readonly IIngredientService _ingredientService = new IngredientService();
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Ingredient Management");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            int option = 0;

            do
            {
                Console.Clear();

                Console.WriteLine("Escolha uma opção:");

                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Criar");
                Console.WriteLine("2 - Exibir por ID");
                Console.WriteLine("3 - Exibir todos");
                Console.WriteLine("4 - Atualizar por ID");
                Console.WriteLine("5 - Remover por ID");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Insert the name of the new ingredient: ");
                        Ingredient ingredient = new Ingredient();
                        ingredient.Description = Console.ReadLine();
                        Ingredient createdIngredient = _ingredientService.Create(ingredient);
                        Console.WriteLine(createdIngredient.ToString());
                        Console.WriteLine("CREATED!");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Insert the ingredient ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Ingredient retrievedIngredient = _ingredientService.Retrieve(id);
                        Console.WriteLine(retrievedIngredient.ToString());
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        List<Ingredient> allIngredients = _ingredientService.RetrieveAll();
                        
                        foreach (Ingredient ingredients in allIngredients)
                            Console.WriteLine(ingredients.ToString());
                       
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();

                        Console.Write("Insert the ingredient ID to update: ");
                        int idUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Insert the ingredient's new name: ");
                        string nameUpdate = Console.ReadLine();

                        Ingredient ingredientUpdated = _ingredientService.Update(new Ingredient { Id = idUpdate, Description = nameUpdate });

                        Console.WriteLine(ingredientUpdated.ToString());
                        Console.WriteLine("UPDATED!");

                        break;
                    case 5:
                        Console.Write("Insert the ingredient ID to delete: ");
                        int idToDelete = Convert.ToInt32(Console.ReadLine());
                        Ingredient ingredientToDelete = _ingredientService.Retrieve(idToDelete);
                        _ingredientService.Delete(idToDelete);
                        Console.WriteLine(ingredientToDelete.ToString());
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
