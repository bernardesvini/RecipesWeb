using RecipesWeb.Model;
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
                         $"values ('{recipe.Title}', {recipe.Difficult.Id}, {recipe.PreparationTime}, {recipe.Category.Id});";
            MSSQL.ExecuteNonQuery(sql);

            int maxId = MSSQL.GetMaxInt("ID", "Recipes");

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                InsertIngredients(maxId, ingredient.Id);
            }

            //sql = $"INSERT INTO RecipesSystem.dbo.recipes_ingredients (recipe_ID, ingredient_ID) " +
            //    $"values ({maxId}, {ingredient.Id});";
            //MSSQL.ExecuteNonQuery(sql);


            return Retrieve(maxId);
        }

        public void Delete(int id)
        {

            DeleteIngredients(id);

            string sql = "DELETE FROM RecipesSystem.dbo.Recipes WHERE Id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);

            //            sql = "DELETE FROM RecipesSystem.dbo.recipe_ingredients WHERE recipe_ID = " + id + ";";
            //            MSSQL.ExecuteNonQuery(sql);

        }

        public List<Recipe> RetrieveAll()
        {

            //"INNER JOIN RecipesSystem.dbo.recipes_ingredients ON RecipesSystem.dbo.Recipes.recipe_ID = RecipesSystem.dbo.Recipes.Id" +
            //"ORDER BY Recipes.Title;";

            string sql = "SELECT * FROM RecipesSystem.dbo.Recipes " +
                "INNER JOIN RecipesSystem.dbo.Category ON RecipesSystem.dbo.Recipes.Category_ID = RecipesSystem.dbo.Category.Id " +
                "INNER JOIN RecipesSystem.dbo.Difficult ON RecipesSystem.dbo.Recipes.Difficult_ID = RecipesSystem.dbo.Difficult.ID;";

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
                "INNER JOIN RecipesSystem.dbo.Difficult ON RecipesSystem.dbo.Recipes.Difficult_ID = RecipesSystem.dbo.Difficult.ID " +
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

            string sql = $"UPDATE RecipesSystem.dbo.Recipes " +
                     $"SET " +
                     $"Title = '{recipe.Title}', " +
                     $"Difficult = {recipe.Difficult.Id}, " +
                     $"Preparation_Time = {recipe.PreparationTime}, " +
                     $"Category_ID = {recipe.Category.Id} " +
                     $"WHERE ID = {recipe.Id};";

            MSSQL.ExecuteNonQuery(sql);

            DeleteIngredients(recipe.Id);

            foreach (Ingredient ing in recipe.Ingredients)
            {
                InsertIngredients(recipe.Id, ing.Id);
            }


            return Retrieve(recipe.Id);
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

            Difficult difficult = new Difficult();
            difficult.Id = Convert.ToInt32(reader["Difficult_ID"]);
            difficult.Name = Convert.ToString(reader["difficult_name"]);

            recipe.Difficult = difficult;
           
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

            Difficult difficult = new Difficult();
            difficult.Id = Convert.ToInt32(reader["Difficult_ID"]);
            difficult.Name = Convert.ToString(reader["difficult_name"]);

            recipe.Difficult = difficult;

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
        //private List<Ingredient> AddIngredientsUpdate(List<Ingredient> ingredients, int id)
        //{
        //    string sql = $"SELECT * FROM RecipesSystem.dbo.recipes_ingredients " +
        //        $"INNER JOIN RecipesSystem.dbo.Ingredients ON RecipesSystem.dbo.recipes_ingredients.ingredient_ID = RecipesSystem.dbo.Ingredients.ID " +
        //        $"WHERE recipe_ID = {id}";

        //    SqlDataReader ingredientReader = MSSQL.Execute(sql);

        //    while (ingredientReader.Read())
        //    {
        //        Ingredient ingredient = new Ingredient();
        //        ingredient.Id = Convert.ToInt32(ingredientReader["ingredient_ID"]);
        //        ingredient.Description = Convert.ToString(ingredientReader["Description"]);

        //        ingredients.Add(ingredient);
        //    }

        //    return ingredients;
        //}
        public void DeleteIngredients(int id)
        {
            string sql = "DELETE FROM RecipesSystem.dbo.recipes_ingredients WHERE recipe_ID = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        private void InsertIngredients(int recipeId, int ingredientId)
        {
            string sql = $"INSERT INTO RecipesSystem.dbo.recipes_ingredients (recipe_ID, ingredient_ID) " +
                  $"values ({recipeId}, {ingredientId});";
            MSSQL.ExecuteNonQuery(sql);
        }
    }

}
