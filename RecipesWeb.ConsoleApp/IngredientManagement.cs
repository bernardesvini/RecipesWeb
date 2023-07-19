using RecipesWeb.Model;
using RecipesWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                        Console.WriteLine(createdIngredient);
                        break;
                    case 2:
                        //Console.WriteLine("Insira o id da Brand");
                        //int id = Convert.ToInt32(Console.ReadLine());
                        //Brand retrievedBrand = _brandService.Retrieve(id);
                        //Console.WriteLine(retrievedBrand);
                        break;
                    case 3:
                        //List<Brand> allBrands = _brandService.RetrieveAll();
                        //Console.WriteLine(JsonSerializer.Serialize(allBrands));
                        break;
                    case 4:
                        //Console.WriteLine("Insira o id da Brand a atualizar");
                        //int idToUpdate = Convert.ToInt32(Console.ReadLine());
                        //Console.WriteLine("Insira o novo nome da Brand");
                        //string newName = Console.ReadLine();
                        //Brand brandToUpdate = new Brand();
                        //brandToUpdate.Id = idToUpdate;
                        //brandToUpdate.Name = newName;
                        //Brand updatedBrand = _brandService.Update(brandToUpdate);
                        //Console.WriteLine(updatedBrand);
                        break;
                    case 5:
                        //Console.WriteLine("Insira o id da Brand a apagar");
                        //int idToDelete = Convert.ToInt32(Console.ReadLine());
                        //_brandService.Delete(idToDelete);
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
