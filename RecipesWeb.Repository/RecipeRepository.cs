using RecipesWeb.Model;
using RecipesWeb.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        public Recipe Create(Recipe recipe)
        {

            string sql = $"INSERT INTO RecipesSystem.dbo.Recipes (Title, Difficult, Preparation_Time, Category_ID) " +
                         $"values ('{recipe.Title}', {((int)recipe.Difficult)}, {recipe.PreparationTime}, {recipe.Category.Id});";
            MSSQL.ExecuteNonQuery(sql);

            int maxId = MSSQL.GetMaxInt("ID", "Recipes");

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                sql = $"INSERT INTO RecipesSystem.dbo.recipes_ingredients (recipe_ID, ingredient_ID) " +
                    $"values ({maxId}, {ingredient.Id});";
                MSSQL.ExecuteNonQuery(sql);
            }

            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM RecipesSystem.dbo.Recipes WHERE Id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);

            sql = "DELETE FROM RecipesSystem.dbo.recipe_ingredients WHERE recipe_ID = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);

        }

        public List<Recipe> RetrieveAll()
        {

            //"INNER JOIN RecipesSystem.dbo.recipes_ingredients ON RecipesSystem.dbo.Recipes.recipe_ID = RecipesSystem.dbo.Recipes.Id" +
            //"ORDER BY Recipes.Title;";

            string sql = "SELECT * FROM RecipesSystem.dbo.Recipes " +
                "INNER JOIN RecipesSystem.dbo.Category ON RecipesSystem.dbo.Recipes.Category_ID = RecipesSystem.dbo.Category.Id;";
       
            SqlDataReader dataReader = MSSQL.Execute(sql);

            List<Recipe> recipes = new List<Recipe>();


            while (dataReader.Read())
            {
                Recipe rec = ParseRetrieve(dataReader);
                recipes.Add(rec);
            }

            foreach (Recipe rec in recipes)
                AddIngredients(rec);

            return recipes;
        }

        public Recipe Retrieve(int id)
        {
            string sql = "SELECT * FROM RecipesSystem.dbo.Recipes " +
                "INNER JOIN RecipesSystem.dbo.Category ON RecipesSystem.dbo.Recipes.Category_ID = RecipesSystem.dbo.Category.Id " +
                $"WHERE RecipesSystem.dbo.Recipes.ID = {id};";

            SqlDataReader dataReader = MSSQL.Execute(sql);
            if (dataReader.Read())
            {
                Recipe recipe = Parse(dataReader);
                return recipe;
            }

            throw new Exception("Recipe with id " + id + " not found.");
        }

        public Recipe Update(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe UpdatePartial(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        private Recipe Parse(SqlDataReader reader)
        {

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["ID"]);
            recipe.Title = Convert.ToString(reader["Title"]);

            if (Convert.ToInt32(reader["Difficult"]) == 0)
                recipe.Difficult = Difficult.Easy;
            else if (Convert.ToInt32(reader["Difficult"]) == 1)
                recipe.Difficult = Difficult.Medium;
            else if (Convert.ToInt32(reader["Difficult"]) == 2)
                recipe.Difficult = Difficult.Hard;
            else if (Convert.ToInt32(reader["Difficult"]) == 3)
                recipe.Difficult = Difficult.Expert;

            recipe.PreparationTime = Convert.ToInt32(reader["Preparation_Time"]);

            Category category = new Category();
            category.Id = Convert.ToInt32(reader["Category_ID"]);
            category.Name = Convert.ToString(reader["Name"]);

            recipe.Category = category;

            AddIngredients(recipe);

            return recipe;
        }

        private Recipe ParseRetrieve(SqlDataReader reader)
        {

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["ID"]);
            recipe.Title = Convert.ToString(reader["Title"]);

            if (Convert.ToInt32(reader["Difficult"]) == 0)
                recipe.Difficult = Difficult.Easy;
            else if (Convert.ToInt32(reader["Difficult"]) == 1)
                recipe.Difficult = Difficult.Medium;
            else if (Convert.ToInt32(reader["Difficult"]) == 2)
                recipe.Difficult = Difficult.Hard;
            else if (Convert.ToInt32(reader["Difficult"]) == 3)
                recipe.Difficult = Difficult.Expert;

            recipe.PreparationTime = Convert.ToInt32(reader["Preparation_Time"]);

            Category category = new Category();
            category.Id = Convert.ToInt32(reader["Category_ID"]);
            category.Name = Convert.ToString(reader["Name"]);

            recipe.Category = category;

          return recipe;
        }

        private void AddIngredients(Recipe recipe)
        {
            string sql = $"SELECT * FROM RecipesSystem.dbo.recipes_ingredients " +
                $"INNER JOIN RecipesSystem.dbo.Ingredients ON RecipesSystem.dbo.recipes_ingredients.ingredient_ID = RecipesSystem.dbo.Ingredients.ID " +
                $"WHERE recipe_ID = {recipe.Id}";

            SqlDataReader ingredientReader = MSSQL.Execute(sql);

            while (ingredientReader.Read())
            {
                Ingredient ingredient = new Ingredient();
                ingredient.Id = Convert.ToInt32(ingredientReader["ingredient_ID"]);
                ingredient.Description = Convert.ToString(ingredientReader["Description"]);

                recipe.Ingredients.Add(ingredient);
            }
        }
    }
}
