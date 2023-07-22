using RecipesWeb.Model;
using RecipesWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.ConsoleApp
{
    internal class CategoryManagement
    {
        private readonly ICategoryService _categoryService = new CategoryService();

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Category Management");
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
                        Console.Write("Insert the name of the new category: ");
                        Category category = new Category();
                        category.Name = Console.ReadLine();
                        Category createdCategory = _categoryService.Create(category);
                        Console.WriteLine(createdCategory.ToString());
                        Console.WriteLine("CREATED!");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Insert the category ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Category retrievedCategory = _categoryService.Retrieve(id);
                        Console.WriteLine(retrievedCategory.ToString());
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        List<Category> allCategories = _categoryService.RetrieveAll();

                        foreach (Category categories in allCategories)
                            Console.WriteLine(categories.ToString());

                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();

                        Console.Write("Insert the category ID to update: ");
                        int idUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Insert the category's new name: ");
                        string nameUpdate = Console.ReadLine();

                        Category categoryUpdated = _categoryService.Update(new Category { Id = idUpdate, Name = nameUpdate });

                        Console.WriteLine(categoryUpdated.ToString());
                        Console.WriteLine("UPDATED!");

                        break;
                    case 5:
                        Console.Write("Insert the category ID to delete: ");
                        int idToDelete = Convert.ToInt32(Console.ReadLine());
                        Category categoryToDelete = _categoryService.Retrieve(idToDelete);
                        _categoryService.Delete(idToDelete);
                        Console.WriteLine(categoryToDelete.ToString());
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
